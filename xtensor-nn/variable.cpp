//
// Created by Deepak Battini on 2019-08-04.
//

#include "variable.h"

namespace xt
{
    namespace nn{
        variable::Shared::Shared() : m_calc_grad(true),
                                     m_data(),
                                     m_inputs(),
                                     m_grads(),
                                     m_grad_func(nullptr)
        {
        }

        variable::Shared::Shared(const xt::xarray<float>& data, bool calc_grad) : m_calc_grad(calc_grad),
                                                                                  m_data(data),
                                                                                  m_inputs(),
                                                                                  m_grads(),
                                                                                  m_grad_func(nullptr)
        {
        }
        variable::Shared::Shared(const xt::xarray<float>& data, const std::vector<variable>& inputs, GradFunc_t grad_func, bool calc_grad):
                m_calc_grad(calc_grad),
                m_data(data),
                m_inputs(inputs.begin(), inputs.end()),
                m_grads(),
                m_grad_func(grad_func)
        {
        }
        variable::variable():
                m_shared(new Shared())
        {
        }
        variable::variable(const xt::xarray<float>& data, bool calc_grad)
                : m_shared(new Shared(data, calc_grad))
        {
        }


        variable::variable(const xt::xarray<float>& data, const std::vector<variable>& inputs, GradFunc_t grad_func)
        {
            bool calc_grad = false;
            for (const auto& input : inputs) {
                calc_grad |= input.isCalcGrad();
            }
            if (calc_grad) {
                m_shared = std::shared_ptr<Shared>(new Shared(data, inputs, grad_func, true));
            }
            else {
                m_shared = std::shared_ptr<Shared>(new Shared(data, false));
            }
        }
        xt::xarray<float>& variable::array() const
        {
            return m_shared->m_data;
        }



        variable& variable::grad() const
        {
            if (!m_shared->m_calc_grad) {
                throw "Gradient calclation disabled.";
            }
            if (m_shared->m_grads.size() == 0) {

                throw "Gradient hasn't been calculated yet.";
            }

            return m_shared->m_grads[0];
        }
        std::ptrdiff_t variable::id() const
        {
            return (std::ptrdiff_t)m_shared.get();
        }

        std::vector<variable>& variable::getInputs() const
        {
            return m_shared->m_inputs;
        }

        void variable::buildSubGraph(Cache_t& cache, DAG_t& dag, const variable& var)
        {
            std::ptrdiff_t id = var.id();
            if (cache.find(id) != cache.end()) {
                return;
            }
            for (const auto& input : var.getInputs()) {
                variable::buildSubGraph(cache, dag, input);
            }
            cache[id] = true;
            dag.push_back(var);
        }

        variable::DAG_t variable::build(const variable& var)
        {
            Cache_t cache;
            variable::DAG_t dag;
            variable::buildSubGraph(cache, dag, var);
            return dag;
        }

        bool variable::isCalcGrad() const
        {
            return m_shared->m_calc_grad;
        }
        bool variable::isGradAvailable() const
        {
            if (!m_shared->m_calc_grad) return false;
            return m_shared->m_grads.size() >= 1;
        }
        auto variable::dims() const
        {
            return m_shared->m_data.shape();
        }

        void variable::zeroGrad()
        {
            m_shared->m_grads.clear();
        }
        void variable::setCalcGrad(bool calc_grad)
        {
            m_shared->m_calc_grad = calc_grad;
            if (!calc_grad) {
                m_shared->m_grad_func = nullptr;
                m_shared->m_inputs.clear();
                m_shared->m_grads.clear();
            }
        }
        void variable::addGrad(const variable& child_grad)
        {
            if (m_shared->m_calc_grad) {
                m_shared->m_grads.push_back(child_grad);
            }
        }

        void variable::evalGrad(bool retain_grad_graph)
        {
            // Flag asking not to calculate gradients
            if (!m_shared->m_calc_grad) return;

            // Best not to evaluate the JIT immediately if theres only a single gradient
            variable grad = m_shared->m_grads[0];
            if (m_shared->m_grads.size() > 1) {
                for (unsigned i = 1; i < m_shared->m_grads.size(); i++) {
                    grad.m_shared->m_data = grad.array() + m_shared->m_grads[i].array();
                }

                //grad.array().eval();
                m_shared->m_grads.resize(1);
            }

            grad.setCalcGrad(retain_grad_graph);
            m_shared->m_grads[0] = grad;
        }


        void variable::calcGradInputs(bool retain_grad_graph)
        {
            // Flag asking not to calculate gradients
            if (!m_shared->m_calc_grad) return;

            // Best not to evaluate the JIT immediately if theres only a single gradient
            if (m_shared->m_grads.size() == 0)
                return;

            variable grad = m_shared->m_grads[0];
            if (m_shared->m_grads.size() > 1) {
                for (unsigned i = 1; i < m_shared->m_grads.size(); i++) {
                    grad.m_shared->m_data = grad.array() + m_shared->m_grads[i].array();
                }

                //grad.array().eval();
                m_shared->m_grads.resize(1);
            }

            grad.setCalcGrad(retain_grad_graph);
            m_shared->m_grads[0] = grad;
        }
        void variable::backward(const variable& grad, bool retain_grad_graph)
        {
            this->addGrad(grad);
            variable::DAG_t dag = variable::build(*this);
            for (auto iter = dag.rbegin(); iter != dag.rend(); iter++) {
                iter->calcGradInputs(retain_grad_graph);
            }
        }
        void variable::backward(bool retain_grad_graph)
        {
            auto ones = variable(xt::ones<float>(this->dims()), false);
            this->backward(ones, retain_grad_graph);
        }
    }
}