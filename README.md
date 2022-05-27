# Computational-Techniques-Solvers - UNDER CONSTRUCTION
This project is about the implementation of computational algorithms on large linear systems in order to significantly reduce the computational cost.It is part of a course I took in my master's degree in Computational Mechanics. The programming language used is C#.

For instance, in Finite Element Analysis we have to deal with large matrices who are sparse. In order to avoid saving the full matrix on the computer memory, we choose to store only parts of it and perform the calculations needed on a reduced and more convenient linear system.

CONTENTS:
ExerciseGroup1: Mainly some basic linear algebra operations needed.

ExerciseGroup2: Direct Solution Methods and Iterative Solution Methods
  Direct: LL Factorization (Cholesky), LU Factorization, CSR CSC COO operations, LL Factorization for matrices in Skyline format.
  Iterative: Jacobi, GaussSeidel, ConjugateGradient. 

Utilities: Some more linear algebra operations and printing functions.

Every method is provided with a test function which performs the calculations on a given matrix. In the end, the function checks if the result is the same as the one we get from performing the same operations using a software like Matlab.

Example: Test LL Factorization (a.k.a Cholesky Factorization)
![image](https://user-images.githubusercontent.com/90531367/170649491-3d784d42-a64f-42d3-b144-ca7ccf965f9f.png)
