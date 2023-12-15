namespace Problem.Tests;

public class ProblemTests
{
    [Fact]
    public void Part1Test1()
    {
        var inputList = new List<string>
        {
            ".|...\\....",
            "|.-.\\.....",
            ".....|-...",
            "........|.",
            "..........",
            ".........\\",
            "..../.\\\\..",
            ".-.-/..|..",
            ".|....-|.\\",
            "..//.|...."
        };
        var result = Problem.ProblemPart1(inputList);
        Assert.Equal(46, result);
    }

    [Fact]
    public void Part2Test1()
    {
        var inputList = new List<string>
        {
            ".|...\\....",
            "|.-.\\.....",
            ".....|-...",
            "........|.",
            "..........",
            ".........\\",
            "..../.\\\\..",
            ".-.-/..|..",
            ".|....-|.\\",
            "..//.|...."
        };
        var result = Problem.ProblemPart2(inputList);
        Assert.Equal(51, result);
    }
}