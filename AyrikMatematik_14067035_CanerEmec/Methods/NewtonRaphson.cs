using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrikMatematik_14067035_CanerEmec
{
    class NewtonRaphson
    {
        private double Epsilon;
        private double InitialValue;
        private double[] A;
        private int IterNo = 0;

        public delegate void NotifyEventHandler(object sender, NREventArgs e);
        public event NotifyEventHandler OnNotify;

        public struct Result
        {
            public double x_i;
            public double x_i_plus_1;
            public double F;
            public double dF;
            public double err;
            public double iter_no;
        }

        private Result result;

        public NewtonRaphson(double[] A, double Eps, double initValue)
        {
            this.A = A;
            this.Epsilon = Eps;
            this.InitialValue = initValue;
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

        private double dF(double x)
        {
            double result = 0;
            for (int i = 0; i < A.Length; i++)
            {
                result += i * A[A.Length - i - 1] * Math.Pow(x, i - 1);
            }
            return result;

        }

        public Result Solve()
        {
            double x = InitialValue;
            double tmp = 0;
            double err = double.PositiveInfinity;

            double t1, t2;
            IterNo = 0;

            while (err > Epsilon)
            {
                tmp = x;

                t1 = F(x);
                t2 = dF(x);

                x = x - (t1 / t2);

                err = Math.Abs(x - tmp);
                IterNo++;

                result.iter_no = IterNo;
                result.x_i = tmp;
                result.x_i_plus_1 = x;
                result.F = t1;
                result.dF = t2;
                result.err = err;

                if(OnNotify != null)
                {
                    NREventArgs args = new NREventArgs(result);
                    OnNotify(this, args);
                }
            }

            return result;
        }

        public class NREventArgs : EventArgs
        {
            public Result Result { get; set; }
            public NREventArgs(Result result)
            {
                this.Result = result;
            }
        }
    }


}
