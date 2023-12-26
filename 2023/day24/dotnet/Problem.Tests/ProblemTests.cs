namespace Problem.Tests;

public class ProblemTests
{
    [Fact]
    public void Part1Test1()
    {
        var inputList = new List<string>
        {
            "19, 13, 30 @ -2,  1, -2",
            "18, 19, 22 @ -1, -1, -2",
            "20, 25, 34 @ -2, -2, -4",
            "12, 31, 28 @ -1, -2, -1",
            "20, 19, 15 @  1, -5, -3"
        };
        var result = Problem.ProblemPart1(inputList, 7, 27);
        Assert.Equal(2, result);
    }

    [Fact]
    public void Part1Test2()
    {
        var lineOne = "19, 13, 30 @ -2,  1, -2";
        var lineTwo = "18, 19, 22 @ -1, -1, -2";
        var result = Problem.IsIntersect(lineOne, lineTwo, 7, 27);
        Assert.Equal(true, result);
    }

    [Fact]
    public void Part1Test3()
    {
        var lineOne = "19, 13, 30 @ -2,  1, -2";
        var lineTwo = "20, 25, 34 @ -2, -2, -4";
        var result = Problem.IsIntersect(lineOne, lineTwo, 7, 27);
        Assert.Equal(true, result);
    }

    [Fact]
    public void Part1Test4()
    {
        var lineOne = "19, 13, 30 @ -2,  1, -2";
        var lineTwo = "12, 31, 28 @ -1, -2, -1";
        var result = Problem.IsIntersect(lineOne, lineTwo, 7, 27);
        Assert.Equal(false, result);
    }

    [Fact]
    public void Part1Test5()
    {
        var lineOne = "19, 13, 30 @ -2,  1, -2";
        var lineTwo = "20, 19, 15 @ 1, -5, -3";
        var result = Problem.IsIntersect(lineOne, lineTwo, 7, 27);
        Assert.Equal(false, result);
    }

    [Fact]
    public void Part1Test6()
    {
        var lineOne = "18, 19, 22 @ -1, -1, -2";
        var lineTwo = "20, 25, 34 @ -2, -2, -4";
        var result = Problem.IsIntersect(lineOne, lineTwo, 7, 27);
        Assert.Equal(false, result);
    }

    [Fact]
    public void Part1Test7()
    {
        var lineOne = "18, 19, 22 @ -1, -1, -2";
        var lineTwo = "12, 31, 28 @ -1, -2, -1";
        var result = Problem.IsIntersect(lineOne, lineTwo, 7, 27);
        Assert.Equal(false, result);
    }

    [Fact]
    public void Part1Test8()
    {
        var lineOne = "18, 19, 22 @ -1, -1, -2";
        var lineTwo = "20, 19, 15 @ 1, -5, -3";
        var result = Problem.IsIntersect(lineOne, lineTwo, 7, 27);
        Assert.Equal(false, result);
    }

    [Fact]
    public void Part1Test9()
    {
        var lineOne = "20, 25, 34 @ -2, -2, -4";
        var lineTwo = "12, 31, 28 @ -1, -2, -1";
        var result = Problem.IsIntersect(lineOne, lineTwo, 7, 27);
        Assert.Equal(false, result);
    }

    [Fact]
    public void Part1Test10()
    {
        var lineOne = "20, 25, 34 @ -2, -2, -4";
        var lineTwo = "20, 19, 15 @ 1, -5, -3";
        var result = Problem.IsIntersect(lineOne, lineTwo, 7, 27);
        Assert.Equal(false, result);
    }

    [Fact]
    public void Part1Test11()
    {
        var lineOne = "12, 31, 28 @ -1, -2, -1";
        var lineTwo = "20, 19, 15 @ 1, -5, -3";
        var result = Problem.IsIntersect(lineOne, lineTwo, 7, 27);
        Assert.Equal(false, result);
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