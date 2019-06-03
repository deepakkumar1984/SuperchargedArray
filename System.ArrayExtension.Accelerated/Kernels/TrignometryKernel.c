__kernel void ndarr_sin_float(global float *x, global float *r)
{
	const int i = get_global_id(0);

	r[i] = sin(x[i]);
}

__kernel void ndarr_cos_float(global float *x, global float *r)
{
	const int i = get_global_id(0);

	r[i] = cos(x[i]);
}

__kernel void ndarr_tan_float(global float *x, global float *r)
{
	const int i = get_global_id(0);

	r[i] = tan(x[i]);
}

__kernel void ndarr_arcsin_float(global float *x, global float *r)
{
	const int i = get_global_id(0);

	r[i] = asin(x[i]);
}

__kernel void ndarr_arccos_float(global float *x, global float *r)
{
	const int i = get_global_id(0);

	r[i] = acos(x[i]);
}

__kernel void ndarr_arctan_float(global float *x, global float *r)
{
	const int i = get_global_id(0);

	r[i] = atan(x[i]);
}

__kernel void ndarr_sinh_float(global float *x, global float *r)
{
	const int i = get_global_id(0);

	r[i] = sinh(x[i]);
}

__kernel void ndarr_cosh_float(global float *x, global float *r)
{
	const int i = get_global_id(0);

	r[i] = cosh(x[i]);
}

__kernel void ndarr_tanh_float(global float *x, global float *r)
{
	const int i = get_global_id(0);

	r[i] = tanh(x[i]);
}

__kernel void ndarr_arctan2_float(global float *y, global float *x, global float *r)
{
	const int i = get_global_id(0);

	r[i] = atan2(y[i], x[i]);
}

__kernel void ndarr_sin_double(global double *x, global double *r)
{
	const int i = get_global_id(0);

	r[i] = sin(x[i]);
}

__kernel void ndarr_cos_double(global double *x, global double *r)
{
	const int i = get_global_id(0);

	r[i] = cos(x[i]);
}

__kernel void ndarr_tan_double(global double *x, global double *r)
{
	const int i = get_global_id(0);

	r[i] = tan(x[i]);
}

__kernel void ndarr_arcsin_double(global double *x, global double *r)
{
	const int i = get_global_id(0);

	r[i] = asin(x[i]);
}

__kernel void ndarr_arccos_double(global double *x, global double *r)
{
	const int i = get_global_id(0);

	r[i] = acos(x[i]);
}

__kernel void ndarr_arctan_double(global double *x, global double *r)
{
	const int i = get_global_id(0);

	r[i] = atan(x[i]);
}

__kernel void ndarr_sinh_double(global double *x, global double *r)
{
	const int i = get_global_id(0);

	r[i] = sinh(x[i]);
}

__kernel void ndarr_cosh_double(global double *x, global double *r)
{
	const int i = get_global_id(0);

	r[i] = cosh(x[i]);
}

__kernel void ndarr_tanh_double(global double *x, global double *r)
{
	const int i = get_global_id(0);

	r[i] = tanh(x[i]);
}

__kernel void ndarr_arctan2_double(global double *y, global double *x, global double *r)
{
	const int i = get_global_id(0);

	r[i] = atan2(y[i], x[i]);
}


