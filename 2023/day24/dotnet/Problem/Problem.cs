using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Problem;
public class Problem
{
    public static long ProblemPart1(List<string> inputList, long minArea, long maxArea)
    {
        long forwardCrossWithinBoundaryCount = 0;

        for (int i = 0; i < inputList.Count()-1; i++)
            for (int j = i+1; j < inputList.Count(); j++)
                if (IsIntersect(inputList[i], inputList[j], minArea, maxArea))
                    forwardCrossWithinBoundaryCount++;

        return forwardCrossWithinBoundaryCount;
    }

    public static bool IsIntersect(string lineOne, string lineTwo, long minArea, long maxArea)
    {
        var lineOneSplit = lineOne.Split("@");
        var coordinatesOneSplit = lineOneSplit[0].Split(",");
        var velocityOneSplit = lineOneSplit[1].Split(",");
        long x1 = long.Parse(coordinatesOneSplit[0].Trim());
        long y1 = long.Parse(coordinatesOneSplit[1].Trim());
        long vX1 = long.Parse(velocityOneSplit[0].Trim());
        long vY1 = long.Parse(velocityOneSplit[1].Trim());
        long x1End = x1 + vX1;
        long y1End = y1 + vY1;
        double m1 = ((double) y1End - (double) y1) / ((double) x1End - (double) x1);
        double c1 = y1 - (m1 * x1);
        double a1 = -1 * m1;
        double b1 = 1;

        var lineTwoSplit = lineTwo.Split("@");
        var coordinatesTwoSplit = lineTwoSplit[0].Split(",");
        var velocityTwoSplit = lineTwoSplit[1].Split(",");
        long x2 = long.Parse(coordinatesTwoSplit[0].Trim());
        long y2 = long.Parse(coordinatesTwoSplit[1].Trim());
        long vX2 = long.Parse(velocityTwoSplit[0].Trim());
        long vY2 = long.Parse(velocityTwoSplit[1].Trim());
        long x2End = x2 + vX2;
        long y2End = y2 + vY2;
        double m2 = ((double) y2End - (double) y2) / ((double) x2End - (double) x2);
        double c2 = y2 - (m2 * x2);
        double a2 = -1 * m2;
        double b2 = 1;

        double delta = (a1 * b2) - (a2 * b1);
        if (delta == 0)
            return false; // Parallel lines
        
        double x = ((b2 * c1) - (b1 * c2)) / delta;
        double y = ((a1 * c2) - (a2 * c1)) / delta;

        if (x < minArea || x > maxArea || y < minArea || y > maxArea)
            return false; // Return false if x and y are outside the square boundaries

        if (vX1 > 0 && x < x1)
            return false; // Intersects behind
        if (vX1 < 0 && x > x1)
            return false; // Intersects behind
        if (vX2 > 0 && x < x2)
            return false; // Intersects behind
        if (vX2 < 0 && x > x2)
            return false; // Intersects behind

        return true;
    }

    public static long ProblemPart2(List<string> inputList)
    {
        return 0;
    }
}
