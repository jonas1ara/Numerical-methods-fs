open System

// Minimum square method
let linearRegression (xValues: float[]) (yValues: float[]) =
    let n = float xValues.Length
    let sumX = Array.sum xValues
    let sumY = Array.sum yValues
    let sumXY = Array.map2 (*) xValues yValues |> Array.sum
    let sumXSquare = Array.map (fun x -> x * x) xValues |> Array.sum
    let meanX = sumX / n
    let meanY = sumY / n

    let slope = (n * sumXY - sumX * sumY) / (n * sumXSquare - sumX * sumX)
    let intercept = meanY - slope * meanX

    slope, intercept

let xValues = [|1.0; 2.0; 3.0; 4.0; 5.0|]
let yValues = [|2.0; 3.0; 4.0; 5.0; 6.0|]

let slope, intercept = linearRegression xValues yValues

printfn "Slope: %f" slope
printfn "Intercept: %f" intercept
