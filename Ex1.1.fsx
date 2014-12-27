type key = int
type Tree = 
    | Leaf
    | Tree of Tree * key * Tree 
let empty = Leaf

let rec insert key tree = 
    match tree with
    | Leaf -> Tree(Leaf, key, Leaf)
    | Tree(l, k, r) -> 
        if key < k
        then Tree((insert key l),k,r)
        elif key > k
        then Tree(l,k,(insert key r))
        else Tree(l,key,r)

// a. Implement member function which returns true if item is found
// else false
let rec isMember key tree =
    match tree with
    | Leaf -> false
    | Tree(l, k, r) -> 
        if key < k
        then isMember key l
        elif key > k
        then isMember key r
        else true
    
let t1 = Tree(Leaf, 5, Leaf)
isMember 4 t1
isMember 6 t1
isMember 5 t1

let t2 = Tree(Tree(Leaf, 4, Leaf), 8, Leaf)
isMember 3 t2
isMember 4 t2
isMember 6 t2
isMember 9 t2
isMember 8 t2

// b. Extend the program to include not just membership but the 
// mapping of keys to bindings