open System

let printMatrix (matrix: float[][]) =
    for row in matrix do
        printfn "%A" row

let printVector (vector: float[]) =
    printfn "%A" vector

let jacobiMethod (matrix: float[][]) (vector: float[]) (tolerance: float) (maxIterations: int) =
    let numRows = matrix.Length
    let numCols = matrix.[0].Length
    let mutable x = Array.zeroCreate<float>(numCols)
    let mutable error = tolerance + 1.0
    let mutable iter = 0

    while iter < maxIterations && error > tolerance do
        let xOld = Array.copy x
        for i in 0 .. numRows - 1 do
            let mutable sum = vector.[i]
            for j in 0 .. numCols - 1 do
                if i <> j then
                    sum <- sum - matrix.[i].[j] * xOld.[j]
            x.[i] <- sum / matrix.[i].[i]
        error <- Array.map2 (fun a b -> abs (a - b)) x xOld |> Array.max
        iter <- iter + 1

    if iter = maxIterations then
        printfn "Warning: Maximum number of iterations reached."

    x

let matrix = [|[|10.0; 2.0; 1.0|]; [|1.0; 5.0; 1.0|]; [|2.0; 3.0; 10.0|]|]
let vector = [|7.0; -8.0; 6.0|]
let tolerance = 1e-6
let maxIterations = 1000

let solution = jacobiMethod matrix vector tolerance maxIterations
printfn "Solution:"
printVector solution
