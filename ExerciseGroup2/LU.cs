using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExerciseGroups_spiroskou.ExerciseGroup2
{
    class LU
    {
        public static (double[,] L, double[,] U) LUFactorization(double[,] A)
        {
            // BUILD UNIT DIAGONAL MATRIX L
            double[,] L = new double[A.GetLength(0), A.GetLength(1)];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (i==j)
                    {
                        L[i, j] = 1;
                    }
                    else
                    {
                        L[i, j] = 0;
                    }
                }
            }
            // BUILD U EQUALS A
            double[,] U = new double[A.GetLength(0), A.GetLength(1)];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    U[i, j] = A[i, j];
                }
            }
            // LU FACTORIZATION ALGORITHM
            for (int i = 0; i < A.GetLength(0)-1; i++)
            {
                for (int j = i+1; j < A.GetLength(1); j++)
                {
                    L[j, i] = U[j, i] / U[i, i];
                    for (int k = i; k < A.GetLength(1); k++)
                    {
                        U[j, k] = U[j, k] - L[j, i] * U[i, k];
                    }
                }
            }
            //Utilities.ShowMatrix(L);
            //Console.WriteLine();
            //Utilities.ShowMatrix(U);
            //Console.WriteLine();
            
            return (L,U);
           
        }
        public static double[] SolveWithLU(double[,] L, double[,] U, double[] b)
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
                    y[i] -= L[i, j] * y[j]/L[i,i];
                }
            }
            // BACKWARD SUBSITUTION Ux = y

            double[] x = new double[L.GetLength(1)];
            x[x.GetLength(0) - 1] = y[x.GetLength(0) - 1] / U[x.GetLength(0) - 1, x.GetLength(0) - 1];
            for (int i = x.GetLength(0)-2; i >= 0 ; i--)
            {
                x[i] = y[i] / U[i, i];
                for (int j = i+1; j < U.GetLength(1); j++)
                {
                    x[i] -= U[i, j] * x[j] / U[i, i];
                }
            }
            //Utilities.ShowArrays(x);
            return x;
        }
        public static void TestLUFactorization()
        {
            double[,] matrixA = new double[,]
            {
                {2,2,4,9 },
                {1,2.6667,71,5 },
                {1,1,3,5 },
                {0,0.3333,1,-2.5 }
            };
            (double[,] L, double[,] U) = LUFactorization(matrixA);
            double[,] A = Utilities.MatrixMatrixFull(L, U);
            double[,] AExpected = matrixA;
            Utilities.CheckEqualMatrices(A, AExpected);
        }
        public static void TestSolveWithLU()
        {
            // TESTS BOTH SOLVE AND FACTORIZATION FUNCTIONS
            double[,] matrixA = new double[,]
            {
                {2,2,4,9 },
                {1,2.6667,71,5 },
                {1,1,3,5 },
                {0,0.3333,1,-2.5 }
            };
            (double[,] L, double[,] U) = LUFactorization(matrixA);
            double[] b = { 1, 1, 1, 1 };
            double[] x = SolveWithLU(L, U,b);
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
