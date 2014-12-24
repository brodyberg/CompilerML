namespace ChapterOne

#load "StraightlineTree.fs"

module ExampleProgram = 
    
    // Example program: 
    // a := 5 + 3 ; b := ( print ( a , a - 1 ) , 10 * a ) ; print ( b )
    
    open ChapterOne
    open Straightline
    
    let prog = 
        CompoundStatement(
            AssignmentStatement(
                "a", 
                OperatorExpression(
                    NumberExpression 5,
                    Plus,
                    NumberExpression 3)),
            CompoundStatement(
                AssignmentStatement(
                    "b",
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

