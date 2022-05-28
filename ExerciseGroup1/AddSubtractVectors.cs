using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CSharpExerciseGroups_spiroskou.ExerciseGroup1
{
    class AddSubtractVectors
    {
        public static double[] AddVectors(double[] x, double[] y) 
        {
            if (x.Length != y.Length)
            {
                throw new Exception("vectors have different dimensions");
            }
            int n = x.Length; 
            double[] z = new double[n]; 
            for (int i = 0; i < n; i++)
            {
                z[i] = x[i] + y[i]; 
            }
            return z;
        }
        public static void TestAddVectors() 
        {
            double[] a = new double[] { 1, 2, 3, 4, 5, };
            double[] b = { 0.1, 0.2, 0.3, 0.4, 0.5 };
            double[] c = AddVectors(a, b);
            double[] cExpected = { 1.1, 2.2, 3.3, 4.4, 5.5 };
            Utilities.CheckEqualArrays(cExpected, c);
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
        public static void TestSubtractVectors() 
        {
            double[] a = new double[] { 1, 2, 3, 4, 5, };
            double[] b = { 0.1, 0.2, 0.3, 0.4, 0.5 };
            double[] c = SubtractVectors(a, b);
            double[] cExpected = { 0.9, 1.8, 2.7, 3.6, 4.5 };
            Utilities.CheckEqualArrays(cExpected, c);
            
        }
    }
}