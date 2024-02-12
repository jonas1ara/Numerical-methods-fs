# Bisection Method

![Bisection Method](https://upload.wikimedia.org/wikipedia/commons/8/8c/Bisection_method.svg)

## Introduction
This repository contains a simple implementation of the bisection method in F# programming language. The bisection method is a numerical technique used to find the roots of a continuous function within a given interval. It's an iterative algorithm that repeatedly bisects an interval and then selects a subinterval in which a root must lie for further processing.

## Installation
To run the provided code, make sure you have F# installed on your system. You can install F# using various methods depending on your operating system. Visit [F# Software Foundation](https://fsharp.org/use/) for installation instructions.

## Usage
1. Clone or download this repository to your local machine.
2. Navigate to the directory containing the code files.
3. Open a terminal or command prompt in that directory.
4. Execute the following command to compile and run the code:

```bash
dotnet run
```

5. The program will output the approximate root of the provided function within the specified interval.

## Code Explanation
```fsharp
open System

let epsilon = 1e-6 // Set the tolerance level for the approximation

// Define the bisection method function
let rec bisection (f: float -> float) (a: float) (b: float) =
 let fa = f a // Compute f(a)
 let fb = f b // Compute f(b)
 if abs (b - a) < epsilon then // Check if the interval is small enough
     (a + b) / 2.0 // Return the midpoint as the approximate root
 else
     let c = (a + b) / 2.0 // Calculate the midpoint of the interval
     let fc = f c // Compute f(c)
     if fa * fc < 0.0 then // Check if the signs of f(a) and f(c) are opposite
         bisection f a c // Recursively call bisection with the left subinterval
     else
         bisection f c b // Recursively call bisection with the right subinterval

// Define the function for which we want to find the root (x^2 - 2)
let f x = x * x - 2.0

let a = 1.0 // Define the lower bound of the interval
let b = 2.0 // Define the upper bound of the interval

// Call the bisection method with the defined function and interval
let root = bisection f a b

// Print the approximate root of the function
printfn "The root of the function is approximately %f" root

```

## Example

For the provided function $f(x) = x^2 - 2$ and the interval $[1, 2]$, the bisection method will approximate the root to be approximately 1.414213, which is the square root of 2.

## References

Jeffrey Chasnov. (2021, 10 febrero). Bisection Method | Lecture 13 | Numerical Methods for Engineers [Vídeo]. YouTube. https://www.youtube.com/watch?v=mzQFGOvH-mk