__kernel void ndarr_floor(global read_only float* x, global write_only float* r)
{
	const int i = get_global_id(0);

	r[i] = floor(x[i]);
}

__kernel void ndarr_ceil(global read_only float* x, global write_only float* r)
{
	const int i = get_global_id(0);

	r[i] = ceil(x[i]);
}

__kernel void ndarr_round(global read_only float* x, global write_only float* r)
{
	const int i = get_global_id(0);

	r[i] = round(x[i]);
}

__kernel void ndarr_trunc(global read_only float* x, global write_only float* r)
{
	const int i = get_global_id(0);

	r[i] = trunc(x[i]);
}

__kernel void ndarr_clip(global read_only float* x, float min, float max, global write_only float* r)
{
	const int i = get_global_id(0);

	if (x[i] > min && x[i] < max)
		r[i] = x[i];
	else if (x[i] >= max)
		r[i] = max;
	else if (x[i] <= min)
		r[i] = min;
}
