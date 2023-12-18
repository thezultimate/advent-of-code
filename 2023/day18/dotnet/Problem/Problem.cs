using System.Diagnostics.Metrics;
using System.Net;
using System.Text.RegularExpressions;
using System.Drawing;

namespace Problem;
public class Problem
{
    public static long ProblemPart1(List<string> inputList)
    {
        // Create dotted grid
        int horizontalLength = 400;
        int verticalLength = 300;

        char[][] grid = new char[verticalLength][];
        for (int y = 0; y < verticalLength; y++)
        {
            char[] hLine = new char[horizontalLength];
            grid[y] = hLine;
        }

        for (int y = 0; y < grid.Length; y++)
            for (int x = 0; x < grid[0].Length; x++)
                grid[y][x] = '.';

        var startCoordinate = (80, 1);
        var currentCoordinate = startCoordinate;
        grid[startCoordinate.Item1][startCoordinate.Item2] = '#';
        var coordinatesSet = new HashSet<(int, int)>();
        coordinatesSet.Add(currentCoordinate);

        foreach (var line in inputList)
        {
            var lineSplit = line.Split(" ");
            var direction = lineSplit[0];
            var steps = int.Parse(lineSplit[1]);
            
            // Left
            if (direction.Equals("L"))
            {
                int y = currentCoordinate.Item1;
                int x = currentCoordinate.Item2;
                for (int i = x; i >= x-steps; i--)
                {
                    grid[y][i] = '#';
                    coordinatesSet.Add((y, i));
                }
                currentCoordinate = (y, x-steps);
            }
            
            // Right
            if (direction.Equals("R"))
            {
                int y = currentCoordinate.Item1;
                int x = currentCoordinate.Item2;
                for (int i = x; i <= x+steps; i++)
                {
                    grid[y][i] = '#';
                    coordinatesSet.Add((y, i));
                }
                currentCoordinate = (y, x+steps);
            }

            // Down
            if (direction.Equals("D"))
            {
                int y = currentCoordinate.Item1;
                int x = currentCoordinate.Item2;
                for (int i = y; i <= y+steps; i++)
                {
                    grid[i][x] = '#';
                    coordinatesSet.Add((i, x));
                }
                currentCoordinate = (y+steps, x);
            }

            // Up
            if (direction.Equals("U"))
            {
                int y = currentCoordinate.Item1;
                int x = currentCoordinate.Item2;
                for (int i = y; i >= y-steps; i--)
                {
                    grid[i][x] = '#';
                    coordinatesSet.Add((i, x));
                }
                currentCoordinate = (y-steps, x);
            }
        }

        // Console.WriteLine(coordinatesSet.Count());

        FillWaterOuterGrid(0, 0, grid);

        long totalCount = 0;

        for (int y = 0; y < grid.Length; y++)
        {
            for (int x = 0; x < grid[0].Length; x++)
            {
                if (grid[y][x] != 'O')
                    totalCount++;
            }
        }

        return totalCount;
    }

    public static void FillWaterOuterGrid(int y, int x, char[][] grid)
    {
        // Terminating case
        if (grid[y][x] != '.')
            return;

        // Recursion case
        grid[y][x] = 'O';
        
        // Right
        if (x+1 < grid[0].Length)
            FillWaterOuterGrid(y, x+1, grid);

        // Down
        if (y+1 < grid.Length)
            FillWaterOuterGrid(y+1, x, grid);

        // Left
        if (x-1 >= 0)
            FillWaterOuterGrid(y, x-1, grid);

        // Up
        if (y-1 >= 0)
            FillWaterOuterGrid(y-1, x, grid);
    }

    public static long ProblemPart2(List<string> inputList)
    {
        return 0;
    }
}
