module FizzBuzz

open NUnit.Framework
open FsUnit

let (|DivisibleBy|_|) d x = 
    match x with
    | x when x % d = 0 -> Some DivisibleBy
    | _ -> None

let FizzBuzzer x = 
    match x with
    | DivisibleBy 15 -> "FizzBuzz"
    | DivisibleBy 3 -> "Fizz"
    | DivisibleBy 5 -> "Buzz"
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

