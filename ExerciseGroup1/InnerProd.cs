using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExerciseGroups_spiroskou.ExerciseGroup1
{
    class InnerProd
    {
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
        public static void TestInnerProduct() 
        {
            double[] x = { 2, 4, 6 };
            double[] y = { 4, 6, 8 };
            double z = InnerProduct(x, y);
            double zExpected = 80;
            Utilities.CheckEqualScalars(zExpected, z);


        }
        
    }
}
