__kernel void ndarr_fill(global float *x, float value)
{
	const int i = get_global_id(0);

	x[i] = value;
}

__kernel void ndarr_gt(global read_only float *a, global read_only float *b, global read_only float *r)
{
	const int i = get_global_id(0);

	if (a[i] > b[i])
		r[i] = 1;
	else
		r[i] = 0;
}

__kernel void ndarr_ge(global read_only float* a, global read_only float* b, global read_only float* r)
{
	const int i = get_global_id(0);

	if (a[i] >= b[i])
		r[i] = 1;
	else
		r[i] = 0;
}

__kernel void ndarr_lt(global read_only float* a, global read_only float* b, global read_only float* r)
{
	const int i = get_global_id(0);

	if (a[i] < b[i])
		r[i] = 1;
	else
		r[i] = 0;
}

__kernel void ndarr_le(global read_only float* a, global read_only float* b, global read_only float* r)
{
	const int i = get_global_id(0);

	if (a[i] <= b[i])
		r[i] = 1;
	else
		r[i] = 0;
}

__kernel void ndarr_eq(global read_only float* a, global read_only float* b, global read_only float* r)
{
	const int i = get_global_id(0);

	if (a[i] == b[i])
		r[i] = 1;
	else
		r[i] = 0;
}

__kernel void ndarr_ne(global read_only float* a, global read_only float* b, global read_only float* r)
{
	const int i = get_global_id(0);

	if (a[i] != b[i])
		r[i] = 1;
	else
		r[i] = 0;
}