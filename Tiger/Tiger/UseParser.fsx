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

// Extremely helpful to notice: this works!!! if and only if 
// we first comment out the Int clause of the statementList
// production in Tiger.fsp 
// and notice that when the MathOp is produced, the values
// are direct ints rather than something defined in Tiger.fs
"let 4 + 5 end" |> parse

let lexbuf = Lexing.LexBuffer<_>.FromString "let 4 + 5 end"
//    TigerParser.start TigerLexer.tokenize lexbuf
TigerLexer.tokenize lexbuf

// We can't do this, but how about something like
// 3 + 4?
"let var N := 0 end" |> parse