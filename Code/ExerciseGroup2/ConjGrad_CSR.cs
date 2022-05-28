using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExerciseGroups_spiroskou.ExerciseGroup2
{
    class ConjGrad_CSR
    {
        public static (double[] xfinal, double normfinal) ConjugateGradientwithCSR(double[] values, double[] col_indices, double[] row_offsets, double[] b, double accuracy, int maxIter, double[] y_init)
        {
            double[] y = new double[row_offsets.Length - 1];
            double[] xfinal = new double[row_offsets.Length - 1];
            double norm = 0;
            double normfinal = 0;
            double[] r = new double[row_offsets.Length - 1];
            double a;

            double[] r_init = new double[row_offsets.Length - 1];
            r_init = Utilities.MatrixVectorCSR(values, col_indices, row_offsets, y_init); 
            r_init = Utilities.SubtractVectors(b, r_init);

            double[] d_init = new double[row_offsets.Length - 1];
            d_init = r_init;
            double[] d = new double[row_offsets.Length - 1];

            for (int iter = 1; iter <= maxIter; iter++)
            {
                double[] z = new double[row_offsets.Length - 1];
                z = Utilities.MatrixVectorCSR(values, col_indices, row_offsets, d_init); 

                double paranomastis = Utilities.InnerProduct(d_init, z);
                double arithmitis = Utilities.InnerProduct(r_init, r_init); 

                a = arithmitis / paranomastis;

                y = Utilities.AddVectors(y_init, Utilities.ScalarMultVector(a, d_init));

                r = Utilities.SubtractVectors(r_init, Utilities.ScalarMultVector(a, z));

                norm = Utilities.EuclideanNorm(r);

                double beta;
                double new_arithmitis = Utilities.InnerProduct(r, r);
                beta = new_arithmitis / arithmitis;

                d = Utilities.AddVectors(r, Utilities.ScalarMultVector(beta, d_init));


                if (norm <= accuracy | iter == maxIter)
                {
                    xfinal = y;
                    normfinal = norm;
                    break;

                }

                y_init = y;
                r_init = r;
                d_init = d;

                Console.WriteLine(iter);
            }

            return (xfinal, normfinal);    



        }


        public static void TestCGwithCSR()
        {
            double[] values = new double[9] { 15, 4, 24, 6, 1, 44, 4, 4, 19 };
            double[] col_indices = new double[9] { 0, 1, 1, 2, 1, 2, 3, 2, 3 };
            double[] row_offsets = new double[5] { 0, 2, 4, 7, 9 };
            double[] b = new double[4] { 1, 2, 3, 4 };
            double Ea = 1e-4;
            int maxiter = 1000000;
            double[] u_init = new double[4] { 0, 0, 0, 0 };

            double[] xfinal = new double[4];
            double normfinal;

            (xfinal, normfinal) = ConjugateGradientwithCSR(values, col_indices, row_offsets, b, Ea, maxiter, u_init);

            for (int i = 0; i < xfinal.Length; i++)
            {
                xfinal[i] = Math.Round(xfinal[i], 4);
            }
            double[] xExpected = { 0.0097, 0.0532, 0.0500, 0.1972 };
            //Utilities.CheckEqualArrays(xfinal, xExpected);
        }

        public static (double[] xfinal, double normfinal) SteepestDescentwithCSR(double[] values, double[] col_indices, double[] row_offsets, double[] b, double accurary, int maxIter, double[] y_init)
        {
            double[] y = new double[row_offsets.Length - 1];
            double[] xfinal = new double[row_offsets.Length - 1];
            double norm = 0;
            double normfinal = 0;
            double[] r = new double[row_offsets.Length - 1];
            double a;

            double[] r_init = new double[row_offsets.Length - 1];
            r_init = Utilities.MatrixVectorCSR(values, col_indices, row_offsets, y_init); 
            r_init = Utilities.SubtractVectors(b, r_init);

            for (int iter = 1; iter <= maxIter; iter++)
            {
                double[] z = new double[row_offsets.Length - 1];
                z = Utilities.MatrixVectorCSR(values, col_indices, row_offsets, r_init); 

                double paranomastis = Utilities.InnerProduct(r_init, z);
                double arithmitis = Utilities.InnerProduct(r_init, r_init); 

                a = arithmitis / paranomastis;

                y = Utilities.AddVectors(y_init, Utilities.ScalarMultVector(a, r_init));

                r = Utilities.SubtractVectors(r_init, Utilities.ScalarMultVector(a, z));

                norm = Utilities.EuclideanNorm(r);

                y_init = y;
                r_init = r;

                if (norm <= accurary | iter == maxIter)
                {
                    xfinal = y;
                    normfinal = norm;
                    break;

                }

                Console.WriteLine(iter);
            }

            return (xfinal, normfinal);



        }


        public static void TestSDwithCSR()
        {
            double[] values = new double[9] { 15, 4, 24, 6, 1, 44, 4, 4, 19 };
            double[] col_indices = new double[9] { 0, 1, 1, 2, 1, 2, 3, 2, 3 };
            double[] row_offsets = new double[5] { 0, 2, 4, 7, 9 };
            double[] b = new double[4] { 1, 2, 3, 4 };
            double accuracy = 1e-4;
            int maxIter = 1000000;
            double[] u_init = new double[4] { 0, 0, 0, 0 };

            double[] xfinal = new double[4];
            double normfinal;

            (xfinal, normfinal) = SteepestDescentwithCSR(values, col_indices, row_offsets, b, accuracy, maxIter, u_init);

            for (int i = 0; i < xfinal.Length; i++)
            {
                xfinal[i] = Math.Round(xfinal[i], 4);
            }
            double[] xExpected = { 0.0097, 0.0532, 0.0500, 0.1972 };
            Utilities.CheckEqualArrays(xfinal, xExpected);


        }


    }
}
