// For more information see https://aka.ms/fsharp-console-apps
// printfn "Implicit Hello World from F#"

// Learn more about F# at http://fsharp.org

open System // like using in C#

[<EntryPoint>] // attributes use compound brackets [<>], tells .net where to start
let main argv =
    printfn "Explicit Hello World from F#!" // print formatted w/ newline
    0 // return an integer exit code

// let declares or "binds" a value or function w/ a name