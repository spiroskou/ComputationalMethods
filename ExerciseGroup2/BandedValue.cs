using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExerciseGroups_spiroskou.ExerciseGroup2
{
    class BandedValue
    {
        public static double GetValueAij(double[] ABanded, int i, int j)
        {
            // upper band only : j>=i always
            int m = 4; // AUTOMATOPOIHSH??
            double Aij = 0;
            if (i==j)
            {
                Aij = ABanded[i];
            }
            if (i<j)
            {
                int diff = j - i;
                Aij = ABanded[m * diff + j];
            }
            if (i>j)
            {
                int diff = i - j;
                Aij = ABanded[m * diff + i];
            }

            return Aij;
        }

        public static void TestGetValueAij()
        {
            int i = 2;
            int j = 3;
            int k = 4;
            int l = 3;
            int m = 2;
            int n = 2;
            double[] ABanded = { 21, 22, 23, 24, 25, 1, 2, 1, 2, 0, 0, 0, 3, 0, 0, 4, 0, 0, 0, 0 };
            double a = GetValueAij(ABanded, i, j);
            double b = GetValueAij(ABanded, k, l);
            double c = GetValueAij(ABanded, m, n);
            double[] y = { a, b, c };
            double[] yExpected = { 1, 2, 23 };
            Utilities.CheckEqualArrays(y, yExpected);
        }
    }
}
