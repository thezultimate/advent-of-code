using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace Problem;
public class Problem
{
    public static long ProblemPart1(List<string> inputList)
    {
        // Time is my friend, classic Dijkstra without priority queue FTW!
        var startVertex = (0, 0, '.', 0);
        var endVertexCoordinate = (inputList.Count()-1, inputList[0].Length-1);

        var Q = new HashSet<(int, int, char, int)>(); // (y, x, direction, straight count)
        var dist = new Dictionary<(int, int, char, int), long>();

        for (int y = 0; y < inputList.Count(); y++)
        {
            for (int x = 0; x < inputList[0].Length; x++)
            {
                if (y == 0 && x == 0) // Start vertex
                {
                    dist[(y, x, '.', 0)] = 999999999;
                    Q.Add((y, x, '.', 0));
                }
                else if (y == endVertexCoordinate.Item1 && x == endVertexCoordinate.Item2) // End vertex can only be approached down or right
                {
                    dist[(y, x, 'v', 1)] = 999999999;
                    dist[(y, x, '>', 1)] = 999999999;
                    dist[(y, x, 'v', 2)] = 999999999;
                    dist[(y, x, '>', 2)] = 999999999;
                    dist[(y, x, 'v', 3)] = 999999999;
                    dist[(y, x, '>', 3)] = 999999999;
                    Q.Add((y, x, 'v', 1));
                    Q.Add((y, x, '>', 1));
                    Q.Add((y, x, 'v', 2));
                    Q.Add((y, x, '>', 2));
                    Q.Add((y, x, 'v', 3));
                    Q.Add((y, x, '>', 3));
                }
                else
                {
                    dist[(y, x, '<', 1)] = 999999999;
                    dist[(y, x, 'v', 1)] = 999999999;
                    dist[(y, x, '>', 1)] = 999999999;
                    dist[(y, x, '^', 1)] = 999999999;
                    dist[(y, x, '<', 2)] = 999999999;
                    dist[(y, x, 'v', 2)] = 999999999;
                    dist[(y, x, '>', 2)] = 999999999;
                    dist[(y, x, '^', 2)] = 999999999;
                    dist[(y, x, '<', 3)] = 999999999;
                    dist[(y, x, 'v', 3)] = 999999999;
                    dist[(y, x, '>', 3)] = 999999999;
                    dist[(y, x, '^', 3)] = 999999999;
                    Q.Add((y, x, '<', 1));
                    Q.Add((y, x, 'v', 1));
                    Q.Add((y, x, '>', 1));
                    Q.Add((y, x, '^', 1));
                    Q.Add((y, x, '<', 2));
                    Q.Add((y, x, 'v', 2));
                    Q.Add((y, x, '>', 2));
                    Q.Add((y, x, '^', 2));
                    Q.Add((y, x, '<', 3));
                    Q.Add((y, x, 'v', 3));
                    Q.Add((y, x, '>', 3));
                    Q.Add((y, x, '^', 3));
                }
            }
        }
        dist[startVertex] = 0;

        while (Q.Count() > 0)
        {
            long minDist = 999999999;
            var u = (-1, -1, '.', 0); // u is a vertex in Q with min dist[u]
            foreach (var aVertext in Q)
            {
                if (dist[aVertext] < minDist)
                {
                    minDist = dist[aVertext];
                    u = aVertext;
                }
            }

            if (minDist == 999999999) // Nothing to remove from Q anymore
                break;

            if (u.Item1 == endVertexCoordinate.Item1 && u.Item2 == endVertexCoordinate.Item2) // Destination reached
                Console.WriteLine($"Destination reached => {dist[u]}");

            Q.RemoveWhere(v => v == u); // This is the performance bottleneck!

            char currentDirection = u.Item3;
            var allowedDirection = new HashSet<char>();
            if (currentDirection == '<')
                allowedDirection = new HashSet<char>{'<', 'v', '^'};
            if (currentDirection == 'v')
                allowedDirection = new HashSet<char>{'v', '<', '>'};
            if (currentDirection == '>')
                allowedDirection = new HashSet<char>{'>', 'v', '^'};
            if (currentDirection == '^')
                allowedDirection = new HashSet<char>{'^', '<', '>'};
            if (currentDirection == '.')
                allowedDirection = new HashSet<char>{'v', '^', '<', '>'};

            // Left neighbour of u
            if (allowedDirection.Contains('<'))
            {
                if (u.Item2-1 >= 0) // Not exceeding left wall
                {
                    var vCoordinate = (u.Item1, u.Item2-1);
                    int currentStraightCount = -1;
                    if (u.Item3 == '<') // Previous direction equals to current direction
                        currentStraightCount = u.Item4 + 1;
                    else
                        currentStraightCount = 1;
                    if (currentStraightCount > 3) // This neighbour is more than 3 blocks straight, do nothing
                    {
                    }
                    else
                    {
                        var v = (vCoordinate.Item1, vCoordinate.Item2, '<', currentStraightCount);
                        long leftEdge = long.Parse(inputList[v.Item1][v.Item2].ToString());
                        long alt = dist[u] + leftEdge;
                        if (dist.ContainsKey(v))
                        {
                            if (alt < dist[v])
                                dist[v] = alt;
                        }
                    }
                }
            }

            // Down neighbour of u
            if (allowedDirection.Contains('v'))
            {
                if (u.Item1+1 < inputList.Count()) // Not exceeding bottom wall
                {
                    var vCoordinate = (u.Item1+1, u.Item2);
                    int currentStraightCount = -1;
                    if (u.Item3 == 'v') // Previous direction equals to current direction
                        currentStraightCount = u.Item4 + 1;
                    else
                        currentStraightCount = 1;
                    if (currentStraightCount > 3) // This neighbour is more than 3 blocks straight, do nothing
                    {
                    }
                    else
                    {
                        var v = (vCoordinate.Item1, vCoordinate.Item2, 'v', currentStraightCount);
                        long downEdge = long.Parse(inputList[v.Item1][v.Item2].ToString());
                        long alt = dist[u] + downEdge;
                        if (dist.ContainsKey(v))
                        {
                            if (alt < dist[v])
                                dist[v] = alt;
                        }
                    }
                }
            }

            // Right neighbour of u
            if (allowedDirection.Contains('>'))
            {
                if (u.Item2+1 < inputList[0].Length) // Not exceeding right wall
                {
                    var vCoordinate = (u.Item1, u.Item2+1);
                    int currentStraightCount = -1;
                    if (u.Item3 == '>') // Previous direction equals to current direction
                        currentStraightCount = u.Item4 + 1;
                    else
                        currentStraightCount = 1;
                    if (currentStraightCount > 3) // This neighbour is more than 3 blocks straight, do nothing
                    {
                    }
                    else
                    {
                        var v = (vCoordinate.Item1, vCoordinate.Item2, '>', currentStraightCount);
                        long rightEdge = long.Parse(inputList[vCoordinate.Item1][vCoordinate.Item2].ToString());
                        long alt = dist[u] + rightEdge;
                        if (dist.ContainsKey(v))
                        {
                            if (alt < dist[v])
                                dist[v] = alt;
                        }
                    }
                }
            }

            // Up neighbour of u
            if (allowedDirection.Contains('^'))
            {
                if (u.Item1-1 >= 0) // Not exceeding top wall
                {
                    var vCoordinate = (u.Item1-1, u.Item2);
                    int currentStraightCount = -1;
                    if (u.Item3 == '^') // Previous direction equals to current direction
                        currentStraightCount = u.Item4 + 1;
                    else
                        currentStraightCount = 1;
                    if (currentStraightCount > 3) // This neighbour is more than 3 blocks straight, do nothing
                    {
                    }
                    else
                    {
                        var v = (vCoordinate.Item1, vCoordinate.Item2, '^', currentStraightCount);
                        long upEdge = long.Parse(inputList[v.Item1][v.Item2].ToString());
                        long alt = dist[u] + upEdge;
                        if (dist.ContainsKey(v))
                        {
                            if (alt < dist[v])
                                dist[v] = alt;
                        }
                    }
                }
            }
        }

        // Console.WriteLine(dist[(endVertexCoordinate.Item1, endVertexCoordinate.Item2, 'v', 1)]);
        // Console.WriteLine(dist[(endVertexCoordinate.Item1, endVertexCoordinate.Item2, '>', 1)]);
        // Console.WriteLine(dist[(endVertexCoordinate.Item1, endVertexCoordinate.Item2, 'v', 2)]);
        // Console.WriteLine(dist[(endVertexCoordinate.Item1, endVertexCoordinate.Item2, '>', 2)]);
        // Console.WriteLine(dist[(endVertexCoordinate.Item1, endVertexCoordinate.Item2, 'v', 3)]);
        // Console.WriteLine(dist[(endVertexCoordinate.Item1, endVertexCoordinate.Item2, '>', 3)]);

        long shortestPathSteps = 999999999;
        long result = dist[(endVertexCoordinate.Item1, endVertexCoordinate.Item2, 'v', 1)];
        if (result < shortestPathSteps)
            shortestPathSteps = result;
        result = dist[(endVertexCoordinate.Item1, endVertexCoordinate.Item2, '>', 1)];
        if (result < shortestPathSteps)
            shortestPathSteps = result;
        result = dist[(endVertexCoordinate.Item1, endVertexCoordinate.Item2, 'v', 2)];
        if (result < shortestPathSteps)
            shortestPathSteps = result;
        result = dist[(endVertexCoordinate.Item1, endVertexCoordinate.Item2, '>', 2)];
        if (result < shortestPathSteps)
            shortestPathSteps = result;
        result = dist[(endVertexCoordinate.Item1, endVertexCoordinate.Item2, 'v', 3)];
        if (result < shortestPathSteps)
            shortestPathSteps = result;
        result = dist[(endVertexCoordinate.Item1, endVertexCoordinate.Item2, '>', 3)];
        if (result < shortestPathSteps)
            shortestPathSteps = result;

        return shortestPathSteps;
    }

    public static long ProblemPart2(List<string> inputList)
    {
        return 0;
    }
}
