using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrikMatematik_14067035_CanerEmec
{
    class Jacobi
    {
        private int N { get; set; }
        private double[,] MatA { get; set; }
        private double[] MatB { get; set; }
        private double[] MatB_old { get; set; }
        private double[] MatC { get; set; }
        private double Eps { get; set; }
        private int MaxIter { get; set; }

        public delegate void NotifyEventHandler(object sender, JacobiEventArgs e);
        public event NotifyEventHandler OnNotify;

        public struct Result
        {
            public double iter_no;
            public double[] result;
            public double err;
        }

        private Result result;

        public Jacobi(int n, string strA, string strC, double eps, int maxIter)
        {
            this.N = n;
            this.Eps = eps;
            this.MaxIter = maxIter;

            MatA = new double[N, N];
            MatB = new double[N];
            MatB_old = new double[N];
            MatC = new double[N];

            ParseAndInitA(MatA, strA);
            ParseAndInitC(MatC, strC);
        }

        private void ParseAndInitA(double[,] Matrix_, String str)
        {
            str = str.Trim();
            string[] strArr = str.Split(';');
            string[] strArr2;

            int k;
            for (int i = 0; i < strArr.Length; i++)
            {
                strArr[i] = strArr[i].Trim();
                strArr2 = strArr[i].Split(' ');

                k = 0;
                for (int j = 0; j < strArr2.Length; j++)
                {
                    if (strArr2[j].Length > 0)
                    {
                        Matrix_[i, k] = Convert.ToDouble(strArr2[j]);
                        k++;
                    }
                }
            }
        }

        private void ParseAndInitC(double[] Matrix_, String str)
        {
            str = str.Trim();
            string[] strArr = str.Split(' ');

            int k = 0;
            for (int i = 0; i < strArr.Length; i++)
            {
                if (strArr[i].Length > 0)
                {
                    Matrix_[k] = Convert.ToDouble(strArr[i]);
                    k++;
                }

            }
        }

        public Result Solve()
        {
            //kontrol ve swap..
            double err = Double.MaxValue;

            result.iter_no = 0;

            while (err > Eps && result.iter_no < MaxIter)
            {
                err = 0;
                //B=B_old...
                for (int i = 0; i < N; i++)
                {
                    MatB[i] = MatC[i];
                    for (int j = 0; j < N; j++)
                    {
                        if (i != j)
                            MatB[i] -= MatA[i, j] * MatB_old[j];
                    }
                    MatB[i] /= MatA[i, i];
                }

                //err & iter++
                for (int i = 0; i < N; i++)
                {
                    err += Math.Abs(MatB[i] - MatB_old[i]);
                }
                err /= N;

                result.iter_no++;
                result.result = MatB;
                result.err = err;

                if (OnNotify != null)
                {
                    JacobiEventArgs args = new JacobiEventArgs(result);
                    OnNotify(this, args);
                }

                //B_old=B
                for (int i = 0; i < N; i++)
                {
                    MatB_old[i] = MatB[i];
                }
            }

            return result;
        }

        public class JacobiEventArgs : EventArgs
        {
            public Result Result { get; set; }
            public JacobiEventArgs(Result result)
            {
                this.Result = result;
            }
        }
    }
}
