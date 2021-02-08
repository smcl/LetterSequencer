(*
From : https://danielbmarkham.com/fun-with-an-interview-question/

    Most candidates cannot solve this interview problem:

        Input: "aaaabbbcca"
        Output: [("a", 4), ("b", 3), ("c", 2), ("a", 1)]
    
        Write a function that converts the input to the output I ask it in the screening interview and give it 25 minutes How would you solve it?
    
After doing the C# version I realised it's probably a bit harder in F#. Again the following is quick-n-dirty and I put it together while on a call
but I think it's quite representative of what I'd do in an interview - nothing fancy, just using the basics well enough to produce a relatively
legible bit of code.
*)

let accumulate (current:char, count:int, seen:(char * int) list) next = 
    if current = next
    then (current, 1 + count, seen)
    else (next, 1, seen @ [(current, count)])

let occurrences' (str:string) = 
    str.ToCharArray()
    |> Array.toList
    |> List.fold accumulate ('!', 0, []) // lol

let occurrences str =
    let curr, cnt, seen = occurrences' str
    seen @ [curr, cnt]
    |> List.skip 1    

[<EntryPoint>]
let main argv =
    printfn "[(\"a\", 4), (\"b\", 3), (\"c\", 2), (\"a\", 1)]"
    
    occurrences "aaaabbbcca"
    |> printfn "%A" // separator + quotes are different, but w/e

    0 // return an integer exit code
