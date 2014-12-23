# load "StraightlineTree.fs"
open ChapterOne
open Straightline

// Example program: 
// a := 5 + 3 ; b := ( print ( a , a - 1 ) , 10 * a ) ; print ( b )

//let x = Id("foo")

//let x = CompoundStatement(1)

let x = foo() // no
let x = Straightline.foo() // no
let x = ChapterOne.Straightline.foo() // yes

open ChapterOne

let x = foo() // no
let x = Straightline.foo() // yes
let x = ChapterOne.Straightline.foo() // yes

open ChapterOne
open Straightline

let x = foo() // yes
let x = Straightline.foo() // yes
let x = ChapterOne.Straightline.foo() // yes

let prog = 
    CompoundStatement(
        AssignmentStatement(
            "a", 
            OperatorExpression(
                NumberExpression 5,
                Plus,
                NumberExpression 3)),
        CompoundStatement(
            AssignmentStatement("b",
                EseqExpression(
                    PrintStatement [IdExpression "a";
                                    OperatorExpression(
                                        IdExpression "a", 
                                        Minus,
                                        NumberExpression 1);],
                    OperatorExpression(
                        NumberExpression 10,
                        Times,
                        IdExpression "a"))),
            PrintStatement [IdExpression "b" ]))

