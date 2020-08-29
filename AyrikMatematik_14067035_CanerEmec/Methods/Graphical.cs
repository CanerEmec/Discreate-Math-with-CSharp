using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrikMatematik_14067035_CanerEmec
{
    class Graphical
    {
        private double Epsilon;
        private double X0;
        private double Dx;
        private double[] A;
        private int IterNo = 0;

        public delegate void NotifyEventHandler(object sender, SEventArgs e);
        public event NotifyEventHandler OnNotify;

        public struct Result
        {
            public double x0;
            public double root;

            public double f0;

            public double err1;    
            public double iter_no;
            public char indicator;
        }

        private Result result;

        public Graphical(double[] A, double eps, double x0, double Dx)
        {
            this.A = A;
            this.Epsilon = eps;
            this.X0 = x0;
            this.Dx = Dx;
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
            double err1 = double.PositiveInfinity;
            double f0 = 0, f1 = 0;
            result.iter_no = 0;
            result.indicator = ' ';

            while (err1 > Epsilon)
            {
                f1 = F(X0);

                result.x0 = X0;
                result.f0 = f1;

                if (f0*f1 < 0)
                {
                    Dx /= 2;
                    X0 -= Dx;
                    f0 = F(X0 - Dx);
                    result.indicator = '\n';
                }
                else
                {
                    f0 = f1;
                    X0 += Dx;
                    result.indicator = ' ';
                }

                err1 = Dx;

                result.iter_no++;

                result.err1 = err1;


                if (OnNotify != null)
                {
                    SEventArgs args = new SEventArgs(result);
                    OnNotify(this, args);
                }

            }
            result.root = X0 - Dx;
            result.f0 = F(X0);

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
