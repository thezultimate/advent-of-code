namespace Problem.Tests;

public class ProblemTests
{
    [Fact]
    public void Part1Test1()
    {
        var inputList = new List<string>
        {
            "32T3K 765",
            "T55J5 684",
            "KK677 28",
            "KTJJT 220",
            "QQQJA 483"
        };
        var result = Problem.ProblemPart1(inputList);
        Assert.Equal(6440, result);
    }

    [Fact]
    public void Part2Test1()
    {
        var inputList = new List<string>
        {
            "32T3K 765",
            "T55J5 684",
            "KK677 28",
            "KTJJT 220",
            "QQQJA 483"
        };
        var result = Problem.ProblemPart2(inputList);
        Assert.Equal(5905, result);
    }
}