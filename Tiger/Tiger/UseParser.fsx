#I "/Users/brodyberg/code/CompilerML/Tiger/Tiger/bin/Debug"

#r "FSharp.PowerPack.dll"
#r "Tiger.dll"

open TigerParser
open TigerLexer
open System.IO

let lexbuf = Lexing.LexBuffer<_>.FromString "let 2"

let parseOutput = TigerParser.start TigerLexer.tokenize lexbuf   
// val parseOutput : Tiger.AST = Let [Number 1; Number 2; Number 3]