# Fourier transform

![Fourier](https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/Fourier_unit_pulse.svg/300px-Fourier_unit_pulse.svg.png)

## Introduction
This repository contains an implementation of the Fourier transform method in the F# programming language. The Fourier transform is a mathematical technique used to decompose a function of time (or a signal) into its constituent frequencies. It has applications in various fields, including signal processing, image processing, and quantum mechanics.

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

## Code explanation 

```fsharp
open System
open System.Numerics

// Function to calculate the Discrete Fourier Transform (DFT) of an array of complex numbers
let discreteFourierTransform (input: Complex[]) =
    let n = input.Length
    let pi = 4.0 * atan 1.0
    Array.init n (fun k ->
        let mutable sum = Complex.Zero
        for j in 0 .. n - 1 do
            let angle = -2.0 * pi * float k * float j / float n
            let omega = Complex.FromPolarCoordinates(1.0, angle)
            sum <- sum + input.[j] * omega
        sum)

// Function to print an array of complex numbers
let printComplexArray (arr: Complex[]) =
    for i = 0 to arr.Length - 1 do
        printfn "%A" arr.[i]

let inputData = [| Complex(1.0, 0.0); Complex(2.0, 0.0); Complex(3.0, 0.0); Complex(4.0, 0.0) |]

printfn "Input Data:"
printComplexArray inputData

let result = discreteFourierTransform inputData

printfn "Discrete Fourier Transform (DFT):"
printComplexArray result
```

## Example

In this example, the code calculates the Discrete Fourier Transform (DFT) of a set of input data represented as an array of complex numbers. The output provides the result of the DFT computati


## References

Brian Douglas. (2013a, enero 11). Introduction to the Fourier Transform (Part 1) [Video]. YouTube. https://www.youtube.com/watch?v=1JnayXHhjlg

Brian Douglas. (2013, 19 enero). Introduction to the Fourier Transform (Part 2) [Video]. YouTube. https://www.youtube.com/watch?v=kKu6JDqNma8