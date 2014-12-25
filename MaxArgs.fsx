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

let rec visitStatement (statement:Statement) (acc:int list) =
    match statement with
    | CompoundStatement(left,right) -> 
//        "CompoundStatement(" :: 
        (visitStatement left acc) @ 
        (visitStatement right acc) @ 
        acc
//        ")" :: acc
    | AssignmentStatement(id,expression) -> 
//        "AssignmentStatement(" ::
//        id :: 
//        " " ::
        (visitExpression expression acc) @ 
        acc
//        ")" :: acc
    | PrintStatement(expressionList) -> 
        let printedItems =
            expressionList
            |> List.fold (fun expressionItems (item:Expression) ->
                expressionItems @ (visitExpression item [])) []
          
        printedItems @ expressionList.Length :: acc
          
//        "PrintStatement(" :: printedItems @ ")" :: acc
and visitExpression (expression:Expression) (acc:int list) = 
    match expression with
    | IdExpression(id) -> acc
//        (sprintf "IdExpression(%s)" id) :: acc
    | NumberExpression(number) -> acc
//        (visitNumber number acc) @ acc
    | OperatorExpression(left,binop,right) -> 
//        "OperatorExpression(" :: 
        (visitExpression left acc) @ 
        (visitBinop binop acc) @ 
        (visitExpression right acc) @ 
        acc
//        ")" :: acc
    | EseqExpression(statement,expression) ->
//        "EseqExpression(" ::
        (visitStatement statement acc) @ 
        (visitExpression expression acc) @ 
        acc
//        ")" :: acc
and visitBinop binop (acc:int list) = 
    match binop with
    | Plus -> acc
//        "Plus" :: acc
    | Minus -> acc  
//"Minus" :: acc
    | Times -> acc
//"Times" :: acc
    | Div -> acc
//"Div" :: acc
and visitNumber number (acc:int list) = acc
//    " " + (number.ToString()) + " " :: acc

let maxargs (statement:Statement) = 
    let printParamCounts = visitStatement statement []

    printParamCounts
    |> Seq.iter (fun item -> printfn "count: %d" item)

    List.max printParamCounts

(maxargs prog) = 2
(maxargs p5) = 1
(maxargs p6) = 2
(maxargs p6a) = 3
(maxargs p2) = 2
(maxargs p4) = 2
(maxargs p4a) = 3




// Write (maxargs: Statement -> int) that tells the maximum 
// number of arguments of any print statement within any sub
// expression of a given statement.
// For example: maxargs(prog) is 2


// No side-effects so: 
// Do not use reference variables, arrays or assignment expressions 
// in implementing these programs