# Euler method

![Euler](https://upload.wikimedia.org/wikipedia/commons/thumb/1/10/Euler_method.svg/220px-Euler_method.svg.png)

## Introduction
This repository contains an implementation of the Euler method in the F# programming language. The Euler method is a simple numerical technique used for solving ordinary differential equations (ODEs) with an initial value problem. It is a first-order numerical method that approximates the solution by stepping through the solution space with small increments.

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

5. The program will output the solution to the ordinary differential equation (ODE) using the Euler method.

## Code Explanation
```fsharp
open System

// Function for solving an ordinary differential equation (EDO) using the Euler method
let eulerMethod (f: float -> float -> float) (x0: float) (y0: float) (xf: float) (h: float) =
 let mutable x = x0
 let mutable y = y0
 let mutable values = []
 
 while x <= xf do
     values <- (x, y) :: values
     let slope = f x y
     y <- y + h * slope
     x <- x + h

 values |> List.rev

// Example: Solve the ordinary differential equation (EDO) y' = -2y, y(0) = 1, for x in [0, 2] with step size h = 0.1
let f x y = -2.0 * y
let x0 = 0.0
let y0 = 1.0
let xf = 2.0
let h = 0.1

let solution = eulerMethod f x0 y0 xf h
printfn "Solution:"
solution |> List.iter (fun (x, y) -> printfn "x = %f, y = %f" x y)
```

## Example

In this example, the code solves the ordinary differential equation (ODE) $y' = -2y$ with the initial condition $y(0) = 1$, for $x$ in the interval $[0, 2]$ with a step size $h = 0.1$ using the Euler method. The output provides the solution points $(x, y)$ along the solution curve.

## References

The Organic Chemistry Tutor. (2017, 11 febrero). Euler’s Method Differential equations, examples, numerical methods, calculus [Video]. YouTube. https://www.youtube.com/watch?v=ukNbG7muKho