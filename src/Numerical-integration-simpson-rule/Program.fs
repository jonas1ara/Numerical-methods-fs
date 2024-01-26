open System

let simpsonRule (f: float -> float) (a: float) (b: float) (n: int) =
    let h = (b - a) / float n
    let sum_odd = 
        seq { for i in 1 .. n/2 -> a + 2.0 * float i * h }
        |> Seq.sumBy (fun xi -> f xi)
    let sum_even = 
        seq { for i in 1 .. n/2-1 -> a + (2.0 * float i - 1.0) * h }
        |> Seq.sumBy (fun xi -> f xi)
    (h / 3.0) * (f a + 4.0 * sum_odd + 2.0 * sum_even + f b)

let f x = sin x
let a = 0.0
let b = 1.0
let n = 100
let integral = simpsonRule f a b n

printfn "The numerical integral of sin(x) from %f to %f using Simpson's rule is approximately %f" a b integral
