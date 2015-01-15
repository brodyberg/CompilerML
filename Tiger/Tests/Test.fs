namespace Tests

open System
open NUnit.Framework

open TigerLexer

[<TestFixture>]
module LexerTests = 

    let tokenize str =
        
        let lexbuf = Lexing.LexBuffer<_>.FromString str    
    
        let _tokenize (lexbuf:Lexing.LexBuffer<char>) = 
            while not lexbuf.IsPastEndOfStream do          
                printfn "%A" (TigerLexer.tokenize lexbuf)
    
        _tokenize lexbuf

    [<Test>]
    let ``Tokenize simple Id``() = 
        Assert.AreEqual("ID foo", "foo" |> tokenize)        
