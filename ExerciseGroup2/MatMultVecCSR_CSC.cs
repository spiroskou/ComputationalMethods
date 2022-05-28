using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExerciseGroups_spiroskou.ExerciseGroup2
{
    class MatMultVecCSR_CSC
    {
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
        public static void TestMatrixVectorCSR()
        {
            
            double[] values = { 2.09065, 0.76202, 3.72194, 2.74205, 1.6819, 0.02756 };
            double[] col_indices = { 2, 0, 1, 2, 0, 3 };
            double[] row_offsets = { 0, 1, 4, 6 };
            double[] vector = { 1, 1, 1, 1 };
            double[] y = MatrixVectorCSR(values, col_indices, row_offsets, vector);
            for (int i = 0; i < y.Length; i++)
            {
                y[i] = Math.Round(y[i], 4);
            }
            double[] yExpected = {2.0906,7.2260,1.7095};
            Utilities.CheckEqualArrays(y, yExpected);

        }
        public static double[] TransposeMatrixVectorCSR(double[] values, double[] col_indices, double[] row_offsets, double[] vector)
        {
            
            int n = row_offsets.Length ;
            double[] y = new double[n];
            for (int i = 0; i < n; i++)
            {
                y[i] = 0;
            }
            for (int i = 0; i < n-1; i++)
            {
                for (int k = Convert.ToInt32(row_offsets[i]); k <= Convert.ToInt32(row_offsets[i + 1] - 1); k++)
                {
                    y[Convert.ToInt32(col_indices[k])] = y[Convert.ToInt32(col_indices[k])] + values[k] * vector[i];
                }
            }
            return y;
        }
        public static void TestTransposeMatrixVectorCSR()
        {

            double[] values = { 2.09065, 0.76202, 3.72194, 2.74205, 1.6819, 0.02756 };
            double[] col_indices = { 2, 0, 1, 2, 0, 3 };
            double[] row_offsets = { 0, 1, 4, 6 };
            double[] vector = { 1, 1, 1, 1 };
            double[] y = TransposeMatrixVectorCSR(values, col_indices, row_offsets, vector);
            for (int i = 0; i < y.Length; i++)
            {
                y[i] = Math.Round(y[i], 4);
            }
            double[] yExpected = {2.4439,3.7219,4.8327,0.0276};
            Utilities.CheckEqualArrays(y, yExpected);

        }
        


    }
}

