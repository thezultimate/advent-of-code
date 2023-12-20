namespace Problem.Tests;

public class ProblemTests
{
    [Fact]
    public void Part1Test1()
    {
        var inputList = new List<string>
        {
            "broadcaster -> a, b, c",
            "%a -> b",
            "%b -> c",
            "%c -> inv",
            "&inv -> a"
        };
        var result = Problem.ProblemPart1(inputList);
        Assert.Equal(32000000, result);
    }

    [Fact]
    public void Part1Test2()
    {
        var inputList = new List<string>
        {
            "broadcaster -> a",
            "%a -> inv, con",
            "&inv -> b",
            "%b -> con",
            "&con -> output"
        };
        var result = Problem.ProblemPart1(inputList);
        Assert.Equal(11687500, result);
    }

    // [Fact]
    // public void Part2Test1()
    // {
    //     var inputList = new List<string>
    //     {
    //         "broadcaster -> a, b, c",
    //         "%a -> b",
    //         "%b -> c",
    //         "%c -> inv",
    //         "&inv -> a"
    //     };
    //     var result = Problem.ProblemPart2(inputList);
    //     Assert.Equal(32000000, result);
    // }

    // [Fact]
    // public void Part2Test2()
    // {
    //     var inputList = new List<string>
    //     {
    //         "broadcaster -> a",
    //         "%a -> inv, con",
    //         "&inv -> b",
    //         "%b -> con",
    //         "&con -> output"
    //     };
    //     var result = Problem.ProblemPart2(inputList);
    //     Assert.Equal(11687500, result);
    // }
}