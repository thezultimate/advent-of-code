using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace Problem;
public class Problem
{
    public static int ProblemPart1(List<string> inputList)
    {
        var totalNumOfWays = 1;

        var maxTimeSplit = inputList[0].Split(":");
        var maxTimeList = maxTimeSplit[1].Trim().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
        var maxDistanceSplit = inputList[1].Split(":");
        var maxDistanceList = maxDistanceSplit[1].Trim().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < maxTimeList.Length; i++) // Each race
        {
            var currentMaxTime = int.Parse(maxTimeList[i]);
            var currentMaxDistance = int.Parse(maxDistanceList[i]);
            var currentNumOfWays = 0;

            for (int holdTime = 0; holdTime <= currentMaxTime; holdTime++)
            {
                var remainingTime = currentMaxTime - holdTime;
                var currentDistance = holdTime * remainingTime;
                if (currentDistance > currentMaxDistance)
                    currentNumOfWays++;
            }
            totalNumOfWays *= currentNumOfWays;
        }

        return totalNumOfWays;
    }

    public static long ProblemPart2(List<string> inputList)
    {
        var maxTimeSplit = inputList[0].Split(":");
        var maxTimeString = maxTimeSplit[1];
        var maxTime = long.Parse(Regex.Replace(maxTimeString, @"\s+", ""));
        var maxDistanceSplit = inputList[1].Split(":");
        var maxDistanceString = maxDistanceSplit[1];
        var maxDistance = long.Parse(Regex.Replace(maxDistanceString, @"\s+", ""));

        var currentNumOfWays = 0;

        for (long holdTime = 0; holdTime <= maxTime; holdTime++)
        {
            var remainingTime = maxTime - holdTime;
            var currentDistance = holdTime * remainingTime;
            if (currentDistance > maxDistance)
                currentNumOfWays++;
        }

        return currentNumOfWays;
    }
}
