#load "StraightlineTree.fs"

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
            PrintStatement [IdExpression "b"]))

let p5 =
    PrintStatement [OperatorExpression(
                        IdExpression "a", 
                        Minus,
                        NumberExpression 1);]

let p6 =
    PrintStatement [IdExpression "a";
                    IdExpression "b"]

let p6a =
    PrintStatement [IdExpression "a";
                    IdExpression "b";
                    IdExpression "c"]

let p2 = 
    PrintStatement [IdExpression "a";
                    OperatorExpression(
                        IdExpression "a", 
                        Minus,
                        NumberExpression 1);]

let p4 = 
    CompoundStatement(p5,p6)

let p4a = 
    CompoundStatement(p6a,p6)    

// Write (maxargs: Statement -> int) that tells the maximum 
// number of arguments of any print statement within any sub
// expression of a given statement.
// For example: maxargs(prog) is 2
let maxargs (statement:Statement) = 
    let rec visitStatement (statement:Statement) (acc:int list) =
        match statement with
        | CompoundStatement(left,right) -> 
            (visitStatement left acc) @ 
            (visitStatement right acc) @ 
            acc
        | AssignmentStatement(id,expression) -> 
            (visitExpression expression acc) @ 
            acc
        | PrintStatement(expressionList) -> 
            let printedItems =
                expressionList
                |> List.fold (fun expressionItems (item:Expression) ->
                    expressionItems @ (visitExpression item [])) []
            printedItems @ expressionList.Length :: acc
    and visitExpression (expression:Expression) (acc:int list) = 
        match expression with
        | IdExpression(id) -> acc
        | NumberExpression(number) -> acc
        | OperatorExpression(left,binop,right) -> 
            (visitExpression left acc) @ 
            (visitBinop binop acc) @ 
            (visitExpression right acc) @ 
            acc
        | EseqExpression(statement,expression) ->
            (visitStatement statement acc) @ 
            (visitExpression expression acc) @ 
            acc
    and visitBinop binop (acc:int list) = 
        match binop with
        | Plus -> acc
        | Minus -> acc  
        | Times -> acc
        | Div -> acc
    and visitNumber number (acc:int list) = acc

    List.max (visitStatement statement [])

(maxargs prog) = 2
(maxargs p5) = 1
(maxargs p6) = 2
(maxargs p6a) = 3
(maxargs p2) = 2
(maxargs p4) = 2
(maxargs p4a) = 3


// No side-effects so: 
// Do not use reference variables, arrays or assignment expressions 
// in implementing these programs