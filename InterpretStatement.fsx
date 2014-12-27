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

// Can we make this signature more awkward?
let update id (thing:(int * ((string * int) list))) = (id,fst thing) :: snd thing
let lookup (id:string) (table:((string*int) list)) = 
    snd (List.find (fun (pair:string * int) -> fst pair = id) table)

let interpret (statement:Statement) = 
    let rec interpStm (statement:Statement) (table:((string * int) list)) =
        match statement with
        | CompoundStatement(left,right) -> 
            table
            |> interpStm left
            |> interpStm right
        | AssignmentStatement(id,expression) -> 
            update id (interpExp expression table)
        | PrintStatement(expressionList) -> 
            expressionList
            |> List.fold (fun acc expression -> 
                let (val',table') = interpExp expression acc
                printfn "%d" val'
                table') 
                table
    and interpExp (expression:Expression) (table:((string * int) list)) = 
        match expression with
        | IdExpression(id) -> lookup id table, table
        | NumberExpression(number) -> number, table
        | OperatorExpression(left,binop,right) -> 

            let (valL,tableL) = interpExp left table
            let (valR,tableR) = interpExp right tableL

            match binop with
            | Plus -> valL + valR, tableR
            | Minus -> valL - valR, tableR
            | Times -> valL * valR, tableR
            | Div -> valL / valR, tableR
        | EseqExpression(statement,expression) ->
            table
            |> interpStm statement
            |> interpExp expression

    interpStm statement []

interpret prog

//8
//7
//80
//val it : (string * int) list = [("b", 80); ("a", 8)]