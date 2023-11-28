namespace Problem.Tests;

public class ProblemTests
{
    [Fact]
    public void Part1Test1()
    {
        var inputArr = new List<string>
        {
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet"
        };
        var result = Problem.ProblemPart1(inputArr);
        Assert.Equal(142, result);
    }

    [Fact]
    public void Part1Test2()
    {
        var inputArr = new List<string>
        {
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen"
        };
        var result = Problem.ProblemPart2(inputArr);
        Assert.Equal(281, result);
    }
}