#I "/Users/brodyberg/code/CompilerML/Tiger/packages/FSPowerPack.Core.Community.3.0.0.0/Lib/Net40"
#I "/Users/brodyberg/code/CompilerML/Tiger/Tiger"
#r "FSharp.PowerPack.dll"

open System.IO
open Microsoft.FSharp.Text.Lexing
#load "TigerAST.fs" 
#load "TigerLexer.fs"

//File.ReadAllText "/Users/brodyberg/code/CompilerML/Tiger/Tiger/Examples/queens.tig"

let tokenize str =
    
    let lexbuf = LexBuffer<_>.FromString str    

    let _tokenize (lexbuf:LexBuffer<char>) = 
        while not lexbuf.IsPastEndOfStream do          
            printfn "lexeme: [%s]" (LexBuffer<_>.LexemeString lexbuf)
            printfn "%A" (TigerLexer.tokenize lexbuf)

    _tokenize lexbuf

"," |> tokenize
 
//lexbuf: Microsoft.FSharp.Text.Lexing.LexBuffer`1[System.Char]
//Comma
//lexbuf: Microsoft.FSharp.Text.Lexing.LexBuffer`1[System.Char]
//EOF
//val it : unit = ()

"+" |> tokenize

//lexeme: []
//BinaryOperator Plus
//lexeme: [+]
//EOF
//val it : unit = ()

"*" |> tokenize

//lexeme: []
//BinaryOperator Multiply
//lexeme: [*]
//EOF
//val it : unit = ()

"/" |> tokenize

//lexeme: []
//BinaryOperator Divide
//lexeme: [/]
//EOF
//val it : unit = ()

"/*" |> tokenize

//lexeme: []
//CommentStart
//lexeme: [/*]
//EOF
//val it : unit = ()

"brody" |> tokenize

//lexeme: []
//ID "brody"
//lexeme: [brody]
//EOF
//val it : unit = ()

"function" |> tokenize

//lexeme: []
//Keyword FUNCTION
//lexeme: [function]
//EOF
//val it : unit = ()

"/* foo bar baz */" |> tokenize

//lexeme: []
//Comments start
//Comments (0) end
//EOF
//val it : unit = ()