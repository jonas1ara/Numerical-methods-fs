# Numerical Integration (Rectangle Rule) README

## Introduction
This repository contains an implementation of Numerical Integration using the Rectangle Rule in the F# programming language. Numerical integration, also known as numerical quadrature, is a technique to approximate the definite integral of a function over a specified interval. The Rectangle Rule is a simple method where the area under the curve is approximated by dividing the interval into subintervals and using rectangles to approximate the area.

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

5. The program will output the approximate value of the integral of the provided function over the specified interval using the Rectangle Rule.

## Code Explanation
```fsharp
open System

// Define a function to compute numerical integration using the Rectangle Rule
let rectangleRule (f: float -> float) (a: float) (b: float) (n: int) =
 let h = (b - a) / float n // Compute the width of each subinterval
 let sum = 
     seq { for i in 0 .. n-1 -> a + float i * h } // Generate a sequence of x values within the interval
     |> Seq.sumBy (fun xi -> f xi) // Compute the sum of function values at each x value
 h * sum // Compute the approximate integral using the Rectangle Rule formula

// Define the function for which we want to compute the integral (e.g., sine function)
let f x = sin x

let a = 0.0 // Define the lower limit of the interval
let b = 1.0 // Define the upper limit of the interval
let n = 100 // Define the number of subintervals
let integral = rectangleRule f a b n // Compute the numerical integral using the Rectangle Rule

// Print the approximate value of the integral
printfn "The numerical integral of sin(x) from %f to %f using the Rectangle Rule is approximately %f" a b integral
```

## Example
In this example, the code computes the numerical integral of the sine function from \( x = 0 \) to \( x = 1 \) using the Rectangle Rule with \( 100 \) subintervals. The output provides an approximation of the integral of sine over the specified interval.

## References
Mrs O’Gram’s Maths. (2020, 21 abril). Integration: Numerical methods - Rectangle Rule [Vídeo]. YouTube. https://www.youtube.com/watch?v=TAbOyEyK0xE