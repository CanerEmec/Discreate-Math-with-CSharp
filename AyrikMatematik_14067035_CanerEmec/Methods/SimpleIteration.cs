using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrikMatematik_14067035_CanerEmec
{
    class SimpleIteration
    {
        private double Epsilon;
        private double X_0;
        private double[] G, H;
        private int IterNo = 0;
        private bool isConvergence;

        public delegate void NotifyEventHandler(object sender, SIEventArgs e);
        public event NotifyEventHandler OnNotify;

        public struct Result
        {
            public double hx;
            public double gx;

            public double err1;    
            public double iter_no;
        }

        private Result result;

        public SimpleIteration(double[] A, double[] H, double eps, double x_0)
        {
            this.G = G;
            this.H = H;
            this.X_0 = x_0;
            this.Epsilon = eps;
            this.isConvergence = false;
        }

        public Result Solve()
        {
            Result result;

            /*
            if (!CheckConvergence(X_0))
            {
                return;
            }*/

            double x = X_0;
            double gx = 0, hx = 0;
            double err = double.PositiveInfinity;

            IterNo = 0;

            while (err > Epsilon)
            {
                gx = F(G, x);
                hx = F(H, x);

                err = Math.Abs(gx - hx);
                IterNo++;

                result.gx = gx;
                result.hx = hx;
                result.iter_no = IterNo;
                result.err1 = err;

                if (OnNotify != null)
                {
                    SIEventArgs args = new SIEventArgs(result);
                    OnNotify(this, args);
                }
            }
            result.gx = gx;
            result.hx = hx;
            result.iter_no = IterNo;
            result.err1 = err;

            return result;
        }

        private bool CheckConvergence(double x0)
        {
            if (Math.Abs(dF(G, x0)) > Math.Abs(dF(H, x0)))
                return true;

            return false;
        }

        private double F(double[] A, double x)
        {
            double result = 0;
            for (int i = 0; i < A.Length; i++)
            {
                result += A[A.Length - i - 1] * Math.Pow(x, i);
            }

            return result;
        }

        private double dF(double[] A, double x)
        {
            double result = 0;
            for (int i = 0; i < A.Length; i++)
            {
                result += i * A[A.Length - i - 1] * Math.Pow(x, i - 1);
            }
            return result;

        }

        public class SIEventArgs : EventArgs
        {
            public Result Result { get; set; }
            public SIEventArgs(Result result)
            {
                this.Result = result;
            }
        }
    }
}
