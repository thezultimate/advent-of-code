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
        var lineOneSplit = lineOne.Split(" @ ");
        var coordinatesOneSplit = lineOneSplit[0].Split(", ");
        var velocityOneSplit = lineOneSplit[1].Split(", ");
        long x1 = long.Parse(coordinatesOneSplit[0]);
        long y1 = long.Parse(coordinatesOneSplit[1]);
        long vX1 = long.Parse(velocityOneSplit[0]);
        long vY1 = long.Parse(velocityOneSplit[1]);
        long x1End = x1 + vX1;
        long y1End = y1 + vY1;
        double m1 = ((double) y1End - (double) y1) / ((double) x1End - (double) x1);
        double c1 = y1 - (m1 * x1);
        double a1 = -1 * m1;
        double b1 = 1;

        var lineTwoSplit = lineTwo.Split(" @ ");
        var coordinatesTwoSplit = lineTwoSplit[0].Split(", ");
        var velocityTwoSplit = lineTwoSplit[1].Split(", ");
        long x2 = long.Parse(coordinatesTwoSplit[0]);
        long y2 = long.Parse(coordinatesTwoSplit[1]);
        long vX2 = long.Parse(velocityTwoSplit[0]);
        long vY2 = long.Parse(velocityTwoSplit[1]);
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
        long finalX = 0;
        long finalY = 0;
        long finalZ = 0;
        long sampleHailstones = 5; // Using a fraction of the input is actually enough
        long targetIntersectionsCount = (sampleHailstones * (sampleHailstones-1)) / 2;
        Console.WriteLine($"Comparisons per guess velocity: {targetIntersectionsCount}");
        var vXvYCandidates = new List<(long, long)>();
        var vXvZCandidates = new List<(long, long)>();

        for (long a = -300; a <= 300; a++)
            for (long b = -300; b <= 300; b++)
            {
                long guessVX = a;
                long guessVY = b;

                var inputListCopy = new List<string>();
                for (int i = 0; i < sampleHailstones; i++)
                {
                    // var hailstoneSplit = hailstone.Split(" @ ");
                    var hailstoneSplit = inputList[i].Split(" @ ");
                    var velocitySplit = hailstoneSplit[1].Split(", ");
                    long vX = long.Parse(velocitySplit[0]);
                    long vY = long.Parse(velocitySplit[1]);
                    long vZ = long.Parse(velocitySplit[2]);
                    long vXSub = vX - guessVX;
                    long vYSub = vY - guessVY;
                    var hailstoneSub = $"{hailstoneSplit[0]} @ {vXSub}, {vYSub}, {vZ}";
                    inputListCopy.Add(hailstoneSub);
                }

                var XYMap = new Dictionary<string, decimal>();
                decimal xOne = 0;
                decimal yOne = 0;
                decimal prevX = decimal.MinValue;
                decimal prevY = decimal.MinValue;
                bool isAllXAndYEqual = true;

                long intersectionsCount = 0;

                // Compare every 2 hailstones in plane x-y
                for (int i = 0; i < inputListCopy.Count()-1; i++)
                {
                    for (int j = i+1; j < inputListCopy.Count(); j++)
                    {
                        XYMap = new Dictionary<string, decimal>();
                        bool isIntersectXY = IsIntersectXY(inputListCopy[i], inputListCopy[j], XYMap);
                        if (isIntersectXY)
                        {
                            intersectionsCount++;
                            xOne = XYMap["x"];
                            yOne = XYMap["y"];
                            if (xOne == decimal.MinValue || yOne == decimal.MinValue)
                                continue; // decimal min value is counted as a match
                            if (prevX == decimal.MinValue && prevY == decimal.MinValue) // The first comparison that is not resulting NaN or infinity
                            {
                                prevX = xOne;
                                prevY = yOne;
                            }
                            else // Not the first comparison
                            {
                                if (xOne != prevX || yOne != prevY)
                                {
                                    isAllXAndYEqual = false;
                                    goto EndCurrentXYGuess;
                                }
                            }
                        }
                    }
                }

                EndCurrentXYGuess:
                if (isAllXAndYEqual && (intersectionsCount == targetIntersectionsCount) && (prevX != decimal.MinValue && prevY != decimal.MinValue))
                {
                    Console.WriteLine($"Candidate X-Y: Position=({prevX}, {prevY}), Velocity=({guessVX}, {guessVY})");
                    finalX = (long) prevX;
                    finalY = (long) prevY;
                    vXvYCandidates.Add((guessVX, guessVY));
                }
            }

        // Get vZ
        foreach (var guessvXvY in vXvYCandidates)
        {
            long guessVX = guessvXvY.Item1;
            long guessVY = guessvXvY.Item2;

            for (int c = -300; c <= 300; c++)
            {
                long guessVZ = c;

                var inputListCopy = new List<string>();
                for (int i = 0; i < sampleHailstones; i++)
                {
                    var hailstoneSplit = inputList[i].Split(" @ ");
                    var velocitySplit = hailstoneSplit[1].Split(", ");
                    long vX = long.Parse(velocitySplit[0]);
                    long vY = long.Parse(velocitySplit[1]);
                    long vZ = long.Parse(velocitySplit[2]);
                    long vXSub = vX - guessVX;
                    long vYSub = vY - guessVY;
                    long vZSub = vZ - guessVZ;
                    var hailstoneSub = $"{hailstoneSplit[0]} @ {vXSub}, {vYSub}, {vZSub}";
                    inputListCopy.Add(hailstoneSub);
                }

                var XZMap = new Dictionary<string, decimal>();
                decimal xOne = 0;
                decimal zOne = 0;
                decimal prevX = decimal.MinValue;
                decimal prevZ = decimal.MinValue;
                bool isAllXAndZEqual = true;

                long intersectionsCount = 0;

                // Compare every 2 hailstones in plane x-z
                for (int i = 0; i < inputListCopy.Count()-1; i++)
                {
                    for (int j = i+1; j < inputListCopy.Count(); j++)
                    {
                        XZMap = new Dictionary<string, decimal>();
                        bool isIntersectXZ = IsIntersectXZ(inputListCopy[i], inputListCopy[j], XZMap);
                        if (isIntersectXZ)
                        {
                            intersectionsCount++;
                            xOne = XZMap["x"];
                            zOne = XZMap["z"];
                            if (xOne == decimal.MinValue || zOne == decimal.MinValue)
                                continue; // decimal min value is counted as a match
                            if (prevX == decimal.MinValue && prevZ == decimal.MinValue) // The first comparison that is not resulting NaN or infinity
                            {
                                prevX = xOne;
                                prevZ = zOne;
                            }
                            else // Not the first comparison
                            {
                                if (xOne != prevX || zOne != prevZ)
                                {
                                    isAllXAndZEqual = false;
                                    goto EndCurrentXZGuess;
                                }
                            }
                        }
                    }
                }

                EndCurrentXZGuess:
                if (isAllXAndZEqual && (intersectionsCount == targetIntersectionsCount) && (prevX != decimal.MinValue && prevZ != decimal.MinValue))
                {
                    Console.WriteLine($"Candidate X-Z: Position=({prevX}, {prevZ}), Velocity=({guessVX}, {guessVZ})");
                    finalX = (long) prevX;
                    finalZ = (long) prevZ;
                    vXvZCandidates.Add((guessVX, guessVZ));
                }
            }
        }

        return (finalX + finalY + finalZ);
    }

    public static bool IsIntersectXY(string lineOne, string lineTwo, Dictionary<string, decimal> XYMap)
    {
        var lineOneSplit = lineOne.Split(" @ ");
        var coordinatesOneSplit = lineOneSplit[0].Split(", ");
        var velocityOneSplit = lineOneSplit[1].Split(", ");
        decimal x1 = decimal.Parse(coordinatesOneSplit[0]);
        decimal y1 = decimal.Parse(coordinatesOneSplit[1]);
        decimal vX1 = decimal.Parse(velocityOneSplit[0]);
        decimal vY1 = decimal.Parse(velocityOneSplit[1]);
        decimal x1End = x1 + vX1;
        decimal y1End = y1 + vY1;
        if (x1End - x1 == 0)
        {
            XYMap["x"] = decimal.MinValue;
            XYMap["y"] = decimal.MinValue;
            return true;
        }
        decimal m1 = (y1End - y1) / (x1End - x1);
        decimal c1 = y1 - (m1 * x1);
        decimal a1 = -1 * m1;
        decimal b1 = 1;

        var lineTwoSplit = lineTwo.Split(" @ ");
        var coordinatesTwoSplit = lineTwoSplit[0].Split(", ");
        var velocityTwoSplit = lineTwoSplit[1].Split(", ");
        decimal x2 = decimal.Parse(coordinatesTwoSplit[0]);
        decimal y2 = decimal.Parse(coordinatesTwoSplit[1]);
        decimal vX2 = decimal.Parse(velocityTwoSplit[0]);
        decimal vY2 = decimal.Parse(velocityTwoSplit[1]);
        decimal x2End = x2 + vX2;
        decimal y2End = y2 + vY2;
        if (x2End - x2 == 0)
        {
            XYMap["x"] = decimal.MinValue;
            XYMap["y"] = decimal.MinValue;
            return true;
        }
        decimal m2 = (y2End - y2) / (x2End - x2);
        decimal c2 = y2 - (m2 * x2);
        decimal a2 = -1 * m2;
        decimal b2 = 1;

        decimal delta = (a1 * b2) - (a2 * b1);
        if (delta == 0)
        {
            XYMap["x"] = decimal.MinValue;
            XYMap["y"] = decimal.MinValue;
            return true; // Parallel lines
        }
        
        decimal x = ((b2 * c1) - (b1 * c2)) / delta;
        decimal y = ((a1 * c2) - (a2 * c1)) / delta;
        x = Math.Round(x);
        y = Math.Round(y);

        if (vX1 > 0 && x < x1)
            return false; // Intersects behind
        if (vX1 < 0 && x > x1)
            return false; // Intersects behind
        if (vX2 > 0 && x < x2)
            return false; // Intersects behind
        if (vX2 < 0 && x > x2)
            return false; // Intersects behind

        XYMap["x"] = x;
        XYMap["y"] = y;

        return true;
    }

    public static bool IsIntersectXZ(string lineOne, string lineTwo, Dictionary<string, decimal> XZMap)
    {
        var lineOneSplit = lineOne.Split(" @ ");
        var coordinatesOneSplit = lineOneSplit[0].Split(", ");
        var velocityOneSplit = lineOneSplit[1].Split(", ");
        decimal x1 = decimal.Parse(coordinatesOneSplit[0]);
        decimal z1 = decimal.Parse(coordinatesOneSplit[2]);
        decimal vX1 = decimal.Parse(velocityOneSplit[0]);
        decimal vZ1 = decimal.Parse(velocityOneSplit[2]);
        decimal x1End = x1 + vX1;
        decimal z1End = z1 + vZ1;
        if (x1End - x1 == 0)
        {
            XZMap["x"] = decimal.MinValue;
            XZMap["z"] = decimal.MinValue;
            return true;
        }
        decimal m1 = (z1End - z1) / (x1End - x1);
        decimal c1 = z1 - (m1 * x1);
        decimal a1 = -1 * m1;
        decimal b1 = 1;

        var lineTwoSplit = lineTwo.Split(" @ ");
        var coordinatesTwoSplit = lineTwoSplit[0].Split(", ");
        var velocityTwoSplit = lineTwoSplit[1].Split(", ");
        decimal x2 = decimal.Parse(coordinatesTwoSplit[0]);
        decimal z2 = decimal.Parse(coordinatesTwoSplit[2]);
        decimal vX2 = decimal.Parse(velocityTwoSplit[0]);
        decimal vZ2 = decimal.Parse(velocityTwoSplit[2]);
        decimal x2End = x2 + vX2;
        decimal z2End = z2 + vZ2;
        if (x2End - x2 == 0)
        {
            XZMap["x"] = decimal.MinValue;
            XZMap["z"] = decimal.MinValue;
            return true;
        }
        decimal m2 = (z2End - z2) / (x2End - x2);
        decimal c2 = z2 - (m2 * x2);
        decimal a2 = -1 * m2;
        decimal b2 = 1;

        decimal delta = (a1 * b2) - (a2 * b1);
        if (delta == 0)
        {
            XZMap["x"] = decimal.MinValue;
            XZMap["z"] = decimal.MinValue;
            return true; // Parallel lines
        }
        
        decimal x = ((b2 * c1) - (b1 * c2)) / delta;
        decimal z = ((a1 * c2) - (a2 * c1)) / delta;
        x = Math.Round(x);
        z = Math.Round(z);

        if (vX1 > 0 && x < x1)
            return false; // Intersects behind
        if (vX1 < 0 && x > x1)
            return false; // Intersects behind
        if (vX2 > 0 && x < x2)
            return false; // Intersects behind
        if (vX2 < 0 && x > x2)
            return false; // Intersects behind

        XZMap["x"] = x;
        XZMap["z"] = z;

        return true;
    }
}
