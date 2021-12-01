namespace Problem.Tests;

public class ProblemTests
{
    [Fact]
    public void Part1Test1()
    {
        var inputArr = new List<int> {1000, 2000, 3000, -1, 4000, -1, 5000, 6000, -1, 7000, 8000, 9000, -1, 10000};
        var result = Problem.ProblemPart1(inputArr);
        Assert.Equal(result, 24000);
    }

    [Fact]
    public void Part2Test1()
    {
        var inputArr = new List<int> {1000, 2000, 3000, -1, 4000, -1, 5000, 6000, -1, 7000, 8000, 9000, -1, 10000};
        var result = Problem.ProblemPart2(inputArr);
        Assert.Equal(result, 45000);
    }
}