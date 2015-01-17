// Signature file for parser generated by fsyacc
module TigerParser
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
type nonTerminalId = 
    | NONTERM__startstart
    | NONTERM_start
    | NONTERM_statementList
    | NONTERM_special
    | NONTERM_value
/// This function maps integers indexes to symbolic token ids
val tagOfToken: token -> int

/// This function maps integers indexes to symbolic token ids
val tokenTagToTokenId: int -> tokenId

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
val prodIdxToNonTerminal: int -> nonTerminalId

/// This function gets the name of a token as a string
val token_to_string: token -> string
val start : (Microsoft.FSharp.Text.Lexing.LexBuffer<'cty> -> token) -> Microsoft.FSharp.Text.Lexing.LexBuffer<'cty> -> (Tiger.Program) 
