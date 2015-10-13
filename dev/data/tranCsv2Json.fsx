#r "./packages/FSharp.Data.2.2.5/lib/net40/FSharp.Data.dll"
open FSharp.Data
open System.IO
open System.Text

type CsvBooks = CsvProvider<"catalog.books.csv", ";", IgnoreErrors=true>
type JsonBooks = JsonProvider<"catalog.books.example.json">

let data = CsvBooks.Load("catalog.books.csv")

let rows = 
    data.Rows 
    //|> Seq.take 10000 

//printfn "----------------------------------------"
//rows |> Seq.take 10 |> Seq.iter (fun x -> printfn "%s" x.BookTitle)

printfn "----------------------------------------"
let writer = new StreamWriter("./catalog.books.json")
let jsons =
    rows 
    |> Seq.map (fun row ->
            [|("ISBN", JsonValue.String row.ISBN); 
            ("BookTitle", JsonValue.String row.BookTitle);
            ("BookAuthor", JsonValue.String row.BookAuthor);
            ("YearOfPublication", JsonValue.String(row.YearOfPublication.ToString()));
            ("Publisher", JsonValue.String row.Publisher);
            ("ImageUrlSmall", JsonValue.String row.ImageUrlSmall);
            ("ImageUrlMedium", JsonValue.String row.ImageUrlMedium);
            ("ImageUrlLarge", JsonValue.String row.ImageUrlLarge)|] |> JsonValue.Record 
        )
    //|> Seq.iter (fun i -> printfn "%s" (i.ToString(JsonSaveOptions.DisableFormatting))) 
    |> Seq.iter (fun i -> writer.WriteLine(i.ToString(JsonSaveOptions.DisableFormatting))) 
writer.Close()

printfn "----------------------------------------"
printf "Alo!"

printfn "----------------------------------------"
