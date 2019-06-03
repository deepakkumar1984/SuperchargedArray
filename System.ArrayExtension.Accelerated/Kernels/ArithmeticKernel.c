__kernel void ndarr_add_float(global float *a, global float *b, global float *r)
{
	const int i = get_global_id(0);

	r[i] = a[i] + b[i];
}

__kernel void ndarr_add_double(global double *a, global double *b, global double *r)
{
	const int i = get_global_id(0);

	r[i] = a[i] + b[i];
}

__kernel void ndarr_sub_float(global float *a, global float *b, global float *r)
{
	const int i = get_global_id(0);

	r[i] = a[i] - b[i];
}

__kernel void ndarr_sub_double(global double *a, global double *b, global double *r)
{
	const int i = get_global_id(0);

	r[i] = a[i] - b[i];
}

__kernel void ndarr_mul_float(global float *a, global float *b, global float *r)
{
	const int i = get_global_id(0);

	r[i] = a[i] * b[i];
}

__kernel void ndarr_mul_double(global double *a, global double *b, global double *r)
{
	const int i = get_global_id(0);

	r[i] = a[i] * b[i];
}

__kernel void ndarr_div_float(global float *a, global float *b, global float *r)
{
	const int i = get_global_id(0);

	r[i] = a[i] / b[i];
}

__kernel void ndarr_div_double(global double *a, global double *b, global double *r)
{
	const int i = get_global_id(0);

	r[i] = a[i] / b[i];
}

__kernel void ndarr_mod_float(global float *a, global float *b, global float *r)
{
	const int i = get_global_id(0);

	r[i] = fmod(a[i], b[i]);
}

__kernel void ndarr_mod_double(global double *a, global double *b, global double *r)
{
	const int i = get_global_id(0);

	r[i] = fmod(a[i], b[i]);
}

__kernel void ndarr_neg_float(global float *x, global float *r)
{
	const int i = get_global_id(0);

	r[i] = -x[i];
}

__kernel void ndarr_neg_double(global double *x, global double *r)
{
	const int i = get_global_id(0);

	r[i] = -x[i];
}

__kernel void ndarr_sign_float(global float *x, global float *r)
{
	const int i = get_global_id(0);

	if (x[i] > 0)
		r[i] = 1;
	else if (x[i] < 0)
		r[i] = -1;
	else
		r[i] = 0;
}

__kernel void ndarr_sign_double(global double *x, global double *r)
{
	const int i = get_global_id(0);

	if (x[i] > 0)
		r[i] = 1;
	else if (x[i] < 0)
		r[i] = -1;
	else
		r[i] = 0;
}

__kernel void ndarr_abs_float(global float *x, global float *r)
{
	const int i = get_global_id(0);

	r[i] = fabs(x[i]);
}

__kernel void ndarr_abs_double(global double *x, global double *r)
{
	const int i = get_global_id(0);

	r[i] = fabs(x[i]);
}