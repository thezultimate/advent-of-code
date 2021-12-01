using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Problem;
public class Problem
{
    public static long ProblemPart1(List<string> inputList)
    {
        var tileMap = new Dictionary<(int, int), HashSet<char>>();

        Traverse(0, 0, '>', tileMap, inputList);

        return tileMap.Count();
    }

    public static void Traverse(int y, int x, char direction, Dictionary<(int, int), HashSet<char>> tileMap, List<string> grid)
    {
        if (!tileMap.ContainsKey((y, x))) // This tile has not been traversed before, continue traversing
        {
            var directionSet = new HashSet<char>();
            directionSet.Add(direction);
            tileMap[(y, x)] = directionSet;
            goto ContinueTraverse;
        }

        if (tileMap.ContainsKey((y, x))) // This tile has been traversed before
        {
            var directionSet = tileMap[(y, x)];
            if (directionSet.Contains(direction)) // This tile has been traversed in this direction, stop traversing
                return;
            else // This tile has been traversed in other direction, continue traversing
            {
                directionSet.Add(direction);
                goto ContinueTraverse;
            }
        }

        ContinueTraverse:
        var currentTile = grid[y][x];

        // Left
        if (direction == '<')
        {
            if (currentTile == '.' || currentTile == '-')
                if (x-1 >= 0)
                    Traverse(y, x-1, direction, tileMap, grid); // Continue traverse in the same direction

            if (currentTile == '\\')
                if (y-1 >= 0)
                    Traverse(y-1, x, '^', tileMap, grid); // Continue traverse up

            if (currentTile == '/')
                if (y+1 < grid.Count())
                    Traverse(y+1, x, 'v', tileMap, grid); // Continue traverse down

            if (currentTile == '|')
            {
                if (y+1 < grid.Count())
                    Traverse(y+1, x, 'v', tileMap, grid); // Continue traverse down
                if (y-1 >= 0)
                    Traverse(y-1, x, '^', tileMap, grid); // Continue traverse up
            }
        }

        // Down
        if (direction == 'v')
        {
            if (currentTile == '.' || currentTile == '|')
                if (y+1 < grid.Count())
                    Traverse(y+1, x, direction, tileMap, grid); // Continue traverse in the same direction

            if (currentTile == '\\')
                if (x+1 < grid[0].Length)
                    Traverse(y, x+1, '>', tileMap, grid); // Continue traverse right

            if (currentTile == '/')
                if (x-1 >= 0)
                    Traverse(y, x-1, '<', tileMap, grid); // Continue traverse left

            if (currentTile == '-')
            {
                if (x-1 >= 0)
                    Traverse(y, x-1, '<', tileMap, grid); // Continue traverse left
                if (x+1 < grid[0].Length)
                    Traverse(y, x+1, '>', tileMap, grid); // Continue traverse right
            }
        }

        // Right
        if (direction == '>')
        {
            if (currentTile == '.' || currentTile == '-')
                if (x+1 < grid[0].Length)
                    Traverse(y, x+1, direction, tileMap, grid); // Continue traverse in the same direction

            if (currentTile == '\\')
                if (y+1 < grid.Count())
                    Traverse(y+1, x, 'v', tileMap, grid); // Continue traverse down

            if (currentTile == '/')
                if (y-1 >= 0)
                    Traverse(y-1, x, '^', tileMap, grid); // Continue traverse up

            if (currentTile == '|')
            {
                if (y+1 < grid.Count())
                    Traverse(y+1, x, 'v', tileMap, grid); // Continue traverse down
                if (y-1 >= 0)
                    Traverse(y-1, x, '^', tileMap, grid); // Continue traverse up
            }
        }

        // Up
        if (direction == '^')
        {
            if (currentTile == '.' || currentTile == '|')
                if (y-1 >= 0)
                    Traverse(y-1, x, direction, tileMap, grid); // Continue traverse in the same direction

            if (currentTile == '\\')
                if (x-1 >= 0)
                    Traverse(y, x-1, '<', tileMap, grid); // Continue traverse left

            if (currentTile == '/')
                if (x+1 < grid[0].Length)
                    Traverse(y, x+1, '>', tileMap, grid); // Continue traverse right

            if (currentTile == '-')
            {
                if (x-1 >= 0)
                    Traverse(y, x-1, '<', tileMap, grid); // Continue traverse left
                if (x+1 < grid[0].Length)
                    Traverse(y, x+1, '>', tileMap, grid); // Continue traverse right
            }
        }
    }

    public static long ProblemPart2(List<string> inputList)
    {
        long maxEnergizedCount = 0;

        // Enter from left-most column with direction >
        for (int i = 0; i < inputList.Count(); i++)
        {
            var tileMap = new Dictionary<(int, int), HashSet<char>>();
            Traverse(i, 0, '>', tileMap, inputList);
            if (tileMap.Count() > maxEnergizedCount)
                maxEnergizedCount = tileMap.Count();
        }

        // Enter from bottom row column with direction ^
        for (int i = 0; i < inputList.Count(); i++)
        {
            var tileMap = new Dictionary<(int, int), HashSet<char>>();
            Traverse(inputList.Count()-1, i, '^', tileMap, inputList);
            if (tileMap.Count() > maxEnergizedCount)
                maxEnergizedCount = tileMap.Count();
        }

        // Enter from right-most column with direction <
        for (int i = 0; i < inputList.Count(); i++)
        {
            var tileMap = new Dictionary<(int, int), HashSet<char>>();
            Traverse(i, inputList[0].Length-1, '<', tileMap, inputList);
            if (tileMap.Count() > maxEnergizedCount)
                maxEnergizedCount = tileMap.Count();
        }

        // Enter from top row column with direction v
        for (int i = 0; i < inputList.Count(); i++)
        {
            var tileMap = new Dictionary<(int, int), HashSet<char>>();
            Traverse(0, i, 'v', tileMap, inputList);
            if (tileMap.Count() > maxEnergizedCount)
                maxEnergizedCount = tileMap.Count();
        }

        return maxEnergizedCount;
    }
}
