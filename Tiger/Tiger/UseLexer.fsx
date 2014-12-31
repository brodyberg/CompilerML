﻿#I "/Users/brodyberg/code/CompilerML/Tiger/packages/FSPowerPack.Core.Community.3.0.0.0/Lib/Net40"
#I "/Users/brodyberg/code/CompilerML/Tiger/Tiger"
#r "FSharp.PowerPack.dll"

open System.IO
open Microsoft.FSharp.Text.Lexing
#load "TigerAST.fs" 
#load "TigerLexer.fs"

let tokenize str =
    
    let lexbuf = LexBuffer<_>.FromString str    

    let _tokenize (lexbuf:LexBuffer<char>) = 
        while not lexbuf.IsPastEndOfStream do          
            printfn "%A" (TigerLexer.tokenize lexbuf)

    _tokenize lexbuf

let theFile = File.ReadAllText "/Users/brodyberg/code/CompilerML/Tiger/Tiger/Examples/queens.tig"
theFile
theFile |> tokenize

"N-1" |> tokenize
// fail: 
//ID "N-1"
//EOF

// closer, but fail still: 
//ID "N"
//Int -1
//EOF

// booyah!
//ID "N"
//BinaryOperator Minus
//Int 1
//EOF
//val it : unit = ()

"5" |> tokenize
//Int 5
//EOF

"-5" |> tokenize
//BinaryOperator Minus
//Int 5
//EOF
" -5" |> tokenize
//Int -5
//EOF

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

"function /* foo bar baz */" |> tokenize

//lexeme: []
//Keyword FUNCTION
//lexeme: [function]
//Comments start
//Comments (0) end
//EOF
//val it : unit = ()

"function /* foo bar baz */ array" |> tokenize

//lexeme: []
//Keyword FUNCTION
//lexeme: [function]
//Comments start
//Comments (0) end
//Keyword ARRAY
//lexeme: [array]
//EOF
//val it : unit = ()

"/* foo /*bar */baz */ array" |> tokenize

//lexeme: []
//Comments start
//comments (1) start
//Comments (1) end
//Comments (0) end
//Keyword ARRAY
//lexeme: [array]
//EOF
//val it : unit = ()