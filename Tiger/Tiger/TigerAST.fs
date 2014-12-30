namespace TigerAST

type value = 
    | Int of int
    | Float of float
    | String of string
    | Comma
    | EOF
    | CommentStart //  of int * int // line, column
    | CommentEnd // of int * int // line, column