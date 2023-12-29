namespace Problem.Tests;

public class ProblemTests
{
    [Fact]
    public void Part1Test1()
    {
        var inputList = new List<string>
        {
            "2413432311323",
            "3215453535623",
            "3255245654254",
            "3446585845452",
            "4546657867536",
            "1438598798454",
            "4457876987766",
            "3637877979653",
            "4654967986887",
            "4564679986453",
            "1224686865563",
            "2546548887735",
            "4322674655533"
        };
        var result = Problem.ProblemPart1(inputList);
        Assert.Equal(102, result);
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