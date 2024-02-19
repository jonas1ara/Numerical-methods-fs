# LU decomposition

![LU](https://wikimedia.org/api/rest_v1/media/math/render/svg/a593e8efae46593df51e1ccf84d7745fd96c3514)

## Introduction
This repository contains an implementation of LU Decomposition in the F# programming language. LU Decomposition, also known as LU factorization, is a method used to factorize a matrix into the product of a lower triangular matrix (L) and an upper triangular matrix (U). It is commonly used in solving systems of linear equations and in numerical analysis.

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

5. The program will output the lower triangular matrix (L) and upper triangular matrix (U) resulting from LU decomposition of the input matrix.

## Code Explanation
```fsharp
open System

// Function to print a matrix
let printMatrix (matrix: float[][]) =
 for row in matrix do
     printfn "%A" row

// Function to perform LU decomposition
let luDecomposition (matrix: float[][]) =
 let numRows = matrix.Length
 let numCols = matrix.[0].Length
 let lower = Array.zeroCreate<float[]>(numRows)
 let upper = Array.zeroCreate<float[]>(numRows)

 for i in 0 .. numRows - 1 do
     lower.[i] <- Array.zeroCreate<float>(numRows)
     upper.[i] <- Array.zeroCreate<float>(numCols)

 // Fill the upper and diagonal matrix of lower
 for i in 0 .. numRows - 1 do
     // Fill the upper matrix
     for j in i .. numCols - 1 do
         upper.[i].[j] <- matrix.[i].[j]

     // Fill the diagonal of lower
     lower.[i].[i] <- 1.0

 // Perform LU decomposition
 for i in 0 .. numRows - 1 do
     for j in i + 1 .. numRows - 1 do
         let factor = upper.[j].[i] / upper.[i].[i]
         lower.[j].[i] <- factor
         for k in i .. numCols - 1 do
             upper.[j].[k] <- upper.[j].[k] - factor * upper.[i].[k]

 lower, upper

// Define the coefficients matrix for LU decomposition
let coefficients = [|[|2.0; 1.0; -1.0|]; [|1.0; 1.0; 1.0|]; [|1.0; -1.0; 2.0|]|]
printfn "Coefficients:"
printMatrix coefficients

// Perform LU decomposition
let lower, upper = luDecomposition coefficients
printfn "Lower:"
printMatrix lower
printfn "Upper:"
printMatrix upper
```

## Example

In this example, the code performs LU Decomposition on the following coefficient matrix:

2.0  1.0  -1.0 \
1.0  1.0  1.0 \
1.0  -1.0  2.0

The output provides the lower triangular matrix (L) and upper triangular matrix (U) resulting from the LU decomposition.

## References

MIT OpenCourseWare. (2018, 25 julio). LU decomposition [Video]. YouTube. https://www.youtube.com/watch?v=-eA2D_rIcNA