open System

let eulerMethod (f: float -> float -> float) (x0: float) (y0: float) (xf: float) (h: float) =
    let mutable x = x0
    let mutable y = y0
    let mutable values = []
    
    while x <= xf do
        values <- (x, y) :: values
        let slope = f x y
        y <- y + h * slope
        x <- x + h

    values |> List.rev

let f x y = -2.0 * y
let x0 = 0.0
let y0 = 1.0
let xf = 2.0
let h = 0.1

let solution = eulerMethod f x0 y0 xf h
printfn "Solution:"
solution |> List.iter (fun (x, y) -> printfn "x = %f, y = %f" x y)
