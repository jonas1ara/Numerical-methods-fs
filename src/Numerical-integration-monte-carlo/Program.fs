open System

let monteCarloIntegration (f: float -> float) (a: float) (b: float) (n: int) =
    let rand = System.Random()
    let mutable sum = 0.0

    for _ in 1 .. n do
        let x = a + (b - a) * rand.NextDouble()
        sum <- sum + f x

    let average = sum / float n
    let integral = average * (b - a)
    integral

let f x = sin x
let a = 0.0
let b = 1.0
let n = 1000000 // Numbers of random points 

let integral = monteCarloIntegration f a b n

printfn "The numerical integral of sin(x) from %f to %f using Monte Carlo method is approximately %f" a b integral
