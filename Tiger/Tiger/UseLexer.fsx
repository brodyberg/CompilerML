#I "/Users/brodyberg/code/CompilerML/Tiger/packages/FSPowerPack.Core.Community.3.0.0.0/Lib/Net40"
#I "/Users/brodyberg/code/CompilerML/Tiger/Tiger"
#r "FSharp.PowerPack.dll"

open System.IO
open Microsoft.FSharp.Text.Lexing
#load "TigerAST.fs" 
#load "TigerLexer.fs"

let tokenize (lexbuf:LexBuffer<char>) = 
    while not lexbuf.IsPastEndOfStream do          
        printfn "%A" (TigerLexer.tokenize lexbuf)

File.ReadAllText "/Users/brodyberg/code/CompilerML/Tiger/Tiger/Examples/queens.tig"
|> LexBuffer<_>.FromString
|> tokenize
 
