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
        "CompoundStatement(" :: 
        (visitStatement left acc) @ 
        (visitStatement right acc) @ 
        ")" :: acc
    | AssignmentStatement(id,expression) -> 
        "AssignmentStatement(" ::
        id :: 
        " " ::
        (visitExpression expression acc) @ 
        ")" :: acc
    | PrintStatement(expressionList) -> 
        let printedItems =
            expressionList
            |> List.fold (fun expressionItems (item:Expression) ->
                expressionItems @ (visitExpression item [])) []
            
        "PrintStatement(" :: printedItems @ ")" :: acc
and visitExpression (expression:Expression) (acc:string list) = 
    match expression with
    | IdExpression(id) -> 
        (sprintf "IdExpression(%s)" id) :: acc
    | NumberExpression(number) -> 
        (visitNumber number acc) @ acc
    | OperatorExpression(left,binop,right) -> 
        "OperatorExpression(" :: 
        (visitExpression left acc) @ 
        (visitBinop binop acc) @ 
        (visitExpression right acc) @ 
        ")" :: acc
    | EseqExpression(statement,expression) ->
        "EseqExpression(" ::
        (visitStatement statement acc) @ 
        (visitExpression expression acc) @ 
        ")" :: acc
and visitBinop binop (acc:string list) = 
    match binop with
    | Plus -> "Plus" :: acc
    | Minus -> "Minus" :: acc
    | Times -> "Times" :: acc
    | Div -> "Div" :: acc
and visitNumber number (acc:string list) = " " + (number.ToString()) + " " :: acc

open System

String.Join("", (visitStatement prog [])) = "CompoundStatement(AssignmentStatement(a OperatorExpression( 5 Plus 3 ))CompoundStatement(AssignmentStatement(b EseqExpression(PrintStatement(IdExpression(a)OperatorExpression(IdExpression(a)Minus 1 ))OperatorExpression( 10 TimesIdExpression(a))))PrintStatement(IdExpression(b))))"
String.Join("", (visitStatement p2 [])) = "PrintStatement(IdExpression(a)OperatorExpression(IdExpression(a)Minus 1 ))"
String.Join("", (visitExpression p3 [])) = "IdExpression(a)"
String.Join("", (visitExpression p4 [])) = "OperatorExpression(IdExpression(a)Minus 1 )"
String.Join("", (visitStatement p5 [])) = "PrintStatement(OperatorExpression(IdExpression(a)Minus 1 ))"
String.Join("", (visitStatement p6 [])) = "PrintStatement(IdExpression(a)IdExpression(b))"
String.Join("", (visitStatement p6a [])) = "PrintStatement(IdExpression(a)IdExpression(b)IdExpression(c))"
