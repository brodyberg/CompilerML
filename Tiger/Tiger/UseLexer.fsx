#I "/Users/brodyberg/code/CompilerML/Tiger/packages/FSPowerPack.Core.Community.3.0.0.0/Lib/Net40"
#I "/Users/brodyberg/code/CompilerML/Tiger/Tiger"
#r "FSharp.PowerPack.dll"

open System.IO
open Microsoft.FSharp.Text.Lexing

let tigerQueens = File.ReadAllText "/Users/brodyberg/code/CompilerML/Tiger/Tiger/Examples/queens.tig"

let lexbuf = LexBuffer<_>.FromString tigerQueens

// THIS file doesn't load TigerAST, but rather the fsl file needs to load it

// #load "TigerAST.fs" // fixup TigerLexer.fs to get Tiger.fsl to pull right TigerAST
#load "TigerAST.fs"
// copy into generated lexer: open Microsoft.FSharp.Text.Lexing   
#load "TigerLexer.fs"

// This signature needs to be in the *.fsl so that it can be built into 
// the TigerLexer.fs - and then so the call actually works at runtime
TigerAST.Int(5)

while not lexbuf.IsPastEndOfStream do  
    printfn "%A" (TigerLexer.tokenize lexbuf)
 
