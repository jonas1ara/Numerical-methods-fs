# Linear interpolation method

# Linear interpolation method

![LI](https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/LinearInterpolation.svg/300px-LinearInterpolation.svg.png)

## Introduction
This repository contains an implementation of the linear interpolation method in the F# programming language. Linear interpolation is a simple and commonly used technique for estimating values between two known data points. It assumes a linear relationship between the data points and provides an approximation for intermediate values.

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

5. The program will output the interpolated value at the specified point `x`.

## Code Explanation
```fsharp
open System

// Linear interpolation method
let linearInterpolation (xValues: float[]) (yValues: float[]) (x: float) =
    let rec findSegment i =
        if i = xValues.Length - 1 || xValues.[i + 1] >= x then i
        else findSegment (i + 1)
    
    let segmentIndex = findSegment 0
    let x0, y0 = xValues.[segmentIndex], yValues.[segmentIndex]
    let x1, y1 = xValues.[segmentIndex + 1], yValues.[segmentIndex + 1]
    
    let slope = (y1 - y0) / (x1 - x0)
    let intercept = y0 - slope * x0
    slope * x + intercept

// Example data
let xValues = [|1.0; 2.0; 3.0; 4.0; 5.0|]
let yValues = [|2.0; 3.0; 5.0; 7.0; 11.0|]
let x = 2.5

// Perform linear interpolation
let y = linearInterpolation xValues yValues x

printfn "Interpolated value at x = %f is y = %f" x y
```

## Example

In this example, the code performs linear interpolation on the given data points to estimate the value of \( y \) at \( x = 2.5 \). The output provides the interpolated value at the specified point.

## References

Jeffrey Chasnov. (2021c, febrero 10). Interpolation | Lecture 43 | Numerical Methods for Engineers [Video]. YouTube. https://www.youtube.com/watch?v=RpxoN9-i7Jc