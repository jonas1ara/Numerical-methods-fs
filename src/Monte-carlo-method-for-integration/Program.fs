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
