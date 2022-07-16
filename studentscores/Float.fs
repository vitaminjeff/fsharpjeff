namespace StudentScores

module Float =

   let tryFromString (s : string) =
      if s = "N/A" then
         Nothing
      else
         Something (float s)

   // curried paraeters
   // let fromStringOr d s : float =

   // tupled parameters
   // let fromStringOr (d, s) : float =
   let fromStringOr d s =
      s
      |> tryFromString
      |> Optional.defaultValue d

   // tuple (*) of two ints
   // let t = (99, 100)

   // tuple (*) of int, float, and string
   // let u = (99, 3.1, "abc")