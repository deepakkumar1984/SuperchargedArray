#include "XTL_Tensor.h"


EXPORT_API(size_t) XLTTensor_ndimension(const xarray<float> &tensor)
{
	return tensor.dimension();
}

EXPORT_API(size_t*) XLTTensor_shape(const xarray<float> tensor)
{
	return (size_t*)tensor.shape().data();
}

EXPORT_API(size_t*) XLTTensor_strides(const xarray<float> tensor)
{
	return (size_t*)tensor.strides().data();
}

/// <summary>
/// XLTs the tensor ones.
/// </summary>
/// <param name="sizes">The sizes.</param>
/// <returns></returns>
EXPORT_API(XTensorHandle) XLTTensor_ones(const int64_t * sizes)
{
	xarray<float> x = xt::ones<float>({ 2, 2 });
	return (void*)&x;
}
