module FizzBuzz

open NUnit.Framework
open FsUnit

let FizzBuzzer x = 
    match x with
    | x when (x % 3) = 0 && (x % 5) = 0 -> "FizzBuzz"
    | x when (x % 3) = 0 -> "Fizz"
    | x when (x % 5) = 0 -> "Buzz"
    | x -> string x

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

