using Amplifier.OpenCL;

namespace SuperchargedArray.Amplified.Kernels
{
    public class InternalDoubleKernels : OpenCLFunctions
    {
        [OpenCLKernel]
        void ndarr_add_double([Global] double[] a, [Global] double[] b, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = a[i] + b[i];
        }

        [OpenCLKernel]
        void ndarr_sub_double([Global] double[] a, [Global] double[] b, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = a[i] - b[i];
        }

        [OpenCLKernel]
        void ndarr_mul_double([Global] double[] a, [Global] double[] b, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = a[i] * b[i];
        }

        [OpenCLKernel]
        void ndarr_div_double([Global] double[] a, [Global] double[] b, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = a[i] / b[i];
        }

        [OpenCLKernel]
        void ndarr_mod_double([Global] double[] a, [Global] double[] b, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = fmod(a[i], b[i]);
        }

        [OpenCLKernel]
        void ndarr_neg_double([Global] double[] x, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = -x[i];
        }

        [OpenCLKernel]
        void ndarr_sign_double([Global] double[] x, [Global] double[] r)
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
        void ndarr_abs_double([Global] double[] x, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = fabs(x[i]);
        }

        [OpenCLKernel]
        void ndarr_fill_double([Global] double[] x, double value)
        {
            int i = get_global_id(0);

            x[i] = value;
        }

        [OpenCLKernel]
        void ndarr_gt_double([Global] double[] a, [Global] double[] b, [Global] double[] r)
        {
            int i = get_global_id(0);

            if (a[i] > b[i])
                r[i] = 1;
            else
                r[i] = 0;
        }

        [OpenCLKernel]
        void ndarr_ge_double([Global] double[] a, [Global] double[] b, [Global] double[] r)
        {
            int i = get_global_id(0);

            if (a[i] >= b[i])
                r[i] = 1;
            else
                r[i] = 0;
        }

        [OpenCLKernel]
        void ndarr_lt_double([Global] double[] a, [Global] double[] b, [Global] double[] r)
        {
            int i = get_global_id(0);

            if (a[i] < b[i])
                r[i] = 1;
            else
                r[i] = 0;
        }

        [OpenCLKernel]
        void ndarr_le_double([Global] double[] a, [Global] double[] b, [Global] double[] r)
        {
            int i = get_global_id(0);

            if (a[i] <= b[i])
                r[i] = 1;
            else
                r[i] = 0;
        }

        [OpenCLKernel]
        void ndarr_eq_double([Global] double[] a, [Global] double[] b, [Global] double[] r)
        {
            int i = get_global_id(0);

            if (a[i] == b[i])
                r[i] = 1;
            else
                r[i] = 0;
        }

        [OpenCLKernel]
        void ndarr_ne_double([Global] double[] a, [Global] double[] b, [Global] double[] r)
        {
            int i = get_global_id(0);

            if (a[i] != b[i])
                r[i] = 1;
            else
                r[i] = 0;
        }

        [OpenCLKernel]
        void ndarr_exp_double([Global] double[] x, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = exp(x[i]);
        }

        [OpenCLKernel]
        void ndarr_log_double([Global] double[] x, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = log(x[i]);
        }

        [OpenCLKernel]
        void ndarr_log1p_double([Global] double[] x, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = log1p(x[i]);
        }

        [OpenCLKernel]
        void ndarr_log10_double([Global] double[] x, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = log10(x[i]);
        }

        [OpenCLKernel]
        void ndarr_sqrt_double([Global] double[] x, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = sqrt(x[i]);
        }

        [OpenCLKernel]
        void ndarr_pow_double([Global] double[] x, double value, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = pow(x[i], value);
        }

        [OpenCLKernel]
        void ndarr_tpow_double(double value, [Global] double[] x, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = pow(value, x[i]);
        }

        [OpenCLKernel]
        void ndarr_square_double([Global] double[] x, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = pow(x[i], 2);
        }

        [OpenCLKernel]
        void ndarr_floor_double([Global] double[] x, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = floor(x[i]);
        }

        [OpenCLKernel]
        void ndarr_ceil_double([Global] double[] x, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = ceil(x[i]);
        }

        [OpenCLKernel]
        void ndarr_round_double([Global] double[] x, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = round(x[i]);
        }

        [OpenCLKernel]
        void ndarr_trunc_double([Global] double[] x, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = trunc(x[i]);
        }

        [OpenCLKernel]
        void ndarr_clip_double([Global] double[] x, double min, double max, [Global] double[] r)
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
        void ndarr_sin_double([Global] double[] x, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = sin(x[i]);
        }

        [OpenCLKernel]
        void ndarr_cos_double([Global] double[] x, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = cos(x[i]);
        }

        [OpenCLKernel]
        void ndarr_tan_double([Global] double[] x, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = tan(x[i]);
        }

        [OpenCLKernel]
        void ndarr_arcsin_double([Global] double[] x, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = asin(x[i]);
        }

        [OpenCLKernel]
        void ndarr_arccos_double([Global] double[] x, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = acos(x[i]);
        }

        [OpenCLKernel]
        void ndarr_arctan_double([Global] double[] x, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = atan(x[i]);
        }

        [OpenCLKernel]
        void ndarr_sinh_double([Global] double[] x, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = sinh(x[i]);
        }

        [OpenCLKernel]
        void ndarr_cosh_double([Global] double[] x, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = cosh(x[i]);
        }

        [OpenCLKernel]
        void ndarr_tanh_double([Global] double[] x, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = tanh(x[i]);
        }

        [OpenCLKernel]
        void ndarr_arctan2_double([Global] double[] y, [Global] double[] x, [Global] double[] r)
        {
            int i = get_global_id(0);

            r[i] = atan2(y[i], x[i]);
        }
    }
}