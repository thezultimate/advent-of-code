namespace Problem.Tests;

public class ProblemTests
{
    [Fact]
    public void Part1Test1()
    {
        var inputList = new List<string>
        {
            "rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7"
        };
        var result = Problem.ProblemPart1(inputList);
        Assert.Equal(1320, result);
    }

    [Fact]
    public void Part1Test2()
    {
        var aString = "HASH";
        var result = Problem.GetHashNumber(aString);
        Assert.Equal(52, result);
    }

    [Fact]
    public void Part1Test3()
    {
        var aString = "rn=1";
        var result = Problem.GetHashNumber(aString);
        Assert.Equal(30, result);
    }

    [Fact]
    public void Part1Test4()
    {
        var aString = "cm-";
        var result = Problem.GetHashNumber(aString);
        Assert.Equal(253, result);
    }

    [Fact]
    public void Part2Test1()
    {
        var inputList = new List<string>
        {
            "rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7"
        };
        var result = Problem.ProblemPart2(inputList);
        Assert.Equal(145, result);
    }

    [Fact]
    public void Part2Test2()
    {
        var strOne = "rn";
        var strTwo = "cm";
        var strOneHash = Problem.GetHashNumber(strOne);
        var strTwoHash = Problem.GetHashNumber(strTwo);
        Assert.Equal(0, strOneHash);
        Assert.Equal(0, strTwoHash);
        Assert.Equal(strOneHash, strTwoHash);
    }

    [Fact]
    public void Part2Test3()
    {
        var strOne = "pc";
        var strTwo = "ot";
        var strThree = "ab";
        var strOneHash = Problem.GetHashNumber(strOne);
        var strTwoHash = Problem.GetHashNumber(strTwo);
        var strThreeHash = Problem.GetHashNumber(strThree);
        Assert.Equal(3, strOneHash);
        Assert.Equal(3, strTwoHash);
        Assert.Equal(3, strThreeHash);
    }
}