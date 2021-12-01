using System.Diagnostics.Metrics;
using System.Runtime.ExceptionServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;

namespace Problem;
public class Problem
{
    public static long ProblemPart1(List<string> inputList)
    {
        long totalLoadNorth = 0;

        // Convert input to list of char array
        var inputListCharArr = new List<char[]>();
        foreach (var line in inputList)
            inputListCharArr.Add(line.ToCharArray());

        // Iterate through each column
        for (int y = 0; y < inputListCharArr.Count(); y++)
        {
            for (int x = 0; x < inputListCharArr[0].Length; x++)
            {
                var currentItem = inputListCharArr[x][y];
                var currentLengthFromBottom = inputListCharArr.Count() - x;
                if (currentItem == 'O') // Current item is a rounded rock
                {
                    for (int i = x-1; i >= 0; i--) // Try to move the rock up
                    {
                        if (i < 0)
                            break;
                        {
                            if (inputListCharArr[i][y] != '.') // This coordinate is already occupied, don't move (exit loop)
                                break;
                            if (inputListCharArr[i][y] == '.') // Move the rock up
                            {
                                inputListCharArr[i][y] = 'O';
                                inputListCharArr[i+1][y] = '.';
                                inputListCharArr[x][y] = '.';
                                currentLengthFromBottom++;
                            }
                        }
                    }
                }
                if (currentItem == 'O')
                    totalLoadNorth += currentLengthFromBottom;
            }
        }

        return totalLoadNorth;
    }

    public static long ProblemPart2(List<string> inputList)
    {
        long cycle = 200; // Enough cycles to get delta repeated occurences
        var gridStringRepresentationMap = new Dictionary<string, List<long>>();

        // Convert input to list of char array
        var inputListCharArr = new List<char[]>();
        foreach (var line in inputList)
            inputListCharArr.Add(line.ToCharArray());

        for (long i = 1; i <= cycle; i++) // Run some cycles to get repeating state
        {
            RollNorth(inputListCharArr);
            RollWest(inputListCharArr);
            RollSouth(inputListCharArr);
            RollEast(inputListCharArr);

            var gridStringRepresentation = GetGridStringRepresentation(inputListCharArr);
            if (gridStringRepresentationMap.ContainsKey(gridStringRepresentation))
                gridStringRepresentationMap[gridStringRepresentation].Add(i);
            else
            {
                var cycleList = new List<long>();
                cycleList.Add(i);
                gridStringRepresentationMap[gridStringRepresentation] = cycleList;
            }
        }

        // Get the first repeating occurrence
        long deltaOccurrence = 0;
        long firstRepeatCycle = 0;
        foreach (var occurrence in gridStringRepresentationMap)
        {
            if (occurrence.Value.Count() > 1)
            {
                var firstOccurrence = occurrence.Value[0];
                var secondOccurrence = occurrence.Value[1];
                deltaOccurrence = secondOccurrence - firstOccurrence;
                firstRepeatCycle = firstOccurrence;
                break;
            }
        }

        long remainingCycle = (1000000000 - firstRepeatCycle) % deltaOccurrence;

        // Convert input to list of char array again for a fresh start
        inputListCharArr = new List<char[]>();
        foreach (var line in inputList)
            inputListCharArr.Add(line.ToCharArray());

        // Run cycles from the beginning until the first repeated occurrence
        for (long i = 1; i <= firstRepeatCycle; i++)
        {
            RollNorth(inputListCharArr);
            RollWest(inputListCharArr);
            RollSouth(inputListCharArr);
            RollEast(inputListCharArr);
        }

        // Run remaining cycles to 1000000000
        for (long i = 1; i <= remainingCycle; i++)
        {
            RollNorth(inputListCharArr);
            RollWest(inputListCharArr);
            RollSouth(inputListCharArr);
            RollEast(inputListCharArr);
        }

        long totalLoadNorth = GetNorthLoad(inputListCharArr);
        
        return totalLoadNorth;
    }

    public static string GetGridStringRepresentation(List<char[]> grid)
    {
        string stringRep = "";
        foreach (var line in grid)
            stringRep += string.Join("", line);
        return stringRep;
    }

    public static long GetNorthLoad(List<char[]> inputListCharArr)
    {
        long northLoad = 0;
        for (int y = 0; y < inputListCharArr.Count(); y++)
        {
            for (int x = 0; x < inputListCharArr[0].Length; x++)
            {
                var currentItem = inputListCharArr[x][y];
                if (currentItem == 'O')
                {
                    int lengthFromBottom = inputListCharArr.Count() - x;
                    northLoad += lengthFromBottom;
                }
            }
        }

        return northLoad;
    }

    public static void RollNorth(List<char[]> inputListCharArr)
    {
        for (int y = 0; y < inputListCharArr.Count(); y++)
        {
            for (int x = 0; x < inputListCharArr[0].Length; x++)
            {
                var currentItem = inputListCharArr[x][y];
                if (currentItem == 'O') // Current item is a rounded rock
                {
                    for (int i = x-1; i >= 0; i--) // Try to move the rock up
                    {
                        if (i < 0)
                            break;
                        {
                            if (inputListCharArr[i][y] != '.') // This coordinate is already occupied, don't move (exit loop)
                                break;
                            if (inputListCharArr[i][y] == '.') // Move the rock up
                            {
                                inputListCharArr[i][y] = 'O';
                                inputListCharArr[i+1][y] = '.';
                                inputListCharArr[x][y] = '.';
                            }
                        }
                    }
                }
            }
        }
    }

    public static void RollWest(List<char[]> inputListCharArr)
    {
        for (int y = 0; y < inputListCharArr.Count(); y++)
        {
            for (int x = 0; x < inputListCharArr[0].Length; x++)
            {
                var currentItem = inputListCharArr[y][x];
                if (currentItem == 'O') // Current item is a rounded rock
                {
                    for (int i = x-1; i >= 0; i--) // Try to move the rock left
                    {
                        if (i < 0)
                            break;
                        {
                            if (inputListCharArr[y][i] != '.') // This coordinate is already occupied, don't move (exit loop)
                                break;
                            if (inputListCharArr[y][i] == '.') // Move the rock left
                            {
                                inputListCharArr[y][i] = 'O';
                                inputListCharArr[y][i+1] = '.';
                                inputListCharArr[y][x] = '.';
                            }
                        }
                    }
                }
            }
        }
    }

    public static void RollSouth(List<char[]> inputListCharArr)
    {
        for (int y = 0; y < inputListCharArr.Count(); y++)
        {
            for (int x = inputListCharArr[0].Length-1; x >= 0; x--)
            {
                var currentItem = inputListCharArr[x][y];
                if (currentItem == 'O') // Current item is a rounded rock
                {
                    for (int i = x+1; i <= inputListCharArr.Count()-1; i++) // Try to move the rock down
                    {
                        if (i > inputListCharArr.Count()-1)
                            break;
                        {
                            if (inputListCharArr[i][y] != '.') // This coordinate is already occupied, don't move (exit loop)
                                break;
                            if (inputListCharArr[i][y] == '.') // Move the rock down
                            {
                                inputListCharArr[i][y] = 'O';
                                inputListCharArr[i-1][y] = '.';
                                inputListCharArr[x][y] = '.';
                            }
                        }
                    }
                }
            }
        }
    }

    public static void RollEast(List<char[]> inputListCharArr)
    {
        for (int y = 0; y < inputListCharArr.Count(); y++)
        {
            // for (int x = 0; x < inputListCharArr[0].Length; x++)
            for (int x = inputListCharArr[0].Length-1; x >= 0; x--)
            {
                var currentItem = inputListCharArr[y][x];
                if (currentItem == 'O') // Current item is a rounded rock
                {
                    // for (int i = x-1; i >= 0; i--) // Try to move the rock left
                    for (int i = x+1; i <= inputListCharArr[0].Length-1; i++) // Try to move the rock right
                    {
                        if (i > inputListCharArr[0].Length-1)
                            break;
                        {
                            if (inputListCharArr[y][i] != '.') // This coordinate is already occupied, don't move (exit loop)
                                break;
                            if (inputListCharArr[y][i] == '.') // Move the rock right
                            {
                                inputListCharArr[y][i] = 'O';
                                inputListCharArr[y][i-1] = '.';
                                inputListCharArr[y][x] = '.';
                            }
                        }
                    }
                }
            }
        }
    }
}
