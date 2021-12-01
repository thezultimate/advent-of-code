using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace Problem;
public class Problem
{
    public static long ProblemPart1(List<string> inputList, long steps)
    {
        // Find S coordinate
        var startCoordinate = (-1, -1);
        for (int y = 0; y < inputList.Count(); y++)
            for (int x = 0; x < inputList[0].Length; x++)
                if (inputList[y][x] == 'S')
                    startCoordinate = (y, x);

        // BFS with max depth steps
        long totalPossibilities = TraverseGarden(startCoordinate, steps, inputList);

        return totalPossibilities;
    }

    public static long TraverseGarden((int, int) startCoordinate, long maxDepth, List<string> inputList)
    {
        var alreadyTraversedSet = new HashSet<(int, int)>();
        var evenStepTraversedSet = new HashSet<(int, int)>();
        
        var Q = new Queue<(int, int, int)>(); // (y, x, depth)
        Q.Enqueue((startCoordinate.Item1, startCoordinate.Item2, 0));
        alreadyTraversedSet.Add((startCoordinate.Item1, startCoordinate.Item2));
        evenStepTraversedSet.Add((startCoordinate.Item1, startCoordinate.Item2));

        while (Q.Count() > 0)
        {
            var currentCoordinate = Q.Dequeue();
            int y = currentCoordinate.Item1;
            int x = currentCoordinate.Item2;
            int currentDepth = currentCoordinate.Item3;
            int nextDepth = currentDepth + 1;
            if (nextDepth <= maxDepth) // Don't enqueue if next depth is > maxDepth
            {
                // Left
                if (x-1 >= 0)
                {
                    if (inputList[y][x-1] != '#') // Left is not a rock
                        if (!alreadyTraversedSet.Contains((y, x-1)))
                        {
                            alreadyTraversedSet.Add((y, x-1));
                            if (nextDepth % 2 == 0)
                                evenStepTraversedSet.Add((y, x-1));
                            Q.Enqueue((y, x-1, nextDepth));
                        }
                }

                // Down
                if (y+1 < inputList.Count())
                {
                    if (inputList[y+1][x] != '#') // Down is not a rock
                        if (!alreadyTraversedSet.Contains((y+1, x)))
                        {
                            alreadyTraversedSet.Add((y+1, x));
                            if (nextDepth % 2 == 0)
                                evenStepTraversedSet.Add((y+1, x));
                            Q.Enqueue((y+1, x, nextDepth));
                        }
                }

                // Right
                if (x+1 < inputList[0].Length)
                {
                    if (inputList[y][x+1] != '#') // Right is not a rock
                        if (!alreadyTraversedSet.Contains((y, x+1)))
                        {
                            alreadyTraversedSet.Add((y, x+1));
                            if (nextDepth % 2 == 0)
                                evenStepTraversedSet.Add((y, x+1));
                            Q.Enqueue((y, x+1, nextDepth));
                        }
                }

                // Up
                if (y-1 >= 0)
                {
                    if (inputList[y-1][x] != '#') // Up is not a rock
                        if (!alreadyTraversedSet.Contains((y-1, x)))
                        {
                            alreadyTraversedSet.Contains((y-1, x));
                            if (nextDepth % 2 == 0)
                                evenStepTraversedSet.Add((y-1, x));
                            Q.Enqueue((y-1, x, nextDepth));
                        }
                }
            }
        }

        return evenStepTraversedSet.Count();
    }

    public static long ProblemPart2(List<string> inputList, long steps)
    {
        long originalGridLength = inputList.Count();

        long expansionFactor = 5; // Odd number
        var inputListExpanded = ExpandInput(inputList, expansionFactor);

        // Find S coordinate
        long middleGrid = (expansionFactor * expansionFactor / 2) + 1;
        long gridCounter = 0;
        var startCoordinate = (-1, -1);
        for (int y = 0; y < inputListExpanded.Count(); y++)
            for (int x = 0; x < inputListExpanded[0].Length; x++)
                if (inputListExpanded[y][x] == 'S')
                {
                    gridCounter++;
                    if (gridCounter == middleGrid)
                        startCoordinate = (y, x);
                }

        // y = ax^2 + bx +c
        long x0 = steps % originalGridLength;
        long x1 = x0 + originalGridLength;
        long x2 = x0 + (originalGridLength * 2);
        long y0 = TraverseGarden2(startCoordinate, x0, inputListExpanded);
        long y1 = TraverseGarden2(startCoordinate, x1, inputListExpanded);
        long y2 = TraverseGarden2(startCoordinate, x2, inputListExpanded);

        long xNormalised = steps / originalGridLength; // The input is scaled/normalised by the original grid length
        double a = (y2 + y0 - (2 * y1)) / 2;
        double b = y1 - y0 - a;
        double c = y0;
        double result = (a * xNormalised * xNormalised) + (b * xNormalised) + c;

        return (long) result;
    }

    public static List<string> ExpandInput(List<string> inputList, long expansionFactor)
    {
        var inputListExpanded = new List<string>();
        var inputListExpandedHorizontal = new List<string>();
        
        foreach (var line in inputList)
        {
            string expandedLine = "";
            for (int i = 0; i < expansionFactor; i++)
                expandedLine += line;
            inputListExpandedHorizontal.Add(expandedLine);
        }

        for (int i = 0; i < expansionFactor; i++)
        {
            foreach (var expandedLine in inputListExpandedHorizontal)
                inputListExpanded.Add(expandedLine);
        }

        return inputListExpanded;
    }

    public static long TraverseGarden2((int, int) startCoordinate, long maxDepth, List<string> inputList)
    {
        var alreadyTraversedSet = new HashSet<(int, int)>();
        var evenStepTraversedSet = new HashSet<(int, int)>();
        var oddStepTraversedSet = new HashSet<(int, int)>();
        
        var Q = new Queue<(int, int, int)>(); // (y, x, depth)
        Q.Enqueue((startCoordinate.Item1, startCoordinate.Item2, 0));
        alreadyTraversedSet.Add((startCoordinate.Item1, startCoordinate.Item2));
        evenStepTraversedSet.Add((startCoordinate.Item1, startCoordinate.Item2));

        while (Q.Count() > 0)
        {
            var currentCoordinate = Q.Dequeue();
            int y = currentCoordinate.Item1;
            int x = currentCoordinate.Item2;
            int currentDepth = currentCoordinate.Item3;
            int nextDepth = currentDepth + 1;
            if (nextDepth <= maxDepth) // Don't enqueue if next depth is > maxDepth
            {
                // Left
                if (x-1 >= 0)
                {
                    if (inputList[y][x-1] != '#') // Left is not a rock
                        if (!alreadyTraversedSet.Contains((y, x-1)))
                        {
                            alreadyTraversedSet.Add((y, x-1));
                            if (nextDepth % 2 == 0)
                                evenStepTraversedSet.Add((y, x-1));
                            else
                                oddStepTraversedSet.Add((y, x-1));
                            Q.Enqueue((y, x-1, nextDepth));
                        }
                }

                // Down
                if (y+1 < inputList.Count())
                {
                    if (inputList[y+1][x] != '#') // Down is not a rock
                        if (!alreadyTraversedSet.Contains((y+1, x)))
                        {
                            alreadyTraversedSet.Add((y+1, x));
                            if (nextDepth % 2 == 0)
                                evenStepTraversedSet.Add((y+1, x));
                            else
                                oddStepTraversedSet.Add((y+1, x));
                            Q.Enqueue((y+1, x, nextDepth));
                        }
                }

                // Right
                if (x+1 < inputList[0].Length)
                {
                    if (inputList[y][x+1] != '#') // Right is not a rock
                        if (!alreadyTraversedSet.Contains((y, x+1)))
                        {
                            alreadyTraversedSet.Add((y, x+1));
                            if (nextDepth % 2 == 0)
                                evenStepTraversedSet.Add((y, x+1));
                            else
                                oddStepTraversedSet.Add((y, x+1));
                            Q.Enqueue((y, x+1, nextDepth));
                        }
                }

                // Up
                if (y-1 >= 0)
                {
                    if (inputList[y-1][x] != '#') // Up is not a rock
                        if (!alreadyTraversedSet.Contains((y-1, x)))
                        {
                            alreadyTraversedSet.Contains((y-1, x));
                            if (nextDepth % 2 == 0)
                                evenStepTraversedSet.Add((y-1, x));
                            else
                                oddStepTraversedSet.Add((y-1, x));
                            Q.Enqueue((y-1, x, nextDepth));
                        }
                }
            }
        }

        if (maxDepth % 2 == 0)
            return evenStepTraversedSet.Count();
        else
            return oddStepTraversedSet.Count();
    }
}
