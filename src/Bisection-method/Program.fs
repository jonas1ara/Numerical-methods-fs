open System

let epsilon = 1e-6

let rec bisection (f: float -> float) (a: float) (b: float) =
    let fa = f a
    let fb = f b
    if abs (b - a) < epsilon then
        (a + b) / 2.0
    else
        let c = (a + b) / 2.0
        let fc = f c
        if fa * fc < 0.0 then
            bisection f a c
        else
            bisection f c b

let f x = x * x - 2.0 // Función de ejemplo: x^2 - 2
let a = 1.0
let b = 2.0
let root = bisection f a b

printfn "The root of the function is approximately %f" root
