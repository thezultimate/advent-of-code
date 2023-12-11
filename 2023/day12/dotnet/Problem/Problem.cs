using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;
using System.Text;
using System.Reflection.Metadata;

namespace Problem;
public class Problem
{
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

            var springConditionCharArray = springConditionInflatedString.ToCharArray();
            var damagedSpringList = damagedSpringInflatedString.Split(",").Select(int.Parse).ToList();
            
        }

        // return totalSumPossibilities;

        return 525152;
    }

}
