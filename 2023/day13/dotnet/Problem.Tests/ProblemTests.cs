namespace Problem.Tests;

public class ProblemTests
{
    [Fact]
    public void Part1Test1()
    {
        var inputList = new List<string>
        {
            "#.##..##.",
            "..#.##.#.",
            "##......#",
            "##......#",
            "..#.##.#.",
            "..##..##.",
            "#.#.##.#.",
            "",
            "#...##..#",
            "#....#..#",
            "..##..###",
            "#####.##.",
            "#####.##.",
            "..##..###",
            "#....#..#"
        };
        var result = Problem.ProblemPart1(inputList);
        Assert.Equal(405, result);
    }

    [Fact]
    public void Part2Test1()
    {
        var inputList = new List<string>
        {
            "#.##..##.",
            "..#.##.#.",
            "##......#",
            "##......#",
            "..#.##.#.",
            "..##..##.",
            "#.#.##.#.",
            "",
            "#...##..#",
            "#....#..#",
            "..##..###",
            "#####.##.",
            "#####.##.",
            "..##..###",
            "#....#..#"
        };
        var result = Problem.ProblemPart2(inputList);
        Assert.Equal(400, result);
    }

    [Fact]
    public void Part2Test2()
    {
        var inputList = new List<string>
        {
            "..#.#......#.",
            "###.#.####.#.",
            "##.##.#..#.##",
            "##..#.####.#.",
            "...###.##.###",
            "###.##.##.##.",
            "###..##..#...",
            "###..##..##..",
            "####.#.##.#.#"
        };
        var result = Problem.ProblemPart2(inputList);
        Assert.Equal(8, result);
    }
}