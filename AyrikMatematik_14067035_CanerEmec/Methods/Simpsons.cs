using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrikMatematik_14067035_CanerEmec
{
    class Simpsons
    {
        private int LowerBound { get; set; }
        private int UpperBound { get; set; }
        private double H { get; set; }

        private double[] A;


        public Simpsons(double[] A,int lb, int ub, int n)
        {
            this.LowerBound = lb;
            this.UpperBound = ub;
            this.H = (ub - lb) /(double) n;
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

        public double Solve(Rule rule)
        {
            double output = 0;
            output += F(LowerBound);
            output += F(UpperBound);
            double x = LowerBound;
            int i = 1;

            while (x + H <= UpperBound)
            {
                x = x + H;

                switch (rule)
                {
                    case Rule.R_3Div8:
                        if (i % 3 == 0)
                        {
                            output += 2 * F(x);
                        }
                        else
                        {
                            output += 3 * F(x);
                        }
                        break;

                    case Rule.R_1Div3:
                        if (i % 2 == 0)
                        {
                            output += 2 * F(x);
                        }
                        else
                        {
                            output += 4 * F(x);
                        }
                        break;
                }
                

                i++;
            }

            if (rule == Rule.R_1Div3)
                return (H / 3) * output;
            return (3 * H / 8) * output;
        }

        /// <summary>
        /// Rule 1/3 ==> R_1Div3
        /// Rule 3/8 ==> R_3Div8
        /// </summary>
        public enum Rule
        {
            R_3Div8,
            R_1Div3
        }
    }
}
