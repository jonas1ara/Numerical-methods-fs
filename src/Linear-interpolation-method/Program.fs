open System

// Linear interpolation method
let linearInterpolation (xValues: float[]) (yValues: float[]) (x: float) =
    let rec findSegment i =
        if i = xValues.Length - 1 || xValues.[i + 1] >= x then i
        else findSegment (i + 1)
    
    let segmentIndex = findSegment 0
    let x0, y0 = xValues.[segmentIndex], yValues.[segmentIndex]
    let x1, y1 = xValues.[segmentIndex + 1], yValues.[segmentIndex + 1]
    
    let slope = (y1 - y0) / (x1 - x0)
    let intercept = y0 - slope * x0
    slope * x + intercept

let xValues = [|1.0; 2.0; 3.0; 4.0; 5.0|]
let yValues = [|2.0; 3.0; 5.0; 7.0; 11.0|]
let x = 2.5

let y = linearInterpolation xValues yValues x

printfn "Interpolated value at x = %f is y = %f" x y
