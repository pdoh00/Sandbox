module DigitalCircuits

// introduce simple type definitions
type Bits = Zero | One;;
// introduce functions over type by pattern matching
let AND x y =
    match (x,y) with
    (Zero,Zero) -> Zero
    |(Zero, One) -> Zero
    |(One, Zero) -> Zero
    |(One, One) -> One ;;

let XOR x y =
    match (x,y) with
    (Zero,Zero) -> Zero
    |(Zero, One) -> One
    |(One, Zero) -> One
    |(One, One) -> Zero;;

let OR x y = 
    match (x,y) with
    (Zero,Zero) -> Zero
    |(Zero, One) -> One
    |(One, Zero) -> One
    |(One, One) -> One;;

let NOT x =
    match(x) with
    (Zero) -> One
    |(One) -> Zero;;

let NAND x y =
    match (x,y) with
    (Zero, Zero) -> One
    |(Zero, One) -> One
    |(One, Zero) -> One
    |(One, One) -> Zero;;

let NOR x y =
    match (x,y) with
    (Zero,Zero) -> One
    |(Zero, One) -> Zero
    |(One, Zero) -> Zero
    |(One, One) -> Zero;;

let HALFADDER x y = 
    (XOR x y, AND x y);;

let ADDER x y carry =
    let (s1, c1) = HALFADDER x y
    let (s2, c2) = HALFADDER s1 carry
    (s2, OR c1 c2)