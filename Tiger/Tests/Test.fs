namespace Tests

open System
open NUnit.Framework

open TigerLexer
open TigerParser

[<TestFixture>]
module LexerTests = 

    let tokenizeOne (str:string) =
        TigerLexer.tokenize (Lexing.LexBuffer<_>.FromString str)    

    [<Test>]
    let ``Tokenize Id``() = 
        match tokenizeOne "foo" with
        | ID(x) -> Assert.Pass()
        | _ -> Assert.Fail()

    [<Test>]
    let ``Tokenize unknown character throws``() = 
        Assert.Throws<UnknownItem>
            (fun () -> tokenizeOne "#" |> ignore) 
        |> ignore

    [<Test>]
    let ``Tokenize newline``() = 
        match tokenizeOne "\"\n\"" with
        | StringLiteral(x) -> Assert.Pass()
        | other -> Assert.Fail(sprintf "Fail, found: %A" other)

    [<Test>]
    let ``Function keyword tokenizes``() =
        match tokenizeOne "function" with 
        | FUNCTION -> Assert.Pass()
        | other -> Assert.Fail(sprintf "Fail, found: %A" other)