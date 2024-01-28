open System

// Función para imprimir una matriz
let printMatrix (matrix: float[][]) =
    for row in matrix do
        printfn "%A" row

// Función para realizar la descomposición LU
let luDecomposition (matrix: float[][]) =
    let numRows = matrix.Length
    let numCols = matrix.[0].Length
    let lower = Array.zeroCreate<float[]>(numRows)
    let upper = Array.zeroCreate<float[]>(numRows)

    for i in 0 .. numRows - 1 do
        lower.[i] <- Array.zeroCreate<float>(numRows)
        upper.[i] <- Array.zeroCreate<float>(numCols)

    // Llenar la matriz upper y diagonal de lower
    for i in 0 .. numRows - 1 do
        // Llenar la matriz upper
        for j in i .. numCols - 1 do
            upper.[i].[j] <- matrix.[i].[j]

        // Llenar la diagonal de lower
        lower.[i].[i] <- 1.0

    // Realizar la descomposición LU
    for i in 0 .. numRows - 1 do
        for j in i + 1 .. numRows - 1 do
            let factor = upper.[j].[i] / upper.[i].[i]
            lower.[j].[i] <- factor
            for k in i .. numCols - 1 do
                upper.[j].[k] <- upper.[j].[k] - factor * upper.[i].[k]

    lower, upper

// Ejemplo de uso
let coefficients = [|[|2.0; 1.0; -1.0|]; [|1.0; 1.0; 1.0|]; [|1.0; -1.0; 2.0|]|]

let lower, upper = luDecomposition coefficients
printfn "Lower:"
printMatrix lower
printfn "Upper:"
printMatrix upper
