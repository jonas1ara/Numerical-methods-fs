# Gaussian elimination method

![GE](https://wikimedia.org/api/rest_v1/media/math/render/svg/8d03fa3a15cf393ba00be5a01e37850c628ca4c3)

## Introduction
This repository contains an implementation of Gaussian Elimination in the F# programming language. Gaussian Elimination is a method used to solve a system of linear equations by transforming the augmented matrix of coefficients and constants into row-echelon form through a series of elementary row operations.

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

5. The program will output the solution to the system of linear equations using Gaussian Elimination.

## Code Explanation
```fsharp
open System

// Function to print a vector
let printVector (vector: float[]) =
 printfn "%A" vector

// Gaussian Elimination implementation
let gaussianElimination (matrix: float[][]) (vector: float[]) =
 let numRows = matrix.Length
 let numCols = matrix.[0].Length
 let augmentedMatrix = Array.zeroCreate<float[]>(numRows)

 // Convert the Matrix to an Augmented Matrix with the Vector
 for i in 0 .. numRows - 1 do
     augmentedMatrix.[i] <- Array.append matrix.[i] [|vector.[i]|]

 // Forward Disposal
 for k in 0 .. numRows - 1 do
     for i in k + 1 .. numRows - 1 do
         let factor = augmentedMatrix.[i].[k] / augmentedMatrix.[k].[k]
         for j in k .. numCols do
             augmentedMatrix.[i].[j] <- augmentedMatrix.[i].[j] - factor * augmentedMatrix.[k].[j]

 // Backward Replacement
 let solution = Array.zeroCreate<float>(numRows)
 for i in (numRows - 1) .. -1 .. 0 do
     let mutable sum = 0.0
     for j in (i + 1) .. numCols - 1 do
         sum <- sum + augmentedMatrix.[i].[j] * solution.[j]
     solution.[i] <- (augmentedMatrix.[i].[numCols - 1] - sum) / augmentedMatrix.[i].[i]

 solution

// Define the coefficients matrix and constants vector for the system of linear equations
let coefficients = [|[|2.0; 1.0; -1.0|]; [|1.0; 1.0; 1.0|]; [|1.0; -1.0; 2.0|]|]
let constants = [|8.0; 12.0; 3.0|]

printfn "Coefficients:" 
for i in 0 .. coefficients.Length - 1 do
 printVector coefficients.[i]

printfn "Constants:"
printVector constants

// Solve the system of linear equations using Gaussian Elimination
let solution = gaussianElimination coefficients constants
printfn "Solution:"
printVector solution
```

## Example

Example
In this example, the code solves the following system of linear equations using Gaussian Elimination:

$2x_1 + x_2 + x_3 = 8$ \
$x_1 + x_2 + x_3 = 12$ \
$x_1 + x_2 + 2x_3 = 3$
 
The output provides the solution to the system of equations.

## References

The Organic Chemistry Tutor. (2018a, febrero 18). Gaussian elimination & Row echelon form [Video]. YouTube. https://www.youtube.com/watch?v=eDb6iugi6Uk

