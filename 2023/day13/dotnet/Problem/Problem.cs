using System.Diagnostics.Metrics;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Problem;
public class Problem
{
    public static long ProblemPart1(List<string> inputList)
    {
        long verticalCount = 0;
        long horizontalCount = 0;
        bool patternFound = false;
        var stepsFromTop = 1;
        var stepsFromLeft = 1;

        var currentPattern = new List<string>();
        for (var line = 0; line < inputList.Count(); line++)
        {
            if (inputList[line].Length > 0)
            {
                currentPattern.Add(inputList[line]);
            }
            else
            {
                // Calculate a pattern
                patternFound = false;
        
                // Check horizontal mirror first
                stepsFromTop = 1;
                for (int i = 0; i < currentPattern.Count()-1; i++) // Iterate through possible mirrors
                {
                    var steps = stepsFromTop;
                    var stepsFromBottom = currentPattern.Count() - stepsFromTop;
                    if (stepsFromBottom < stepsFromTop)
                        steps = stepsFromBottom;
                    var equalCount = 0;
                    for (int j = 1; j <= steps; j++)
                    {
                        var prevLine = currentPattern[i+1-j];
                        var nextLine = currentPattern[i+j];
                        if (!prevLine.Equals(nextLine)) // Two horizontal lines not equal
                        {
                            stepsFromTop++;
                            break;
                        }
                        else
                            equalCount++;
                    }
                    if (equalCount == steps) // Found the mirror
                    {
                        patternFound = true;
                        horizontalCount += stepsFromTop;
                        stepsFromTop = 1;
                        break;
                    }
                }

                // Check vertical mirrors if horizontal mirror doesn't exist
                if (!patternFound)
                {
                    stepsFromLeft = 1;
                    for (int i = 0; i < currentPattern[0].Length-1; i++) // Iterate through possible mirrors
                    {
                        var steps = stepsFromLeft;
                        var stepsFromRight = currentPattern[0].Length - stepsFromLeft;
                        if (stepsFromRight < stepsFromLeft)
                            steps = stepsFromRight;
                        var equalCount = 0;
                        for (int j = 1; j <= steps; j++)
                        {
                            var prevLineIndex = i+1-j;
                            var nextLineIndex = i+j;
                            if (!AreTwoLinesEqual(currentPattern, prevLineIndex, nextLineIndex)) // Two vertical lines not equal
                            {
                                stepsFromLeft++;
                                break;
                            }
                            else
                                equalCount++;
                        }
                        if (equalCount == steps) // Found the mirror
                        {
                            patternFound = true;
                            verticalCount += stepsFromLeft;
                            stepsFromLeft = 1;
                            break;
                        }
                    }
                }

                currentPattern = new List<string>();
            }
        }

        // The last pattern
        // Calculate a pattern
        patternFound = false;
        
        // Check horizontal first
        stepsFromTop = 1;
        for (int i = 0; i < currentPattern.Count()-1; i++) // Iterate through possible mirrors
        {
            var steps = stepsFromTop;
            var stepsFromBottom = currentPattern.Count() - stepsFromTop;
            if (stepsFromBottom < stepsFromTop)
                steps = stepsFromBottom;
            var equalCount = 0;
            for (int j = 1; j <= steps; j++)
            {
                var prevLine = currentPattern[i+1-j];
                var nextLine = currentPattern[i+j];
                if (!prevLine.Equals(nextLine)) // Two horizontal lines not equal
                {
                    stepsFromTop++;
                    break;
                }
                else
                    equalCount++;
            }
            if (equalCount == steps) // Found the mirror
            {
                patternFound = true;
                horizontalCount += stepsFromTop;
                stepsFromTop = 1;
                break;
            }
        }

        // Check vertical mirrors if horizontal mirror doesn't exist
        if (!patternFound)
        {
            stepsFromLeft = 1;
            for (int i = 0; i < currentPattern[0].Length-1; i++) // Iterate through possible mirrors
            {
                var steps = stepsFromLeft;
                var stepsFromRight = currentPattern[0].Length - stepsFromLeft;
                if (stepsFromRight < stepsFromLeft)
                    steps = stepsFromRight;
                var equalCount = 0;
                for (int j = 1; j <= steps; j++)
                {
                    var prevLineIndex = i+1-j;
                    var nextLineIndex = i+j;
                    if (!AreTwoLinesEqual(currentPattern, prevLineIndex, nextLineIndex)) // Two vertical lines not equal
                    {
                        stepsFromLeft++;
                        break;
                    }
                    else
                        equalCount++;
                }
                if (equalCount == steps) // Found the mirror
                {
                    patternFound = true;
                    verticalCount += stepsFromLeft;
                    stepsFromLeft = 1;
                    break;
                }
            }
        }
        
        currentPattern = new List<string>();

        var totalSum = (100 * horizontalCount) + verticalCount;
        return totalSum;
    }

    public static bool AreTwoLinesEqual(List<string> pattern, int aIndex, int bIndex)
    {
        var equalCounter = 0;
        for (int i = 0; i < pattern.Count(); i++)
        {
            var aItem = pattern[i][aIndex];
            var bItem = pattern[i][bIndex];
            if (aItem != bItem) // Not equal, quit exit
                return false;
            
            // Equals
            equalCounter++;
        }
        if (equalCounter == pattern.Count())
            return true;

        return false;
    }

    public static bool AreTwoLinesEqualCharArr(List<char[]> pattern, int aIndex, int bIndex)
    {
        var equalCounter = 0;
        for (int i = 0; i < pattern.Count(); i++)
        {
            var aItem = pattern[i][aIndex];
            var bItem = pattern[i][bIndex];
            if (aItem != bItem) // Not equal, quit exit
                return false;
            
            // Equals
            equalCounter++;
        }
        if (equalCounter == pattern.Count())
            return true;

        return false;
    }

    public static long ProblemPart2(List<string> inputList)
    {
        var newMirrorSet = new HashSet<string>();
        long verticalCount = 0;
        long horizontalCount = 0;
        string currentOldMirror = "";

        var currentPattern = new List<char[]>();
        for (var line = 0; line < inputList.Count(); line++)
        {
            if (inputList[line].Length > 0)
            {
                currentPattern.Add(inputList[line].ToCharArray());
            }
            else
            {
                // Old mirror of this pattern
                currentOldMirror = GetCurrentOldMirror(currentPattern);

                // Flip each char and calculate a pattern
                for (int y = 0; y < currentPattern.Count(); y++)
                {
                    for (int x = 0; x < currentPattern[0].Length; x++)
                    {
                        // Flip current char in current pattern
                        var currentChar = currentPattern[y][x];
                        var flippedChar = currentChar;
                        if (currentChar == '#')
                            flippedChar = '.';
                        if (currentChar == '.')
                            flippedChar = '#';
                        currentPattern[y][x] = flippedChar;

                        // Calculate if there is a new mirror
                        bool patternFound = false;

                        // Check horizontal first
                        int stepsFromTop = 1;
                        for (int i = 0; i < currentPattern.Count()-1; i++) // Iterate through possible mirrors
                        {
                            var steps = stepsFromTop;
                            var stepsFromBottom = currentPattern.Count() - stepsFromTop;
                            if (stepsFromBottom < stepsFromTop)
                                steps = stepsFromBottom;
                            var equalCount = 0;
                            for (int j = 1; j <= steps; j++)
                            {
                                var prevLine = new string(currentPattern[i+1-j]);
                                var nextLine = new string(currentPattern[i+j]);
                                if (!prevLine.Equals(nextLine)) // Two horizontal lines not equal
                                {
                                    stepsFromTop++;
                                    break;
                                }
                                else
                                    equalCount++;
                            }
                            if (equalCount == steps) // Found a mirror
                            {
                                if (!currentOldMirror.Equals("H," + stepsFromTop)) // Found new horizontal mirror
                                {
                                    patternFound = true;
                                    horizontalCount += stepsFromTop;
                                    newMirrorSet.Add("H," + stepsFromTop);
                                    stepsFromTop = 1;
                                    goto FoundNewPattern;
                                };
                                if (currentOldMirror.Equals("H," + stepsFromTop)) // Found old horizontal mirror
                                {
                                    stepsFromTop++;
                                }
                            }
                        }

                        // Check vertical mirrors if horizontal mirror doesn't exist
                        if (!patternFound)
                        {
                            int stepsFromLeft = 1;
                            for (int i = 0; i < currentPattern[0].Length-1; i++) // Iterate through possible mirrors
                            {
                                var steps = stepsFromLeft;
                                var stepsFromRight = currentPattern[0].Length - stepsFromLeft;
                                if (stepsFromRight < stepsFromLeft)
                                    steps = stepsFromRight;
                                var equalCount = 0;
                                for (int j = 1; j <= steps; j++)
                                {
                                    var prevLineIndex = i+1-j;
                                    var nextLineIndex = i+j;
                                    if (!AreTwoLinesEqualCharArr(currentPattern, prevLineIndex, nextLineIndex)) // Two vertical lines not equal
                                    {
                                        stepsFromLeft++;
                                        break;
                                    }
                                    else
                                        equalCount++;
                                }
                                if (equalCount == steps) // Found a mirror
                                {
                                    if (!currentOldMirror.Equals("V," + stepsFromLeft)) // Found new vertical mirror
                                    {
                                        patternFound = true;
                                        verticalCount += stepsFromLeft;
                                        newMirrorSet.Add("V," + stepsFromLeft);
                                        stepsFromLeft = 1;
                                        goto FoundNewPattern;
                                    }
                                    if (currentOldMirror.Equals("V," + stepsFromLeft)) // Found old vertical mirror
                                    {
                                        stepsFromLeft++;
                                    }
                                }
                            }
                        }

                        // Return flipped char to current char
                        currentPattern[y][x] = currentChar; 
                    }
                }

                FoundNewPattern:
                currentPattern = new List<char[]>();
            }
            
        }

        // The last pattern
        // Old mirror of this pattern
        currentOldMirror = GetCurrentOldMirror(currentPattern);

        // Flip each char and calculate a pattern
        for (int y = 0; y < currentPattern.Count(); y++)
        {
            for (int x = 0; x < currentPattern[0].Length; x++)
            {
                // Flip current char in current pattern
                var currentChar = currentPattern[y][x];
                var flippedChar = currentChar;
                if (currentChar == '#')
                    flippedChar = '.';
                if (currentChar == '.')
                    flippedChar = '#';
                currentPattern[y][x] = flippedChar;

                // Calculate if there is a new mirror
                bool patternFound = false;

                // Check horizontal first
                int stepsFromTop = 1;
                for (int i = 0; i < currentPattern.Count()-1; i++) // Iterate through possible mirrors
                {
                    var steps = stepsFromTop;
                    var stepsFromBottom = currentPattern.Count() - stepsFromTop;
                    if (stepsFromBottom < stepsFromTop)
                        steps = stepsFromBottom;
                    var equalCount = 0;
                    for (int j = 1; j <= steps; j++)
                    {
                        var prevLine = new string(currentPattern[i+1-j]);
                        var nextLine = new string(currentPattern[i+j]);
                        if (!prevLine.Equals(nextLine)) // Two horizontal lines not equal
                        {
                            stepsFromTop++;
                            break;
                        }
                        else
                            equalCount++;
                    }
                    if (equalCount == steps) // Found a mirror
                    {
                        if (!currentOldMirror.Equals("H," + stepsFromTop)) // Found new horizontal mirror
                        {
                            patternFound = true;
                            horizontalCount += stepsFromTop;
                            newMirrorSet.Add("H," + stepsFromTop);
                            stepsFromTop = 1;
                            goto FoundNewPatternLast;
                        };
                        if (currentOldMirror.Equals("H," + stepsFromTop)) // Found old horizontal mirror
                        {
                            stepsFromTop++;
                        }
                    }
                }

                // Check vertical mirrors if horizontal mirror doesn't exist
                if (!patternFound)
                {
                    int stepsFromLeft = 1;
                    for (int i = 0; i < currentPattern[0].Length-1; i++) // Iterate through possible mirrors
                    {
                        var steps = stepsFromLeft;
                        var stepsFromRight = currentPattern[0].Length - stepsFromLeft;
                        if (stepsFromRight < stepsFromLeft)
                            steps = stepsFromRight;
                        var equalCount = 0;
                        for (int j = 1; j <= steps; j++)
                        {
                            var prevLineIndex = i+1-j;
                            var nextLineIndex = i+j;
                            if (!AreTwoLinesEqualCharArr(currentPattern, prevLineIndex, nextLineIndex)) // Two vertical lines not equal
                            {
                                stepsFromLeft++;
                                break;
                            }
                            else
                                equalCount++;
                        }
                        if (equalCount == steps) // Found a mirror
                        {
                            if (!currentOldMirror.Equals("V," + stepsFromLeft)) // Found new vertical mirror
                            {
                                patternFound = true;
                                verticalCount += stepsFromLeft;
                                newMirrorSet.Add("V," + stepsFromLeft);
                                stepsFromLeft = 1;
                                goto FoundNewPatternLast;
                            }
                            if (currentOldMirror.Equals("V," + stepsFromLeft)) // Found old vertical mirror
                            {
                                stepsFromLeft++;
                            }
                        }
                    }
                }

                // Return flipped char to current char
                currentPattern[y][x] = currentChar; 
            }
        }

        FoundNewPatternLast:
        currentPattern = new List<char[]>();

        var totalSum = (100 * horizontalCount) + verticalCount;
        return totalSum;

        // return 400;
    }

    public static string GetCurrentOldMirror(List<char[]> currentPattern)
    {
        // Calculate a pattern
        bool patternFound = false;

        // Check horizontal mirror first
        int stepsFromTop = 1;
        for (int i = 0; i < currentPattern.Count()-1; i++) // Iterate through possible mirrors
        {
            var steps = stepsFromTop;
            var stepsFromBottom = currentPattern.Count() - stepsFromTop;
            if (stepsFromBottom < stepsFromTop)
                steps = stepsFromBottom;
            var equalCount = 0;
            for (int j = 1; j <= steps; j++)
            {
                var prevLine = new string(currentPattern[i+1-j]);
                var nextLine = new string(currentPattern[i+j]);
                if (!prevLine.Equals(nextLine)) // Two horizontal lines not equal
                {
                    stepsFromTop++;
                    break;
                }
                else
                    equalCount++;
            }
            if (equalCount == steps) // Found the mirror
            {
                patternFound = true;
                return "H," + stepsFromTop;
                stepsFromTop = 1;
                break;
            }
        }

        // Check vertical mirrors if horizontal mirror doesn't exist
        if (!patternFound)
        {
            int stepsFromLeft = 1;
            for (int i = 0; i < currentPattern[0].Length-1; i++) // Iterate through possible mirrors
            {
                var steps = stepsFromLeft;
                var stepsFromRight = currentPattern[0].Length - stepsFromLeft;
                if (stepsFromRight < stepsFromLeft)
                    steps = stepsFromRight;
                var equalCount = 0;
                for (int j = 1; j <= steps; j++)
                {
                    var prevLineIndex = i+1-j;
                    var nextLineIndex = i+j;
                    if (!AreTwoLinesEqualCharArr(currentPattern, prevLineIndex, nextLineIndex)) // Two vertical lines not equal
                    {
                        stepsFromLeft++;
                        break;
                    }
                    else
                        equalCount++;
                }
                if (equalCount == steps) // Found the mirror
                {
                    patternFound = true;
                    return "V," + stepsFromLeft;
                    stepsFromLeft = 1;
                    break;
                }
            }
        }

        return "";
    }
}
