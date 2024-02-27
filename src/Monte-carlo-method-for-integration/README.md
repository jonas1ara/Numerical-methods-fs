# Monte Carlo method for integration

![MC integration](https://miro.medium.com/v2/resize:fit:720/format:webp/1*CmlQbGdECPyfM5vZeEkHUg.png)

## Introduction
This repository contains an implementation of the Monte Carlo Integration method in the F# programming language. The Monte Carlo method is a statistical technique used for estimating numerical results by simulating random sampling.

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

open System

// Function to calculate the integral of a function using the Monte Carlo method
let monteCarloIntegration (f: float -> float) (a: float) (b: float) (n: int) =
    let rand = System.Random()
    let mutable sum = 0.0

    for _ in 1 .. n do
        let x = a + (b - a) * rand.NextDouble()
        sum <- sum + f x

    let average = sum / float n
    let integral = average * (b - a)
    integral


// Calculate the integral of sin(x) in the interval [0, π] using the Monte Carlo method
let f x = sin x
let a = 0.0
let b = Math.PI
let n = 1000000

let integral = monteCarloIntegration f a b n

printfn "The integral of sin(x) in the interval [0, π] using the Monte Carlo method is approximately %f" integral
```

## Example

In this example, the code calculates the integral of the function $\sin(x)$ in the interval $[0, \pi]$ using the Monte Carlo method. The output provides an approximate value for the integral.


## References

Ethan Smith. (2018, 30 junio). Monte Carlo Integration [Video]. YouTube. https://www.youtube.com/watch?v=8276ZswRw7M