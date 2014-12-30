namespace TigerAST

// I think it all has to build to the same type overall - re: error below
type value = 
    | Int of int
    | Float of float
    | String of string
    | Comma
    | EOF

type Comment = 
    | CommentStart
    | CommentEnd

///Tiger.fsl(37,34): error FS0001: This expression was expected to have type
//    value    
//but here has type
//    Operator    
//type Operator =
//    | Comma