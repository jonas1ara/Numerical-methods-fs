open System

let rectangleRule (f: float -> float) (a: float) (b: float) (n: int) =
    let h = (b - a) / float n
    let sum = 
        seq { for i in 0 .. n-1 -> a + float i * h }
        |> Seq.sumBy (fun xi -> f xi)
    h * sum

let f x = sin x
let a = 0.0
let b = 1.0
let n = 100
let integral = rectangleRule f a b n

printfn "The numerical integral of sin(x) from %f to %f using the rectangle rule is approximately %f" a b integral