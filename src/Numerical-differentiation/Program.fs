open System

let diff (f: float -> float) (x: float) (h: float) =
    (f (x + h) - f (x - h)) / (2.0 * h)

let f x = sin x
let x = 0.0
let h = 0.1
let df = diff f x h

printfn "The first derivative of sin(0) is approximately %f" df


