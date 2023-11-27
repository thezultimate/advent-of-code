namespace Problem;
public class Problem
{
    public static int ProblemPart1(List<int> inputArr)
    {
        var maxCalories = 0;
        var localSum = 0;
        foreach (var i in inputArr)
        {
            if (i == -1)
            {
                if (localSum > maxCalories)
                {
                    maxCalories = localSum;
                }
                localSum = 0;
            }
            else
            {
                localSum += i;
            }
        }
        if (localSum > 0)
        {
            if (localSum > maxCalories)
            {
                maxCalories = localSum;
            }
        }
        return maxCalories;
    }

    public static int ProblemPart2(List<int> inputArr)
    {
        var sumArr = new List<int>();
        var localSum = 0;
        foreach (var i in inputArr)
        {
            if (i == -1)
            {
                sumArr.Add(localSum);
                localSum = 0;
            }
            else
            {
                localSum += i;
            }
        }
        if (localSum > 0)
        {
            sumArr.Add(localSum);
        }
        sumArr.Sort((a, b) => 
        {
            return b - a;
        });
        return sumArr[0] + sumArr[1] + sumArr[2];
    }
}
