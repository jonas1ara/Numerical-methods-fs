# Numerical differentiation

![Numerical differentiation](https://upload.wikimedia.org/wikipedia/commons/thumb/1/18/Derivative.svg/230px-Derivative.svg.png)

## Introduction
This repository contains an implementation of Numerical Differentiation in F# programming language. Numerical differentiation is a technique used to approximate the derivative of a function at a point using numerical methods, particularly when an analytical expression for the derivative is not available or is difficult to compute.

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

5. The program will output the approximate value of the derivative of the provided function at the specified point.

## Code Explanation
```fsharp
open System

// Define a function to compute the numerical differentiation of a given function at a point x with a step size h
let diff (f: float -> float) (x: float) (h: float) =
 (f (x + h) - f (x - h)) / (2.0 * h)

// Define the function for which we want to compute the derivative (e.g., sine function)
let f x = sin x

let x = 0.0 // Define the point at which to compute the derivative
let h = 0.1 // Define the step size for numerical differentiation

// Compute the numerical derivative of the function at point x with step size h
let df = diff f x h

// Print the approximate value of the derivative
printfn "The first derivative of sin(0) is approximately %f" df

```

## Example

In this example, the code computes the numerical differentiation of the sine function at point $x = 0$ using a step size of $h = 0.1$. The output provides an approximation of the first derivative of sine at $x = 0$.

## References

StudySession. (2023b, julio 1). Introduction to numerical differentiation | Numerical Methods [Vídeo]. YouTube. https://www.youtube.com/watch?v=-3MwUJCDjts