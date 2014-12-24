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

let p3 = IdExpression "a"

let p4 =
    OperatorExpression(
        IdExpression "a", 
        Minus,
        NumberExpression 1)

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

let rec visitStatement (statement:Statement) (acc:string list) =
    match statement with
    | CompoundStatement(left,right) -> 
        "CompoundStatement(\n" :: 
        (visitStatement left acc) @ 
        (visitStatement right acc) @ 
        ")" :: acc
    | AssignmentStatement(id,expression) -> 
        "AssignmentStatement(" ::
        id :: 
        (visitExpression expression acc) @ 
        ")" :: acc
    | PrintStatement(expressionList) -> 
        let start =     
            "PrintStatement(\n" :: 
            (expressionList
            |> List.fold (fun acc2 expression -> 
                printfn "expression: %A" expression
                acc2 @ (visitExpression expression acc2))
                [])
        start @ ")" :: acc        
and visitExpression (expression:Expression) (acc:string list) = 
    match expression with
    | IdExpression(id) -> 
        printfn "id: %s" id
        "IdExpression(" :: id :: ")" :: acc
//        (visitId id acc) @ 
//        ")" :: acc
    | NumberExpression(number) -> 
        (visitNumber number acc) @ acc
    | OperatorExpression(left,binop,right) -> 
        "OperatorExpression(" :: 
        (visitExpression left acc) @ 
        (visitBinop binop acc) @ 
        (visitExpression right acc) @ 
        ")" :: acc
    | EseqExpression(statement,expression) ->
        "EseqExpression(\n" ::
        (visitStatement statement acc) @ 
        (visitExpression expression acc) @ 
        ")" :: acc
and visitBinop binop (acc:string list) = 
    match binop with
    | Plus -> "Plus" :: acc
    | Minus -> "Minus" :: acc
    | Times -> "Times" :: acc
    | Div -> "Div" :: acc
and visitNumber number (acc:string list) = (number.ToString()) :: acc
//and visitId name (acc:string list) = name :: acc

visitStatement prog []
visitStatement p2 []
|> List.iter (fun item -> printf "%s" item) 

visitExpression p3 []
visitExpression p4 []
visitStatement p5 []
visitStatement p6 []
|> List.iter (fun item -> printf "%s" item) 

visitStatement p6a []
|> List.iter (fun item -> printf "%s" item) 


// Write (maxargs: Statement -> int) that tells the maximum 
// number of arguments of any print statement within any sub
// expression of a given statement.
// For example: maxargs(prog) is 2

// No side-effects so: 
// Do not use reference variables, arrays or assignment expressions 
// in implementing these programs