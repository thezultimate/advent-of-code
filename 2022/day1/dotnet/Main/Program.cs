namespace Main;
class Program
{
    static void Main(string[] args)
    {
        var inputArrString = File.ReadAllLines("input.txt");
        var inputArr = new List<int>();
        foreach (var i in inputArrString)
        {
            if (i.Length > 0)
            {
                inputArr.Add(Int32.Parse(i));
            }
            else
            {
                inputArr.Add(-1);
            }
        }

        var resultPart1 = Problem.Problem.ProblemPart1(inputArr);
        var resultPart2 = Problem.Problem.ProblemPart2(inputArr);
        Console.WriteLine(resultPart1);
        Console.WriteLine(resultPart2);
    }
}
