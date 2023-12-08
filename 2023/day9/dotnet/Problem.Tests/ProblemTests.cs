namespace Problem.Tests;

public class ProblemTests
{
    [Fact]
    public void Part1Test1()
    {
        var inputList = new List<string>
        {
            "0 3 6 9 12 15",
            "1 3 6 10 15 21",
            "10 13 16 21 30 45"
        };
        var result = Problem.ProblemPart1(inputList);
        Assert.Equal(114, result);
    }

    [Fact]
    public void Part2Test1()
    {
        var inputList = new List<string>
        {
            "0 3 6 9 12 15",
            "1 3 6 10 15 21",
            "10 13 16 21 30 45"
        };
        var result = Problem.ProblemPart2(inputList);
        Assert.Equal(2, result);
    }
}