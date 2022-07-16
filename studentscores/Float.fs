namespace StudentScores

module Float =

   let tryFromString (s : string) : float option =
      if s = "N/A" then
         None
      else
         Some (float s)

   // curried paraeters
   // let fromStringOr d s : float =

   // tupled parameters
   // let fromStringOr (d, s) : float =
   let fromStringOr (d, s) : float =
      s
      |> tryFromString
      |> Option.defaultValue d

   // tuple (*) of two ints
   // let t = (99, 100)

   // tuple (*) of int, float, and string
   // let u = (99, 3.1, "abc")