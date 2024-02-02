open System

// Función para imprimir un vector
let printVector (vector: float[]) =
    printfn "%A" vector

// Función para calcular el error relativo entre dos vectores
let relativeError (x: float[]) (y: float[]) =
    let normX = Array.sumBy (fun xi -> xi * xi) x |> sqrt
    let normY = Array.sumBy (fun yi -> yi * yi) y |> sqrt
    Array.zip x y
    |> Array.map (fun (xi, yi) -> abs (xi - yi))
    |> Array.max / (max normX normY + 1e-10)

// Función para resolver un sistema de ecuaciones lineales usando el método de Gauss-Seidel
let gaussSeidelMethod (matrix: float[][]) (vector: float[]) (tolerance: float) (maxIterations: int) =
    let numRows = matrix.Length
    let numCols = matrix.[0].Length
    let x = Array.zeroCreate<float>(numCols)
    let mutable error = tolerance + 1.0
    let mutable iter = 0

    while iter < maxIterations && error > tolerance do
        for i in 0 .. numRows - 1 do
            let mutable sum = 0.0
            for j in 0 .. numCols - 1 do
                if i <> j then
                    sum <- sum + matrix.[i].[j] * x.[j]
            x.[i] <- (vector.[i] - sum) / matrix.[i].[i]
        let xOld = Array.copy x
        error <- relativeError xOld x
        iter <- iter + 1

    if iter = maxIterations then
        printfn "Warning: Maximum number of iterations reached."

    x

// Ejemplo de uso
let coefficients = [|[|10.0; 2.0; 1.0|]; [|1.0; 5.0; 1.0|]; [|2.0; 3.0; 10.0|]|]
let constants = [|7.0; -8.0; 6.0|]
let tolerance = 1e-6
let maxIterations = 1000

let solution = gaussSeidelMethod coefficients constants tolerance maxIterations
printfn "Solution:"
printVector solution
