//
// Created by Deepak Battini on 2019-08-04.
//

#ifndef XTENSOR_NN_VARIABLE_H
#define XTENSOR_NN_VARIABLE_H

#pragma once
#include <xtensor/xarray.hpp>
#include "enumerations.h"
#include <cstddef>
#include <functional>
#include <memory>
#include <vector>
#include <unordered_map>

namespace xtensor{
    namespace nn
    {
        class variable {
        public:
            typedef std::function<void(std::vector<variable>&, const variable&)> GradFunc_t;
            typedef std::unordered_map<std::ptrdiff_t, bool> Cache_t;
            typedef std::vector<variable> DAG_t;

        private:
            struct Shared {
                Shared();

                Shared(const xt::xarray<float> &data, bool calc_grad);

                Shared(const xt::xarray<float> &data,
                       const std::vector<variable> &inputs,
                       GradFunc_t grad_func,
                       bool calc_grad);

                bool m_calc_grad;
                xt::xarray<float> m_data;
                std::vector<variable> m_inputs;
                std::vector<variable> m_grads;
                GradFunc_t m_grad_func;
            };
        public:
            variable();
            variable(const xt::xarray<float>& data, bool calc_grad);
            variable(const xt::xarray<float>& data,
                     const std::vector<variable>& inputs,
                     GradFunc_t grad_func);

            xt::xarray<float>& array() const;

            variable& grad() const;

            std::ptrdiff_t id() const;

            bool isCalcGrad() const;

            bool isGradAvailable() const;

            const size_t* dims() const;

            void zeroGrad();

            void setCalcGrad(bool calc_grad);

            void addGrad(const variable& child_grad);

            void calcGradInputs(bool retain_grad_graph = false);

            void backward(const variable& grad, bool retain_grad_graph = false);

            void backward(bool retain_grad_graph = false);


        private:
            void evalGrad(bool retain_grad_graph = false);

            std::vector<variable>& getInputs() const;

            static void buildSubGraph(Cache_t& cache, DAG_t& dag, const variable& var);

            static DAG_t build(const variable& var);

            std::shared_ptr<Shared> m_shared;
        };

    }
}



#endif //XTENSOR_NN_VARIABLE_H
