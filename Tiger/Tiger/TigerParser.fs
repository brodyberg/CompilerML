// Implementation file for parser generated by fsyacc
module TigerParser
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open Microsoft.FSharp.Text.Lexing
open Microsoft.FSharp.Text.Parsing.ParseHelpers
# 1 "Tiger.fsp"

open Tiger

# 10 "TigerParser.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | LBRACKET
  | RBRACKET
  | LPAREN
  | RPAREN
  | PERIOD
  | COLON
  | SEMICOLON
  | COMMA
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
  | EQUAL
  | LESS
  | LESSEQUAL
  | GREATER
  | GREATEREQUAL
  | ASSIGN
  | PLUS
  | MINUS
  | DIVIDE
  | MULTIPLY
  | EXPONENT
  | AND
  | OR
  | Comment of (string)
  | StringLiteral of (string)
  | Float of (float)
  | Int of (int)
  | ID of (string)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_LBRACKET
    | TOKEN_RBRACKET
    | TOKEN_LPAREN
    | TOKEN_RPAREN
    | TOKEN_PERIOD
    | TOKEN_COLON
    | TOKEN_SEMICOLON
    | TOKEN_COMMA
    | TOKEN_INT
    | TOKEN_ARRAY
    | TOKEN_TYPE
    | TOKEN_IF
    | TOKEN_THEN
    | TOKEN_ELSE
    | TOKEN_FOR
    | TOKEN_TO
    | TOKEN_DO
    | TOKEN_WHILE
    | TOKEN_FUNCTION
    | TOKEN_LET
    | TOKEN_IN
    | TOKEN_NIL
    | TOKEN_VAR
    | TOKEN_OF
    | TOKEN_END
    | TOKEN_EQUAL
    | TOKEN_LESS
    | TOKEN_LESSEQUAL
    | TOKEN_GREATER
    | TOKEN_GREATEREQUAL
    | TOKEN_ASSIGN
    | TOKEN_PLUS
    | TOKEN_MINUS
    | TOKEN_DIVIDE
    | TOKEN_MULTIPLY
    | TOKEN_EXPONENT
    | TOKEN_AND
    | TOKEN_OR
    | TOKEN_Comment
    | TOKEN_StringLiteral
    | TOKEN_Float
    | TOKEN_Int
    | TOKEN_ID
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startstart
    | NONTERM_start
    | NONTERM_statementList
    | NONTERM_special
    | NONTERM_value

// This function maps tokens to integers indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | LBRACKET  -> 1 
  | RBRACKET  -> 2 
  | LPAREN  -> 3 
  | RPAREN  -> 4 
  | PERIOD  -> 5 
  | COLON  -> 6 
  | SEMICOLON  -> 7 
  | COMMA  -> 8 
  | INT  -> 9 
  | ARRAY  -> 10 
  | TYPE  -> 11 
  | IF  -> 12 
  | THEN  -> 13 
  | ELSE  -> 14 
  | FOR  -> 15 
  | TO  -> 16 
  | DO  -> 17 
  | WHILE  -> 18 
  | FUNCTION  -> 19 
  | LET  -> 20 
  | IN  -> 21 
  | NIL  -> 22 
  | VAR  -> 23 
  | OF  -> 24 
  | END  -> 25 
  | EQUAL  -> 26 
  | LESS  -> 27 
  | LESSEQUAL  -> 28 
  | GREATER  -> 29 
  | GREATEREQUAL  -> 30 
  | ASSIGN  -> 31 
  | PLUS  -> 32 
  | MINUS  -> 33 
  | DIVIDE  -> 34 
  | MULTIPLY  -> 35 
  | EXPONENT  -> 36 
  | AND  -> 37 
  | OR  -> 38 
  | Comment _ -> 39 
  | StringLiteral _ -> 40 
  | Float _ -> 41 
  | Int _ -> 42 
  | ID _ -> 43 

// This function maps integers indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_LBRACKET 
  | 2 -> TOKEN_RBRACKET 
  | 3 -> TOKEN_LPAREN 
  | 4 -> TOKEN_RPAREN 
  | 5 -> TOKEN_PERIOD 
  | 6 -> TOKEN_COLON 
  | 7 -> TOKEN_SEMICOLON 
  | 8 -> TOKEN_COMMA 
  | 9 -> TOKEN_INT 
  | 10 -> TOKEN_ARRAY 
  | 11 -> TOKEN_TYPE 
  | 12 -> TOKEN_IF 
  | 13 -> TOKEN_THEN 
  | 14 -> TOKEN_ELSE 
  | 15 -> TOKEN_FOR 
  | 16 -> TOKEN_TO 
  | 17 -> TOKEN_DO 
  | 18 -> TOKEN_WHILE 
  | 19 -> TOKEN_FUNCTION 
  | 20 -> TOKEN_LET 
  | 21 -> TOKEN_IN 
  | 22 -> TOKEN_NIL 
  | 23 -> TOKEN_VAR 
  | 24 -> TOKEN_OF 
  | 25 -> TOKEN_END 
  | 26 -> TOKEN_EQUAL 
  | 27 -> TOKEN_LESS 
  | 28 -> TOKEN_LESSEQUAL 
  | 29 -> TOKEN_GREATER 
  | 30 -> TOKEN_GREATEREQUAL 
  | 31 -> TOKEN_ASSIGN 
  | 32 -> TOKEN_PLUS 
  | 33 -> TOKEN_MINUS 
  | 34 -> TOKEN_DIVIDE 
  | 35 -> TOKEN_MULTIPLY 
  | 36 -> TOKEN_EXPONENT 
  | 37 -> TOKEN_AND 
  | 38 -> TOKEN_OR 
  | 39 -> TOKEN_Comment 
  | 40 -> TOKEN_StringLiteral 
  | 41 -> TOKEN_Float 
  | 42 -> TOKEN_Int 
  | 43 -> TOKEN_ID 
  | 46 -> TOKEN_end_of_input
  | 44 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startstart 
    | 1 -> NONTERM_start 
    | 2 -> NONTERM_statementList 
    | 3 -> NONTERM_statementList 
    | 4 -> NONTERM_statementList 
    | 5 -> NONTERM_statementList 
    | 6 -> NONTERM_statementList 
    | 7 -> NONTERM_special 
    | 8 -> NONTERM_value 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 46 
let _fsyacc_tagOfErrorTerminal = 44

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | LBRACKET  -> "LBRACKET" 
  | RBRACKET  -> "RBRACKET" 
  | LPAREN  -> "LPAREN" 
  | RPAREN  -> "RPAREN" 
  | PERIOD  -> "PERIOD" 
  | COLON  -> "COLON" 
  | SEMICOLON  -> "SEMICOLON" 
  | COMMA  -> "COMMA" 
  | INT  -> "INT" 
  | ARRAY  -> "ARRAY" 
  | TYPE  -> "TYPE" 
  | IF  -> "IF" 
  | THEN  -> "THEN" 
  | ELSE  -> "ELSE" 
  | FOR  -> "FOR" 
  | TO  -> "TO" 
  | DO  -> "DO" 
  | WHILE  -> "WHILE" 
  | FUNCTION  -> "FUNCTION" 
  | LET  -> "LET" 
  | IN  -> "IN" 
  | NIL  -> "NIL" 
  | VAR  -> "VAR" 
  | OF  -> "OF" 
  | END  -> "END" 
  | EQUAL  -> "EQUAL" 
  | LESS  -> "LESS" 
  | LESSEQUAL  -> "LESSEQUAL" 
  | GREATER  -> "GREATER" 
  | GREATEREQUAL  -> "GREATEREQUAL" 
  | ASSIGN  -> "ASSIGN" 
  | PLUS  -> "PLUS" 
  | MINUS  -> "MINUS" 
  | DIVIDE  -> "DIVIDE" 
  | MULTIPLY  -> "MULTIPLY" 
  | EXPONENT  -> "EXPONENT" 
  | AND  -> "AND" 
  | OR  -> "OR" 
  | Comment _ -> "Comment" 
  | StringLiteral _ -> "StringLiteral" 
  | Float _ -> "Float" 
  | Int _ -> "Int" 
  | ID _ -> "ID" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | LBRACKET  -> (null : System.Object) 
  | RBRACKET  -> (null : System.Object) 
  | LPAREN  -> (null : System.Object) 
  | RPAREN  -> (null : System.Object) 
  | PERIOD  -> (null : System.Object) 
  | COLON  -> (null : System.Object) 
  | SEMICOLON  -> (null : System.Object) 
  | COMMA  -> (null : System.Object) 
  | INT  -> (null : System.Object) 
  | ARRAY  -> (null : System.Object) 
  | TYPE  -> (null : System.Object) 
  | IF  -> (null : System.Object) 
  | THEN  -> (null : System.Object) 
  | ELSE  -> (null : System.Object) 
  | FOR  -> (null : System.Object) 
  | TO  -> (null : System.Object) 
  | DO  -> (null : System.Object) 
  | WHILE  -> (null : System.Object) 
  | FUNCTION  -> (null : System.Object) 
  | LET  -> (null : System.Object) 
  | IN  -> (null : System.Object) 
  | NIL  -> (null : System.Object) 
  | VAR  -> (null : System.Object) 
  | OF  -> (null : System.Object) 
  | END  -> (null : System.Object) 
  | EQUAL  -> (null : System.Object) 
  | LESS  -> (null : System.Object) 
  | LESSEQUAL  -> (null : System.Object) 
  | GREATER  -> (null : System.Object) 
  | GREATEREQUAL  -> (null : System.Object) 
  | ASSIGN  -> (null : System.Object) 
  | PLUS  -> (null : System.Object) 
  | MINUS  -> (null : System.Object) 
  | DIVIDE  -> (null : System.Object) 
  | MULTIPLY  -> (null : System.Object) 
  | EXPONENT  -> (null : System.Object) 
  | AND  -> (null : System.Object) 
  | OR  -> (null : System.Object) 
  | Comment _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | StringLiteral _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | Float _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | Int _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | ID _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 1us; 65535us; 2us; 3us; 1us; 65535us; 2us; 6us; 2us; 65535us; 2us; 8us; 11us; 12us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; 5us; 7us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; 3us; 1us; 4us; 1us; 5us; 1us; 6us; 1us; 6us; 1us; 6us; 1us; 6us; 1us; 7us; 1us; 8us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 6us; 8us; 10us; 12us; 14us; 16us; 18us; 20us; 22us; 24us; 26us; 28us; |]
let _fsyacc_action_rows = 15
let _fsyacc_actionTableElements = [|1us; 32768us; 20us; 2us; 0us; 49152us; 4us; 16386us; 9us; 14us; 23us; 9us; 41us; 13us; 42us; 7us; 1us; 32768us; 25us; 4us; 1us; 32768us; 0us; 5us; 0us; 16385us; 0us; 16387us; 0us; 16388us; 0us; 16389us; 1us; 32768us; 43us; 10us; 1us; 32768us; 31us; 11us; 1us; 32768us; 9us; 14us; 0us; 16390us; 0us; 16391us; 0us; 16392us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 2us; 3us; 8us; 10us; 12us; 13us; 14us; 15us; 16us; 18us; 20us; 22us; 23us; 24us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 4us; 0us; 1us; 1us; 1us; 4us; 1us; 1us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 2us; 2us; 2us; 2us; 2us; 3us; 4us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 65535us; 65535us; 65535us; 16385us; 16387us; 16388us; 16389us; 65535us; 65535us; 65535us; 16390us; 16391us; 16392us; |]
let _fsyacc_reductions ()  =    [| 
# 335 "TigerParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Tiger.Program)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (Microsoft.FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startstart));
# 344 "TigerParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'statementList)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 22 "Tiger.fsp"
                                                     
                                                      printfn "BRODY HERE"
                                                      printfn "BRODY HERE"
                                                      Tiger.Let(_2) 
                   )
# 22 "Tiger.fsp"
                 : Tiger.Program));
# 358 "TigerParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 29 "Tiger.fsp"
                                                 [] 
                   )
# 29 "Tiger.fsp"
                 : 'statementList));
# 368 "TigerParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'special)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 30 "Tiger.fsp"
                                           
                                                 printfn "SPECIAL: %A" _1
                     //                            [ Tiger.Special("foo") ] 
                                                 [ Tiger.Special(_1) ] 
                                             
                   )
# 30 "Tiger.fsp"
                 : 'statementList));
# 383 "TigerParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 35 "Tiger.fsp"
                                               
                                                 printfn "BRODY HERE"
                                                 [ Tiger.Number(4) ] 
                   )
# 35 "Tiger.fsp"
                 : 'statementList));
# 396 "TigerParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'value)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 38 "Tiger.fsp"
                                                 
                                                 printfn "BRODY HERE"
                                                 [ Tiger.Number(4) ] 
                   )
# 38 "Tiger.fsp"
                 : 'statementList));
# 409 "TigerParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : 'value)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 41 "Tiger.fsp"
                                                 [ Tiger.Var(_2, _4) ] 
                   )
# 41 "Tiger.fsp"
                 : 'statementList));
# 421 "TigerParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : float)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 43 "Tiger.fsp"
                                  
                                     printfn "special inner: %A" _1
                                     
                                     Tiger.Float(_1)
                                     // _1
                                     // or: ast.Float(_1)?
                                     // System.Double.Parse(_1)
                                     // 4.55
                                  
                   )
# 43 "Tiger.fsp"
                 : 'special));
# 440 "TigerParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 53 "Tiger.fsp"
                                                   5 
                   )
# 53 "Tiger.fsp"
                 : 'value));
|]
# 451 "TigerParser.fs"
let tables () : Microsoft.FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:Microsoft.FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 47;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = (tables ()).Interpret(lexer, lexbuf, startState)
let start lexer lexbuf : Tiger.Program =
    Microsoft.FSharp.Core.Operators.unbox ((tables ()).Interpret(lexer, lexbuf, 0))
