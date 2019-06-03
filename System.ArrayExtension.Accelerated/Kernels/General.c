__kernel void ndarr_fill_float(global float *x, float value)
{
	const int i = get_global_id(0);

	x[i] = value;
}

__kernel void ndarr_gt_float(global float *a, global float *b, global float *r)
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

__kernel void ndarr_fill_double(global double *x, double value, global double *r)
{
	const int i = get_global_id(0);

	r[i] = value;
}

__kernel void ndarr_gt_double(global double *a, global double *b, global double *r)
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