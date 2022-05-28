using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExerciseGroups_spiroskou.ExerciseGroup2
{
    class LL
    {
        public static double[,] LLFactorization(double[,] A)
        {
            double[,] L = new double[A.GetLength(0), A.GetLength(1)];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                L[i, i] = A[i, i];
                double sum = 0;
                for (int k = 0; k < i; k++)
                {
                    sum = sum - L[i, k] * L[i, k];
                }
                L[i, i] += sum;
                L[i, i] = Math.Sqrt(L[i, i]);
                for (int j = i + 1; j < A.GetLength(1); j++)
                {
                    L[j, i] = A[j, i] / L[i, i];
                    double sum2 = 0;
                    for (int l = 0; l < i; l++)
                    {
                        sum2 = sum2 - L[i, l] * L[j, l] / L[i, i];
                    }
                    L[j, i] = L[j, i] + sum2;
                }
            }
            //Utilities.ShowMatrix(L);
            //Console.WriteLine();
            return L;
        }
        public static double[] SolveWithLL(double[,] L,  double[] b)
        {
            // SOLVE LINEAR SYSTEM Ax=b
            // FORWARD SUBSITUTION Ly=b

            double[] y = new double[L.GetLength(1)];
            y[0] = b[0] / L[0, 0];
            for (int i = 1; i < L.GetLength(0); i++)
            {
                y[i] = b[i] / L[i, i];
                for (int j = 0; j < i; j++)
                {
                    y[i] -= L[i, j] * y[j] / L[i, i];
                }
            }
            // BACKWARD SUBSITUTION Ux = y

            double[] x = new double[L.GetLength(1)];
            double[,] U = Utilities.TransposeMatrixFull(L);
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
        public static void TestLLFactorization()
        {
            double[,] matrixA = new double[,]
            {
                {8.9156, 0.4590, 0.0588, 0.5776},
                {0.4590, 7.5366,0.4276,0.3282 },
                {0.0588,0.4276,6.4145,0.4144},
                {0.5776,0.3282,0.4144,7.7576 }
            };
            double[,] L = LLFactorization(matrixA);
            double[,] U = Utilities.TransposeMatrixFull(L);
            double[,] A = Utilities.MatrixMatrixFull(L, U);
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    A[i, j] = Math.Round(A[i, j], 4);
                }
            }
            double[,] AExpected = matrixA;
            Utilities.CheckEqualMatrices(A, AExpected);
        }
        public static void TestSolveWithLL()
        {
            // TESTS BOTH SOLVE AND FACTORIZATION FUNCTIONS
            double[,] matrixA = new double[,]
            {
                {8.9156, 0.4590, 0.0588, 0.5776},
                {0.4590, 7.5366,0.4276,0.3282 },
                {0.0588,0.4276,6.4145,0.4144},
                {0.5776,0.3282,0.4144,7.7576 }
            };
            double[,] L = LLFactorization(matrixA);
            double[] b = { 1, 1, 1, 1 };
            double[] x = SolveWithLL(L, b);
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = Math.Round(x[i], 4);
            }
            double[] xExpected = { 0.0983, 0.1140, 0.1403, 0.1093 };
            Utilities.CheckEqualArrays(x, xExpected);
        }

    }
}
