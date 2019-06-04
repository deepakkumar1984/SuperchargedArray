#pragma OPENCL EXTENSION cl_khr_fp64 : enable
__kernel void ndarr_add_double(global double* a, global double* b, global double* r)
{
	const int i = get_global_id(0);

	r[i] = a[i] + b[i];
}

__kernel void ndarr_sub_double(global double* a, global double* b, global double* r)
{
	const int i = get_global_id(0);

	r[i] = a[i] - b[i];
}

__kernel void ndarr_mul_double(global double* a, global double* b, global double* r)
{
	const int i = get_global_id(0);

	r[i] = a[i] * b[i];
}

__kernel void ndarr_div_double(global double* a, global double* b, global double* r)
{
	const int i = get_global_id(0);

	r[i] = a[i] / b[i];
}

__kernel void ndarr_mod_double(global double* a, global double* b, global double* r)
{
	const int i = get_global_id(0);

	r[i] = fmod(a[i], b[i]);
}

__kernel void ndarr_neg_double(global double* x, global double* r)
{
	const int i = get_global_id(0);

	r[i] = -x[i];
}

__kernel void ndarr_sign_double(global double* x, global double* r)
{
	const int i = get_global_id(0);

	if (x[i] > 0)
		r[i] = 1;
	else if (x[i] < 0)
		r[i] = -1;
	else
		r[i] = 0;
}

__kernel void ndarr_abs_double(global double* x, global double* r)
{
	const int i = get_global_id(0);

	r[i] = fabs(x[i]);
}


__kernel void ndarr_fill_double(global double* x, double value)
{
	const int i = get_global_id(0);

	x[i] = value;
}

__kernel void ndarr_gt_double(global double* a, global double* b, global double* r)
{
	const int i = get_global_id(0);

	if (a[i] > b[i])
		r[i] = 1;
	else
		r[i] = 0;
}

__kernel void ndarr_ge_double(global double* a, global double* b, global double* r)
{
	const int i = get_global_id(0);

	if (a[i] >= b[i])
		r[i] = 1;
	else
		r[i] = 0;
}

__kernel void ndarr_lt_double(global double* a, global double* b, global double* r)
{
	const int i = get_global_id(0);

	if (a[i] < b[i])
		r[i] = 1;
	else
		r[i] = 0;
}

__kernel void ndarr_le_double(global double* a, global double* b, global double* r)
{
	const int i = get_global_id(0);

	if (a[i] <= b[i])
		r[i] = 1;
	else
		r[i] = 0;
}

__kernel void ndarr_eq_double(global double* a, global double* b, global double* r)
{
	const int i = get_global_id(0);

	if (a[i] == b[i])
		r[i] = 1;
	else
		r[i] = 0;
}

__kernel void ndarr_ne_double(global double* a, global double* b, global double* r)
{
	const int i = get_global_id(0);

	if (a[i] != b[i])
		r[i] = 1;
	else
		r[i] = 0;
}

__kernel void ndarr_exp_double(global double* x, global double* r)
{
	const int i = get_global_id(0);

	r[i] = exp(x[i]);
}

__kernel void ndarr_log_double(global double* x, global double* r)
{
	const int i = get_global_id(0);

	r[i] = log(x[i]);
}

__kernel void ndarr_log1p_double(global double* x, global double* r)
{
	const int i = get_global_id(0);

	r[i] = log1p(x[i]);
}

__kernel void ndarr_log10_double(global double* x, global double* r)
{
	const int i = get_global_id(0);

	r[i] = log10(x[i]);
}

__kernel void ndarr_sqrt_double(global double* x, global double* r)
{
	const int i = get_global_id(0);

	r[i] = sqrt(x[i]);
}

__kernel void ndarr_pow_double(global double* x, double value, global double* r)
{
	const int i = get_global_id(0);

	r[i] = pow(x[i], value);
}

__kernel void ndarr_tpow_double(double value, global double* x, global double* r)
{
	const int i = get_global_id(0);

	r[i] = pow(value, x[i]);
}

__kernel void ndarr_square_double(global double* x, global double* r)
{
	const int i = get_global_id(0);

	r[i] = pow(x[i], 2);
}

__kernel void ndarr_floor_double(global double* x, global double* r)
{
	const int i = get_global_id(0);

	r[i] = floor(x[i]);
}

__kernel void ndarr_ceil_double(global double* x, global double* r)
{
	const int i = get_global_id(0);

	r[i] = ceil(x[i]);
}

__kernel void ndarr_round_double(global double* x, global double* r)
{
	const int i = get_global_id(0);

	r[i] = round(x[i]);
}

__kernel void ndarr_trunc_double(global double* x, global double* r)
{
	const int i = get_global_id(0);

	r[i] = trunc(x[i]);
}

__kernel void ndarr_clip_double(global double* x, double min, double max, global double* r)
{
	const int i = get_global_id(0);

	if (x[i] > min && x[i] < max)
		r[i] = x[i];
	else if (x[i] >= max)
		r[i] = max;
	else if (x[i] <= min)
		r[i] = min;
}

__kernel void ndarr_sin_double(global double* x, global double* r)
{
	const int i = get_global_id(0);

	r[i] = sin(x[i]);
}

__kernel void ndarr_cos_double(global double* x, global double* r)
{
	const int i = get_global_id(0);

	r[i] = cos(x[i]);
}

__kernel void ndarr_tan_double(global double* x, global double* r)
{
	const int i = get_global_id(0);

	r[i] = tan(x[i]);
}

__kernel void ndarr_arcsin_double(global double* x, global double* r)
{
	const int i = get_global_id(0);

	r[i] = asin(x[i]);
}

__kernel void ndarr_arccos_double(global double* x, global double* r)
{
	const int i = get_global_id(0);

	r[i] = acos(x[i]);
}

__kernel void ndarr_arctan_double(global double* x, global double* r)
{
	const int i = get_global_id(0);

	r[i] = atan(x[i]);
}

__kernel void ndarr_sinh_double(global double* x, global double* r)
{
	const int i = get_global_id(0);

	r[i] = sinh(x[i]);
}

__kernel void ndarr_cosh_double(global double* x, global double* r)
{
	const int i = get_global_id(0);

	r[i] = cosh(x[i]);
}

__kernel void ndarr_tanh_double(global double* x, global double* r)
{
	const int i = get_global_id(0);

	r[i] = tanh(x[i]);
}

__kernel void ndarr_arctan2_double(global double* y, global double* x, global double* r)
{
	const int i = get_global_id(0);

	r[i] = atan2(y[i], x[i]);
}