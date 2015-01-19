#I "/Users/brodyberg/code/CompilerML/Tiger/Tiger/bin/Debug"

#r "FSharp.PowerPack.dll"
#r "Tiger.dll"

open TigerParser
open TigerLexer
open System.IO

let parse (str:string) = 
    let lexbuf = Lexing.LexBuffer<_>.FromString str
    TigerParser.start TigerLexer.tokenize lexbuf

"let end" |> parse

"let 5 end" |> parse

"let 17 end" |> parse

"let 1.2345 end" |> parse

"let var N := 0 end" |> parse