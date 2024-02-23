# Linear regression method

![lr](https://upload.wikimedia.org/wikipedia/commons/thumb/b/b0/Linear_least_squares_example2.svg/220px-Linear_least_squares_example2.svg.png)

## Introduction
This repository contains an implementation of the linear regression method in the F# programming language. Linear regression is a statistical method used to model the relationship between two variables by fitting a linear equation to observed data.

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

5. The program will output the slope and intercept of the linear regression line.

## Code explanation

```fsharp
open System

// Minimum squares method
let linearRegression (xValues: float[]) (yValues: float[]) =
    // Calculate the number of data points
    let n = float xValues.Length
    // Calculate the sum of x and y values
    let sumX = Array.sum xValues
    let sumY = Array.sum yValues
    // Calculate the sum of products of x and y values
    let sumXY = Array.map2 (*) xValues yValues |> Array.sum
    // Calculate the sum of squared x values
    let sumXSquare = Array.map (fun x -> x * x) xValues |> Array.sum
    // Calculate the mean of x and y values
    let meanX = sumX / n
    let meanY = sumY / n

    // Calculate the slope and intercept of the linear regression line
    let slope = (n * sumXY - sumX * sumY) / (n * sumXSquare - sumX * sumX)
    let intercept = meanY - slope * meanX

    slope, intercept

// Example data points
let xValues = [|1.0; 2.0; 3.0; 4.0; 5.0|]
let yValues = [|2.0; 3.0; 4.0; 5.0; 6.0|]

// Perform linear regression on the example data points
let slope, intercept = linearRegression xValues yValues

// Output the results
printfn "Slope: %f" slope
printfn "Intercept: %f" intercept
```

## Example

In this example, the code performs linear regression on the given data points to estimate the slope and intercept of the linear regression line. The output provides the calculated slope and intercept values.

## References

The Organic Chemistry Tutor. (2020, 14 julio). Linear Regression Using Least Squares Method - Line of Best Fit Equation [Video]. YouTube. https://www.youtube.com/watch?v=P8hT5nDai6A