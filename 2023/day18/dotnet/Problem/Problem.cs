using System.Diagnostics.Metrics;
using System.Net;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Net.NetworkInformation;

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

        FillWaterOuterGrid(0, 0, grid); // This is too fancy, no need

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
        var startCoordinate = (0L, 0L);
        var currentCoordinate = startCoordinate;
        var coordinatesSet = new HashSet<(long, long)>(); // Holds coordinates at the edges of the polygon
        coordinatesSet.Add(currentCoordinate);

        foreach (var line in inputList)
        {
            var lineSplit = line.Split(" ");
            var hexString = lineSplit[2];
            var hexSteps = hexString.Substring(2, 5);
            var hexDirection = hexString.Substring(7, 1);
            var steps = HexToDec(hexSteps);
            var direction = GetDirection(hexDirection);
            
            // Console.WriteLine($"{direction} {steps}");

            // Left
            if (direction.Equals("L"))
            {
                long y = currentCoordinate.Item1;
                long x = currentCoordinate.Item2;
                for (long i = x; i >= x-steps; i--)
                    coordinatesSet.Add((y, i));
                currentCoordinate = (y, x-steps);
            }
            
            // Right
            if (direction.Equals("R"))
            {
                var y = currentCoordinate.Item1;
                var x = currentCoordinate.Item2;
                for (long i = x; i <= x+steps; i++)
                    coordinatesSet.Add((y, i));
                currentCoordinate = (y, x+steps);
            }

            // Down
            if (direction.Equals("D"))
            {
                var y = currentCoordinate.Item1;
                var x = currentCoordinate.Item2;
                for (long i = y; i <= y+steps; i++)
                    coordinatesSet.Add((i, x));
                currentCoordinate = (y+steps, x);
            }

            // Up
            if (direction.Equals("U"))
            {
                var y = currentCoordinate.Item1;
                var x = currentCoordinate.Item2;
                for (long i = y; i >= y-steps; i--)
                    coordinatesSet.Add((i, x));
                currentCoordinate = (y-steps, x);
            }
        }

        // Console.WriteLine(coordinatesSet.Count());

        // Construct polygon
        var polygon = new List<(long, long)>();
        foreach (var aCoordinate in coordinatesSet)
            polygon.Add(aCoordinate);

        long area = (long) ShoelaceArea(polygon);

        return area;
    }

    public static double ShoelaceArea(List<(long, long)> v) {
        long n = v.Count;
        double a = 0.0;
        for (int i = 0; i < n - 1; i++) {
            a += v[i].Item2 * v[i+1].Item1;
            a -= v[i].Item1 * v[i+1].Item2;
        }
        a = Math.Abs(a) / 2;
        return a + n / 2 + 1;
    }

    public static String GetDirection(string hexDirection)
    {
        switch (hexDirection)
        {
            case "0":
                return "R";
            case "1":
                return "D";
            case "2":
                return "L";
            case "3":
                return "U";
        }
        return "-";
    }

    public static long HexToDec(string hex)
    {
        var hexSingleDigitToDecimalMap = new Dictionary<char, int>
        {
            {'0', 0},
            {'1', 1},
            {'2', 2},
            {'3', 3},
            {'4', 4},
            {'5', 5},
            {'6', 6},
            {'7', 7},
            {'8', 8},
            {'9', 9},
            {'a', 10},
            {'b', 11},
            {'c', 12},
            {'d', 13},
            {'e', 14},
            {'f', 15},
        };

        long sum = 0;
        long power = hex.Length-1;
        foreach (var hexChar in hex)
        {
            var currentBase = hexSingleDigitToDecimalMap[hexChar];
            sum += currentBase * (int) Math.Pow(16, power);
            power--;
        }

        return sum;
    }
}
