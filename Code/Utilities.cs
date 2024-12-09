using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CSharpExerciseGroups_spiroskou
{
    class Utilities
    {
        public static void ShowArrays(double[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                Console.Write(x[i]);
                Console.Write(" ");
            }
        }

        public static void ShowMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public static void CheckEqualArrays(double[] x, double[] y) 
        {
            Debug.Assert(x.Length == y.Length);
            for (int i = 0; i < x.Length; i++)
            {
                Debug.Assert(x[i] == y[i]);
            }
            Console.WriteLine("Method is correct");
        }

        public static void CheckEqualScalars(double x, double y) 
        {
            Debug.Assert(x == y);
            Console.WriteLine("Method is correct");
        }

        public static void CheckEqualMatrices(double[,] x,double[,] y)
        {
            // MATRICES HAVE TO BE SAME SIZE
            Debug.Assert(x.GetLength(0) == y.GetLength(0) && x.GetLength(1) == y.GetLength(1));
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    Debug.Assert(x[i, j] == y[i, j]);
                }
            }
            Console.WriteLine("Method is correct");
        }

        public static double[,] MatrixMatrixFull(double[,] A, double[,] B)
        {
            Debug.Assert(A.GetLength(1) == B.GetLength(0));
            double[,] C = new double[A.GetLength(0),B.GetLength(1)];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j<B.GetLength(1); j++)
                {
                    double sum = 0;
                    for (int k = 0; k < A.GetLength(1); k++)
                    {
                        sum += A[i, k] * B[k, j];
                    }
                    C[i, j] = sum;
                }
            }
            ShowMatrix(C);
            Console.WriteLine();
            return C;
            
        }

        public static double[,] TransposeMatrixFull(double[,] A)
        {
            double[,] C = new double[A.GetLength(0), A.GetLength(1)];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    C[i, j] = A[j, i];
                }
            }
            //ShowMatrix(C);
            Console.WriteLine();
            return C;
        }

        public static double GetMaxArray(double[] x)
        {
            double max = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] > max)
                {
                    max = x[i];
                }
            }
            return max;
        }

        public static double[] MatVecMult(double[,] a, double[] x)
        {



            int ai = a.GetLength(0);
            int aj = a.GetLength(1);
            int xj = x.Length;
            double[] b = new double[ai];

            if (aj == xj)
            {
                for (int i = 0; i < ai; i++)
                {
                    for (int j = 0; j < aj; j++)
                    {
                        b[i] = b[i] + a[i, j] * x[j];
                    }

                }

            }
            else
            {
                Console.WriteLine("Matrix columns must be equal to the vector's rows.");
            }
            return b;
        }

        public static double[] AddVectors(double[] x, double[] y) 
        {
            if (x.Length != y.Length)
            {
                throw new Exception("vectors have different dimensions");
            }
            int n = x.Length; //number of vector elements
            double[] z = new double[n]; // initialization of the final vector
            for (int i = 0; i < n; i++)
            {
                z[i] = x[i] + y[i]; // final vector's elements
            }
            return z;
        }

        public static double[] SubtractVectors(double[] x, double[] y) 
        {
            if (x.Length != y.Length)
            {
                throw new Exception("vectors have different dimensions");
            }
            int n = x.Length; //number of vector elements
            double[] z = new double[n]; // initialization of the final vector
            for (int i = 0; i < n; i++)
            {
                z[i] = x[i] - y[i]; // final vector's elements
            }
            return z;
        }

        public static double[] ScalarMultVector(double a, double[] x) 
        {
            int n = x.Length;
            double[] y = new double[n];
            for (int i = 0; i < x.Length; i++)
                y[i] = a * x[i];
            return y;
        }

        public static double EuclideanNorm(double[] x) 
        {

            int n = x.Length; 
            double norm2 = 0;
            for (int i = 0; i < n; i++)
            {
                norm2 += x[i] * x[i];
            }
            norm2 = Math.Sqrt(norm2);
            return norm2;
        }

        public static double[] MatrixVectorCSR(double[] values, double[] col_indices, double[] row_offsets, double[] vector)
        {
            
            int m = row_offsets.Length - 1;
            double[] y = new double[m];
            for (int i = 0; i < m; i++)
            {
                y[i] = 0;
                for (int k = Convert.ToInt32(row_offsets[i]); k <= Convert.ToInt32(row_offsets[i + 1] - 1); k++)
                {
                    y[i] = y[i] + values[k] * vector[Convert.ToInt32(col_indices[k])];
                }
            }
            return y;
        }
        public static double InnerProduct(double[] x, double[] y)
        {
            if (x.Length != y.Length)
            {
                throw new Exception("vectors have different dimensions");
            }
            int n = x.Length;
            double z = 0;
            for (int i = 0; i < n; i++)
            {
                z += x[i] * y[i];
            }
            return z;
        }
    }
}
