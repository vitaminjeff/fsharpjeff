namespace StudentScores

module Summary =
   
   open System.IO

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
      // |> Array.sortByDescending (fun student -> student.MeanScore)
      |> Array.sortBy (fun student -> student.Name)
      |> Array.iter Student.printSummary