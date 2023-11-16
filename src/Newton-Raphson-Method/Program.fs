let newtonRaphson (f: float -> float) (fPrime: float -> float) (initialGuess: float) (tolerance: float) (maxIterations: int) =
    let rec iterate x n =
        let fx = f x
        if abs fx < tolerance || n = maxIterations then
            x
        else
            let xNext = x - fx / (fPrime x)
            iterate xNext (n + 1)

    iterate initialGuess 0

// Example usage:
let f x = x * x - 2.0  // Function for which we want to find the root (e.g., sqrt(2))
let fPrime x = 2.0 * x // Derivative of the function

let initialGuess = 1.0 // Initial guess for the root
let tolerance = 1e-6   // Tolerance for stopping criterion
let maxIterations = 100 // Maximum number of iterations

let result = newtonRaphson f fPrime initialGuess tolerance maxIterations
printfn "Approximate root: %f" result

