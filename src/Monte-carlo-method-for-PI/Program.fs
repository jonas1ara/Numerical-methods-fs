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
