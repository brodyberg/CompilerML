#I @"/Users/brodyberg/code/CompilerML/Tiger/Tiger/bin/Debug"

#r "Tiger.dll"
#r "FSharp.PowerPack.dll"

open TigerLexer
open System.IO

let tokenize str =
    
    let lexbuf = Lexing.LexBuffer<_>.FromString str    

    let _tokenize (lexbuf:Lexing.LexBuffer<char>) = 
        while not lexbuf.IsPastEndOfStream do          
            printfn "%A" (TigerLexer.tokenize lexbuf)

    _tokenize lexbuf

let bar = TigerLexer.tokenize (Lexing.LexBuffer<_>.FromString "foo")

let theFile = File.ReadAllText "/Users/brodyberg/code/CompilerML/Tiger/Tiger/Examples/queens.tig"
theFile
theFile |> tokenize

let fooTig = File.ReadAllText "/Users/brodyberg/code/CompilerML/Tiger/Tiger/Examples/escapeSequence.tig"
fooTig
fooTig |> tokenize
// StringLiteral "\foo"
// StringLiteral "\n"
// EOF
// val it : unit = ()

"foo" |> tokenize
//ID "foo"
//EOF

"#" |> tokenize 
//Unrecognized character [#] at line 1 column 1
//FSI_0004.TigerLexer+UnknownItem: Exception of type 'FSI_0004.TigerLexer+UnknownItem' was thrown.

"\"\n\"" |> tokenize
//StringLiteral "
//"
//EOF

"foo \"bar\" baz" |> tokenize
//ID "foo"
//StringLiteral "bar"
//ID "baz"
//EOF

"foo \"\" baz" |> tokenize
//ID "foo"
//StringLiteral ""
//ID "baz"
//EOF

"-4.4" |> tokenize
" -4.4" |> tokenize

"N-1" |> tokenize
//ID "N"
//Minus
//Int 1
//EOF
//val it : unit = ()

"5" |> tokenize
//Int 5
//EOF

"-5" |> tokenize
//Minus
//Int 5
//EOF
" -5" |> tokenize
//Int -5
//EOF

"," |> tokenize
//Comma
//EOF
//val it : unit = ()

"+" |> tokenize
//Plus
//EOF
//val it : unit = ()

"*" |> tokenize
//Multiply
//EOF
//val it : unit = ()

"/" |> tokenize
//Divide
//EOF
//val it : unit = ()

"/*" |> tokenize
// TigerLexer+EndOfFile: Exception of type 'TigerLexer+EndOfFile' was thrown.

"brody" |> tokenize
//ID "brody"
//EOF
//val it : unit = ()

"function" |> tokenize
//FUNCTION
//EOF
//val it : unit = ()

"/* foo bar baz */" |> tokenize
//Comments start
//EOF
//val it : unit = ()

"function /* foo bar baz */" |> tokenize
//FUNCTION
//Comments start
//EOF
//val it : unit = ()

"function /* foo bar baz */ array" |> tokenize
//FUNCTION
//Comments start
//ARRAY
//EOF
//val it : unit = ()

"/* foo /*bar */baz */ array" |> tokenize
//Comments start
//ARRAY
//EOF
//val it : unit = ()