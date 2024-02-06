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
