using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExerciseGroups_spiroskou.ExerciseGroup2
{
    class LUOverwriteA
    {
        public static double[,] LUOverrideA(double[,] A)
        {
            // LU FACTORIZATION ALGORITHM
            for (int i = 0; i < A.GetLength(0) - 1; i++)
            {
                for (int j = i + 1; j < A.GetLength(1); j++)
                {
                    A[j, i] = A[j, i] / A[i, i];
                    for (int k = i + 1; k < A.GetLength(1); k++)
                    {
                        A[j, k] = A[j, k] - A[j, i] * A[i, k];
                    }
                }
            }
            //Utilities.ShowMatrix(A);
            return A;
        }
        public static double[] SolveWithOverrideLU(double[,] A, double[] b)
        {
            // SOLVE LINEAR SYSTEM Ax=b
            // FORWARD SUBSITUTION Ly=b

            double[] y = new double[A.GetLength(1)];
            y[0] = b[0];
            for (int i = 1; i < A.GetLength(0); i++)
            {
                y[i] = b[i];
                for (int j = 0; j < i; j++)
                {
                    y[i] -= A[i, j] * y[j];
                }
            }
            // BACKWARD SUBSITUTION Ux = y

            double[] x = new double[A.GetLength(1)];
            x[x.GetLength(0) - 1] = y[x.GetLength(0) - 1] / A[x.GetLength(0) - 1, x.GetLength(0) - 1];
            for (int i = x.GetLength(0) - 2; i >= 0; i--)
            {
                x[i] = y[i] / A[i, i];
                for (int j = i + 1; j < A.GetLength(1); j++)
                {
                    x[i] -= A[i, j] * x[j] / A[i, i];
                }
            }
            //Utilities.ShowArrays(x);
            return x;
        }
        public static void TestSolveWithOverrideLU()
        {
            // TESTS BOTH SOLVE AND FACTORIZATION FUNCTIONS
            double[,] matrixA = new double[,]
            {
                {2,2,4,9 },
                {1,2.6667,71,5 },
                {1,1,3,5 },
                {0,0.3333,1,-2.5 }
            };
            double[,] A = LUOverrideA(matrixA);
            double[] b = { 1, 1, 1, 1 };
            double[] x = SolveWithOverrideLU(A, b);
            //Utilities.ShowArrays(x);
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = Math.Round(x[i], 4);
            }
            double[] xExpected = { -26.0175, 18.7931, -0.4606, 1.9213 };
            Utilities.CheckEqualArrays(x, xExpected);
        }
    }
}
