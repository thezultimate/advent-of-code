using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace Problem;
public class Problem
{
    public static long ProblemPart1(List<string> inputList)
    {
        var rulesMap = new Dictionary<string, List<string>>();
        var partRatingMapList = new List<Dictionary<string, long>>();

        bool partRatingSection = false;
        foreach (var line in inputList)
        {
            if (line.Length == 0) // This line is the separator
            {
                partRatingSection = true;
                continue;
            }

            if (!partRatingSection) // This line is part of the rule section
            {
                var lineSplit = line.Split("{");
                var ruleName = lineSplit[0];
                var ruleString = lineSplit[1].Trim('}');
                var ruleList = ruleString.Split(",").ToList();
                rulesMap[ruleName] = ruleList;
            }
            else // This line is part of the parts rating section
            {
                var lineTrimmed = line.Trim('{');
                lineTrimmed = lineTrimmed.Trim('}');
                var partRatingList = lineTrimmed.Split(",");
                var partRatingMap = new Dictionary<string, long>();
                foreach (var partRating in partRatingList)
                {
                    var partRatingSplit = partRating.Split("=");
                    var category = partRatingSplit[0];
                    long rating = long.Parse(partRatingSplit[1]);
                    partRatingMap[category] = rating;
                }
                partRatingMapList.Add(partRatingMap);
            }
        }

        long totalSum = 0;
        foreach (var partRatingMap in partRatingMapList)
        {
            var firstRule = rulesMap["in"];
            var result = Problem.IsPartAccepted(firstRule, partRatingMap, rulesMap);
            if (result) // Accepted part
            {
                long currentSum = partRatingMap["x"] + partRatingMap["m"] + partRatingMap["a"] + partRatingMap["s"];
                totalSum += currentSum;
            }
        }

        return totalSum;
    }

    public static bool IsPartAccepted(List<string> currentRule, Dictionary<string, long> partRatingMap, 
        Dictionary<string, List<string>> rulesMap)
    {
        for (int i = 0; i < currentRule.Count(); i++) // Go through the rules
        {
            var currentCondition = currentRule[i];
            
            if (currentCondition.Contains(":")) // Not last condition in the rule
            {
                var currentConditionSplit = currentCondition.Split(":");
                var aCondition = currentConditionSplit[0];
                var destination = currentConditionSplit[1];

                if (aCondition.Contains("<"))
                {
                    var aConditionSplit = aCondition.Split("<");
                    var category = aConditionSplit[0];
                    long rating = long.Parse(aConditionSplit[1]);
                    if (partRatingMap[category] >= rating)
                        continue; // Rating doesn't fit, continue to next condition
                    else // Rating fits, go to destination
                    {
                        if (destination.Equals("A")) // Terminating condition, accept
                            return true;
                        if (destination.Equals("R")) // Terminating condition, reject
                            return false;
                        var nextRule = rulesMap[destination];
                        return IsPartAccepted(nextRule, partRatingMap, rulesMap); // Recursive condition, go to next rule
                    }
                }

                if (aCondition.Contains(">"))
                {
                    var aConditionSplit = aCondition.Split(">");
                    var category = aConditionSplit[0];
                    long rating = long.Parse(aConditionSplit[1]);
                    if (partRatingMap[category] <= rating)
                        continue; // Rating doesn't fit, continue to next condition
                    else // Rating fits, go to destination
                    {
                        if (destination.Equals("A")) // Terminating condition, accept
                            return true;
                        if (destination.Equals("R")) // Terminating condition, reject
                            return false;
                        var nextRule = rulesMap[destination];
                        return IsPartAccepted(nextRule, partRatingMap, rulesMap); // Recursive condition, go to next rule
                    }
                }
            }
            else // Last condition in the rule
            {
                if (currentCondition.Equals("A")) // Terminating condition, accept
                    return true;
                
                if (currentCondition.Equals("R")) // Terminating condition, reject
                    return false;
                
                var nextRule = rulesMap[currentCondition];
                return IsPartAccepted(nextRule, partRatingMap, rulesMap); // Recursive condition, go to next rule
            }

        }

        Console.WriteLine("FORBIDDEN!");
        return false; // Must never reach here
    }

    public static long ProblemPart2(List<string> inputList)
    {
        return 0;
    }
}
