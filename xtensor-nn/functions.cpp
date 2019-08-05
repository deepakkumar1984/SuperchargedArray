//
// Created by Deepak Battini on 2019-08-05.
//
#include "variable.h"
#include "functions.h"

namespace xt{
    namespace nn{
        variable sigmoid(const variable& input)
        {
            auto result = xt::exp(input.array()) / (1 + xt::exp(input.array()));
            auto grad_func = [](std::vector<variable> &inputs, const variable &grad_output) {
                auto tmp = sigmoid(inputs[0]);
                inputs[0].addGrad(grad_output * tmp * (1 - tmp));
            };
            return variable(result, {input}, grad_func);
        }
    }
}
