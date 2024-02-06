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
