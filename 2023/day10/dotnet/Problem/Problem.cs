using System.Diagnostics.Metrics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;
using System.Security.Cryptography.X509Certificates;

namespace Problem;
public class Problem
{
    public static long ProblemPart1(List<string> inputList)
    {
        var allowedNextTileMap = new Dictionary<string, HashSet<char>>();
        allowedNextTileMap["right"] = new HashSet<char>{'-', 'J', '7'};
        allowedNextTileMap["down"] = new HashSet<char>{'|', 'L', 'J'};
        allowedNextTileMap["left"] = new HashSet<char>{'-', 'L', 'F'};
        allowedNextTileMap["up"] = new HashSet<char>{'|', '7', 'F'};

        var allowedDirectionMap = new Dictionary<char, (string, string)>();
        allowedDirectionMap['|'] = ("up", "down");
        allowedDirectionMap['-'] = ("right", "left");
        allowedDirectionMap['L'] = ("up", "right");
        allowedDirectionMap['J'] = ("up", "left");
        allowedDirectionMap['7'] = ("down", "left");
        allowedDirectionMap['F'] = ("down", "right");


        var firstAlreadyTraversedIndexSet = new HashSet<string>();
        var secondAlreadyTraversedIndexSet = new HashSet<string>();

        // Find S index
        int sY = -1, sX = -1;
        for (int y = 0; y < inputList.Count(); y++)
        {
            for (int x = 0; x < inputList.Count(); x++)
            {
                if (inputList[y][x] == 'S')
                {
                    sY = y;
                    sX = x;
                    firstAlreadyTraversedIndexSet.Add(sY + "," + sX);
                    secondAlreadyTraversedIndexSet.Add(sY + "," + sX);
                }
            }
        }

        // Find the indices of two tiles next to S that enters the loop
        var pipeEntryTilesIndex = new List<(int, int)>();
        if (sX+1 <= inputList[0].Length-1) // Right
        {
            var rightTile = inputList[sY][sX+1];
            if (allowedNextTileMap["right"].Contains(rightTile))
                pipeEntryTilesIndex.Add((sY, sX+1));
        }
        if (sY+1 <= inputList.Count()-1) // Down
        {
            var downTile = inputList[sY+1][sX];
            if (allowedNextTileMap["down"].Contains(downTile))
                pipeEntryTilesIndex.Add((sY+1, sX));
        }
        if (sX-1 >= 0) // Left
        {
            var leftTile = inputList[sY][sX-1];
            if (allowedNextTileMap["left"].Contains(leftTile))
                pipeEntryTilesIndex.Add((sY, sX-1));
        }
        if (sY-1 >= 0) // Up
        {
            var upTile = inputList[sY-1][sX];
            if (allowedNextTileMap["up"].Contains(upTile))
                pipeEntryTilesIndex.Add((sY-1, sX));
        }
        var (firstY, firstX) = pipeEntryTilesIndex[0];
        var (secondY, secondX) = pipeEntryTilesIndex[1];
        firstAlreadyTraversedIndexSet.Add(firstY + "," + firstX);
        secondAlreadyTraversedIndexSet.Add(secondY + "," + secondX);
        var firstTile = inputList[firstY][firstX];
        var secondTile = inputList[secondY][secondX];

        // Traverse the loop from both start tiles at the same time
        long firstStepCount = 1;
        long secondStepCount = 1;
        int firstNextY = -1;
        int firstNextX = -1;
        int secondNextY = -1;
        int secondNextX = -1;
        bool found = false;
        while (!found)
        {
            var (firstNextDirectionOne, firstNextDirectionTwo) = allowedDirectionMap[firstTile];
            var (firstPossibleNextY, firstPossibleNextX) = GetNextDirectionIndices(firstY, firstX, firstNextDirectionOne);
            if (!firstAlreadyTraversedIndexSet.Contains(firstPossibleNextY + "," + firstPossibleNextX))
            {
                firstNextY = firstPossibleNextY;
                firstNextX = firstPossibleNextX;
            }
            (firstPossibleNextY, firstPossibleNextX) = GetNextDirectionIndices(firstY, firstX, firstNextDirectionTwo);
            if (!firstAlreadyTraversedIndexSet.Contains(firstPossibleNextY + "," + firstPossibleNextX))
            {
                firstNextY = firstPossibleNextY;
                firstNextX = firstPossibleNextX;
            }
            firstTile = inputList[firstNextY][firstNextX];
            firstY = firstNextY;
            firstX = firstNextX;
            firstAlreadyTraversedIndexSet.Add(firstY + "," + firstX);
            firstStepCount++;

            var (secondNextDirectionOne, secondNextDirectionTwo) = allowedDirectionMap[secondTile];
            var (secondPossibleNextY, secondPossibleNextX) = GetNextDirectionIndices(secondY, secondX, secondNextDirectionOne);
            if (!secondAlreadyTraversedIndexSet.Contains(secondPossibleNextY + "," + secondPossibleNextX))
            {
                secondNextY = secondPossibleNextY;
                secondNextX = secondPossibleNextX;
            }
            (secondPossibleNextY, secondPossibleNextX) = GetNextDirectionIndices(secondY, secondX, secondNextDirectionTwo);
            if (!secondAlreadyTraversedIndexSet.Contains(secondPossibleNextY + "," + secondPossibleNextX))
            {
                secondNextY = secondPossibleNextY;
                secondNextX = secondPossibleNextX;
            }
            secondTile = inputList[secondNextY][secondNextX];
            secondY = secondNextY;
            secondX = secondNextX;
            secondAlreadyTraversedIndexSet.Add(secondY + "," + secondX);
            secondStepCount++;

            if (firstY == secondY && firstX == secondX)
            {
                found = true;
            }
        }

        if (firstStepCount > secondStepCount)
            return firstStepCount;
        return secondStepCount;
        // return 4;
    }

    public static (int, int) GetNextDirectionIndices(int y, int x, string direction)
    {
        if (direction == "right")
            return (y, x+1);
        if (direction == "down")
            return (y+1, x);
        if (direction == "left")
            return (y, x-1);
        if (direction == "up")
            return (y-1, x);
        return (-1, -1);
    }

    public static long ProblemPart2(List<string> inputList)
    {
        // Convert input to list of char array
        var grid = new List<char[]>();
        foreach (var line in inputList)
        {
            var lineCharArray = line.ToCharArray();
            grid.Add(lineCharArray);
        }

        // Convert grid to an extended grid with dots
        var extendedGrid = new List<char[]>();
        for (int i = 0; i <= grid.Count()+1; i++)
        {
            var charArr = new char[grid[0].Length+2];
            for (int j = 0; j <= grid[0].Length+1; j++)
                charArr[j] = '.';
            extendedGrid.Add(charArr);
        }
        for (int i = 0; i < grid.Count(); i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                extendedGrid[i+1][j+1] = grid[i][j];
            }
        }

        FillWaterOuterExtendedGrid(0, 0, extendedGrid); // Fill water from the outside for fun

        // Shows a nice image
        foreach (var line in extendedGrid)
        {
            foreach (var aChar in line)
                Console.Write(aChar);
            Console.WriteLine();
        }

        var allowedNextTileMap = new Dictionary<string, HashSet<char>>();
        allowedNextTileMap["right"] = new HashSet<char>{'-', 'J', '7'};
        allowedNextTileMap["down"] = new HashSet<char>{'|', 'L', 'J'};
        allowedNextTileMap["left"] = new HashSet<char>{'-', 'L', 'F'};
        allowedNextTileMap["up"] = new HashSet<char>{'|', '7', 'F'};

        var allowedDirectionMap = new Dictionary<char, (string, string)>();
        allowedDirectionMap['|'] = ("up", "down");
        allowedDirectionMap['-'] = ("right", "left");
        allowedDirectionMap['L'] = ("up", "right");
        allowedDirectionMap['J'] = ("up", "left");
        allowedDirectionMap['7'] = ("down", "left");
        allowedDirectionMap['F'] = ("down", "right");

        var firstAlreadyTraversedIndexSet = new HashSet<string>();

        // Find S index
        int sY = -1, sX = -1;
        string sIndex = "";
        for (int y = 0; y < extendedGrid.Count(); y++)
        {
            for (int x = 0; x < extendedGrid[0].Length; x++)
            {
                if (extendedGrid[y][x] == 'S')
                {
                    sY = y;
                    sX = x;
                    sIndex = sY + "," + sX;
                    firstAlreadyTraversedIndexSet.Add(sY + "," + sX);
                }
            }
        }

        // Find the indices of two tiles next to S that enters the loop
        var pipeEntryTilesIndex = new List<(int, int)>();
        if (sX+1 <= extendedGrid[0].Length-1) // Right
        {
            var rightTile = extendedGrid[sY][sX+1];
            if (allowedNextTileMap["right"].Contains(rightTile))
                pipeEntryTilesIndex.Add((sY, sX+1));
        }
        if (sY+1 <= extendedGrid.Count()-1) // Down
        {
            var downTile = extendedGrid[sY+1][sX];
            if (allowedNextTileMap["down"].Contains(downTile))
                pipeEntryTilesIndex.Add((sY+1, sX));
        }
        if (sX-1 >= 0) // Left
        {
            var leftTile = extendedGrid[sY][sX-1];
            if (allowedNextTileMap["left"].Contains(leftTile))
                pipeEntryTilesIndex.Add((sY, sX-1));
        }
        if (sY-1 >= 0) // Up
        {
            var upTile = extendedGrid[sY-1][sX];
            if (allowedNextTileMap["up"].Contains(upTile))
                pipeEntryTilesIndex.Add((sY-1, sX));
        }
        var (firstY, firstX) = pipeEntryTilesIndex[0]; // Only interested in the first one
        firstAlreadyTraversedIndexSet.Add(firstY + "," + firstX);
        var firstTile = extendedGrid[firstY][firstX];

        // Traverse the loop from one side only
        long firstStepCount = 1;
        int firstNextY = -1;
        int firstNextX = -1;
        bool found = false;
        while (!found)
        {
            var (firstNextDirectionOne, firstNextDirectionTwo) = allowedDirectionMap[firstTile];
            var (firstPossibleNextY, firstPossibleNextX) = GetNextDirectionIndices(firstY, firstX, firstNextDirectionOne);
            var firstPossibleNextIndex = firstPossibleNextY + "," + firstPossibleNextX;
            if (firstPossibleNextIndex.Equals(sIndex) && firstStepCount > 1)
                found = true;
            if (!firstAlreadyTraversedIndexSet.Contains(firstPossibleNextIndex))
            {
                firstNextY = firstPossibleNextY;
                firstNextX = firstPossibleNextX;
            }
            (firstPossibleNextY, firstPossibleNextX) = GetNextDirectionIndices(firstY, firstX, firstNextDirectionTwo);
            firstPossibleNextIndex = firstPossibleNextY + "," + firstPossibleNextX;
            if (firstPossibleNextIndex.Equals(sIndex) && firstStepCount > 1)
                found = true;
            if (!firstAlreadyTraversedIndexSet.Contains(firstPossibleNextIndex))
            {
                firstNextY = firstPossibleNextY;
                firstNextX = firstPossibleNextX;
            }
            firstTile = extendedGrid[firstNextY][firstNextX];
            firstY = firstNextY;
            firstX = firstNextX;
            firstAlreadyTraversedIndexSet.Add(firstY + "," + firstX);
            firstStepCount++;
        }

        // Use existing library for constructing a polygon of points
        var polygon = new Point[firstAlreadyTraversedIndexSet.Count()];
        int polygonIndex = 0;
        foreach (var indexString in firstAlreadyTraversedIndexSet)
        {
            var indexStringSplit = indexString.Split(",");
            int y = int.Parse(indexStringSplit[0]);
            int x = int.Parse(indexStringSplit[1]);
            polygon[polygonIndex] = new Point(x, y);
            polygonIndex++;
        }

        var insideCount = 0;
        for (int y = 0; y < extendedGrid.Count(); y++)
        {
            for (int x = 0; x < extendedGrid[0].Length; x++)
            {
                var indexString = y + "," + x;
                if (!firstAlreadyTraversedIndexSet.Contains(indexString))
                {
                    if (IsPointInPolygon(new Point(x, y), polygon))
                        insideCount++;
                }
            }
        }
        
        return insideCount;
    }

    // Took from Stack Overflow how to check if a point is inside a polygon
    public static bool IsPointInPolygon(Point p, Point[] polygon)
    {
        double minX = polygon[ 0 ].X;
        double maxX = polygon[ 0 ].X;
        double minY = polygon[ 0 ].Y;
        double maxY = polygon[ 0 ].Y;
        for ( int i = 1 ; i < polygon.Length ; i++ )
        {
            Point q = polygon[ i ];
            minX = Math.Min( q.X, minX );
            maxX = Math.Max( q.X, maxX );
            minY = Math.Min( q.Y, minY );
            maxY = Math.Max( q.Y, maxY );
        }

        if ( p.X < minX || p.X > maxX || p.Y < minY || p.Y > maxY )
        {
            return false;
        }

        bool inside = false;
        for ( int i = 0, j = polygon.Length - 1 ; i < polygon.Length ; j = i++ )
        {
            if ( ( polygon[ i ].Y > p.Y ) != ( polygon[ j ].Y > p.Y ) &&
                p.X < ( polygon[ j ].X - polygon[ i ].X ) * ( p.Y - polygon[ i ].Y ) / ( polygon[ j ].Y - polygon[ i ].Y ) + polygon[ i ].X )
            {
                inside = !inside;
            }
        }

        return inside;
    }

    public static void FillWaterOuterExtendedGrid(int y, int x, List<char[]> extendedGrid)
    {
        // Terminating case
        if (extendedGrid[y][x] != '.')
            return;

        // Recursion case
        extendedGrid[y][x] = 'O';
        
        // Right
        if (x+1 < extendedGrid[0].Length)
            FillWaterOuterExtendedGrid(y, x+1, extendedGrid);

        // Down
        if (y+1 < extendedGrid.Count())
            FillWaterOuterExtendedGrid(y+1, x, extendedGrid);

        // Left
        if (x-1 >= 0)
            FillWaterOuterExtendedGrid(y, x-1, extendedGrid);

        // Up
        if (y-1 >= 0)
            FillWaterOuterExtendedGrid(y-1, x, extendedGrid);
    }
}
