﻿namespace Main;
class Program
{
    static void Main(string[] args)
    {
        var inputArr = File.ReadAllLines("input.txt");
        var inputList = new List<string>(inputArr);
        var resultPart1 = Problem.Problem.ProblemPart1(inputList, 64);
        var resultPart2 = Problem.Problem.ProblemPart2(inputList, 26501365);
        Console.WriteLine(resultPart1);
        Console.WriteLine(resultPart2);
    }
}
