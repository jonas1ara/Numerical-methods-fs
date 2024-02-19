# Numerical integration trapezoidal rule

![Trapezoidal rule](https://upload.wikimedia.org/wikipedia/commons/e/ea/Integration_rectangle.png)

## Introduction
This repository contains an implementation of Numerical Integration using the Trapezoidal Rule in the F# programming language. The Trapezoidal Rule is a numerical method used to approximate the definite integral of a function over a specified interval. It provides a simple approximation by approximating the area under the curve with trapezoids.

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

5. The program will output the approximate value of the integral of the provided function over the specified interval using the Trapezoidal Rule.

## Code Explanation
```fsharp
open System

// Define a function to compute numerical integration using the Trapezoidal Rule
let trapezoidalRule (f: float -> float) (a: float) (b: float) (n: int) =
 let h = (b - a) / float n // Compute the width of each subinterval
 let sum = 
     seq { for i in 1 .. n-1 -> a + float i * h } // Generate a sequence of x values within the interval (excluding the endpoints)
     |> Seq.sumBy (fun xi -> f xi) // Compute the sum of function values at each x value
 0.5 * h * (f a + 2.0 * sum + f b) // Compute the approximate integral using the Trapezoidal Rule formula

// Define the function for which we want to compute the integral (e.g., sine function)
let f x = sin x

let a = 0.0 // Define the lower limit of the interval
let b = 1.0 // Define the upper limit of the interval
let n = 100 // Define the number of subintervals
let integral = trapezoidalRule f a b n // Compute the numerical integral using the Trapezoidal Rule

// Print the approximate value of the integral
printfn "The numerical integral of sin(x) from %f to %f using the Trapezoidal Rule is approximately %f" a b integral
```

## Example

In this example, the code computes the numerical integral of the sine function from \(x = 0\) to \(x = 1\) using the Trapezoidal Rule with \(100\) subintervals. The output provides an approximation of the integral of sine over the specified interval.

## References

The Organic Chemistry Tutor. (2018b, marzo 13). Trapezoidal rule [Vídeo]. YouTube. https://www.youtube.com/watch?v=Rn9Gr52zhrY
