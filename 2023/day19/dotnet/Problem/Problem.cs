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
        var rulesMap = new Dictionary<string, List<string>>();

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
            else // This line is part of the parts rating section, removed for part 2
            {
            }
        }

        var firstRuleName = "in";
        var firstRule = rulesMap[firstRuleName];
        var allAcceptedRoutesList = new List<List<(string, string)>>();
        var currentRoute = new List<(string, string)>(); // (rule name, condition)
        TraverseRules(firstRuleName, firstRule, rulesMap, currentRoute, allAcceptedRoutesList);

        // For each accepted route in allAcceptedRoutesList, transform to (category, startRange, endRange)
        var allAcceptedRoutesRangesList = new List<List<(string, long, long)>>();
        var xMasRangesList = new List<Dictionary<string, HashSet<(long, long)>>>();
        foreach (var acceptedRoute in allAcceptedRoutesList)
        {
            var acceptedRoutesRanges = new List<(string, long, long)>();
            var xMasRanges = new Dictionary<string, HashSet<(long, long)>>();
            foreach (var rawCondition in acceptedRoute)
            {
                var aCondition = rawCondition.Item2;
                if (aCondition.Contains(":"))
                    aCondition = aCondition.Split(":")[0];
                if (aCondition.Contains(">"))
                {
                    var aConditionSplit = aCondition.Split(">");
                    string aCategory = aConditionSplit[0];
                    long aValue = long.Parse(aConditionSplit[1]);
                    var aRange = (aCategory, aValue+1, 4000);
                    acceptedRoutesRanges.Add(aRange);
                    if (xMasRanges.ContainsKey(aCategory))
                        xMasRanges[aCategory].Add((aValue+1, 4000));
                    else
                        xMasRanges[aCategory] = new HashSet<(long, long)>() {(aValue+1, 4000)};
                }
                if (aCondition.Contains("<"))
                {
                    var aConditionSplit = aCondition.Split("<");
                    string aCategory = aConditionSplit[0];
                    long aValue = long.Parse(aConditionSplit[1]);
                    var aRange = (aCategory, 1, aValue-1);
                    acceptedRoutesRanges.Add(aRange);
                    if (xMasRanges.ContainsKey(aCategory))
                        xMasRanges[aCategory].Add((1, aValue-1));
                    else
                        xMasRanges[aCategory] = new HashSet<(long, long)>() {(1, aValue-1)};
                }
            }
            allAcceptedRoutesRangesList.Add(acceptedRoutesRanges);
            if (!xMasRanges.ContainsKey("x"))
                xMasRanges["x"] = new HashSet<(long, long)>() {(1, 4000)};
            if (!xMasRanges.ContainsKey("m"))
                xMasRanges["m"] = new HashSet<(long, long)>() {(1, 4000)};
            if (!xMasRanges.ContainsKey("a"))
                xMasRanges["a"] = new HashSet<(long, long)>() {(1, 4000)};
            if (!xMasRanges.ContainsKey("s"))
                xMasRanges["s"] = new HashSet<(long, long)>() {(1, 4000)};
            xMasRangesList.Add(xMasRanges);
        }

        // Reduce xMasRanges to contain only 1 range per category (x, m, a, s)
        foreach (var xMasRanges in xMasRangesList)
        {
            foreach (var categoryRanges in xMasRanges)
            {
                var aCategory = categoryRanges.Key;
                var ranges = categoryRanges.Value;
                if (ranges.Count() == 1) // Only 1 range for this category, do nothing
                {
                }
                else // Reduce to only intersections of ranges
                {
                    var reducedRanges = new HashSet<(long, long)>();
                    var Q = new Queue<(long, long)>();
                    foreach (var range in ranges)
                        Q.Enqueue(range);
                    while (Q.Count() > 0)
                    {
                        var currentRange = Q.Dequeue();
                        bool isIntersects = false;
                        foreach (var range in ranges)
                        {
                            if (currentRange == range) // Don't compare with itself
                                continue;
                            if (IsIntersects(currentRange, range))
                            {
                                isIntersects = true;
                                var reducedRange = ReduceRange(currentRange, range);
                                ranges.Remove(currentRange);
                                ranges.Remove(range);
                                ranges.Add(reducedRange);
                                Q.Enqueue(reducedRange);
                                break;
                            }
                            else // Current range doesn't intersect, continue
                                continue;
                        }
                        if (!isIntersects)
                            reducedRanges.Add(currentRange);
                    }
                    xMasRanges[aCategory] = reducedRanges;
                }
            }
        }

        long totalSum = 0;

        foreach (var xMasRanges in xMasRangesList)
        {
            long multiplyResult = 1;
            foreach (var categoryRanges in xMasRanges)
            {
                foreach (var aRange in categoryRanges.Value)
                {
                    multiplyResult *= (aRange.Item2 - aRange.Item1 + 1);
                }
            }
            totalSum += multiplyResult;
        }

        return totalSum;
    }

    public static (long, long) ReduceRange((long, long) currentRange, (long, long) range)
    {
        long x1Start = currentRange.Item1;
        long x1End = currentRange.Item2;
        long x2Start = range.Item1;
        long x2End = range.Item2;
        
        if (x1Start >= x2Start && x1Start <= x2End && x1End >= x2Start && x1End <= x2End) // currentRange is inside range
            return (currentRange);
        
        if (x1Start <= x2Start && x1Start <= x2End && x1End >= x2Start && x1End >= x2End) // range is inside currentRange
            return range;

        if (x1Start <= x2Start && x1Start <= x2End && x1End >= x2Start && x1End <= x2End) // Intersects between x2Start and x1End
            return (x2Start, x1End);

        if (x1Start >= x2Start && x1Start <= x2End && x1End >= x2Start && x1End >= x2End) // Intersects between x1Start and x2End
            return (x1Start, x2End);

        return (-1, -1);
    }

    public static bool IsIntersects((long, long) currentRange, (long, long) range)
    {
        long x1Start = currentRange.Item1;
        long x1End = currentRange.Item2;
        long x2Start = range.Item1;
        long x2End = range.Item2;
        if (x1Start <= x2End && x1End >= x2Start)
            return true;

        return false;
    }

    public static void TraverseRules(string currentRuleName, List<string> currentRule, Dictionary<string, List<string>> rulesMap, 
        List<(string, string)> currentRoute, List<List<(string, string)>> allAcceptedRoutesList)
    {
        // DFS from currentRule
        var inverseConditionsList = new List<string>();
        for (int i = 0; i < currentRule.Count(); i++) // Go through the rules
        {
            var currentRouteCopy = new List<(string, string)>(currentRoute);
            var currentCondition = currentRule[i];

            foreach (var inverseCondition in inverseConditionsList)
                currentRouteCopy.Add((currentRuleName, inverseCondition)); // Add the inverse of previous conditions
            
            currentRouteCopy.Add((currentRuleName, currentCondition));

            // Add the inverse of current condition to the list for next iteration
            if (currentCondition.Contains(":"))
            {
                var currentConditionSplit = currentCondition.Split(":");
                var aCondition = currentConditionSplit[0];
                if (aCondition.Contains("<"))
                {
                    var aConditionSplit = aCondition.Split("<");
                    var aRating = aConditionSplit[0];
                    long aValue = long.Parse(aConditionSplit[1]);
                    var inverseCondition = aRating + ">" + (aValue-1);
                    inverseConditionsList.Add(inverseCondition);
                }
                if (aCondition.Contains(">"))
                {
                    var aConditionSplit = aCondition.Split(">");
                    var aRating = aConditionSplit[0];
                    long aValue = long.Parse(aConditionSplit[1]);
                    var inverseCondition = aRating + "<" + (aValue+1);
                    inverseConditionsList.Add(inverseCondition);
                }
            }

            if (currentCondition.Contains(":")) // Not last condition in the rule
            {
                var currentConditionSplit = currentCondition.Split(":");
                var aCondition = currentConditionSplit[0];
                var destination = currentConditionSplit[1];

                if (destination.Equals("A")) // Terminating condition, accept
                {
                    allAcceptedRoutesList.Add(currentRouteCopy);
                    continue;
                }
                
                if (destination.Equals("R")) // Terminating condition, reject
                    continue;

                var nextRule = rulesMap[destination];
                TraverseRules(destination, nextRule, rulesMap, currentRouteCopy, allAcceptedRoutesList); // Recursive condition, go to next rule
            }
            else // Last condition in the rule
            {
                if (currentCondition.Equals("A")) // Terminating condition, accept
                {
                    allAcceptedRoutesList.Add(currentRouteCopy);
                    continue;
                }

                if (currentCondition.Equals("R")) // Terminating condition, reject
                    continue;

                var nextRule = rulesMap[currentCondition];
                TraverseRules(currentCondition, nextRule, rulesMap, currentRouteCopy, allAcceptedRoutesList); // Recursive condition, go to next rule
            }
        }
    }
}
