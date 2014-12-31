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
    | And
    | Or    

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
    | VAR
    | OF
    | END

type Punctuation = 
    | LBracket
    | RBracket
    | LParen
    | RParen
    | Period
    | Colon
    | SemiColon
    | Comma

type token = 
    | Int of int
    | Float of float
    | String of string
    | PunctuationItem of Punctuation
    | EOF
    | BinaryOperator of Operator
    | Comment of string
    | Keyword of Keyword 
    | ID of string
    | StringLiteral of string
