using Amplifier.OpenCL;

namespace SuperchargedArray.Amplified.Kernels
{
    public class InternalFloatKernels : OpenCLFunctions
    {
        [OpenCLKernel]
        void ndarr_add_float([Global] float[] a, [Global] float[] b, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = a[i] + b[i];
        }

        [OpenCLKernel]
        void ndarr_sub_float([Global] float[] a, [Global] float[] b, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = a[i] - b[i];
        }

        [OpenCLKernel]
        void ndarr_mul_float([Global] float[] a, [Global] float[] b, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = a[i] * b[i];
        }

        [OpenCLKernel]
        void ndarr_div_float([Global] float[] a, [Global] float[] b, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = a[i] / b[i];
        }

        [OpenCLKernel]
        void ndarr_mod_float([Global] float[] a, [Global] float[] b, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = fmod(a[i], b[i]);
        }

        [OpenCLKernel]
        void ndarr_neg_float([Global] float[] x, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = -x[i];
        }

        [OpenCLKernel]
        void ndarr_sign_float([Global] float[] x, [Global] float[] r)
        {
            int i = get_global_id(0);

            if (x[i] > 0)
                r[i] = 1;
            else if (x[i] < 0)
                r[i] = -1;
            else
                r[i] = 0;
        }

        [OpenCLKernel]
        void ndarr_abs_float([Global] float[] x, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = fabs(x[i]);
        }

        [OpenCLKernel]
        void ndarr_fill_float([Global] float[] x, float value)
        {
            int i = get_global_id(0);

            x[i] = value;
        }

        [OpenCLKernel]
        void ndarr_gt_float([Global] float[] a, [Global] float[] b, [Global] float[] r)
        {
            int i = get_global_id(0);

            if (a[i] > b[i])
                r[i] = 1;
            else
                r[i] = 0;
        }

        [OpenCLKernel]
        void ndarr_ge_float([Global] float[] a, [Global] float[] b, [Global] float[] r)
        {
            int i = get_global_id(0);

            if (a[i] >= b[i])
                r[i] = 1;
            else
                r[i] = 0;
        }

        [OpenCLKernel]
        void ndarr_lt_float([Global] float[] a, [Global] float[] b, [Global] float[] r)
        {
            int i = get_global_id(0);

            if (a[i] < b[i])
                r[i] = 1;
            else
                r[i] = 0;
        }

        [OpenCLKernel]
        void ndarr_le_float([Global] float[] a, [Global] float[] b, [Global] float[] r)
        {
            int i = get_global_id(0);

            if (a[i] <= b[i])
                r[i] = 1;
            else
                r[i] = 0;
        }

        [OpenCLKernel]
        void ndarr_eq_float([Global] float[] a, [Global] float[] b, [Global] float[] r)
        {
            int i = get_global_id(0);

            if (a[i] == b[i])
                r[i] = 1;
            else
                r[i] = 0;
        }

        [OpenCLKernel]
        void ndarr_ne_float([Global] float[] a, [Global] float[] b, [Global] float[] r)
        {
            int i = get_global_id(0);

            if (a[i] != b[i])
                r[i] = 1;
            else
                r[i] = 0;
        }

        [OpenCLKernel]
        void ndarr_exp_float([Global] float[] x, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = exp(x[i]);
        }

        [OpenCLKernel]
        void ndarr_log_float([Global] float[] x, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = log(x[i]);
        }

        [OpenCLKernel]
        void ndarr_log1p_float([Global] float[] x, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = log1p(x[i]);
        }

        [OpenCLKernel]
        void ndarr_log10_float([Global] float[] x, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = log10(x[i]);
        }

        [OpenCLKernel]
        void ndarr_sqrt_float([Global] float[] x, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = sqrt(x[i]);
        }

        [OpenCLKernel]
        void ndarr_pow_float([Global] float[] x, float value, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = pow(x[i], value);
        }

        [OpenCLKernel]
        void ndarr_tpow_float(float value, [Global] float[] x, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = pow(value, x[i]);
        }

        [OpenCLKernel]
        void ndarr_square_float([Global] float[] x, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = pow(x[i], 2);
        }

        [OpenCLKernel]
        void ndarr_floor_float([Global] float[] x, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = floor(x[i]);
        }

        [OpenCLKernel]
        void ndarr_ceil_float([Global] float[] x, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = ceil(x[i]);
        }

        [OpenCLKernel]
        void ndarr_round_float([Global] float[] x, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = round(x[i]);
        }

        [OpenCLKernel]
        void ndarr_trunc_float([Global] float[] x, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = trunc(x[i]);
        }

        [OpenCLKernel]
        void ndarr_clip_float([Global] float[] x, float min, float max, [Global] float[] r)
        {
            int i = get_global_id(0);

            if (x[i] > min && x[i] < max)
                r[i] = x[i];
            else if (x[i] >= max)
                r[i] = max;
            else if (x[i] <= min)
                r[i] = min;
        }

        [OpenCLKernel]
        void ndarr_sin_float([Global] float[] x, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = sin(x[i]);
        }

        [OpenCLKernel]
        void ndarr_cos_float([Global] float[] x, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = cos(x[i]);
        }

        [OpenCLKernel]
        void ndarr_tan_float([Global] float[] x, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = tan(x[i]);
        }

        [OpenCLKernel]
        void ndarr_arcsin_float([Global] float[] x, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = asin(x[i]);
        }

        [OpenCLKernel]
        void ndarr_arccos_float([Global] float[] x, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = acos(x[i]);
        }

        [OpenCLKernel]
        void ndarr_arctan_float([Global] float[] x, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = atan(x[i]);
        }

        [OpenCLKernel]
        void ndarr_sinh_float([Global] float[] x, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = sinh(x[i]);
        }

        [OpenCLKernel]
        void ndarr_cosh_float([Global] float[] x, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = cosh(x[i]);
        }

        [OpenCLKernel]
        void ndarr_tanh_float([Global] float[] x, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = tanh(x[i]);
        }

        [OpenCLKernel]
        void ndarr_arctan2_float([Global] float[] y, [Global] float[] x, [Global] float[] r)
        {
            int i = get_global_id(0);

            r[i] = atan2(y[i], x[i]);
        }
    }
}