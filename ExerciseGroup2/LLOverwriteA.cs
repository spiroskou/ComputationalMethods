using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExerciseGroups_spiroskou.ExerciseGroup2
{
    class LLOverwriteA
    {
        public static double[,] LLOverride(double[,] A)
        {
            
            for (int i = 0; i < A.GetLength(0); i++)
            {
                A[i, i] = A[i, i];
                double sum = 0;
                for (int k = 0; k < i; k++)
                {
                    sum = sum - A[i, k] * A[i, k];
                }
                A[i, i] += sum;
                A[i, i] = Math.Sqrt(A[i, i]);
                for (int j = i + 1; j < A.GetLength(1); j++)
                {
                    A[j, i] = A[j, i] / A[i, i];
                    double sum2 = 0;
                    for (int l = 0; l < i; l++)
                    {
                        sum2 = sum2 - A[i, l] * A[j, l] / A[i, i];
                    }
                    A[j, i] = A[j, i] + sum2;
                }
            }
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = i+1; j < A.GetLength(1); j++)
                {
                    A[i, j] = 0;
                }
            }
            //Utilities.ShowMatrix(A);
            //Console.WriteLine();
            return A;
        }
        public static double[] SolveWithLLOverride(double[,] A, double[] b)
        {
            // SOLVE LINEAR SYSTEM Ax=b
            // FORWARD SUBSITUTION Ly=b

            double[] y = new double[A.GetLength(1)];
            y[0] = b[0] / A[0, 0];
            for (int i = 1; i < A.GetLength(0); i++)
            {
                y[i] = b[i] / A[i, i];
                for (int j = 0; j < i; j++)
                {
                    y[i] -= A[i, j] * y[j] / A[i, i];
                }
            }
            // BACKWARD SUBSITUTION Ux = y

            double[] x = new double[A.GetLength(1)];
            double[,] U = Utilities.TransposeMatrixFull(A);
            x[x.GetLength(0) - 1] = y[x.GetLength(0) - 1] / U[x.GetLength(0) - 1, x.GetLength(0) - 1];
            for (int i = x.GetLength(0) - 2; i >= 0; i--)
            {
                x[i] = y[i] / U[i, i];
                for (int j = i + 1; j < U.GetLength(1); j++)
                {
                    x[i] -= U[i, j] * x[j] / U[i, i];
                }
            }
            //Utilities.ShowArrays(x);
            return x;
        }
        public static void TestSolveWithLLOverride()
        {
            // TESTS BOTH SOLVE AND FACTORIZATION FUNCTIONS
            double[,] matrixA = new double[,]
            {
                {8.9156, 0.4590, 0.0588, 0.5776},
                {0.4590, 7.5366,0.4276,0.3282 },
                {0.0588,0.4276,6.4145,0.4144},
                {0.5776,0.3282,0.4144,7.7576 }
            };
            double[,] A = LLOverride(matrixA);
            double[] b = { 1, 1, 1, 1 };
            double[] x = SolveWithLLOverride(A, b);
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = Math.Round(x[i], 4);
            }
            double[] xExpected = { 0.0983, 0.1140, 0.1403, 0.1093 };
            Utilities.CheckEqualArrays(x, xExpected);
        }
    }
}
