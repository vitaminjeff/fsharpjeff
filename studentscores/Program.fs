// For more information see https://aka.ms/fsharp-console-apps
// printfn "Hello from F#"
open System
open System.IO

type Student =
   {
      Name : string
      Id : string
      MeanScore : float
      MinScore : float
      MaxScore : float
   }

module Student = 

   let fromString (s : string) =
      let elements = s.Split('\t')
      let name = elements.[0]
      let id = elements.[1]
      let scores =
         elements
         |> Array.skip 2
         |> Array.map float
      let meanScore = scores |> Array.average
      let minScore = scores |> Array.min
      let maxScore = scores |> Array.max
      {
         Name = name
         Id = id
         MeanScore = meanScore
         MinScore = minScore
         MaxScore = maxScore
      }

   let printSummary (student : Student) =
      printfn "%s\t%s\t%0.1f\t%0.1f\t%0.1f" student.Name student.Id student.MeanScore student.MinScore student.MaxScore

let getSortKey (student : Student) = student.MeanScore

let summarize filePath =
   let rows = File.ReadAllLines filePath
   let studentCount = (rows |> Array.length) - 1
   printfn "Student count: %i" studentCount
   rows
   |> Array.skip 1
   // |> Array.iter printMeanScore
   // Convert each line to a Student instance
   // Sort by mean score (descending)
   // Print each Student instance
   |> Array.map Student.fromString
   |> Array.sortByDescending getSortKey
   |> Array.iter Student.printSummary

[<EntryPoint>]
let main argv =
   if argv.Length = 1 then
      let filePath = argv.[0]
      if File.Exists filePath then
         printfn "Processing %s" filePath
         summarize filePath
         0
      else
         printfn "File not found: %s" filePath
         2
   else
      printfn "Please specify a file"
      1

