# Runge kutta method

![RK](https://upload.wikimedia.org/wikipedia/commons/thumb/b/b1/Comparison_of_the_Runge-Kutta_methods_for_the_differential_equation_%28red_is_the_exact_solution%29.svg/280px-Comparison_of_the_Runge-Kutta_methods_for_the_differential_equation_%28red_is_the_exact_solution%29.svg.png)

## Introduction
This repository contains an implementation of the fourth-order Runge-Kutta method in the F# programming language. The Runge-Kutta method is a numerical technique used to solve ordinary differential equations (ODEs) numerically. It is a popular method known for its accuracy and stability.

## Implementation
The provided code demonstrates the use of the fourth-order Runge-Kutta method to solve an ordinary differential equation (ODE) of the form y' = -2y, with the initial condition y(0) = 1, over the interval [0, 2] with a step size of h = 0.1.

## Usage
1. Clone or download this repository to your local machine.
2. Navigate to the directory containing the code files.
3. Open a terminal or command prompt in that directory.
4. Execute the following command to compile and run the code:

```bash
dotnet run
```

5. The program will output the solution points (x, y) along the solution curve.

## Code Explanation

```fsharp
// Function for solving an ordinary differential equation (ODE) using the fourth-order Runge–Kutta method
let rungeKutta4Method (f: float -> float -> float) (x0: float) (y0: float) (xf: float) (h: float) =
    let mutable x = x0                          // Initialize x with the initial value
    let mutable y = y0                          // Initialize y with the initial value
    let mutable values = []                     // Initialize an empty list to store solution points

    while x <= xf do                            // Loop until x reaches the final value xf
        values <- (x, y) :: values              // Append the current solution point to the list
        let k1 = h * f x y                      // Calculate the first slope component
        let k2 = h * f (x + h / 2.0) (y + k1 / 2.0)   // Calculate the second slope component
        let k3 = h * f (x + h / 2.0) (y + k2 / 2.0)   // Calculate the third slope component
        let k4 = h * f (x + h) (y + k3)         // Calculate the fourth slope component
        y <- y + (k1 + 2.0 * k2 + 2.0 * k3 + k4) / 6.0   // Update y using the weighted average of slopes
        x <- x + h                              // Increment x by the step size

    values |> List.rev                         // Reverse the list of solution points (optional)


// Example: Solve the ordinary differential equation (EDO) y' = -2y, y(0) = 1, for x in [0, 2] with step size h = 0.1

let f x y = -2.0 * y
let x0 = 0.0
let y0 = 1.0
let xf = 2.0
let h = 0.1

let solution = rungeKutta4Method f x0 y0 xf h
printfn "Solution:"
solution |> List.iter (fun (x, y) -> printfn "x = %f, y = %f" x y)
```

## Example
In this example, the code solves the ODE y' = -2y with the initial condition y(0) = 1, for x in the interval [0, 2] with a step size h = 0.1 using the fourth-order Runge-Kutta method. The output provides the solution points (x, y) along the solution curve.

## References

Jeffrey Chasnov. (2021c, febrero 10). Runge Kutta Methods | Lecture 50 | Numerical Methods for Engineers [Video]. YouTube. https://www.youtube.com/watch?v=C4UymmEi3Kw