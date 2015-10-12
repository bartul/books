#r "./packages/FSharp.Data.2.2.5/lib/net40/FSharp.Data.dll"
open FSharp.Data
open System.IO

type CsvBooks = CsvProvider<"catalog.books.csv", ";">
let data = CsvBooks.Load("catalog.books.csv")

type JsonBooks = JsonProvider<"catalog.books.example.json">


let rows = 
    data.Rows 
    |> Seq.take 100

printfn "----------------------------------------"
rows |> Seq.iter (fun x -> printfn "%s" x.BookTitle)

//JsonValue.WriteTo(new StreamWriter(""), );

printfn "----------------------------------------"
let writer = new StreamWriter("./catalog.books.json");
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


printfn "----------------------------------------"
printf "Alo!"

printfn "----------------------------------------"
