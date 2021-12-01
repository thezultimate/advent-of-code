namespace Problem.Tests;

public class ProblemTests
{
    [Fact]
    public void Part1Test1()
    {
        var inputList = new List<string>
        {
            "O....#....",
            "O.OO#....#",
            ".....##...",
            "OO.#O....O",
            ".O.....O#.",
            "O.#..O.#.#",
            "..O..#O..O",
            ".......O..",
            "#....###..",
            "#OO..#...."
        };
        var result = Problem.ProblemPart1(inputList);
        Assert.Equal(136, result);
    }

    [Fact]
    public void Part2Test1()
    {
        var inputList = new List<string>
        {
            "O....#....",
            "O.OO#....#",
            ".....##...",
            "OO.#O....O",
            ".O.....O#.",
            "O.#..O.#.#",
            "..O..#O..O",
            ".......O..",
            "#....###..",
            "#OO..#...."
        };
        var result = Problem.ProblemPart2(inputList);
        Assert.Equal(64, result);
    }

    [Fact]
    public void Part2Test2()
    {
        var inputList = new List<string>
        {
            "OOOO.#.O..",
            "OO..#....#",
            "OO..O##..O",
            "O..#.OO...",
            "........#.",
            "..#....#.#",
            "..O..#.O.O",
            "..O.......",
            "#....###..",
            "#....#...."
        };
        var inputListCharArr = new List<char[]>();
        foreach (var line in inputList)
            inputListCharArr.Add(line.ToCharArray());
        var result = Problem.GetNorthLoad(inputListCharArr);
        Assert.Equal(136, result);
    }
}