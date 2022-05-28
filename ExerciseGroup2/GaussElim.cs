using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CSharpExerciseGroups_spiroskou.ExerciseGroup2
{
    class GaussElim
    {
        public static double[,] GaussianElimination(double[,] A, double[,] B)
        {
            // A MUST BE SQUARE MATRIX
            Debug.Assert(A.GetLength(0) == A.GetLength(1));
            // FIND MAX OF THE FIRST COLUMN
            double max = A[0,0];
            int ithRow = 0;
            for (int i=0; i<A.GetLength(0);i++)
            {
                if (Math.Abs(A[i,0]) > Math.Abs(max))
                {
                    max = A[i, 0];
                    ithRow = i;
                }
            }
            // SWAP FIRST ROW WITH ITHROW
            // BUILD VECTORS FOR FIRST ROW
            double[] a1 = new double[A.GetLength(1)];
            double[] b1 = new double[B.GetLength(1)];
            for (int i = 0; i < A.GetLength(1); i++)
            {
                a1[i] = A[0, i];
            }
            for (int i = 0; i < B.GetLength(1); i++)
            {
                b1[i] = B[0, i];
            }

            for (int j = 0; j<A.GetLength(1); j++)
            {
                A[0, j] = A[ithRow, j];
                A[ithRow, j] = a1[j];
            }
            for (int j = 0; j < B.GetLength(1); j++)
            {
                B[0, j] = B[ithRow, j];
                B[ithRow, j] = b1[j];
            }
            //Utilities.ShowMatrix(A);
            //Console.WriteLine();
            //Utilities.ShowMatrix(B);
            //Console.WriteLine();



            // CREATE AUGMENTED AB

            double[,] AUG = new double[A.GetLength(0), A.GetLength(1) + B.GetLength(1)];
            for (int i = 0; i < AUG.GetLength(0); i++)
            {
               for (int j=0; j< A.GetLength(1);j++)
                {
                    AUG[i, j] = A[i, j];
                }
               for (int j=A.GetLength(1); j<A.GetLength(1)+B.GetLength(1);j++)
                {
                    AUG[i, j] = B[i, j-A.GetLength(1)];
                }
            }
            //Utilities.ShowMatrix(AUG);
            //Console.WriteLine();


            // MAKE AUG AN UPPER TRIANGULAR MATRIX
            for (int i = 0; i<AUG.GetLength(0)-1; i++)
            {
                for (int l =i+1; l<AUG.GetLength(0); l++)
                {
                    double fctr = AUG[l, i] / AUG[i, i];
                    for (int j = 0; j<AUG.GetLength(1); j++)
                    {
                       
                        AUG[l, j] = AUG[l, j] - fctr * AUG[i, j];

                    }
                }
                    
            }

            //Utilities.ShowMatrix(AUG);
            //Console.WriteLine();

            // BREAK AUGMENTED MATRIX TO A AND B
            for (int i = 0; i < AUG.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    A[i, j] = AUG[i, j];
                }
            }

            for (int i = 0; i < AUG.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = AUG[i, j + A.GetLength(1)];
                }
            }
            //Utilities.ShowMatrix(A);
            //Console.WriteLine();
            //Utilities.ShowMatrix(B);
            //Console.WriteLine();

            // BACK SUBSITUTION!!!!!!!!!!
            double[,] X = new double[A.GetLength(1), B.GetLength(1)];
            for (int j = 0; j < X.GetLength(1); j++)
            {
                X[X.GetLength(0) - 1, j] = B[X.GetLength(0) - 1, j] / A[A.GetLength(0) - 1, A.GetLength(0) - 1];
            }
            //Utilities.ShowMatrix(X);
            //Console.WriteLine();
            for (int i = X.GetLength(0)-2; i >= 0; i--)
            {
                for (int j = 0; j < X.GetLength(1); j++)
                {
                    X[i, j] = B[i, j] / A[i, i];
                    for (int k = i+1; k < A.GetLength(1); k++)
                    {
                        X[i,j] -= A[i, k] * X[k, j]/A[i,i];
                    }
                    
                }
            }
            
            return X;
        }
        public static void TestGaussianElimination()
        {
            double[,] matrixA = new double[4, 4]
            {
                {1.4,6.4,9.1,0 },
                {3.2,2.1,3.6,0 },
                {-1.8,0.3,0.1,0 },
                {5.4,-0.2,-0.5,1}
            };
            double[,] matrixB = new double[4, 3]
            {
                {1,1,0 },
                {1,0,0 },
                {1,0,1 },
                {1,0,0 }
            };
            double [,] x = GaussianElimination(matrixA, matrixB);
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    x[i, j] = Math.Round(x[i, j], 4);
                }
            }
            double[,] xExpected = new double[4, 3]
            {
                {-3.2107, 0.5424, -2.4501 },
                {-21.0723, 4.2394, -15.0125 },
                {15.4239, -2.9551, 10.9352 },
                {21.8354, -3.5586, 15.6958 }
            };
            Utilities.CheckEqualMatrices(x, xExpected);
        }
    }
}
