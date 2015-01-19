namespace Tiger

//type Op = 
//    | Set
///    | LBracket
//    | RBracket
//    | Plus
//    | Minus

//type Statement = 
  //  | Number of int

//type Label = 
//    | Id of string
//    | TypeName of string

//type PrimitiveType = 
//    | Int

//type HighLevelType = 
//    | Array
    
// I'm confused, do we need to put syntax level stuff in our AST?
// like var row := intArray [ N ] of 0?

// what we are starting to do below is create the productions
// which should actually happen in fsp
// also: incrementalism

//type Statement = 
//    | ArrayDecl of Label * 
//    | TypeDecl of Label * HighLevelType * PrimitiveType
//    // and then we specify the actual type?
//    | VarInt of Label * PrimitiveType * int
//    | VarType of Label * Label // length, initialValue
//    | Foo of string * string

type Primitive = 
    | Float of float

type Op = 
    | Assign

type Statement = 
    | Statement of string
    | Var of string * int
    | Number of int
//    | Special of string
    | Special of Primitive

type Program = 
    | Let of Statement list
