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

// What do we return when a branch has no PrintStatement?
// How do we collect a value when we are branching?
// pass around list of PrintStatement argument counts
// only ever pass back max(PrintStatement argument count list) 

// that's how we do it, the mutual recursion across statement
// and/or expression...
//
//"foo" :: []
//
//"foo" :: "bar" :: []

//[] |> :: "foo"
//
//[] |> "foo" ::
//
//"foo" :: ([])

["foo"] @ []

let rec visitStatement (statement:Statement) (acc:string list) =
    match statement with
    | CompoundStatement(left,right) -> 
//        let x = visitStatement left acc
//        let y = visitStatement right acc
//        x @ y @ "CompoundStatement" :: acc
//
//
        (visitStatement left acc) @ (visitStatement right acc) @ "CompoundStatement" :: acc
    | AssignmentStatement(id,expression) -> 
        (visitId id acc) @ (visitExpression expression acc) @ "AssignmentStatement" :: acc
    | PrintStatement(expressionList) -> 
        "PrintStatement" :: 
        (expressionList
        |> List.fold (fun acc expression -> 
            (visitExpression expression acc) @ acc)
            acc)
and visitExpression (expression:Expression) (acc:string list) = 
    match expression with
    | IdExpression(id) -> 
        (visitId id acc) @ acc
    | NumberExpression(number) -> 
        (visitNumber number acc) @ acc
    | OperatorExpression(left,binop,right) -> 
        (visitExpression left acc) @ (visitBinop binop acc) @ (visitExpression right acc) @ acc
    | EseqExpression(statement,expression) ->
        (visitStatement statement acc) @ (visitExpression expression acc) @ acc
and visitBinop binop (acc:string list) = 
    match binop with
    | Plus -> "Plus" :: acc
    | Minus -> "Minus" :: acc
    | Times -> "Times" :: acc
    | Div -> "Div" :: acc
and visitNumber number (acc:string list) =
    (number.ToString()) :: acc
and visitId name (acc:string list) = name :: acc

//let rec visitEverything (statement:Statement) (acc:string list) =
//    match statement with
//    | CompoundStatement(left,right) -> 
//        visitEverything(left,acc) :: visitEverything(right,acc) :: "CompoundStatement" :: acc
//    | AssignmentStatement(_,expression) -> 
//        visitEverything(expression,acc) :: "AssignmentStatement" :: acc
//    | 
//
//
//
//
//let maxargs (statement:Statement) = 
//    match statement with
//    | PrintStatement(args) -> 
//        args.Length 
//        for s in args -> 
//            maxargs(s)
//    | CompoundStatement(statementLeft, statementRight) -> 
//        maxargs(statementLeft)
//        maxargs(statementRight)
//    | _ -> 


// do a (recursive?) match through the structure
// find a print and then count args there?

// loop through
// find print statement, find length of list of arguments


// Write (maxargs: Statement -> int) that tells the maximum 
// number of arguments of any print statement within any sub
// expression of a given statement.
// For example: maxargs(prog) is 2

// No side-effects so: 
// Do not use reference variables, arrays or assignment expressions 
// in implementing these programs