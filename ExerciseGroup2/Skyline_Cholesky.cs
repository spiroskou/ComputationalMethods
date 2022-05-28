using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExerciseGroups_spiroskou.ExerciseGroup2
{
    class Skyline_Cholesky
    {
        public static (double[] values, int[] diag_offsets) FullToSkyline(double[,] A)
        {
            int nnz = 0;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (A[i, j] != 0)
                    {
                        nnz++;
                    }
                    if (A[i, j] == 0)
                    {
                        for (int l = j - 1; l >= 0; l--)
                        {
                            if (A[i, l] != 0)
                            {
                                nnz++;
                            }
                        }
                    }
                }
            }
            int m = A.GetLength(0);
            double[] values = new double[nnz];
            int[] diag_offsets = new int[m + 1];
            int k = 0;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (i == j)
                    {
                        diag_offsets[i] = k;
                    }
                    if (A[i, j] == 0)
                    {
                        for (int l = j - 1; l >= 0; l--)
                        {
                            if (A[i, l] != 0)
                            {
                                values[k] = A[i, j];
                                k++;
                            }
                        }
                    }
                    if (A[i, j] != 0)
                    {
                        values[k] = A[i, j];
                        k++;
                    }
                }
            }
            diag_offsets[m] = nnz;
            //Console.WriteLine("VALUES");
            //Utilities.ShowArrays(values);
            //Console.WriteLine();
            //Console.WriteLine("DIAG_OFFSETS");
            //Utilities.ShowArrays(diag_offsets);
            return (values, diag_offsets);
        }

        
        
          


            public static (double[] values, int[] diag_offsets) LLFactorizationSkylineToSkyline(double[] values, int[] diag_offsets)
            {
                int check = values.Length - 1;
                for (int i = 0; i < diag_offsets.Length - 1; i++)     
                {
                    int h = diag_offsets[i + 1] - diag_offsets[i]; 
                    int p = i - (h - 1); 
                    for (int j = h - 1; j >= 0; j--)
                    {
                        if (j == 0)
                        {
                            
                            double sum1 = 0;
                            for (int l = h - 1; l > 0; l--)
                            {
                                sum1 -= values[diag_offsets[i] + l] * values[diag_offsets[i] + l];
                            }
                            values[diag_offsets[i]] += sum1;
                            values[diag_offsets[i]] = Math.Sqrt(values[diag_offsets[i]]);
                            continue;
                        }
                        

                        double sum2 = 0;
                        for (int w = 1; w < h - j; w++)
                        {
                            int e = i + 1;
                            if (e == diag_offsets.Length - 1)
                            {
                                e -= 1;
                            }
                            if (values[diag_offsets[i] + j + w] == values[diag_offsets[e]] || values[diag_offsets[i] + j] == values[check] || values[diag_offsets[i - j] + w] == values[diag_offsets[i - j + 1]])
                            {
                                break;
                            }
                            sum2 -= values[diag_offsets[i] + j + w] * values[diag_offsets[i - j] + w];
                        }

                        values[diag_offsets[i] + j] = (1 / values[diag_offsets[p]]) * (values[diag_offsets[i] + j] + sum2);
                        p++;
                    }

                }
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = Math.Round(values[i], 4);
                }
                Utilities.ShowArrays(values);
                return (values, diag_offsets);
            }

        public static double[] BackSubsitutionSkyline(double[] values, int[] diag_offsets, double[] y)
        {
            int rows = diag_offsets.Length - 1;
            double[] x = new double[rows];
            for (int i = rows - 1; i >= 0; i--)
            {
                x[i] = y[i];
                double sum = 0;
                int p = (rows - 1) - i;
                for (int k = rows - 1; k > i; k--)
                {
                    int e = k + 1;
                    if (e == diag_offsets.Length - 1)
                    {
                        e -= 1;
                    }
                    if (diag_offsets[k] + p >= values.Length)
                    {
                        p--;
                        continue;
                    }
                    if (values[diag_offsets[k] + p] == values[diag_offsets[e]])
                    {
                        p--;
                        continue;
                    }
                    sum -= values[diag_offsets[k] + p] * x[k];
                    p--;
                }
                x[i] += sum;
                x[i] /= values[diag_offsets[i]];
            }
            return x;
        }

        public static double[] ForwardSubsitutionSkyline(double[] values, int[] diag_offsets, double[] b)
        {
            int rows = diag_offsets.Length - 1;
            double[] y = new double[rows];
            for (int i = 0; i < rows; i++)
            {
                y[i] = b[i];
                double sum = 0;
                int j = rows - 1 - i;
                for (int p = rows - 1 - j; p > 0; p--)
                {
                    if (diag_offsets[i] + p >= values.Length)
                    {
                        continue;
                    }
                    int e = i + 1;
                    if (e == diag_offsets.Length - 1)
                    {
                        e -= 1;
                    }
                    if (values[diag_offsets[i] + p] == values[diag_offsets[e]])
                    {
                        continue;
                    }
                    sum -= values[diag_offsets[i] + p] * y[i - p];
                }

                y[i] += sum;
                y[i] /= values[diag_offsets[i]];

            }
            return y;
        }

    }
}
