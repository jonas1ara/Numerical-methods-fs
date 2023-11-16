let newtonRaphson (f: float -> float) (df: float -> float) (x0: float) (tol: float) (maxIter: int) =
    let rec loop (x: float) (iter: int) =
        let fx = f x
        let dfx = df x
        let x1 = x - fx / dfx
        if abs (x1 - x) < tol then x1
        elif iter < maxIter then loop x1 (iter + 1)
        else failwith "Newton-Raphson method failed to converge"
    loop x0 0


let f x = x ** 3.0 - 2.0 * x - 5.0
let df x = 3.0 * x ** 2.0 - 2.0

let root = newtonRaphson f df 1.0 0.0001 1000
printfn "The root of the function is %f" root

