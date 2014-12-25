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
    printfn "0"
    match statement with
    | CompoundStatement(left,right) -> 
        printfn "1"
        "CompoundStatement(\n" :: 
        (visitStatement left acc) @ 
        (visitStatement right acc) @ 
        ")" :: acc
    | AssignmentStatement(id,expression) -> 
        printfn "2"
        "AssignmentStatement(" ::
        id :: 
        (visitExpression expression acc) @ 
        ")" :: acc
    | PrintStatement(expressionList) -> 
        printfn "3"
//        let start =     
            // we're accumulating something
            // and we're walking something
            // make sure we're doing the right one at the
            // right time
//        let newThings =     
//            expressionList
//            |> List.map (fun expression ->
//                visitExpression expression acc)

        let foo =
            expressionList
            |> List.fold (fun expressionItems (item:Expression) ->
                expressionItems @ (visitExpression item []) []
//                (visitExpression item []) @ expressionItems) []
            
        foo @ acc

//        "PrintStatement(\n" :: newThings @ ")" :: acc
            
//            
//            (expressionList
//            |> List.fold (fun acc2 expression -> 
//                printfn "expression: %A" expression
//                acc2 @ (visitExpression expression acc2))
////                acc)
//        start @ ")" :: acc        
and visitExpression (expression:Expression) (acc:string list) = 
    printfn "4"
    match expression with
    | IdExpression(id) -> 
        printfn "5"
        printfn "id: %s inList: %A" id acc

        let item = sprintf "IdExpression(%s)" id

//        let returnList = "IdExpression(" :: id :: ")" :: acc

        let returnList = item :: acc

        printfn "returnList: %A\n" returnList

        returnList
//        (visitId id acc) @ 
//        ")" :: acc
    | NumberExpression(number) -> 
        printfn "6"
        (visitNumber number acc) @ acc
    | OperatorExpression(left,binop,right) -> 
        printfn "7"
        "OperatorExpression(" :: 
        (visitExpression left acc) @ 
        (visitBinop binop acc) @ 
        (visitExpression right acc) @ 
        ")" :: acc
    | EseqExpression(statement,expression) ->
        printfn "8"
        "EseqExpression(\n" ::
        (visitStatement statement acc) @ 
        (visitExpression expression acc) @ 
        ")" :: acc
and visitBinop binop (acc:string list) = 
    printfn "9"
    match binop with
    | Plus -> "Plus" :: acc
    | Minus -> "Minus" :: acc
    | Times -> "Times" :: acc
    | Div -> "Div" :: acc
and visitNumber number (acc:string list) = 
    printfn "10"    
    (number.ToString()) :: acc
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

//System.String.Join

// Write (maxargs: Statement -> int) that tells the maximum 
// number of arguments of any print statement within any sub
// expression of a given statement.
// For example: maxargs(prog) is 2

// No side-effects so: 
// Do not use reference variables, arrays or assignment expressions 
// in implementing these programs