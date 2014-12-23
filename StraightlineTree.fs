namespace ChapterOne

// Appel pg. 9
module Straightline = 

    let foo () = 1
    
    type Id = Id of string
    type Binop =
        | Plus
        | Minus
        | Times
        | Div
    type Statement =
        | CompoundStatement of Statement * Statement
        | AssignmentStatement of Id * Expression
        | PrintStatement of Expression list
    and Expression =
        | IdExpression of Id
        | NumberExpression of int
        | OperatorExpression of Expression * Binop * Expression
        | EseqExpression of Statement * Expression
    
