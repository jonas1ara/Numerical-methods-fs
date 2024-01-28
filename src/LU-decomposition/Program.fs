open System

let printMatrix (matrix: float[][]) =
    for row in matrix do
        printfn "%A" row

// Function to perform LU decomposition
let luDecomposition (matrix: float[][]) =
    let numRows = matrix.Length
    let numCols = matrix.[0].Length
    let lower = Array.zeroCreate<float[]>(numRows)
    let upper = Array.zeroCreate<float[]>(numRows)

    for i in 0 .. numRows - 1 do
        lower.[i] <- Array.zeroCreate<float>(numRows)
        upper.[i] <- Array.zeroCreate<float>(numCols)

    // Fill the upper and diagonal matrix of lower
    for i in 0 .. numRows - 1 do
        // Fill the upper matrix
        for j in i .. numCols - 1 do
            upper.[i].[j] <- matrix.[i].[j]

        // Fill the diagonal of lower
        lower.[i].[i] <- 1.0

    // Perform LU decomposition
    for i in 0 .. numRows - 1 do
        for j in i + 1 .. numRows - 1 do
            let factor = upper.[j].[i] / upper.[i].[i]
            lower.[j].[i] <- factor
            for k in i .. numCols - 1 do
                upper.[j].[k] <- upper.[j].[k] - factor * upper.[i].[k]

    lower, upper

let coefficients = [|[|2.0; 1.0; -1.0|]; [|1.0; 1.0; 1.0|]; [|1.0; -1.0; 2.0|]|]
printfn "Coefficients:"
printMatrix coefficients


let lower, upper = luDecomposition coefficients
printfn "Lower:"
printMatrix lower
printfn "Upper:"
printMatrix upper
