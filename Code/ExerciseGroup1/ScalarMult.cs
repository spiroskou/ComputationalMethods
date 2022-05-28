using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CSharpExerciseGroups_spiroskou.ExerciseGroup1
{
    class ScalarMult
    {
        public static double[] ScalarMultVector(double a, double[] x) 
        {
            int n = x.Length;
            double[] y = new double[n];
            for (int i = 0; i < x.Length; i++)
                y[i] = a * x[i];
            return y;
        }
        public static void TestScalarMultVector() 
        {
            double a = 2;
            double[] x = { 2, 4, 6 };
            double[] y = ScalarMultVector(a, x);
            double[] yExpected = { 4, 8, 12};
            Utilities.CheckEqualArrays(yExpected, y);
            
        }
        
    }
}
