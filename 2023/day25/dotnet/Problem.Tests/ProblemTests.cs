namespace Problem.Tests;

public class ProblemTests
{
    [Fact]
    public void Part1Test1()
    {
        var inputList = new List<string>
        {
            "jqt: rhn xhk nvd",
            "rsh: frs pzl lsr",
            "xhk: hfx",
            "cmg: qnr nvd lhk bvb",
            "rhn: xhk bvb hfx",
            "bvb: xhk hfx",
            "pzl: lsr hfx nvd",
            "qnr: nvd",
            "ntq: jqt hfx bvb xhk",
            "nvd: lhk",
            "lsr: lhk",
            "rzs: qnr cmg lsr rsh",
            "frs: qnr lhk lsr"
        };
        var result = Problem.ProblemPart1(inputList);
        Assert.Equal(54, result);
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