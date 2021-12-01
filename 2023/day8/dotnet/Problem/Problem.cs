using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace Problem;
public class Problem
{
    public static int ProblemPart1(List<string> inputList)
    {
        var direction = inputList[0];
        var network = new Dictionary<string, (string, string)>();
        var initialSource = "AAA";

        for (int i = 2; i < inputList.Count(); i++)
        {
            var networkSplit = inputList[i].Split("=");
            var source = networkSplit[0].Trim();
            var destinationClean = networkSplit[1].Trim().Remove(0, 1);
            destinationClean = destinationClean.Remove(destinationClean.Length-1, 1);
            var destinationSplit = destinationClean.Split(",");
            var destinationTuple = (destinationSplit[0].Trim(), destinationSplit[1].Trim());
            network[source] = destinationTuple;
        }

        var currentPosition = initialSource;
        var steps = 0;
        var directionIndex = 0;

        while (!currentPosition.Equals("ZZZ"))
        {
            var (nextLeft, nextRight) = network[currentPosition];
            if (directionIndex >= direction.Length)
                directionIndex = 0;
            if (direction[directionIndex] == 'L')
                currentPosition = nextLeft;
            else
                currentPosition = nextRight;
            directionIndex++;
            steps++;
        }

        return steps;
    }

public static long ProblemPart2(List<string> inputList)
    {
        var direction = inputList[0];
        var network = new Dictionary<string, (string, string)>();
        var currentSourceList = new List<string>();

        for (int i = 2; i < inputList.Count(); i++)
        {
            var networkSplit = inputList[i].Split("=");
            var source = networkSplit[0].Trim();
            var destinationClean = networkSplit[1].Trim().Remove(0, 1);
            destinationClean = destinationClean.Remove(destinationClean.Length-1, 1);
            var destinationSplit = destinationClean.Split(",");
            var destinationTuple = (destinationSplit[0].Trim(), destinationSplit[1].Trim());
            network[source] = destinationTuple;
        }

        foreach (var networkEntry in network)
        {
            if (networkEntry.Key[2] == 'A')
                currentSourceList.Add(networkEntry.Key);
        }

        var deltaStepsList = new List<long>();

        for (int i = 0; i < currentSourceList.Count(); i++)
        {
            long steps = 0;
            long prevSteps = steps;
            bool found = false;
            long deltaSteps = -1;
            while (!found) // Continue steps
            {
                foreach (var directionChar in direction)
                {
                    var (nextLeft, nextRight) = network[currentSourceList[i]];
                    if (directionChar == 'L')
                        currentSourceList[i] = nextLeft;
                    else
                        currentSourceList[i] = nextRight;
                    steps++;

                    // Check if ending with Z
                    if (currentSourceList[i][2] == 'Z')
                    {
                        deltaSteps = steps - prevSteps;
                        prevSteps = steps;
                    }
                }
                if (steps > 100000) // Give enough rounds to get stable delta steps
                    found = true;
            }
            deltaStepsList.Add(deltaSteps);
        }

        var lcm = GetLcm(deltaStepsList);

        return lcm;
    }

    public static long Gcd(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public static long Lcm(long a, long b)
    {
        return (a * b / Gcd(a, b));
    }

    public static long GetLcm(List<long> deltaStepsList)
    {
        deltaStepsList.Sort();
        long lcm = deltaStepsList[0];
        for (int i = 1; i < deltaStepsList.Count(); i++)
        {
            lcm = Lcm(lcm, deltaStepsList[i]);
        }
        return lcm;
    }
}