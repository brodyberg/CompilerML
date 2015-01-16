#I "/Users/brodyberg/code/CompilerML/Tiger/Tiger/bin/Debug"

#r "FSharp.PowerPack.dll"
#r "Tiger.dll"

open TigerParser
open TigerLexer
open System.IO

let parse (str:string) = 
    let lexbuf = Lexing.LexBuffer<_>.FromString str
    TigerParser.start TigerLexer.tokenize lexbuf

//let lexbuf = Lexing.LexBuffer<_>.FromString "let end"

//TigerLexer.tokenize lexbuf

//TigerParser.start TigerLexer.tokenize lexbuf

//let parseOutput = TigerParser.start TigerLexer.tokenize lexbuf   
// val it : Tiger.Program = Let []

// val parseOutput : Tiger.AST = Let [Number 1; Number 2; Number 3]

"let end" |> parse