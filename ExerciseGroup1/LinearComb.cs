using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExerciseGroups_spiroskou.ExerciseGroup1
{
    class LinearComb
    {
        public static double[] LinearCombinationOfTwoVectors(double a, double b, double[] x, double[] y) 
        {
            if (x.Length != y.Length)
            {
                throw new Exception("vectors have different dimensions");
            }
            int n = x.Length;
            double[] z = new double[n];
            for (int i = 0; i < n; i++)
            {
                z[i] = a * x[i] + b * y[i];
            }
            return z;
        }
        public static void TestLinearCombinationOfTwoVectors() 
        {
            double a = 2;
            double b = 3;
            double[] x = { 2, 4, 6 };
            double[] y = { 4, 6, 8 };
            double[] z = LinearCombinationOfTwoVectors(a, b, x, y);
            double[] zExpected = { 16, 26, 36 };
            Utilities.CheckEqualArrays(zExpected, z);


        }
        
    }
}
