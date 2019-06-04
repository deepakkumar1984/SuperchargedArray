__kernel void ndarr_add_float(global float* a, global float* b, global float* r)
{
	const int i = get_global_id(0);

	r[i] = a[i] + b[i];
}

__kernel void ndarr_sub_float(global float* a, global float* b, global float* r)
{
	const int i = get_global_id(0);

	r[i] = a[i] - b[i];
}

__kernel void ndarr_mul_float(global float* a, global float* b, global float* r)
{
	const int i = get_global_id(0);

	r[i] = a[i] * b[i];
}

__kernel void ndarr_div_float(global float* a, global float* b, global float* r)
{
	const int i = get_global_id(0);

	r[i] = a[i] / b[i];
}

__kernel void ndarr_mod_float(global float* a, global float* b, global float* r)
{
	const int i = get_global_id(0);

	r[i] = fmod(a[i], b[i]);
}

__kernel void ndarr_neg_float(global float* x, global float* r)
{
	const int i = get_global_id(0);

	r[i] = -x[i];
}

__kernel void ndarr_sign_float(global float* x, global float* r)
{
	const int i = get_global_id(0);

	if (x[i] > 0)
		r[i] = 1;
	else if (x[i] < 0)
		r[i] = -1;
	else
		r[i] = 0;
}

__kernel void ndarr_abs_float(global float* x, global float* r)
{
	const int i = get_global_id(0);

	r[i] = fabs(x[i]);
}


__kernel void ndarr_fill_float(global float* x, float value)
{
	const int i = get_global_id(0);

	x[i] = value;
}

__kernel void ndarr_gt_float(global float* a, global float* b, global float* r)
{
	const int i = get_global_id(0);

	if (a[i] > b[i])
		r[i] = 1;
	else
		r[i] = 0;
}

__kernel void ndarr_ge_float(global float* a, global float* b, global float* r)
{
	const int i = get_global_id(0);

	if (a[i] >= b[i])
		r[i] = 1;
	else
		r[i] = 0;
}

__kernel void ndarr_lt_float(global float* a, global float* b, global float* r)
{
	const int i = get_global_id(0);

	if (a[i] < b[i])
		r[i] = 1;
	else
		r[i] = 0;
}

__kernel void ndarr_le_float(global float* a, global float* b, global float* r)
{
	const int i = get_global_id(0);

	if (a[i] <= b[i])
		r[i] = 1;
	else
		r[i] = 0;
}

__kernel void ndarr_eq_float(global float* a, global float* b, global float* r)
{
	const int i = get_global_id(0);

	if (a[i] == b[i])
		r[i] = 1;
	else
		r[i] = 0;
}

__kernel void ndarr_ne_float(global float* a, global float* b, global float* r)
{
	const int i = get_global_id(0);

	if (a[i] != b[i])
		r[i] = 1;
	else
		r[i] = 0;
}

__kernel void ndarr_exp_float(global float* x, global float* r)
{
	const int i = get_global_id(0);

	r[i] = exp(x[i]);
}

__kernel void ndarr_log_float(global float* x, global float* r)
{
	const int i = get_global_id(0);

	r[i] = log(x[i]);
}

__kernel void ndarr_log1p_float(global float* x, global float* r)
{
	const int i = get_global_id(0);

	r[i] = log1p(x[i]);
}

__kernel void ndarr_log10_float(global float* x, global float* r)
{
	const int i = get_global_id(0);

	r[i] = log10(x[i]);
}

__kernel void ndarr_sqrt_float(global float* x, global float* r)
{
	const int i = get_global_id(0);

	r[i] = sqrt(x[i]);
}

__kernel void ndarr_pow_float(global float* x, float value, global float* r)
{
	const int i = get_global_id(0);

	r[i] = pow(x[i], value);
}

__kernel void ndarr_tpow_float(float value, global float* x, global float* r)
{
	const int i = get_global_id(0);

	r[i] = pow(value, x[i]);
}

__kernel void ndarr_square_float(global float* x, global float* r)
{
	const int i = get_global_id(0);

	r[i] = pow(x[i], 2);
}

__kernel void ndarr_floor_float(global float* x, global float* r)
{
	const int i = get_global_id(0);

	r[i] = floor(x[i]);
}

__kernel void ndarr_ceil_float(global float* x, global float* r)
{
	const int i = get_global_id(0);

	r[i] = ceil(x[i]);
}

__kernel void ndarr_round_float(global float* x, global float* r)
{
	const int i = get_global_id(0);

	r[i] = round(x[i]);
}

__kernel void ndarr_trunc_float(global float* x, global float* r)
{
	const int i = get_global_id(0);

	r[i] = trunc(x[i]);
}

__kernel void ndarr_clip_float(global float* x, float min, float max, global float* r)
{
	const int i = get_global_id(0);

	if (x[i] > min && x[i] < max)
		r[i] = x[i];
	else if (x[i] >= max)
		r[i] = max;
	else if (x[i] <= min)
		r[i] = min;
}

__kernel void ndarr_sin_float(global float* x, global float* r)
{
	const int i = get_global_id(0);

	r[i] = sin(x[i]);
}

__kernel void ndarr_cos_float(global float* x, global float* r)
{
	const int i = get_global_id(0);

	r[i] = cos(x[i]);
}

__kernel void ndarr_tan_float(global float* x, global float* r)
{
	const int i = get_global_id(0);

	r[i] = tan(x[i]);
}

__kernel void ndarr_arcsin_float(global float* x, global float* r)
{
	const int i = get_global_id(0);

	r[i] = asin(x[i]);
}

__kernel void ndarr_arccos_float(global float* x, global float* r)
{
	const int i = get_global_id(0);

	r[i] = acos(x[i]);
}

__kernel void ndarr_arctan_float(global float* x, global float* r)
{
	const int i = get_global_id(0);

	r[i] = atan(x[i]);
}

__kernel void ndarr_sinh_float(global float* x, global float* r)
{
	const int i = get_global_id(0);

	r[i] = sinh(x[i]);
}

__kernel void ndarr_cosh_float(global float* x, global float* r)
{
	const int i = get_global_id(0);

	r[i] = cosh(x[i]);
}

__kernel void ndarr_tanh_float(global float* x, global float* r)
{
	const int i = get_global_id(0);

	r[i] = tanh(x[i]);
}

__kernel void ndarr_arctan2_float(global float* y, global float* x, global float* r)
{
	const int i = get_global_id(0);

	r[i] = atan2(y[i], x[i]);
}