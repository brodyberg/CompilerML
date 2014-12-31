namespace TigerAST

type Operator = 
    | Equal
    | Less
    | LessEqual
    | Greater
    | GreaterEqual
    | Assign
    | Plus
    | Minus
    | Divide
    | Multiply
    | Exponent    

type Keyword = 
    | INT
    | ARRAY
    | TYPE
    | IF
    | THEN
    | ELSE
    | FOR
    | TO
    | DO
    | WHILE
    | FUNCTION
    | LET
    | IN
    | NIL   

type value = 
    | Int of int
    | Float of float
    | String of string
    | Comma
    | EOF
    | BinaryOperator of Operator
    | Comment of string
//    | CommentStart //  of int * int // line, column
//    | CommentEnd // of int * int // line, column
    | Keyword of Keyword 
    | ID of string
