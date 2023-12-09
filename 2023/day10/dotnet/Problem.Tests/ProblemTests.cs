namespace Problem.Tests;

public class ProblemTests
{
    [Fact]
    public void Part1Test1()
    {
        var inputList = new List<string>
        {
            ".....",
            ".S-7.",
            ".|.|.",
            ".L-J.",
            "....."
        };
        var result = Problem.ProblemPart1(inputList);
        Assert.Equal(4, result);
    }

    [Fact]
    public void Part1Test2()
    {
        var inputList = new List<string>
        {
            "..F7.",
            ".FJ|.",
            "SJ.L7",
            "|F--J",
            "LJ..."
        };
        var result = Problem.ProblemPart1(inputList);
        Assert.Equal(8, result);
    }

    [Fact]
    public void Part2Test1()
    {
        var inputList = new List<string>
        {
            "..........",
            ".S------7.",
            ".|F----7|.",
            ".||....||.",
            ".||....||.",
            ".|L-7F-J|.",
            ".|..||..|.",
            ".L--JL--J.",
            ".........."
        };
        var result = Problem.ProblemPart2(inputList);
        Assert.Equal(4, result);
    }

    [Fact]
    public void Part2Test2()
    {
        var inputList = new List<string>
        {
            ".F----7F7F7F7F-7....",
            ".|F--7||||||||FJ....",
            ".||.FJ||||||||L7....",
            "FJL7L7LJLJ||LJ.L-7..",
            "L--J.L7...LJS7F-7L7.",
            "....F-J..F7FJ|L7L7L7",
            "....L7.F7||L7|.L7L7|",
            ".....|FJLJ|FJ|F7|.LJ",
            "....FJL-7.||.||||...",
            "....L---J.LJ.LJLJ..."
        };
        var result = Problem.ProblemPart2(inputList);
        Assert.Equal(8, result);
    }

    [Fact]
    public void Part2Test3()
    {
        var inputList = new List<string>
        {
            "FF7FSF7F7F7F7F7F---7",
            "L|LJ||||||||||||F--J",
            "FL-7LJLJ||||||LJL-77",
            "F--JF--7||LJLJ7F7FJ-",
            "L---JF-JLJ.||-FJLJJ7",
            "|F|F-JF---7F7-L7L|7|",
            "|FFJF7L7F-JF7|JL---7",
            "7-L-JL7||F7|L7F-7F7|",
            "L.L7LFJ|||||FJL7||LJ",
            "L7JLJL-JLJLJL--JLJ.L"
        };
        var result = Problem.ProblemPart2(inputList);
        Assert.Equal(10, result);
    }
}