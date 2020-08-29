using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrikMatematik_14067035_CanerEmec
{
    class Trapezoidal
    {
        private int LowerBound { get; set; }
        private int UpperBound { get; set; }
        private double H { get; set; }

        private double[] A;


        public Trapezoidal(double[] A, int lb, int ub, int n)
        {
            this.LowerBound = lb;
            this.UpperBound = ub;
            this.H = (ub - lb) / (double)n;
            this.A = A;
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

        public double Solve()
        {
            double output = 0;
            output += F(LowerBound);
            output += F(UpperBound);
            double x = LowerBound;
            int i = 1;

            while (x + H <= UpperBound)
            {
                x = x + H;
                output += 2 * F(x);
                i++;
            }

            return (H / 2) * output;
        }
    }
}
