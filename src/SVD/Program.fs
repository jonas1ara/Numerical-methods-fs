open System

let printMatrix (matrix: float[][]) =
    for row in matrix do
        printfn "%A" row

let printVector (vector: float[]) =
    printfn "%A" vector

// Transpose of a matrix
let transpose (matrix: float[][]) =
    let numRows = matrix.Length
    let numCols = matrix.[0].Length
    let result = Array.zeroCreate<float[]>(numCols)
    for i in 0 .. numCols - 1 do
        result.[i] <- Array.zeroCreate<float>(numRows)
        for j in 0 .. numRows - 1 do
            result.[i].[j] <- matrix.[j].[i]
    result

// Multiplication of two matrices
let multiplyMatrices (matrixA: float[][]) (matrixB: float[][]) =
    let numRowsA = matrixA.Length
    let numColsA = matrixA.[0].Length
    let numColsB = matrixB.[0].Length
    let result = Array.zeroCreate<float[]>(numRowsA)
    for i in 0 .. numRowsA - 1 do
        result.[i] <- Array.zeroCreate<float>(numColsB)
        for j in 0 .. numColsB - 1 do
            let mutable sum = 0.0
            for k in 0 .. numColsA - 1 do
                sum <- sum + matrixA.[i].[k] * matrixB.[k].[j]
            result.[i].[j] <- sum
    result

// Singular Value Decomposition
let svdDecomposition (matrix: float[][]) =
    let m = matrix.Length
    let n = matrix.[0].Length

    // Step 1: Calculate mtm matrix
    let mtm = multiplyMatrices (transpose matrix) matrix

    // Step 2: Calculate mtm vectors and eigenvalues
    // Any eigenvalue algorithm can be used here
    // In this example, we'll use an iterative power algorithm
    let mutable v = Array.init n (fun _ -> 1.0)
    let mutable u = Array.init m (fun _ -> Array.init m (fun _ -> 0.0)) 

    let maxIterations = 1000
    let mutable iter = 0
    let mutable error = 1e-10

    while iter < maxIterations && error > 1e-10 do
        let vNew = multiplyMatrices mtm [|v|] |> Array.concat // Calculate mtm * v
        let sigma = Array.sumBy (fun x -> x * x) vNew |> sqrt // Calculate sigma
        v <- vNew |> Array.map (fun x -> x / sigma) // Normalize v

        let uNew = multiplyMatrices matrix [|v|] |> Array.concat
        u <- uNew

        error <- Array.map2 (fun x y -> abs (x - y)) v vNew |> Array.max
        iter <- iter + 1

    let w = Array2D.zeroCreate<float>(m, n)
    for i in 0 .. min m n - 1 do
        w.[i, i] <- v.[i]

    u, w, transpose [|v|]

let matrix = [|[|1.0; 2.0; 3.0|]; [|4.0; 5.0; 6.0|]|]
let u, w, vt = svdDecomposition matrix

printfn "Matrix U:"
printMatrix u
printfn "Matrix W (Singular Values):"
printMatrix w
printfn "Matrix VT (Transpose of V):"
printMatrix vt
