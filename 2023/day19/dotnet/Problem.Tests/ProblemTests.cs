namespace Problem.Tests;

public class ProblemTests
{
    [Fact]
    public void Part1Test1()
    {
        var inputList = new List<string>
        {
            "px{a<2006:qkq,m>2090:A,rfg}",
            "pv{a>1716:R,A}",
            "lnx{m>1548:A,A}",
            "rfg{s<537:gd,x>2440:R,A}",
            "qs{s>3448:A,lnx}",
            "qkq{x<1416:A,crn}",
            "crn{x>2662:A,R}",
            "in{s<1351:px,qqz}",
            "qqz{s>2770:qs,m<1801:hdj,R}",
            "gd{a>3333:R,R}",
            "hdj{m>838:A,pv}",
            "",
            "{x=787,m=2655,a=1222,s=2876}",
            "{x=1679,m=44,a=2067,s=496}",
            "{x=2036,m=264,a=79,s=2244}",
            "{x=2461,m=1339,a=466,s=291}",
            "{x=2127,m=1623,a=2188,s=1013}"
        };
        var result = Problem.ProblemPart1(inputList);
        Assert.Equal(19114, result);
    }

    [Fact]
    public void Part1Test2()
    {
        var rulesMap = new Dictionary<string, List<string>>
        {
            {"px", new List<string>{"a<2006:qkq", "m>2090:A", "rfg"}},
            {"pv", new List<string>{"a>1716:R", "A"}},
            {"lnx", new List<string>{"m>1548:A", "A"}},
            {"rfg", new List<string>{"s<537:gd", "x>2440:R", "A"}},
            {"qs", new List<string>{"s>3448:A","lnx"}},
            {"qkq", new List<string>{"x<1416:A", "crn"}},
            {"crn", new List<string>{"x>2662:A", "R"}},
            {"in", new List<string>{"s<1351:px", "qqz"}},
            {"qqz", new List<string>{"s>2770:qs", "m<1801:hdj", "R"}},
            {"gd", new List<string>{"a>3333:R", "R"}},
            {"hdj", new List<string>{"m>838:A", "pv"}}
        };
        var partRatingMap = new Dictionary<string, long>
        {
            {"x", 787},
            {"m", 2655},
            {"a", 1222},
            {"s", 2876},
        };
        var firstRule = rulesMap["in"];
        var result = Problem.IsPartAccepted(firstRule, partRatingMap, rulesMap);
        Assert.Equal(true, result);
    }

    [Fact]
    public void Part1Test3()
    {
        var rulesMap = new Dictionary<string, List<string>>
        {
            {"px", new List<string>{"a<2006:qkq", "m>2090:A", "rfg"}},
            {"pv", new List<string>{"a>1716:R", "A"}},
            {"lnx", new List<string>{"m>1548:A", "A"}},
            {"rfg", new List<string>{"s<537:gd", "x>2440:R", "A"}},
            {"qs", new List<string>{"s>3448:A","lnx"}},
            {"qkq", new List<string>{"x<1416:A", "crn"}},
            {"crn", new List<string>{"x>2662:A", "R"}},
            {"in", new List<string>{"s<1351:px", "qqz"}},
            {"qqz", new List<string>{"s>2770:qs", "m<1801:hdj", "R"}},
            {"gd", new List<string>{"a>3333:R", "R"}},
            {"hdj", new List<string>{"m>838:A", "pv"}}
        };
        var partRatingMap = new Dictionary<string, long>
        {
            {"x", 1679},
            {"m", 44},
            {"a", 2067},
            {"s", 496},
        };
        var firstRule = rulesMap["in"];
        var result = Problem.IsPartAccepted(firstRule, partRatingMap, rulesMap);
        Assert.Equal(false, result);
    }

    [Fact]
    public void Part1Test4()
    {
        var rulesMap = new Dictionary<string, List<string>>
        {
            {"px", new List<string>{"a<2006:qkq", "m>2090:A", "rfg"}},
            {"pv", new List<string>{"a>1716:R", "A"}},
            {"lnx", new List<string>{"m>1548:A", "A"}},
            {"rfg", new List<string>{"s<537:gd", "x>2440:R", "A"}},
            {"qs", new List<string>{"s>3448:A","lnx"}},
            {"qkq", new List<string>{"x<1416:A", "crn"}},
            {"crn", new List<string>{"x>2662:A", "R"}},
            {"in", new List<string>{"s<1351:px", "qqz"}},
            {"qqz", new List<string>{"s>2770:qs", "m<1801:hdj", "R"}},
            {"gd", new List<string>{"a>3333:R", "R"}},
            {"hdj", new List<string>{"m>838:A", "pv"}}
        };
        var partRatingMap = new Dictionary<string, long>
        {
            {"x", 2036},
            {"m", 264},
            {"a", 79},
            {"s", 2244},
        };
        var firstRule = rulesMap["in"];
        var result = Problem.IsPartAccepted(firstRule, partRatingMap, rulesMap);
        Assert.Equal(true, result);
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