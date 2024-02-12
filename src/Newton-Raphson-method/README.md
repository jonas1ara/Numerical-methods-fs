# Newton-Raphson method

![Newton-Raphson](https://upload.wikimedia.org/wikipedia/commons/thumb/8/8c/Newton_iteration.svg/300px-Newton_iteration.svg.png)

## Introduction
This repository contains an implementation of the Newton-Raphson Method in F# programming language. The Newton-Raphson Method is a root-finding algorithm used to find successively better approximations to the roots (or zeroes) of a real-valued function. It is a powerful numerical technique commonly used for solving nonlinear equations.

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

5. The program will output the approximate root of the provided function.

## Code Explanation
```fsharp
open System

// Definition of the function implementing the Newton-Raphson method
let newtonRaphson (f: float -> float) (df: float -> float) (x0: float) (tol: float) (maxIter: int) =
    // Definition of an inner function to iterate until convergence or reach the maximum number of iterations
    let rec loop (x: float) (iter: int) =
        let fx = f x                // Compute the value of the function at x
        let dfx = df x              // Compute the value of the derivative of the function at x
        let x1 = x - fx / dfx       // Compute the next approximation of the root using the Newton-Raphson formula
        if abs (x1 - x) < tol then  // Check if the difference between successive approximations is less than the tolerance
            x1                      // Return the current approximation as the root if tolerance is satisfied
        elif iter < maxIter then    // If tolerance is not met and the number of iterations is less than the maximum limit
            loop x1 (iter + 1)      // Continue iterating with the new approximation
        else                        // If the maximum iteration limit is reached without convergence
            failwith "Newton-Raphson method failed to converge"  // Raise an exception indicating failure to converge

    // Start the iteration process with the initial guess and iteration count set to 0
    loop x0 0


let f x = x ** 3.0 - 2.0 * x - 5.0
let df x = 3.0 * x ** 2.0 - 2.0

// Call the Newton-Raphson method with the provided function, its derivative, initial guess, tolerance, and maximum iterations
let root = newtonRaphson f df 1.0 0.0001 1000

// Print the approximate root of the function
printfn "The root of the function is %f" root


```

## Example

For the provided function $f(x) = x^3 - 2x - 5$, the Newton-Raphson Method is used to approximate the root. In this example, the initial guess is $x_0 = 1.0$, with a tolerance of $0.0001$ and a maximum iteration limit of $1000$.

## References

MathAndPhysics. (2020, 30 mayo). Newton-Raphson method | Animated and explained | Algorithm for finding roots of a function [Vídeo]. YouTube. https://www.youtube.com/watch?v=qlNqPE_X4ME