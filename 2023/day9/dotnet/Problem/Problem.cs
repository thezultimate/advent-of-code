using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace Problem;
public class Problem
{
    public static long ProblemPart1(List<string> inputList)
    {
        long extrapolationSum = 0;
        var historyList = new List<List<long>>();

        foreach (var history in inputList) // Iterate through each history
        {
            var historySplit = history.Split(" ");
            var stepList = new List<long>();
            foreach (var step in historySplit) // Iterate through each step
                stepList.Add(long.Parse(step.Trim()));
            historyList.Add(stepList);
        }

        foreach (var history in historyList) // Iterate through history list
        {
            var initialLastHistoryStepList = new List<long>();
            var (zeroHistory, lastHistoryStepList) = GetLastHistorySteps(history, initialLastHistoryStepList);
            long currentExtrapolationSum = 0;
            foreach (var lastHistoryStep in lastHistoryStepList)
                currentExtrapolationSum += lastHistoryStep;
            extrapolationSum += currentExtrapolationSum;
        }

        return extrapolationSum;
    }

    public static (List<long>, List<long>) GetLastHistorySteps(List<long> history, List<long> lastHistoryStepList)
    {
        lastHistoryStepList.Add(history[history.Count()-1]);

        // Terminating case
        // Check if all steps are zero
        var zeroCount = 0;
        foreach (var step in history)
            if (step == 0)
                zeroCount++;
        if (zeroCount == history.Count()) // All zeros
            return (history, lastHistoryStepList);

        // Recursion case
        var tempList = new List<long>();
        for (int i = 1; i < history.Count(); i++)
        {
            var currentDelta = history[i] - history[i-1];
            tempList.Add(currentDelta);
        }
        return GetLastHistorySteps(tempList, lastHistoryStepList);
    }

    public static long ProblemPart2(List<string> inputList)
    {
        long extrapolationSum = 0;
        var historyList = new List<List<long>>();

        foreach (var history in inputList) // Iterate through each history
        {
            var historySplit = history.Split(" ");
            var stepList = new List<long>();
            foreach (var step in historySplit) // Iterate through each step
                stepList.Add(long.Parse(step.Trim()));
            historyList.Add(stepList);
        }

        foreach (var history in historyList) // Iterate through history list
        {
            var initialFirstHistoryStepList = new List<long>();
            var (zeroHistory, firstHistoryStepList) = GetFirstHistorySteps(history, initialFirstHistoryStepList);
            long currentExtrapolationNegation = 0;
            for (int i = firstHistoryStepList.Count() - 2; i >= 0; i--)
                currentExtrapolationNegation = firstHistoryStepList[i] - currentExtrapolationNegation;
            extrapolationSum += currentExtrapolationNegation;
        }

        return extrapolationSum;
    }

    public static (List<long>, List<long>) GetFirstHistorySteps(List<long> history, List<long> firstHistoryStepList)
    {
        firstHistoryStepList.Add(history[0]);

        // Terminating case
        // Check if all steps are zero
        var zeroCount = 0;
        foreach (var step in history)
            if (step == 0)
                zeroCount++;
        if (zeroCount == history.Count()) // All zeros
            return (history, firstHistoryStepList);

        // Recursion case
        var tempList = new List<long>();
        for (int i = 1; i < history.Count(); i++)
        {
            var currentDelta = history[i] - history[i-1];
            tempList.Add(currentDelta);
        }
        return GetFirstHistorySteps(tempList, firstHistoryStepList);
    }
}
