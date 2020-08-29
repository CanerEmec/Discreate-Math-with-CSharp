using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrikMatematik_14067035_CanerEmec
{
    class GaussJordanElimination
    {
        private int N { get; set; }
        private double[,] MatA { get; set; }
        private double[] MatB { get; set; }
        private double[] MatC { get; set; }
        private double[,] MatAC { get; set; }

        public delegate void NotifyEventHandler(object sender, GJEEventArgs e);
        public event NotifyEventHandler OnNotify;

        public struct Result
        {
            public bool isSolved;
            public double iter_no;
            public string explanation;
            public double[,] matAC;
            public double[] result;
        }

        private Result result;

        public GaussJordanElimination(int n, string strA, string strC)
        {
            this.N = n;
            MatA = new double[N, N];
            MatB = new double[N];
            MatC = new double[N];
            MatAC = new double[N, N + 1];

            ParseAndInitA(MatA, strA);
            ParseAndInitC(MatC, strC);
            ConcatMatrices();
        }

        private void ConcatMatrices()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    MatAC[i, j] = MatA[i, j];
                }

                MatAC[i, N] = MatC[i];
            }
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

        private void SwapRows(int first, int second)
        {
            if (first > N - 1 || second > N - 1)
                return;

            double[] temp = new double[N + 1];

            for (int i = 0; i < N + 1; i++)
            {
                temp[i] = MatAC[first, i];
                MatAC[first, i] = MatAC[second, i];
                MatAC[second, i] = temp[i];
            }
        }

        private void MultiplyRow(double constant, int rNum)
        {
            for (int i = 0; i < N + 1; i++)
            {
                MatAC[rNum, i] *= constant;
            }
        }

        private void AddRows(int first, int second)
        {
            for (int i = 0; i < N + 1; i++)
            {
                MatAC[second, i] += MatAC[first, i];
            }
        }

        private void MultiplyAndAdd(double constant, int first, int second)
        {
            double[] temp = new double[N + 1];

            for (int i = 0; i < N + 1; i++)
            {
                temp[i] = MatAC[first, i] * constant;
                MatAC[second, i] += temp[i];
            }
        }

        public Result Solve()
        {
            double divider = 0, multiplier = 0;
            //kontrol ve swap..

            result.iter_no = 0;
            result.isSolved = false;
            result.matAC = MatAC;

            for (int i = 0; i < N; i++)//rows
            {
                divider = 1 / MatAC[i, i];  //asal eksendekiler 1 yapiliyor.
                MultiplyRow(divider, i);

                result.explanation = "Row " + (i + 1) + " divided by " + 1 / divider + ". ";
                result.iter_no++;

                if (OnNotify != null)
                {
                    GJEEventArgs args = new GJEEventArgs(result);
                    OnNotify(this, args);
                }

                for (int j = i + 1; j < N; j++)//oth rows 0 laniyor..
                {
                    multiplier = -MatAC[j, i];
                    MultiplyAndAdd(multiplier, i, j);

                    result.explanation = "Row " + (i + 1) + " multiplied by " + multiplier + " then added to Row " + (j + 1) + ". ";
                    result.iter_no++;

                    if (OnNotify != null)
                    {
                        GJEEventArgs args = new GJEEventArgs(result);
                        OnNotify(this, args);
                    }
                }
            }

            for (int i = N-1; i > -1; i--)
            {
                for (int j = i - 1; j > -1; j--)
                {
                    multiplier = -MatAC[j, i];
                    MultiplyAndAdd(multiplier, i, j);

                    result.explanation = "Row " + (i + 1) + " multiplied by " + multiplier + " then added to Row " + (j + 1) + ". ";
                    result.iter_no++;

                    if (OnNotify != null)
                    {
                        GJEEventArgs args = new GJEEventArgs(result);
                        OnNotify(this, args);
                    }

                }
            }

            for (int i = 0; i < N; i++)
            {
                MatB[i] = MatAC[i, N];
            }

            result.result = MatB;
            result.matAC = MatAC;
            result.explanation = "SOLVED !!";
            result.iter_no++;
            result.isSolved = true;

            if (OnNotify != null)
            {
                GJEEventArgs args = new GJEEventArgs(result);
                OnNotify(this, args);
            }
            return result;
        }

        public class GJEEventArgs : EventArgs
        {
            public Result Result { get; set; }
            public GJEEventArgs(Result result)
            {
                this.Result = result;
            }
        }
    }
}
