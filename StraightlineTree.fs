// Appel pg. 9

namespace Straightline

type Id = Id of string
type Binop =
    | Plus
    | Minus
    | Times
    | Div
type Statement =
    | CompoundStatement of Statement * Statement
    | AssignStatement of Id * Expression
    | PrintStatement of Expression list
and Expression =
    | IdExpression of Id
    | NumberExpression of int
    | OperatorExpression of Expression * Binop * Expression
    | EseqExpression of Statement * Expression

