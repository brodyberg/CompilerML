namespace Tiger

module AST =
    
    type value = 
        | Int of int
        | Float of float
        | String of string
    
    type Comment = 
        | CommentStart
        | CommentEnd