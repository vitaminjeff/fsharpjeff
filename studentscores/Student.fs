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

   let nameParts (s : string) =
      let elements = s.Split(',')
      let surname = elements.[0].Trim()
      let givenName = elements.[1].Trim()
      // (surname, givenName) // tuple brackets optional
      surname, givenName

   let namePartsPatternMatched (s : string) =
      let elements = s.Split(',')
      // make sure to cover all cases or
      // Microsoft.FSharp.Core.MatchFailureException: The match cases were incomplete
      match elements with
      | [|surname; givenName|] ->
         // use anonymous record syntax to
         // avoid the field position dependency of tuples
         {| Surname = surname.Trim()
            GivenName = givenName.Trim() |}
      | [|surname|] ->
         {| Surname = surname.Trim()
            GivenName = "(None)" |}
      | _ -> 
         raise (System.FormatException(sprintf "Invalid name format: \"%s\"" s))


   let fromString (s : string) =
      let elements = s.Split('\t')
      let name = elements.[0]
      let processedName = elements.[0] |> namePartsPatternMatched
      let id = elements.[1]
      let scores =
         elements
         |> Array.skip 2
         // |> Array.map Float.tryFromString
         // |> Array.choose Float.tryFromString // combined mapping and filtering operation, just takes Some values
         // |> Array.map (fun s -> Float.fromStringOr (50.0, s))
         // |> Array.map TestResult.fromString
         // |> Array.choose TestResult.tryEffectiveScore
         |> Array.map (Float.fromStringOr 50.)
      let meanScore = scores |> Array.average
      let minScore = scores |> Array.min
      let maxScore = scores |> Array.max
      {
         Name = name
         Surname = processedName.Surname
         GivenName = processedName.GivenName
         Id = id
         MeanScore = meanScore
         MinScore = minScore
         MaxScore = maxScore
      }

   let printSummary (student : Student) =
      printfn "%s\t%s\t%s\t%0.1f\t%0.1f\t%0.1f" student.Surname student.GivenName student.Id student.MeanScore student.MinScore student.MaxScore
