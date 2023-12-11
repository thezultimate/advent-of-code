using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace Problem;
public class Problem
{
    public static int ProblemPart1(List<string> inputList)
    {
        var emptyColumnSet = new HashSet<int>(); // For checking x
        var emptyRowSet = new HashSet<int>(); // For checking y
        var galaxyCoordinateList = new List<(int, int)>();

        // Find empty rows and columns
        for (int y = 0; y < inputList.Count(); y++)
        {
            var dotCountRow = 0;
            var dotCountColumn = 0;
            for (int x = 0; x < inputList[0].Length; x++)
            {
                if (inputList[y][x] == '.')
                    dotCountRow++;
                if (inputList[x][y] == '.')
                    dotCountColumn++;
            }
            if (dotCountRow == inputList[0].Length)
                emptyRowSet.Add(y);
            if (dotCountColumn == inputList.Count())
                emptyColumnSet.Add(y);
        }

        // Add galaxies to a list
        for (int y = 0; y < inputList.Count(); y++)
            for (int x = 0; x < inputList[0].Length; x++)
                if (inputList[y][x] == '#')
                    galaxyCoordinateList.Add((y, x));

        // Calculate min distance of each pair of galaxy coordinates
        var sumMinDistance = 0;
        for (int i = 0; i < galaxyCoordinateList.Count()-1; i++)
            for (int j = i+1; j < galaxyCoordinateList.Count(); j++)
            {
                var (firstY, firstX) = galaxyCoordinateList[i];
                var (secondY, secondX) = galaxyCoordinateList[j];
                var minDistance = Math.Abs(secondX - firstX) + Math.Abs(secondY - firstY);
                
                // Add columns due to expansion
                var startColumn = firstX;
                var endColumn = secondX;
                if (secondX < firstX)
                {
                    startColumn = secondX;
                    endColumn = firstX;
                }
                for (int k = startColumn; k <= endColumn; k++)
                    if (emptyColumnSet.Contains(k))
                        minDistance++;

                // Add rows due to expansion
                var startRow = firstY;
                var endRow = secondY;
                if (secondY < firstY)
                {
                    startRow = secondY;
                    endRow = firstY;
                }
                for (int k = startRow; k <= endRow; k++)
                    if (emptyRowSet.Contains(k))
                        minDistance++;

                // Add total min distance
                sumMinDistance += minDistance;
            }

        return sumMinDistance;
    }

    public static long ProblemPart2(List<string> inputList, int expansionFactor)
    {
        var emptyColumnSet = new HashSet<int>(); // For checking x
        var emptyRowSet = new HashSet<int>(); // For checking y
        var galaxyCoordinateList = new List<(int, int)>();

        // Find empty rows and columns
        for (int y = 0; y < inputList.Count(); y++)
        {
            var dotCountRow = 0;
            var dotCountColumn = 0;
            for (int x = 0; x < inputList[0].Length; x++)
            {
                if (inputList[y][x] == '.')
                    dotCountRow++;
                if (inputList[x][y] == '.')
                    dotCountColumn++;
            }
            if (dotCountRow == inputList[0].Length)
                emptyRowSet.Add(y);
            if (dotCountColumn == inputList.Count())
                emptyColumnSet.Add(y);
        }

        // Add galaxies to a list
        for (int y = 0; y < inputList.Count(); y++)
            for (int x = 0; x < inputList[0].Length; x++)
                if (inputList[y][x] == '#')
                    galaxyCoordinateList.Add((y, x));

        // Calculate min distance of each pair of galaxy coordinates
        long sumMinDistance = 0;
        for (int i = 0; i < galaxyCoordinateList.Count()-1; i++)
            for (int j = i+1; j < galaxyCoordinateList.Count(); j++)
            {
                var (firstY, firstX) = galaxyCoordinateList[i];
                var (secondY, secondX) = galaxyCoordinateList[j];
                long minDistance = Math.Abs(secondX - firstX) + Math.Abs(secondY - firstY);
                
                // Add columns due to expansion
                var startColumn = firstX;
                var endColumn = secondX;
                if (secondX < firstX)
                {
                    startColumn = secondX;
                    endColumn = firstX;
                }
                for (int k = startColumn; k <= endColumn; k++)
                    if (emptyColumnSet.Contains(k))
                        minDistance += expansionFactor-1;

                // Add rows due to expansion
                var startRow = firstY;
                var endRow = secondY;
                if (secondY < firstY)
                {
                    startRow = secondY;
                    endRow = firstY;
                }
                for (int k = startRow; k <= endRow; k++)
                    if (emptyRowSet.Contains(k))
                        minDistance += expansionFactor-1;

                // Add total min distance
                sumMinDistance += minDistance;
            }

        return sumMinDistance;
    }
}
