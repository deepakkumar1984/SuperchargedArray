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