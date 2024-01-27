open System

let printVector (vector: float[]) =
    printfn "%A" vector

let gaussianElimination (matrix: float[][]) (vector: float[]) =
    let numRows = matrix.Length
    let numCols = matrix.[0].Length
    let augmentedMatrix = Array.zeroCreate<float[]>(numRows)

    // Convert the Matrix to an Augmented Matrix with the Vector
    for i in 0 .. numRows - 1 do
        augmentedMatrix.[i] <- Array.append matrix.[i] [|vector.[i]|]

    // Forward Disposal
    for k in 0 .. numRows - 1 do
        for i in k + 1 .. numRows - 1 do
            let factor = augmentedMatrix.[i].[k] / augmentedMatrix.[k].[k]
            for j in k .. numCols do
                augmentedMatrix.[i].[j] <- augmentedMatrix.[i].[j] - factor * augmentedMatrix.[k].[j]

    // Backward Replacement
    let solution = Array.zeroCreate<float>(numRows)
    for i in (numRows - 1) .. -1 .. 0 do
        let mutable sum = 0.0
        for j in (i + 1) .. numCols - 1 do
            sum <- sum + augmentedMatrix.[i].[j] * solution.[j]
        solution.[i] <- (augmentedMatrix.[i].[numCols - 1] - sum) / augmentedMatrix.[i].[i]

    solution


// Ejemplo de uso
let coefficients = [|[|2.0; 1.0; -1.0|]; [|1.0; 1.0; 1.0|]; [|1.0; -1.0; 2.0|]|]
let constants = [|8.0; 12.0; 3.0|]

printfn "Coefficients:" 
for i in 0 .. coefficients.Length - 1 do
    printVector coefficients.[i]

printfn "Constants:"
printVector constants

let solution = gaussianElimination coefficients constants
printfn "Solution:"
printVector solution
