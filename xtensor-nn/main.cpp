#include <iostream>
#include <xtensor/xreducer.hpp>
#include <xtensor/xarray.hpp>

int main() {
    long shape[2] = {2,3};
    xt::xarray<float> x = xt::ones<float>(shape);

    std::cout << "Hello, World!" << std::endl;
    return 0;
}