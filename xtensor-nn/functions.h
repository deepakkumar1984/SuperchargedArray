//
// Created by Deepak Battini on 2019-08-05.
//

#ifndef XTENSOR_NN_FUNCTIONS_H
#define XTENSOR_NN_FUNCTIONS_H

#pragma once
#include <xtensor/xarray.hpp>
#include "variable.h"

namespace xt{
    namespace nn{
        variable operator +(const variable& lhs, const variable& rhs);
        variable operator *(const variable& lhs, const variable& rhs);
        variable operator -(const variable& lhs, const variable& rhs);
        variable operator /(const variable& lhs, const variable& rhs);
        variable operator >(const variable& lhs, const variable& rhs);
        variable operator <(const variable& lhs, const variable& rhs);
        variable operator >=(const variable& lhs, const variable& rhs);
        variable operator <=(const variable& lhs, const variable& rhs);

        variable operator +(const double& lhs, const variable& rhs);
        variable operator *(const double& lhs, const variable& rhs);
        variable operator -(const double& lhs, const variable& rhs);
        variable operator /(const double& lhs, const variable& rhs);
        variable operator >(const double& lhs, const variable& rhs);
        variable operator <(const double& lhs, const variable& rhs);
        variable operator >=(const double& lhs, const variable& rhs);
        variable operator <=(const double& lhs, const variable& rhs);

        variable operator +(const variable& lhs, const double& rhs);
        variable operator *(const variable& lhs, const double& rhs);
        variable operator -(const variable& lhs, const double& rhs);
        variable operator /(const variable& lhs, const double& rhs);
        variable operator >(const variable& lhs, const double& rhs);
        variable operator <(const variable& lhs, const double& rhs);
        variable operator >=(const variable& lhs, const double& rhs);
        variable operator <=(const variable& lhs, const double& rhs);
        variable operator !(const variable& input);

        variable negate(const variable& input);
        variable reciprocal(const variable& input);

        variable exp(const variable& input);
        variable log(const variable& input);
        variable sin(const variable& input);
        variable cos(const variable& input);
        variable tanh(const variable& input);
        variable sigmoid(const variable& input);

        variable Max(const variable &lhs, const variable &rhs);

        variable Max(const variable &lhs, const double &rhs);
        variable Max(const double &lhs, const variable &rhs);

        variable Min(const variable& lhs, const variable& rhs);

        variable Min(const variable& lhs, const double& rhs);
        variable Min(const double& lhs, const variable& rhs);

        variable transpose(const variable& input);
        variable tileAs(const variable& input, const variable& reference);
        variable sumAs(const variable& input, const variable& reference);

        variable tile(const variable& input, const std::vector<int>& repeats);
        variable sum(const variable& input, const std::vector<int>& axes);
        variable mean(const variable& input, const std::vector<int>& axes);

        variable matmul(const variable& lhs, const variable& rhs);
        variable matmulTN(const variable& lhs, const variable& rhs);
        variable matmulNT(const variable& lhs, const variable& rhs);

        variable abs(const variable& input);

        variable flat(const variable& input);
        variable moddims(const variable& input, const size_t* dims);
    }
}
#endif //XTENSOR_NN_FUNCTIONS_H
