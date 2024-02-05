open System

// Función para resolver una ecuación diferencial ordinaria (EDO) usando el método de Runge-Kutta de cuarto orden
let rungeKutta4Method (f: float -> float -> float) (x0: float) (y0: float) (xf: float) (h: float) =
    let mutable x = x0
    let mutable y = y0
    let mutable values = []

    while x <= xf do
        values <- (x, y) :: values
        let k1 = h * f x y
        let k2 = h * f (x + h / 2.0) (y + k1 / 2.0)
        let k3 = h * f (x + h / 2.0) (y + k2 / 2.0)
        let k4 = h * f (x + h) (y + k3)
        y <- y + (k1 + 2.0 * k2 + 2.0 * k3 + k4) / 6.0
        x <- x + h

    values |> List.rev

// Ejemplo de uso: resolver la ecuación diferencial y' = -2 * y, con y(0) = 1, en el intervalo [0, 2] con paso h = 0.1
let f x y = -2.0 * y
let x0 = 0.0
let y0 = 1.0
let xf = 2.0
let h = 0.1

let solution = rungeKutta4Method f x0 y0 xf h
printfn "Solution:"
solution |> List.iter (fun (x, y) -> printfn "x = %f, y = %f" x y)

