#I "/Users/brodyberg/code/CompilerML/Tiger/packages/FSPowerPack.Core.Community.3.0.0.0/Lib/Net40"
#I "/Users/brodyberg/code/CompilerML/Tiger/Tiger"
#r "FSharp.PowerPack.dll"

open System.IO
open Microsoft.FSharp.Text.Lexing
#load "TigerAST.fs" 
#load "TigerLexer.fs"

//File.ReadAllText "/Users/brodyberg/code/CompilerML/Tiger/Tiger/Examples/queens.tig"

let tokenize (lexbuf:LexBuffer<char>) = 
    while not lexbuf.IsPastEndOfStream do          
        printfn "lexeme: [%s]" (LexBuffer<_>.LexemeString lexbuf)
        printfn "%A" (TigerLexer.tokenize lexbuf)

","
|> LexBuffer<_>.FromString
|> tokenize
 
//lexbuf: Microsoft.FSharp.Text.Lexing.LexBuffer`1[System.Char]
//Comma
//lexbuf: Microsoft.FSharp.Text.Lexing.LexBuffer`1[System.Char]
//EOF
//val it : unit = ()

"/"
|> LexBuffer<_>.FromString
|> tokenize

"/*"
|> LexBuffer<_>.FromString
|> tokenize
