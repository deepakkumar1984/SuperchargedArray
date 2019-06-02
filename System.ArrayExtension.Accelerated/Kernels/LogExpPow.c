__kernel void ndarr_exp(global read_only float* x, global write_only float* r)
{
	const int i = get_global_id(0);

	r[i] = exp(x[i]);
}

__kernel void ndarr_log(global read_only float* x, global write_only float* r)
{
	const int i = get_global_id(0);

	r[i] = log(x[i]);
}

__kernel void ndarr_log1p(global read_only float* x, global write_only float* r)
{
	const int i = get_global_id(0);

	r[i] = log1p(x[i]);
}

__kernel void ndarr_log10(global read_only float* x, global write_only float* r)
{
	const int i = get_global_id(0);

	r[i] = log10(x[i]);
}

__kernel void ndarr_sqrt(global read_only float* x, global write_only float* r)
{
	const int i = get_global_id(0);

	r[i] = sqrt(x[i]);
}

__kernel void ndarr_pow(global read_only float* x, float value, global write_only float* r)
{
	const int i = get_global_id(0);

	r[i] = pow(x[i], value);
}

__kernel void ndarr_tpow(float value, global read_only float* x, global write_only float* r)
{
	const int i = get_global_id(0);

	r[i] = pow(value, x[i]);
}

__kernel void ndarr_square(global read_only float* x, global write_only float* r)
{
	const int i = get_global_id(0);

	r[i] = pow(x[i], 2);
}