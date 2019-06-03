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

