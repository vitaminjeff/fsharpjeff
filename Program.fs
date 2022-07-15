// For more information see https://aka.ms/fsharp-console-apps
// printfn "Implicit Hello World from F#"

// Learn more about F# at http://fsharp.org

open System // like using in C#

[<EntryPoint>] // attributes use compound brackets [<>], tells .net where to start
let main argv =
    // let person = argv.[0]
    // printfn "Hello World from F#!"

    // let mutable person = "Anonymous Person"
    // if argv.Length > 0 then
    //     person <- argv.[0]

    // minimize the use of mutable values
    let person = 
        if argv.Length > 0 then
            argv.[0]
        else
            "Anonymous Person"

    printfn "Hello %s from F#!" person
    // printfn "Explicit Hello World from F#!" // print formatted w/ newline
    // printfn "The args are: %A" argv // print formatted w/ newline
    0 // return an integer exit code

// let declares or "binds" a value or function w/ a name

// motivational transparency