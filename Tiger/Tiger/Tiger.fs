namespace Tiger

type Statement = 
    | Number of int

type AST = 
    | Let of Statement list