using System.Diagnostics.Metrics;

namespace Problem.Tests;

public class ProblemTests
{
    [Fact]
    public void Part1Test1()
    {
        var inputList = new List<string>
        {
            "???.### 1,1,3",
            ".??..??...?##. 1,1,3",
            "?#?#?#?#?#?#?#? 1,3,1,6",
            "????.#...#... 4,1,1",
            "????.######..#####. 1,6,5",
            "?###???????? 3,2,1"
        };
        var result = Problem.ProblemPart1(inputList);
        Assert.Equal(21, result);
    }

    [Fact]
    public void Part1Test2()
    {
        var line = "#.#.###";
        var damageCountList = new List<int>() {1, 1, 3};
        var result = Problem.IsLineCorrect(line.ToCharArray(), damageCountList);
        Assert.Equal(true, result);
    }

    [Fact]
    public void Part1Test3()
    {
        var line = ".#...#....###.";
        var damageCountList = new List<int>() {1, 1, 3};
        var result = Problem.IsLineCorrect(line.ToCharArray(), damageCountList);
        Assert.Equal(true, result);
    }

    [Fact]
    public void Part1Test4()
    {
        var line = ".#.###.#.######";
        var damageCountList = new List<int>() {1, 3, 1, 6};
        var result = Problem.IsLineCorrect(line.ToCharArray(), damageCountList);
        Assert.Equal(true, result);
    }

    [Fact]
    public void Part1Test5()
    {
        var line = "####.#...#...";
        var damageCountList = new List<int>() {4, 1, 1};
        var result = Problem.IsLineCorrect(line.ToCharArray(), damageCountList);
        Assert.Equal(true, result);
    }

    [Fact]
    public void Part1Test6()
    {
        var line = "#....######..#####.";
        var damageCountList = new List<int>() {1, 6, 5};
        var result = Problem.IsLineCorrect(line.ToCharArray(), damageCountList);
        Assert.Equal(true, result);
    }

    [Fact]
    public void Part1Test7()
    {
        var line = ".###.##....#";
        var damageCountList = new List<int>() {3, 2, 1};
        var result = Problem.IsLineCorrect(line.ToCharArray(), damageCountList);
        Assert.Equal(true, result);
    }

    [Fact]
    public void Part2Test1()
    {
        var inputList = new List<string>
        {
            "???.### 1,1,3",
            ".??..??...?##. 1,1,3",
            "?#?#?#?#?#?#?#? 1,3,1,6",
            "????.#...#... 4,1,1",
            "????.######..#####. 1,6,5",
            "?###???????? 3,2,1"
        };
        var result = Problem.ProblemPart2(inputList);
        Assert.Equal(525152, result);
    }
}