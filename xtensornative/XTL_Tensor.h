#pragma once
#include <xtensor/xarray.hpp>
#include <xtensor/xtensor.hpp>
#include "Stdafx.h"

using namespace xt;

typedef void *XTensorHandle;

EXPORT_API(size_t) XLTTensor_ndimension(const xarray<float> &tensor);

// Returns the size of the target dimension of the input tensor.
EXPORT_API(size_t*) XLTTensor_shape(const xarray<float> tensor);

// Returns the strides of the input tensor.
EXPORT_API(size_t*) XLTTensor_strides(const xarray<float> tensor);

EXPORT_API(XTensorHandle) XLTTensor_ones(const int64_t * sizes);
