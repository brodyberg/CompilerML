#I "/Users/brodyberg/code/CompilerML/Tiger/packages/FSPowerPack.Core.Community.3.0.0.0/Lib/Net40"
#I "/Users/brodyberg/code/CompilerML/Tiger/Tiger"
#r "FSharp.PowerPack.dll"

open System.IO
open Microsoft.FSharp.Text.Lexing

// we need to have the lexer return TigerParser.token?
// so what happens to TigerAST?
// yes, I see now that the tokens in the example are defined 
// by the parser
#load "TigerAST.fs" 
#load "TigerLexer.fs"
#load "TigerParser.fs" 

//let toLexBuf (str:string) = LexBuffer<_>.FromString str

let theFile = File.ReadAllText "/Users/brodyberg/code/CompilerML/Tiger/Tiger/Examples/queens.tig"

//let x =     
//    File.ReadAllText "/Users/brodyberg/code/CompilerML/Tiger/Tiger/Examples/queens.tig"
//    |> toLexBuf
//    |> TigerLexer.tokenize

let lexbuf = Lexing.LexBuffer<_>.FromString theFile
let parseOutput = TigerParser.start TigerLexer.tokenize lexbuf   

//TigerParser.start x

//|> TigerParser.start