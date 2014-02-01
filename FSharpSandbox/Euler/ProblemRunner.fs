open System
open System.Diagnostics
open ProjectEuler
open Problems_1_10

let sw = new Stopwatch()
sw.Start()

printf "Answer to Problem 1 is %d\n" (problem1 999) //complete

printf "Answer to Problem 2 is %d\n" (problem2 4000000) //complete

//printf "Answer to Problem 3 is %A\n" problem3

printf "Answer to Problem 4 is %d\n" problem4 //complete

//printf "Answer to Problem 5 is %d\n" problem5

printf "Answer to Problem 6 is %d\n" (problem6 100) //complete

//printf "Answer to Problem 7 is %d\n" problem7

printf "Answer to Problem 8 is %d\n" problem8 //complete

//printf "Answer to Problem 9 is %d\n" problem9

printf "Answer to Problem is 10 %d\n" (problem10 2000000L) //complete

printf "Total time to complete %d seconds\n" sw.Elapsed.Seconds

printf "Press any key to continue..."
System.Console.ReadKey() |> ignore
