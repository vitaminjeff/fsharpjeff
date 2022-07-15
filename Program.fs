// For more information see https://aka.ms/fsharp-console-apps
// printfn "Implicit Hello World from F#"

// Learn more about F# at http://fsharp.org

open System // like using in C#

let sayHello person =
    printfn "Hello %s from my F# program!" person

let isValid person =
    not(String.IsNullOrWhiteSpace person)

let indexBasedForLoop (argv : string[]) =
    for i in 0..argv.Length-1 do
        let person = argv.[0]
        sayHello person

let iteratorBasedForLoop (argv : string[]) =
    for person in argv do
        sayHello person

let arrayIterBasedNonForLoop (argv : string[]) =
    // forward piping operator |> 
    // take the value before me and provide it as the last argument to the function after me
    argv |> Array.iter sayHello

[<EntryPoint>] // attributes use compound brackets [<>], tells .net where to start
let main argv =
    // let person = argv.[0]
    // printfn "Hello World from F#!"

    // let mutable person = "Anonymous Person"
    // if argv.Length > 0 then
    //     person <- argv.[0]

    // minimize the use of mutable values
    // let person = 
    //     if argv.Length > 0 then
    //         argv.[0]
    //     else
    //         "Anonymous Person"

    // indexBasedForLoop argv
    // iteratorBasedForLoop argv
    let validNames = argv |> Array.filter isValid
    validNames |> arrayIterBasedNonForLoop
    printfn "Nice to meet you."
    0

// let declares or "binds" a value or function w/ a name

// motivational transparency