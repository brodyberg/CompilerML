#I "/Users/brodyberg/code/CompilerML/Tiger/packages/FSPowerPack.Core.Community.3.0.0.0/Lib/Net40"
#I "/Users/brodyberg/code/CompilerML/Tiger/Tiger"
#r "FSharp.PowerPack.dll"

open System.IO
open Microsoft.FSharp.Text.Lexing
#load "TigerAST.fs" 
#load "TigerLexer.fs"
#load "TigerParser.fs" 

//let tokenize str =
//    
//    let lexbuf = LexBuffer<_>.FromString str    
//
//    let _tokenize (lexbuf:LexBuffer<char>) = 
//        while not lexbuf.IsPastEndOfStream do          
//            printfn "%A" (TigerLexer.tokenize lexbuf)
//
//    _tokenize lexbuf

//let tokenize str =
//    let lexbuf = LexBuffer<_>.FromString str    
//
//    seq {
//        while not lexbuf.IsPastEndOfStream do 
//            yield TigerLexer.tokenize lexbuf
//    }    
//
//let parse tokens =
//    tokens
//    |> Seq.map (fun token -> TigerParser.start

let lexbuf = LexBuffer<_>.FromString str    
TigerParser.start TigerLexer.tokenize lexbuf

"let" |> tokenize |> parse 

