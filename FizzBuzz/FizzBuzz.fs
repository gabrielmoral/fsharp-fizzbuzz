module FizzBuzz

open NUnit.Framework
open FsUnit

let (|DivisibleBy3|DivisibleBy5|DivisibleBy15|Other|) x = 
    match (x % 3, x % 5) with
    | 0,0 -> DivisibleBy15
    | 0,_ -> DivisibleBy3
    | _,0 -> DivisibleBy5
    | _,_ -> Other x

let FizzBuzzer x = 
    match x with
    | DivisibleBy15 -> "FizzBuzz"
    | DivisibleBy3 -> "Fizz"
    | DivisibleBy5 -> "Buzz"
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

