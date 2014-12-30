#I "/Users/brodyberg/code/CompilerML/Tiger/packages/FSPowerPack.Core.Community.3.0.0.0/Lib/Net40"
#I "/Users/brodyberg/code/CompilerML/Tiger/Tiger"
#r "FSharp.PowerPack.dll"

open System.IO
open Microsoft.FSharp.Text.Lexing

let tigerQueens = File.ReadAllText "/Users/brodyberg/code/CompilerML/Tiger/Tiger/Examples/queens.tig"

let lexbuf = LexBuffer<_>.FromString tigerQueens

#load "TigerLexer.fs"

while not lexbuf.IsPastEndOfStream do  
    printfn "%A" (TigerLexer.tokenize lexbuf)
 
