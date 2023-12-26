using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace Problem;
public class Problem
{
    public static long ProblemPart1(List<string> inputList)
    {
        var brickList = new List<(long, long, long, long, long, long)>();

        foreach (var line in inputList)
        {
            var lineSplit = line.Split("~");
            var startRange = lineSplit[0].Split(",");
            var endRange = lineSplit[1].Split(",");
            var brick = (
                long.Parse(startRange[0]), long.Parse(endRange[0]), // x
                long.Parse(startRange[1]), long.Parse(endRange[1]), // y
                long.Parse(startRange[2]), long.Parse(endRange[2]) // z
            );
            brickList.Add(brick);
        }

        var brickListSortedByZAscending = brickList.OrderBy(x => x.Item5).ToList();

        for (int i = 0; i < brickListSortedByZAscending.Count(); i++)
        {
            if (brickListSortedByZAscending[i].Item5 > 1) // Iterate through bricks that are not on the ground
            {
                var currentBrick = brickListSortedByZAscending[i];
                long zBelow = currentBrick.Item5-1;
                while (zBelow >= 1)
                {
                    bool isBlocked = false;
                    for (int j = i-1; j >= 0; j--) // Iterate through below bricks, check if any is blocking
                    {
                        var previousBrick = brickListSortedByZAscending[j];
                        if (IsBrickBlocking(previousBrick, currentBrick))
                        {
                            isBlocked = true;
                            break; // Previous brick is blocking
                        }
                    }

                    if (isBlocked)
                        break;

                    // Current brick is not blocked, move down one level
                    currentBrick = (currentBrick.Item1, currentBrick.Item2, currentBrick.Item3, currentBrick.Item4, 
                        currentBrick.Item5-1, currentBrick.Item6-1);
                    brickListSortedByZAscending[i] = currentBrick;
                    zBelow--;
                }
            }
        }

        long bricksSafeToDisintegrate = 1; // The last one is the top, safe to disintegrate

        for (int i = 0; i < brickListSortedByZAscending.Count()-1; i++) // Iterate through bricks from the lowest to be removed, the last one is assumed to be free
        {
            bool isCurrentBrickSafeToDisintegrate = true;
            for (int j = i+1; j < brickListSortedByZAscending.Count(); j++) // Iterate through all bricks one level above
            {
                if (CanFallDown(j, i, brickListSortedByZAscending)) // Check if brick at j can fall down if brick at i is removed
                {
                    isCurrentBrickSafeToDisintegrate = false;
                    break;
                }
            }
            if (isCurrentBrickSafeToDisintegrate)
                bricksSafeToDisintegrate++;
        }

        return bricksSafeToDisintegrate;
    }

    public static bool CanFallDown(int nextBrickIndex, int brickRemovedIndex, List<(long, long, long, long, long, long)> brickListSortedByZAscending)
    {
        var nextBrick = brickListSortedByZAscending[nextBrickIndex];
        if (nextBrick.Item5 == 1)
            return false; // Next brick is standing on the floor
        
        for (int i = nextBrickIndex-1; i >= 0; i--)
        {
            if (i == brickRemovedIndex)
                continue; // Skip removed brick, it can@t block

            var potentialBlockingBrick = brickListSortedByZAscending[i];
            if (IsBrickBlocking(potentialBlockingBrick, nextBrick))
                return false;
        }

        return true;
    }

    public static bool IsBrickBlocking((long, long, long, long, long, long) previousBrick, (long, long, long, long, long, long) currentBrick)
    {
        // z must overlap to be blocking
        if (currentBrick.Item5 > previousBrick.Item6+1)
            return false; // Current brick is higher than previous brick

        // x and y must have overlap to be blocking
        bool xOverlap = false;
        if (currentBrick.Item2 >= previousBrick.Item1 && currentBrick.Item1 <= previousBrick.Item2)
            xOverlap = true;

        bool yOverlap = false;
        if (currentBrick.Item4 >= previousBrick.Item3 && currentBrick.Item3 <= previousBrick.Item4)
            yOverlap = true;

        return xOverlap && yOverlap;
    }

    public static long ProblemPart2(List<string> inputList)
    {
        return 0;
    }
}
