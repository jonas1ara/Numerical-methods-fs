# Gradient descent

![GD](https://upload.wikimedia.org/wikipedia/commons/7/79/Gradient_descent.png)

## Introduction
This repository contains an implementation of the Gradient Descent method in the F# programming language. Gradient Descent is an optimization algorithm used to minimize the cost function of a model by iteratively adjusting its parameters. In this implementation, we apply the Gradient Descent method to find the optimal parameters for a linear regression model.

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

// Define the cost function
let costFunction (theta0: float) (theta1: float) (xValues: float[]) (yValues: float[]) =
    let m = float xValues.Length
    let sumOfSquares = Array.map2 (fun x y -> (theta0 + theta1 * x - y) ** 2.0) xValues yValues |> Array.sum
    sumOfSquares / (2.0 * m)

// Calculate the partial derivative of the cost function with respect to theta0
let partialDerivativeTheta0 (theta0: float) (theta1: float) (xValues: float[]) (yValues: float[]) =
    let m = float xValues.Length
    let sum = Array.map2 (fun x y -> theta0 + theta1 * x - y) xValues yValues |> Array.sum
    sum / m

// Calculate the partial derivative of the cost function with respect to theta1
let partialDerivativeTheta1 (theta0: float) (theta1: float) (xValues: float[]) (yValues: float[]) =
    let m = float xValues.Length
    let sum = Array.map2 (fun x y -> (theta0 + theta1 * x - y) * x) xValues yValues |> Array.sum
    sum / m

// Gradient descent algorithm
let gradientDescent (xValues: float[]) (yValues: float[]) (alpha: float) (iterations: int) =
    let mutable theta0 = 0.0
    let mutable theta1 = 0.0

    for i in 1 .. iterations do
        let tempTheta0 = theta0 - alpha * partialDerivativeTheta0 theta0 theta1 xValues yValues
        let tempTheta1 = theta1 - alpha * partialDerivativeTheta1 theta0 theta1 xValues yValues
        theta0 <- tempTheta0
        theta1 <- tempTheta1

    theta0, theta1

let xValues = [|1.0; 2.0; 3.0; 4.0; 5.0|]
let yValues = [|2.0; 3.0; 4.0; 5.0; 6.0|]
let alpha = 0.01
let iterations = 1000

let theta0Optimal, theta1Optimal = gradientDescent xValues yValues alpha iterations

printfn "Optimal theta0: %f" theta0Optimal
printfn "Optimal theta1: %f" theta1Optimal
```


## Example


In this example, the code estimates the optimal parameters \( \theta_0 \) and \( \theta_1 \) for a linear regression model using the Gradient Descent method. The output provides the optimal values of \( \theta_0 \) and \( \theta_1 \) obtained after a specified number of iterations.

## References

IBM Technology. (2022, 15 septiembre). Gradient Descent explained [Vídeo]. YouTube. https://www.youtube.com/watch?v=i62czvwDlsw