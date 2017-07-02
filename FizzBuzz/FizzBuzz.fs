module FizzBuzz

open NUnit.Framework
open FsUnit


let (|DivisibleByThree|_|) x = if x % 3 = 0 then Some DivisibleByThree else None
let (|DivisibleByFive|_|) x = if x % 5 = 0 then Some DivisibleByFive else None

let (|DivisibleByFifteen|_|) x = 
    match x with
    | DivisibleByFive & DivisibleByThree -> Some DivisibleByFifteen 
    | _ -> None

let FizzBuzzer x = 
    match x with
    | DivisibleByFifteen -> "FizzBuzz"
    | DivisibleByThree -> "Fizz"
    | DivisibleByFive -> "Buzz"
    | _ -> string x

let FizzBuzz x = 
    { 1 .. x }
    |> Seq.map FizzBuzzer
    |> Seq.fold (+) ""

[<Test>]
let ``FizzBuzzTest`` () =
    FizzBuzz 1 |> should equal "1"
    FizzBuzz 2 |> should equal "12"
    FizzBuzz 3 |> should equal "12Fizz"
    FizzBuzz 4 |> should equal "12Fizz4"
    FizzBuzz 5 |> should equal "12Fizz4Buzz"
    FizzBuzz 15 |> should equal "12Fizz4BuzzFizz78FizzBuzz11Fizz1314FizzBuzz"

