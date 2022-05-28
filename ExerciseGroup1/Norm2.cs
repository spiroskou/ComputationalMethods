using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExerciseGroups_spiroskou.ExerciseGroup1
{
    class Norm2
    {
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
        public static void TestEuclideanNorm() 
        {
            double[] x = { 2, 4, 6 };
            double z = EuclideanNorm(x);
            double zExpected = Math.Sqrt(56);
            Utilities.CheckEqualScalars(zExpected, z);


        }
        

    }
}
