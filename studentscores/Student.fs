namespace StudentScores

type Student =
   {
      Name : string
      Surname : string
      GivenName: string
      Id : string
      MeanScore : float
      MinScore : float
      MaxScore : float
   }

module Student = 

   let namePart i (s : string) =
      let elements = s.Split(',')
      elements.[i].Trim()

   let fromString (s : string) =
      let elements = s.Split('\t')
      let name = elements.[0]
      // Inefficient, splitting name string twice
      let given = namePart 1 name
      let sur = namePart 0 name
      let id = elements.[1]
      let scores =
         elements
         |> Array.skip 2
         // |> Array.map Float.tryFromString
         // |> Array.choose Float.tryFromString // combined mapping and filtering operation, just takes Some values
         // |> Array.map (fun s -> Float.fromStringOr (50.0, s))
         |> Array.map TestResult.fromString
         |> Array.choose TestResult.tryEffectiveScore
      let meanScore = scores |> Array.average
      let minScore = scores |> Array.min
      let maxScore = scores |> Array.max
      {
         Name = name
         Surname = sur
         GivenName = given
         Id = id
         MeanScore = meanScore
         MinScore = minScore
         MaxScore = maxScore
      }

   let printSummary (student : Student) =
      printfn "%s\t%s\t%s\t%0.1f\t%0.1f\t%0.1f" student.Surname student.GivenName student.Id student.MeanScore student.MinScore student.MaxScore
