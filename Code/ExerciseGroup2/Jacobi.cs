using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExerciseGroups_spiroskou.ExerciseGroup2
{
    class Jacobi
    {
        public static (double[] x, double rfinal) JacobiSolver(double[,] A, double[] b, double accuracy, int maxIter, double[] y_init)
        {
            double[] x = new double[A.GetLength(0)];
            double rfinal = 0;
            for (int iter = 1; iter < maxIter; iter++)
            {
                double[] y = new double[A.GetLength(0)];
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        y[i] = y[i] + A[i, j] * y_init[j];
                    }
                    for (int j = i + 1; j < A.GetLength(1); j++)
                    {
                        y[i] = y[i] + A[i, j] * y_init[j];
                    }
                    y[i] = (b[i] - y[i]) / A[i, i];
                }
                double[] z = Utilities.MatVecMult(A, y);
                double[] residual = Utilities.SubtractVectors(b, z);
                double norm = Utilities.EuclideanNorm(residual);
                y_init = y;


                if (norm <= accuracy | iter == maxIter)
                {
                    x = y;
                    rfinal = norm;
                    break;

                }

                Console.WriteLine(iter);

            }
            return (x, rfinal); // sygklinei an o A einai diagonally governant
        }



        public static void TestJacobiSolver()
        {
            double[,] A = new double[4, 4] { { 15, 4, 1, 3 }, { 3, 24, 6, 2 }, { 1, 0, 44, 4 }, { 0, 1, 4, 19 } };
            double[] b = new double[4] { 1, 2, 3, 4 };
            double[] y_init = new double[4] { 0, 0, 0, 0 };
            double accuracy = 1e-4;
            int maxIter = 1000000;

            double[] x = new double[4];
            double rfinal;

            (x, rfinal) = JacobiSolver(A, b, accuracy, maxIter, y_init);

            for (int i = 0; i < x.Length; i++)
            {
                x[i] = Math.Round(x[i], 4);
            }
            double[] xExpected = { 0.0097, 0.0532, 0.0500, 0.1972 };
            Utilities.CheckEqualArrays(x, xExpected);

        }
    }
}
