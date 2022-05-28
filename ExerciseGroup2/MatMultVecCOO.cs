using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExerciseGroups_spiroskou.ExerciseGroup2
{
    class MatMultVecCOO
    {
        public static double[] MatrixVectorCOORow(double[] values, double[] rows, double[] columns, double[] x)
        {
            int m = (int)Utilities.GetMaxArray(rows);
            int n = (int)Utilities.GetMaxArray(columns);
            double[] b;
            if (m >= n)
            {
                b = new double[x.Length + Math.Abs(m - n)];
            }
            else
            {
                b = new double[x.Length - Math.Abs(m - n)];
            }
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = 0;
                for (int j = 0; j < values.Length; j++)
                {
                    if (rows[j] == i)
                    {
                        b[i] = b[i] + values[j] * x[(int)columns[j]];
                    }
                }
            }
            return b;
        }

        public static void TestMatrixVectorCOORow()
        {
            // 3X4 X 4X1 = 3X1
            double[] values = { 2.09065, 0.76202, 3.72194, 2.74205, 1.6819, 0.02756 };
            double[] rows = {0,1,1,1,2,2};
            double[] columns = {2,0,1,2,0,3};
            double[] vector = { 1, 1, 1, 1 };
            double[] y = MatrixVectorCOORow(values, rows, columns, vector);
            for (int i = 0; i < y.Length; i++)
            {
                y[i] = Math.Round(y[i], 4);
            }
            double[] yExpected = { 2.0906, 7.2260, 1.7095 };
            Utilities.CheckEqualArrays(y, yExpected);
        }

        public static double[] TransposeMatrixVectorCOORow(double[] values, double[] rows, double[] columns, double[] x)
        {
            int m = (int)Utilities.GetMaxArray(rows);
            int n = (int)Utilities.GetMaxArray(columns);
            double[] b;
            if (m >= n)
            {
                b = new double[x.Length - Math.Abs(m - n)];
            }
            else
            {
                b = new double[x.Length + Math.Abs(m - n)];
            }
            for (int i = 0; i < b.Length; i++)
            {
                for (int j = 0; j < values.Length; j++)
                {
                    if (columns[j] == i)
                    {
                        b[i] = b[i] + values[j] * x[(int)rows[j]];
                    }

                }

            }

            return b;
        }

        public static void TestTransposeMatrixVectorCOORow()
        {

            double[] values = { 2.09065, 0.76202, 3.72194, 2.74205, 1.6819, 0.02756 };
            double[] rows = { 0, 1, 1, 1, 2, 2 };
            double[] columns = { 2, 0, 1, 2, 0, 3 };
            double[] vector = { 1, 1, 1 };
            double[] y = TransposeMatrixVectorCOORow(values, rows, columns, vector);
            for (int i = 0; i < y.Length; i++)
            {
                y[i] = Math.Round(y[i], 4);
            }
            double[] yExpected = { 2.4439, 3.7219, 4.8327, 0.0276 };
            Utilities.CheckEqualArrays(y, yExpected);

        }
    }
}
