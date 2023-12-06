namespace Problem.Tests;

public class ProblemTests
{
    [Fact]
    public void Part1Test1()
    {
        var inputList = new List<string>
        {
            "Time:      7  15   30",
            "Distance:  9  40  200"
        };
        var result = Problem.ProblemPart1(inputList);
        Assert.Equal(288, result);
    }

    [Fact]
    public void Part2Test1()
    {
        var inputList = new List<string>
        {
            "Time:      7  15   30",
            "Distance:  9  40  200"
        };
        var result = Problem.ProblemPart2(inputList);
        Assert.Equal(71503, result);
    }
}