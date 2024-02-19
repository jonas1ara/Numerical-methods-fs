# Gauss-Seidel Method

![GS](https://wikimedia.org/api/rest_v1/media/math/render/svg/3390dc713c4fb50faaad1260833d3f1a2da38a88)

## Introduction
This repository contains an implementation of the Gauss-Seidel Method in the F# programming language. The Gauss-Seidel Method is an iterative technique used to solve a system of linear equations. It is a variant of the Jacobi Method and provides a faster convergence rate by using updated values of variables as soon as they are available.

## Installation
To run the provided code, ensure you have F# installed on your system. You can install F# using various methods depending on your operating system. Visit [F# Software Foundation](https://fsharp.org/use/) for installation instructions.

## Usage
1. Clone or download this repository to your local machine.
2. Navigate to the directory containing the code files.
3. Open a terminal or command prompt in that directory.
4. Execute the following command to compile and run the code:

```bash
dotnet run
```

5. The program will output the solution to the system of linear equations using the Gauss-Seidel Method.

## Code Explanation
```fsharp
open System

// Function to print a matrix
let printMatrix (matrix: float[][]) =
 for row in matrix do
     printfn "%A" row

// Function to print a vector
let printVector (vector: float[]) =
 printfn "%A" vector

// Gauss-Seidel Method implementation
let gaussSeidelMethod (matrix: float[][]) (vector: float[]) (tolerance: float) (maxIterations: int) =
 let numRows = matrix.Length
 let numCols = matrix.[0].Length
 let mutable x = Array.zeroCreate<float>(numCols)
 let mutable error = tolerance + 1.0
 let mutable iter = 0

 while iter < maxIterations && error > tolerance do
     let xOld = Array.copy x
     for i in 0 .. numRows - 1 do
         let mutable sum = vector.[i]
         for j in 0 .. numCols - 1 do
             if i <> j then
                 sum <- sum - matrix.[i].[j] * x.[j]
         x.[i] <- sum / matrix.[i].[i]
     error <- Array.map2 (fun a b -> abs (a - b)) x xOld |> Array.max
     iter <- iter + 1

 if iter = maxIterations then
     printfn "Warning: Maximum number of iterations reached."

 x

// Define the matrix and vector for the system of linear equations
let matrix = [|[|10.0; 2.0; 1.0|]; [|1.0; 5.0; 1.0|]; [|2.0; 3.0; 10.0|]|]
let vector = [|7.0; -8.0; 6.0|]
let tolerance = 1e-6
let maxIterations = 1000

// Solve the system of linear equations using the Gauss-Seidel Method
let solution = gaussSeidelMethod matrix vector tolerance maxIterations
printfn "Solution:"
printVector solution
```

## Example

In this example, the code solves the following system of linear equations using the Gauss-Seidel Method:

$10x_1 + 2x_2 + x_3 = 7$ \
$x_1 + 5x_2 + x_3 = -8$ \
$2x_1 + 3x_2 + 10x_3 = 6$

The output provides the solution to the system of equations.

## References

Jeffrey Chasnov. (2021b, febrero 10). Jacobi, Gauss-Seidel and SOR Methods | Lecture 66 | Numerical Methods for Engineers [Video]. YouTube. https://www.youtube.com/watch?v=QpzOttega9s