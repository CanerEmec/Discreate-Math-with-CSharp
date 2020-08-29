using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrikMatematik_14067035_CanerEmec
{
    class BiSection
    {
        private double Epsilon;
        private double X_left;
        private double X_right;
        private double X_center;
        private double[] A;
        private int IterNo = 0;

        public delegate void NotifyEventHandler(object sender, BSEventArgs e);
        public event NotifyEventHandler OnNotify;

        public struct Result
        {
            public double x_left;
            public double x_rigth;
            public double x_center;

            public double fa;
            public double fb;
            public double fc;

            public double err1;     // |a-b|
            public double iter_no;
        }

        private Result result;

        public BiSection(double[] A, double eps, double x_left, double x_right)
        {
            this.A = A;
            this.Epsilon = eps;
            this.X_left = x_left;
            this.X_right = x_right;
            this.X_center = (x_left + X_right) / 2;
        }
        private double F(double x)
        {
            double result = 0;
            for (int i = 0; i < A.Length; i++)
            {
                result += A[A.Length - i - 1] * Math.Pow(x, i);
            }

            return result;
        }

        public Result Solve()
        {
            double err1 = double.PositiveInfinity, err2 = double.PositiveInfinity;
            double fa, fb, fc;
            result.iter_no = 0;

            while (err1 > Epsilon && err2 > Epsilon)
            {
                X_center = (X_left + X_right) / 2;
                fa = F(X_left);
                fb = F(X_right);
                fc = F(X_center);

                if (fa * fc > 0)
                {
                    X_left = X_center;
                }
                else if (fb * fc > 0)
                {
                    X_right = X_center;
                }

                err1 = Math.Abs(X_left - X_right);
                err2 = Math.Abs(fc);

                result.iter_no++;
                result.x_left = X_left;
                result.x_rigth = X_right;
                result.x_center = X_center;

                result.fa = fa;
                result.fb = fb;
                result.fc = fc;
                result.err1 = err1;

                if(OnNotify != null)
                {
                    BSEventArgs args = new BSEventArgs(result);
                    OnNotify(this, args);
                }

            }

            return result;
        }

        public class BSEventArgs : EventArgs
        {
            public Result Result { get; set; }
            public BSEventArgs(Result result)
            {
                this.Result = result;
            }
        }

    }
}
