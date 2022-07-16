// For more information see https://aka.ms/fsharp-console-apps
// printfn "Hello from F#"

open System

// curried parameters support partial application
let add a b =
   a + b

let c = add 2 3

// partial application of a currying function
// binding value d using curried function add w/out supplying all the arguents
// get another function expecting all the arguments you didn't supply a value for
let d = add 2 

let e = d 4

[<EntryPoint>]
let main argv =
   printfn "e: %i" e
   0