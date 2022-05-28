using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CSharpExerciseGroups_spiroskou.ExerciseGroup2
{
    class MatVecFull
    {
		public static double[] MatrixVectorFull(double[,] matrix, double[] vector)
		{
			Debug.Assert(matrix.GetLength(1) == vector.Length);
			double[] c = new double[matrix.GetLength(0)];
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				double sum = 0;
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					sum += matrix[i, j] * vector[j];
				}
				c[i] = sum;
			}
			return c;
		}
		public static void TestMatrixVectorFull()
		{
			double[,] matrix = new double[2, 3]
			{
				{1,-1,2 },
				{0,-3,1 }
			};
			double[] vector = new double[] { 2, 1, 0 };
			double[] cExpected = new double[] { 1, -3 };
			double[] c = MatrixVectorFull(matrix, vector);
			Utilities.CheckEqualArrays(c, cExpected);
		}
	}
}
