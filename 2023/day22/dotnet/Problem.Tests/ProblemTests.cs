namespace Problem.Tests;

public class ProblemTests
{
    [Fact]
    public void Part1Test1()
    {
        var inputList = new List<string>
        {
            "1,0,1~1,2,1",
            "0,0,2~2,0,2",
            "0,2,3~2,2,3",
            "0,0,4~0,2,4",
            "2,0,5~2,2,5",
            "0,1,6~2,1,6",
            "1,1,8~1,1,9"
        };
        var result = Problem.ProblemPart1(inputList);
        Assert.Equal(5, result);
    }

    [Fact]
    public void Part2Test1()
    {
        var inputList = new List<string>
        {
        };
        var result = Problem.ProblemPart2(inputList);
        Assert.Equal(0, result);
    }
}