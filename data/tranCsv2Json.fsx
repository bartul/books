#r "./packages/FSharp.Data.2.2.5/lib/net40/FSharp.Data.dll"
open FSharp.Data

type CsvBooks = CsvProvider<"catalog.books.csv", ";">
let data = CsvBooks.Load("catalog.books.csv")

type JsonBooks = JsonProvider<"catalog.books.example.json">

let rows = 
    data.Rows 
    |> Seq.take 3

rows |> Seq.iter (fun x -> printfn "%s" (x.BookTitle + " " + x.GetType().Name))

let jsons =
    rows 
    |> Seq.map (fun row ->
        JsonValue.Record [|("ISBN", JsonValue.String row.ISBN); ("BookTitle", JsonValue.String row.BookTitle)|]
        )

//jsons |> Seq.iter (fun x -> printfn "%s" JsonValue.String)

printf "Alo!"