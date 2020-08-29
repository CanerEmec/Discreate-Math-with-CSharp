using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrıkMaAyrikMatematik_14067035_CanerEmectematik
{
    class Matrix
    {
        private int N { get; set; }

        public Matrix(double[,] mat, int n, string str)
        {
            this.N = n;
            ParseAndInit(mat, str);
        }

        private void ParseAndInit(double[,] Matrix_, String str)
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

        public double[,] Identity(int size)
        {
            if (size < 1)
                return null;

            if (size == 1)
                return new double[1, 1] { { 1 } };

            if (size == 2)
                return new double[2, 2] { { 1, 0 }, { 0, 1 } };

            if (size == 3)
                return new double[3, 3] { {1, 0, 0 },
                                          {0, 1, 0 },
                                          {0, 0, 1 } };

            if (size == 4)
                return new double[4, 4] { {1, 0, 0, 0 },
                                          {0, 1, 0, 0 },
                                          {0, 0, 1, 0 },
                                          {0, 0, 0, 1 }};


            double[,] matrix = new double[size, size];

            for (int i = 0; i < size; i++)
            {
                matrix[i, i] = 1;
            }

            return matrix;
        }

        // Function to get cofactor of A[p,q] in [,]temp. n is current 
        // dimension of [,]A 
        void getCofactor(double[,] A, double[,] temp, int p, int q, int n)
        {
            int i = 0, j = 0;

            // Looping for each element of the matrix 
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    // Copying into temporary matrix only those element 
                    // which are not in given row and column 
                    if (row != p && col != q)
                    {
                        temp[i, j++] = A[row, col];

                        // Row is filled, so increase row index and 
                        // reset col index 
                        if (j == n - 1)
                        {
                            j = 0;
                            i++;
                        }
                    }
                }
            }
        }

        /* Recursive function for finding determinant of matrix. 
        n is current dimension of [,]A. */
        public double determinant(double[,] A, int n)
        {
            double D = 0; // Initialize result 

            // Base case : if matrix contains single element 
            if (n == 1)
                return A[0, 0];

            double[,] temp = new double[N, N]; // To store cofactors 

            int sign = 1; // To store sign multiplier 

            // Iterate for each element of first row 
            for (int f = 0; f < n; f++)
            {
                // Getting Cofactor of A[0,f] 
                getCofactor(A, temp, 0, f, n);
                D += sign * A[0, f] * determinant(temp, n - 1);

                // terms are to be added with alternate sign 
                sign = -sign;
            }
            return D;
        }

        // Function to get adjoint of A[N,N] in adj[N,N]. 
        public void adjoint(double[,] A, double[,] adj)
        {
            if (N == 1)
            {
                adj[0, 0] = 1;
                return;
            }

            // temp is used to store cofactors of [,]A 
            int sign = 1;
            double[,] temp = new double[N, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    // Get cofactor of A[i,j] 
                    getCofactor(A, temp, i, j, N);

                    // sign of adj[j,i] positive if sum of row 
                    // and column indexes is even. 
                    sign = ((i + j) % 2 == 0) ? 1 : -1;

                    // Interchanging rows and columns to get the 
                    // transpose of the cofactor matrix 
                    adj[j, i] = (sign) * (determinant(temp, N - 1));
                }
            }
        }

        // Function to calculate and store inverse, returns false if 
        // matrix is singular 
        public bool inverse(double[,] A, double[,] inverse)
        {
            // Find determinant of [,]A 
            double det = determinant(A, N);
            if (det == 0)
            {
                Console.Write("Singular matrix, can't find its inverse");
                return false;
            }

            // Find adjoint 
            double[,] adj = new double[N, N];
            adjoint(A, adj);

            // Find Inverse using formula "inverse(A) = adj(A)/det(A)" 
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    inverse[i, j] = adj[i, j] / (float)det;

            return true;
        }

        public string display(double[,] A)
        {
            string str = "";
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    //Console.Write("{0:F4} ", A[i, j]);
                    str += String.Format("{0:F4}\t", A[i, j]);
                }
                str += "\n";
                //Console.WriteLine();
            }
            return str;
        }

        public void display(float[,] A)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write("{0:F4} ", A[i, j]);
                Console.WriteLine();
            }
        }

        public void display(int[,] A)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write("{0:F4} ", A[i, j]);
                Console.WriteLine();
            }
        }
    }
}
