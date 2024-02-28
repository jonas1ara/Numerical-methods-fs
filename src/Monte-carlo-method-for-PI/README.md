# Monte Carlo Method for π

![Monte Carlo PI](https://upload.wikimedia.org/wikipedia/commons/thumb/e/e5/Estimacion_de_Pi_por_Montercarlo.gif/296px-Estimacion_de_Pi_por_Montercarlo.gif)


## Introduction
This repository contains an implementation of the Monte Carlo method in the F# programming language to estimate the value of π (pi). The Monte Carlo method is a statistical technique that uses random sampling to obtain numerical results. In this implementation, we use the method to estimate π by generating random points within a square and determining the proportion that fall within a quarter of a unit circle.

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

```fsharp
open System

// Function to estimate the value of π using the Monte Carlo method
let monteCarloPiEstimation (numPoints: int) =
    let rand = System.Random()
    let mutable numPointsInsideCircle = 0

    for _ in 1 .. numPoints do
        let x = rand.NextDouble()
        let y = rand.NextDouble()
        if x * x + y * y <= 1.0 then
            numPointsInsideCircle <- numPointsInsideCircle + 1

    let piEstimation = 4.0 * float numPointsInsideCircle / float numPoints
    piEstimation

// Calculate the value of π using the Monte Carlo method with 1,000,000 points
let numPoints = 1000000
let estimatedPi = monteCarloPiEstimation numPoints

printfn "The estimated value of π using the Monte Carlo method with %d points is approximately %f" numPoints estimatedPi
```

## Example

In this example, the code estimates the value of $\pi$ using the Monte Carlo method with 1,000,000 points. The output provides the estimated value of $\pi$ based on the generated random points.


## References

ritvikmath. (2021, 6 enero). Monte Carlo Methods : Data Science Basics [Video]. YouTube. https://www.youtube.com/watch?v=EaR3C4e600k