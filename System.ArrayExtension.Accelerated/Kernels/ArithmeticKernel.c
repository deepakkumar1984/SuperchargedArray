__kernel void ndarr_add(global read_only float *a, global read_only float *b, global write_only float *r)
{
	const int i = get_global_id(0);

	r[i] = a[i] + b[i];
}

__kernel void ndarr_sub(global read_only float *a, global read_only float *b, global write_only float *r)
{
	const int i = get_global_id(0);

	r[i] = a[i] - b[i];
}

__kernel void ndarr_mul(global read_only float *a, global read_only float *b, global write_only float *r)
{
	const int i = get_global_id(0);

	r[i] = a[i] * b[i];,
}

__kernel void ndarr_div(global read_only float *a, global read_only float *b, global write_only float *r)
{
	const int i = get_global_id(0);

	r[i] = a[i] / b[i];
}

__kernel void ndarr_mod(global read_only float *a, float b, global write_only float *r)
{
	const int i = get_global_id(0);

	r[i] = fmod(a[i], b);
}

__kernel void ndarr_neg(global read_only float *x, global write_only float *r)
{
	const int i = get_global_id(0);

	r[i] = -x[i];
}


__kernel void ndarr_sign(global read_only float *x, global write_only float *r)
{
	const int i = get_global_id(0);

	if (x[i] > 0)
		r[i] = 1;
	else if (x[i] < 0)
		r[i] = -1;
	else
		r[i] = 0;
}

__kernel void ndarr_abs(global read_only float *x, global write_only float *r)
{
	const int i = get_global_id(0);

	r[i] = fabs(x[i]);
}
