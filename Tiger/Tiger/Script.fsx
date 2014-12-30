﻿#I "/Users/brodyberg/code/CompilerML/Tiger/packages/FSPowerPack.Core.Community.3.0.0.0/Lib/Net40"
#r "FSharp.PowerPack.dll"

open System.IO
open Microsoft.FSharp.Text.Lexing

let x = "foo" 

// warning FS1125: The instantiation of the generic 
// type 'LexBuffer' is missing and can't be inferred from the arguments or return type of this member. Consider providing a type instantiation when accessing this type, e.g. 'LexBuffer<_>'.
// val lexbuf : LexBuffer<char>

//let buffer = Lexing.LexBuffer<string>()

//    let b = Lexing.LexBuffer.FromString x

let tigerQueens = File.ReadAllLines "/Users/brodyberg/code/CompilerML/Tiger/Tiger/Examples/queens.tig"

let lexbuf = LexBuffer<_>.FromString tigerQueens

// how to open OUR lexer?

#load "/Users/brodyberg/code/CompilerML/Tiger/Tiger/TigerLexer.fs"

while not lexbuf.IsPastEndOfStream do  
    printfn "%A" (SqlLexer.tokenize lexbuf)   
 
//Console.WriteLine("(press any key)")   
//Console.ReadKey(true) |> ignore    