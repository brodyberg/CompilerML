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

// mutually recursive: 
// interpStm(stm * table) -> table
// interpExp(exp * table) -> int * table
// update(table * id * int) -> table
// lookup(table * id) -> int // searches down the list

let update table id value = (id,value) :: table
let lookup (table:((string*int) list)) (id:string) = 
    snd (List.find (fun (pair:string * int) -> fst pair = id) table)

// Note: case-sensitive
let table = update [] "C" 6
lookup table "C"
let table' = update table "c" 7
lookup table' "c"
lookup table "C"



let interp (statement:Statement) = 0