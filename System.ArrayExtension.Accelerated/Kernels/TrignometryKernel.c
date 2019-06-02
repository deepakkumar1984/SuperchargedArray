__kernel void ndarr_sin(global read_only float *x, global write_only float *r)
{
	const int i = get_global_id(0);

	r[i] = sin(x[i]);
}

__kernel void ndarr_cos(global read_only float *x, global write_only float *r)
{
	const int i = get_global_id(0);

	r[i] = cos(x[i]);
}

__kernel void ndarr_tan(global read_only float *x, global write_only float *r)
{
	const int i = get_global_id(0);

	r[i] = tan(x[i]);
}

__kernel void ndarr_arcsin(global read_only float *x, global write_only float *r)
{
	const int i = get_global_id(0);

	r[i] = asin(x[i]);
}

__kernel void ndarr_arccos(global read_only float *x, global write_only float *r)
{
	const int i = get_global_id(0);

	r[i] = acos(x[i]);
}

__kernel void ndarr_arctan(global read_only float *x, global write_only float *r)
{
	const int i = get_global_id(0);

	r[i] = atan(x[i]);
}

__kernel void ndarr_sinh(global read_only float *x, global write_only float *r)
{
	const int i = get_global_id(0);

	r[i] = sinh(x[i]);
}

__kernel void ndarr_cosh(global read_only float *x, global write_only float *r)
{
	const int i = get_global_id(0);

	r[i] = cosh(x[i]);
}

__kernel void ndarr_tanh(global read_only float *x, global write_only float *r)
{
	const int i = get_global_id(0);

	r[i] = tanh(x[i]);
}

__kernel void ndarr_arctan2(global read_only float *y, global read_only float *x, global write_only float *r)
{
	const int i = get_global_id(0);

	r[i] = atan2(y[i], x[i]);
}

