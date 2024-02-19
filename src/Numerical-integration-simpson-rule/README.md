# Numerical integration Simpson rule

![Simpson rule](https://upload.wikimedia.org/wikipedia/commons/5/50/Integration_simpson.png)

## Introduction
This repository contains an implementation of Numerical Integration using Simpson's Rule in the F# programming language. Simpson's Rule is a numerical method used to approximate the definite integral of a function over a specified interval. It provides a more accurate approximation compared to methods like the Rectangle Rule or Trapezoidal Rule by using quadratic approximations of the function.

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

5. The program will output the approximate value of the integral of the provided function over the specified interval using Simpson's Rule.

## Code Explanation
```fsharp
open System

// Define a function to compute numerical integration using Simpson's Rule
let simpsonRule (f: float -> float) (a: float) (b: float) (n: int) =
 let h = (b - a) / float n // Compute the width of each subinterval
 let sum_odd = 
     seq { for i in 1 .. n/2 -> a + 2.0 * float i * h } // Generate a sequence of x values for odd indices
     |> Seq.sumBy (fun xi -> f xi) // Compute the sum of function values at odd indices
 let sum_even = 
     seq { for i in 1 .. n/2-1 -> a + (2.0 * float i - 1.0) * h } // Generate a sequence of x values for even indices
     |> Seq.sumBy (fun xi -> f xi) // Compute the sum of function values at even indices
 (h / 3.0) * (f a + 4.0 * sum_odd + 2.0 * sum_even + f b) // Compute the approximate integral using Simpson's Rule formula

// Define the function for which we want to compute the integral (e.g., sine function)
let f x = sin x

let a = 0.0 // Define the lower limit of the interval
let b = 1.0 // Define the upper limit of the interval
let n = 100 // Define the number of subintervals
let integral = simpsonRule f a b n // Compute the numerical integral using Simpson's Rule

// Print the approximate value of the integral
printfn "The numerical integral of sin(x) from %f to %f using Simpson's Rule is approximately %f" a b integral
```

## Example

In this example, the code computes the numerical integral of the sine function from $x = 0$ to $x = 1$ using Simpson's Rule with $100$ subintervals. The output provides an approximation of the integral of sine over the specified interval.

## References

The Organic Chemistry Tutor. (2018, 13 marzo). Simpson’s Rule & Numerical Integration [Vídeo]. YouTube. https://www.youtube.com/watch?v=7EqRRuh-5Lk
