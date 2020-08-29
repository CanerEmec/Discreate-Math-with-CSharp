using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrikMatematik_14067035_CanerEmec
{
    class Secant
    {
        private double Epsilon;
        private double X0;
        private double X1;
        private double X2;
        private double[] A;
        private int IterNo = 0;

        public delegate void NotifyEventHandler(object sender, SEventArgs e);
        public event NotifyEventHandler OnNotify;

        public struct Result
        {
            public double x0;
            public double x1;
            public double x2;

            public double f0;
            public double f1;
            public double f2;

            public double err1;     // |a-b|
            public double iter_no;
        }

        private Result result;

        public Secant(double[] A, double eps, double x0, double x1)
        {
            this.A = A;
            this.Epsilon = eps;
            this.X0 = x0;
            this.X1 = x1;
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
            double f0, f1, f2;
            result.iter_no = 0;

            while (err1 > Epsilon && err2 > Epsilon)
            {
                
                f0 = F(X0);
                f1 = F(X1);

                X2 = X1 - ((X1 - X0) / (f1 - f0))*f1;
                f2 = F(X2);

                

                err1 = Math.Abs(X1 - X2);
                err2 = Math.Abs(f2);

                result.iter_no++;
                result.x0 = X0;
                result.x1 = X1;
                result.x2 = X2;

                result.f0 = f0;
                result.f1 = f1;
                result.f2 = f2;
                result.err1 = err1;

                X0 = X1;
                X1 = X2;

                if (OnNotify != null)
                {
                    SEventArgs args = new SEventArgs(result);
                    OnNotify(this, args);
                }

            }

            return result;
        }

        public class SEventArgs : EventArgs
        {
            public Result Result { get; set; }
            public SEventArgs(Result result)
            {
                this.Result = result;
            }
        }
    }
}
