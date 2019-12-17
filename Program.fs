// Learn more about F# at http://fsharp.org

open System
open Microsoft.Data.Analysis

let AppendToCol (item : Nullable<'T> )(col:PrimitiveDataFrameColumn<'T>) =
    col.Append(item)
    col

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    let dateTimes = 
        PrimitiveDataFrameColumn<DateTime>("DateTimes")
        |> AppendToCol (Nullable<DateTime>(DateTime.Parse("2019/01/01")))
        |> AppendToCol (Nullable<DateTime>(DateTime.Parse("2019/01/02")))
        |> AppendToCol (Nullable<DateTime>(DateTime.Parse("2019/01/02")))
        :> DataFrameColumn 
    let ints = 
        PrimitiveDataFrameColumn<int>("Ints", int64 3)
        :> DataFrameColumn
    let strings = 
        StringDataFrameColumn("Strings", int64 3)
        
        :> DataFrameColumn
    
    let df = 
        [dateTimes; ints; strings]
        |> DataFrame
    
    printfn "%A" df
    
    0 // return an integer exit code
