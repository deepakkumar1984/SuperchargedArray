#include <iostream>
#include <xtensor/xreducer.hpp>
#include <xtensor/xarray.hpp>
#include "variable.h"
#include "functions.h"

using namespace xt::nn;
int main() {
    auto x_array = xt::xarray<float>({2, 2});
    x_array.fill(3);

    auto x = new variable(x_array, true);
    auto y = xt::nn::sigmoid(x);
    //std::cout << grad.array().data();
    return 0;
}