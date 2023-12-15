using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;
using System.Text;
using System.Reflection.Metadata;

namespace Problem;
public class Problem
{

    public static Dictionary<string, long> cache;
    public static long ProblemPart1(List<string> inputList)
    {
        long totalSumPossibilities = 0;

        foreach (var line in inputList)
        {
            var lineSplit = line.Split(" ");
            var springConditionString = lineSplit[0];
            var springConditionCharArray = springConditionString.ToCharArray();
            var damagedSpringList = lineSplit[1].Split(",").Select(int.Parse).ToList();
            
            // Get list of question marks indices in the line
            var questionMarkIndexList = new List<int>();
            for (int i = 0; i < springConditionCharArray.Length; i++)
            {
                if (springConditionCharArray[i] == '?')
                {
                    questionMarkIndexList.Add(i);
                }
            }

            // Get possible combinations for question marks in the line
            var possibleCombinations = new HashSet<string>();
            GetPossibileCombinations(new char[] {'#', '.'}, questionMarkIndexList.Count(), "", possibleCombinations);

            // Put each possible combination chars to question marks
            long sumPossibleCombination = 0;
            foreach (var aCombination in possibleCombinations)
            {
                for (int i = 0; i < aCombination.Length; i++)
                {
                    springConditionCharArray[questionMarkIndexList[i]] = aCombination[i];
                }
                // Check if it is correct
                if (IsLineCorrect(springConditionCharArray, damagedSpringList))
                {
                    sumPossibleCombination++;
                }
            }
            totalSumPossibilities += sumPossibleCombination;
        }

        return totalSumPossibilities;
    }

    public static bool IsLineCorrect(char[] line, List<int> damageCountList)
    {
        var damageCountLength = damageCountList.Count();
        var damageCountIndex = 0;
        var tempDamageCount = 0;
        var damageGroupCount = 0;
        
        foreach (var aChar in line)
        {
            if (aChar == '#')
            {
                tempDamageCount++;
            }

            if (aChar == '.')
            {
                if (tempDamageCount > 0)
                {
                    damageGroupCount++;
                    if (damageCountIndex == damageCountLength) // Index out of bound of damageCountList
                    {
                        return false;
                    }
                    if (tempDamageCount != damageCountList[damageCountIndex]) // Not matching
                    {
                        return false;
                    }
                    // Matching
                    damageCountIndex++;
                    tempDamageCount = 0;
                }
            }
        }

        // End of line check
        if (tempDamageCount > 0) // Last char in line is #
        {
            damageGroupCount++;
            if (damageCountIndex == damageCountLength) // Index out of bound of damageCountList
            {
                return false;
            }
            if (tempDamageCount != damageCountList[damageCountIndex]) // Not matching
            {
                return false;
            }
        }

        if (damageGroupCount == damageCountLength)
        {
            return true;
        }

        return false;
    }

    public static void GetPossibileCombinations(char[] chars, int slotNumber, string aString, HashSet<string> possibleCombinations)
    {
        // Terminating case
        if (aString.Length == slotNumber)
        {
            possibleCombinations.Add(aString);
            return;
        }

        // Recursive case
        var copyStringDot = String.Copy(aString);
        var copyStringHash = String.Copy(aString);
        copyStringDot += ".";
        copyStringHash += "#";
        GetPossibileCombinations(chars, slotNumber, copyStringDot, possibleCombinations);
        GetPossibileCombinations(chars, slotNumber, copyStringHash, possibleCombinations);
    }

    public static long ProblemPart2(List<string> inputList)
    {
        // Tried generating all possible combinations but didn't scale. So tried processing condition spring string from left to right.
        long totalSumPossibilities = 0;

        foreach (var line in inputList)
        {
            var lineSplit = line.Split(" ");
            var springConditionString = lineSplit[0];
            var damagedSpringString = lineSplit[1];

            // Inflate 5X
            var springConditionInflatedString = "";
            for (int i = 0; i < 5; i++)
            {
                if (i < 5-1)
                    springConditionInflatedString += springConditionString + "?";
                else
                    springConditionInflatedString += springConditionString;
            }
            var damagedSpringInflatedString = "";
            for (int i = 0; i < 5; i++)
            {
                if (i < 5-1)
                    damagedSpringInflatedString += damagedSpringString + ",";
                else
                    damagedSpringInflatedString += damagedSpringString;
            }

            var damagedSpringList = damagedSpringInflatedString.Split(",").Select(int.Parse).ToList();
            var memo = new Dictionary<string, long>();
            // Console.WriteLine($"Processing: {springConditionInflatedString}");
            var currentPossibilities = GetPossibilities(springConditionInflatedString, damagedSpringList, memo);
            // Console.WriteLine($"Possibilities: {currentPossibilities}");
            totalSumPossibilities += currentPossibilities;
        }

        return totalSumPossibilities;
    }

    public static long GetPossibilities(string springConditionString, List<int> damagedSpringList, Dictionary<string, long> memo)
    {
        var key = springConditionString + "," + string.Join(",", damagedSpringList);
        if (memo.ContainsKey(key)) // Exists in memo
            return memo[key];
        
        var possibilities = CountPossibilities(springConditionString, damagedSpringList, memo);
        memo[key] = possibilities;

        return possibilities;
    }

    public static long CountPossibilities(string springConditionString, List<int> damagedSpringList, Dictionary<string, long> memo)
    {
        bool isStringEmpty = false;
        var tempString = "";
        var tempList = new List<int>();
        while (!isStringEmpty)
        {
            if (damagedSpringList.Count() == 0) // Group is empty
            {
                if (springConditionString.Contains('#')) // Exists damaged spring
                    return 0;
                else
                    return 1; // Remaining springs are operational
            }

            if (springConditionString.Length == 0)
                return 0; // No more spring condition to check

            if (springConditionString[0] == '.') // Spring conditions start with operational
            {
                springConditionString = springConditionString.Trim('.'); // Remove operation springs at the beginning and at the end
                continue;
            }

            if (springConditionString[0] == '?') // Spring conditions start with either operational or damaged
            {
                var remainingString = "";
                for (int i = 1; i < springConditionString.Length; i++)
                    remainingString += springConditionString[i];

                // Get possibilities beginning with .
                tempString = "." + remainingString;
                var dotPossibilities = GetPossibilities(tempString, damagedSpringList, memo);

                // Get possibilities beginning with #
                tempString = "#" + remainingString;
                var hashPossibilities = GetPossibilities(tempString, damagedSpringList, memo);

                return dotPossibilities + hashPossibilities;
            }

            if (springConditionString[0] == '#') // Spring conditions start with damaged
            {
                var firstDamagedCount = damagedSpringList[0];
                if (damagedSpringList.Count() == 0) // Group is empty
                    return 0; // Not possible since there still exists damaged springs

                if (springConditionString.Length < firstDamagedCount)
                    return 0; // Cannot fit to the damaged string group

                for (int i = 0; i < firstDamagedCount; i++)
                    if (springConditionString[i] == '.')
                        return 0; // Damage group length < damage count

                if (damagedSpringList.Count() > 1) // Exists next damage count
                {
                    if (springConditionString.Length < firstDamagedCount + 1)
                        return 0; // Not enough condition chars to fit damage count
                    
                    if (springConditionString[firstDamagedCount] == '#')
                        return 0; // Two damage count groups must be separated by . or ?

                    // Jump to next damage group count
                    tempString = "";
                    for (int i = firstDamagedCount+1; i < springConditionString.Length; i++)
                        tempString += springConditionString[i];
                    springConditionString = tempString;

                    // Remove first group count from the list
                    tempList = new List<int>();
                    for (int i = 1; i < damagedSpringList.Count(); i++)
                        tempList.Add(damagedSpringList[i]);
                    damagedSpringList = tempList;

                    continue;
                }

                // Jump to next damage group count
                tempString = "";
                for (int i = firstDamagedCount; i < springConditionString.Length; i++)
                    tempString += springConditionString[i];
                springConditionString = tempString;

                // Remove first group count from the list
                tempList = new List<int>();
                for (int i = 1; i < damagedSpringList.Count(); i++)
                    tempList.Add(damagedSpringList[i]);
                damagedSpringList = tempList;

                continue;
            }
        }

        return -999999999;
    }
}
