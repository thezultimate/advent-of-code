using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace Problem;
public class Problem
{
    public static long ProblemPart1(List<string> inputList)
    {
        long sum = 0;
        var steps = inputList[0].Split(",");
        foreach (var step in steps)
            sum += GetHashNumber(step);

        return sum;
    }

    public static int GetHashNumber(string aString)
    {
        var charAsciiNumber = new Dictionary<char, int>()
        {
            {'0', 48},
            {'1', 49},
            {'2', 50},
            {'3', 51},
            {'4', 52},
            {'5', 53},
            {'6', 54},
            {'7', 55},
            {'8', 56},
            {'9', 57},
            {'A', 65},
            {'B', 66},
            {'C', 67},
            {'D', 68},
            {'E', 69},
            {'F', 70},
            {'G', 71},
            {'H', 72},
            {'I', 73},
            {'J', 74},
            {'K', 75},
            {'L', 76},
            {'M', 77},
            {'N', 78},
            {'O', 79},
            {'P', 80},
            {'Q', 81},
            {'R', 82},
            {'S', 83},
            {'T', 84},
            {'U', 85},
            {'V', 86},
            {'W', 87},
            {'X', 88},
            {'Y', 89},
            {'Z', 90},
            {'a', 97},
            {'b', 98},
            {'c', 99},
            {'d', 100},
            {'e', 101},
            {'f', 102},
            {'g', 103},
            {'h', 104},
            {'i', 105},
            {'j', 106},
            {'k', 107},
            {'l', 108},
            {'m', 109},
            {'n', 110},
            {'o', 111},
            {'p', 112},
            {'q', 113},
            {'r', 114},
            {'s', 115},
            {'t', 116},
            {'u', 117},
            {'v', 118},
            {'w', 119},
            {'x', 120},
            {'y', 121},
            {'z', 122},
            {'=', 61},
            {'-', 45},
        };

        int currentValue = 0;
        foreach (var aChar in aString)
        {
            var currentAsciiNumber = charAsciiNumber[aChar];
            currentValue += currentAsciiNumber;
            currentValue *= 17;
            currentValue %= 256;
        }

        return currentValue;
    }

    public static long ProblemPart2(List<string> inputList)
    {
        // Create boxes
        var box = new List<List<(string, int)>>();
        for (int i = 0; i <= 255; i++)
            box.Add(new List<(string, int)>()); // Add empty list of lenses to the box

        var steps = inputList[0].Split(",");
        foreach (var step in steps)
        {
            if (step.Contains("=")) // Upsert lense to one of the boxes
            {
                var stepSplit = step.Split("=");
                var boxLabelString = stepSplit[0];
                var boxLabelNumber = GetHashNumber(boxLabelString);
                var focalLength = int.Parse(stepSplit[1]);
                var lenseList = box[boxLabelNumber];
                if (lenseList.Count() == 0) // Box is empty, add lense
                {
                    lenseList.Add((boxLabelString, focalLength));
                    continue;
                }
                bool lenseFound = false;
                for (int i = 0; i < lenseList.Count(); i++) // There are lenses in the box
                    if (lenseList[i].Item1 == boxLabelString) // Lense found
                    {
                        lenseList[i] = (boxLabelString, focalLength); // Update lense focal length
                        lenseFound = true;
                    }
                if (!lenseFound) // No current lense in the box, apend to the end of the list
                    lenseList.Add((boxLabelString, focalLength));
            }
            if (step.Contains("-")) // Remove lense if exists
            {
                var stepSplit = step.Split("-");
                var boxLabelString = stepSplit[0];
                var boxLabelNumber = GetHashNumber(boxLabelString);
                var lenseList = box[boxLabelNumber];
                if (lenseList.Count() > 0) // Box is not empty, check if it contains current lense
                {
                    bool lenseFound = false;
                    for (int i = 0; i < lenseList.Count(); i++) // There are lenses in the box
                    {
                        if (lenseList[i].Item1 == boxLabelString) // Lense found
                        {
                            lenseList.RemoveAt(i);
                            lenseFound = true;
                        }
                    }
                }
                    
            }
        }

        long sumFocusingPower = 0;
        for (int i = 0; i < box.Count(); i++)
        {
            var lenses = box[i];
            if (lenses.Count() == 0) // Empty box
                continue;
            
            for (int j = 0; j < lenses.Count(); j++)
                sumFocusingPower += (i+1) * (j+1) * lenses[j].Item2;
        }

        return sumFocusingPower;
    }
}
