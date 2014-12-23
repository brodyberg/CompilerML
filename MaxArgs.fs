# load "StraightlineTree.fs"

// Example program: 
// a := 5 + 3 ; b := ( print ( a , a - 1 ) , 10 * a ) ; print ( b )

open ChapterOne
open Straightline

//let x = foo() // yes
//let x = Straightline.foo() // yes
//let x = ChapterOne.Straightline.foo() // yes

let x = Id("foo")
//let x = AssignmentStatement(Id("foo"), Expression(NumberExpression(5)))
let x = AssignmentStatement(Id("foo"), NumberExpression(5))



let x = Plus

// we can see Id & Binop, but not Statement or Expression
let Expression

let prog = 
    CompoundStatement(
        AssignmentStatement(
            Id("a"), 
            OperatorExpression(
                NumberExpression 5,
                Plus,
                NumberExpression 3)),
        CompoundStatement(
            AssignmentStatement(
                Id("b"),
                EseqExpression(
                    PrintStatement [IdExpression(Id("a"));
                                    OperatorExpression(
                                        IdExpression(Id("a")), 
                                        Minus,
                                        NumberExpression 1);],
                    OperatorExpression(
                        NumberExpression 10,
                        Times,
                        IdExpression(Id("a"))))),
            PrintStatement [IdExpression(Id("b")) ]))

