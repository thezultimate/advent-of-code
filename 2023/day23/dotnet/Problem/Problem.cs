using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace Problem;
public class Problem
{
    public static long ProblemPart1(List<string> inputList)
    {
        long maxSteps = -1;

        var visitedCoordinate = new HashSet<(int, int)>();
        visitedCoordinate.Add((0, 1));
        var startCoordinate = (0, 1, 0, visitedCoordinate); // (y, x, depth, set of visited coordinates)
        var endCoordinate = (inputList.Count()-1, inputList[0].Length-2);
        
        var Q = new Queue<(int, int, long, HashSet<(int, int)>)>();
        Q.Enqueue(startCoordinate);

        // Console.WriteLine("Start BFS");

        while (Q.Count() > 0)
        {
            var v = Q.Dequeue();
            int y = v.Item1;
            int x = v.Item2;
            long currentDepth = v.Item3;
            var currentVisitedCoordinate = v.Item4;
            if (y == endCoordinate.Item1 && x == endCoordinate.Item2)
            {
                // Console.WriteLine($"Destination reached in {currentDepth} steps.");
                if (currentDepth > maxSteps)
                    maxSteps = currentDepth;
            }

            long nextDepth = currentDepth + 1;

            if (inputList[y][x] == '<') // Left slope, only go to left neighbour
            {
                // Left
                if (x-1 >= 0) // Not exceeding left wall
                {
                    var yNext = y;
                    var xNext = x-1;
                    if (inputList[yNext][xNext] != '#') // Neighbour is not forest
                    {
                        if (!currentVisitedCoordinate.Contains((yNext, xNext))) // Neighbour has not been visited
                        {
                            var nextVisitedCoordinate = new HashSet<(int, int)>(currentVisitedCoordinate);
                            nextVisitedCoordinate.Add((yNext, xNext));
                            var w = (yNext, xNext, nextDepth, nextVisitedCoordinate);
                            Q.Enqueue(w);
                        }
                    }
                }
            }
            else if (inputList[y][x] == 'v') // Down slope, only go to down neighbour
            {
                // Down
                if (y+1 < inputList.Count()) // Not exceeding bottom wall
                {
                    var yNext = y+1;
                    var xNext = x;
                    if (inputList[yNext][xNext] != '#') // Neighbour is not forest
                    {
                        if (!currentVisitedCoordinate.Contains((yNext, xNext))) // Neighbour has not been visited
                        {
                            var nextVisitedCoordinate = new HashSet<(int, int)>(currentVisitedCoordinate);
                            nextVisitedCoordinate.Add((yNext, xNext));
                            var w = (yNext, xNext, nextDepth, nextVisitedCoordinate);
                            Q.Enqueue(w);
                        }
                    }
                }
            }
            else if (inputList[y][x] == '>') // Right slope, only go to right neighbour
            {
                // Right
                if (x+1 < inputList[0].Length) // Not exceeding right wall
                {
                    var yNext = y;
                    var xNext = x+1;
                    if (inputList[yNext][xNext] != '#') // Neighbour is not forest
                    {
                        if (!currentVisitedCoordinate.Contains((yNext, xNext))) // Neighbour has not been visited
                        {
                            var nextVisitedCoordinate = new HashSet<(int, int)>(currentVisitedCoordinate);
                            nextVisitedCoordinate.Add((yNext, xNext));
                            var w = (yNext, xNext, nextDepth, nextVisitedCoordinate);
                            Q.Enqueue(w);
                        }
                    }
                }
            }
            else if (inputList[y][x] == '^') // Up slope, only go to up neighbour
            {
                // Up
                if (y-1 >= 0) // Not exceeding top wall
                {
                    var yNext = y-1;
                    var xNext = x;
                    if (inputList[yNext][xNext] != '#') // Neighbour is not forest
                    {
                        if (!currentVisitedCoordinate.Contains((yNext, xNext)))
                        {
                            var nextVisitedCoordinate = new HashSet<(int, int)>(currentVisitedCoordinate);
                            nextVisitedCoordinate.Add((yNext, xNext));
                            var w = (yNext, xNext, nextDepth, nextVisitedCoordinate);
                            Q.Enqueue(w);
                        }
                    }
                }
            }
            else // Current coordinate is . or #
            {
                // Left
                if (x-1 >= 0) // Not exceeding left wall
                {
                    var yNext = y;
                    var xNext = x-1;
                    if (inputList[yNext][xNext] != '#') // Neighbour is not forest
                    {
                        if (!currentVisitedCoordinate.Contains((yNext, xNext))) // Neighbour has not been visited
                        {
                            var nextVisitedCoordinate = new HashSet<(int, int)>(currentVisitedCoordinate);
                            nextVisitedCoordinate.Add((yNext, xNext));
                            var w = (yNext, xNext, nextDepth, nextVisitedCoordinate);
                            Q.Enqueue(w);
                        }
                    }
                }

                // Down
                if (y+1 < inputList.Count()) // Not exceeding bottom wall
                {
                    var yNext = y+1;
                    var xNext = x;
                    if (inputList[yNext][xNext] != '#') // Neighbour is not forest
                    {
                        if (!currentVisitedCoordinate.Contains((yNext, xNext))) // Neighbour has not been visited
                        {
                            var nextVisitedCoordinate = new HashSet<(int, int)>(currentVisitedCoordinate);
                            nextVisitedCoordinate.Add((yNext, xNext));
                            var w = (yNext, xNext, nextDepth, nextVisitedCoordinate);
                            Q.Enqueue(w);
                        }
                    }
                }

                // Right
                if (x+1 < inputList[0].Length) // Not exceeding right wall
                {
                    var yNext = y;
                    var xNext = x+1;
                    if (inputList[yNext][xNext] != '#') // Neighbour is not forest
                    {
                        if (!currentVisitedCoordinate.Contains((yNext, xNext))) // Neighbour has not been visited
                        {
                            var nextVisitedCoordinate = new HashSet<(int, int)>(currentVisitedCoordinate);
                            nextVisitedCoordinate.Add((yNext, xNext));
                            var w = (yNext, xNext, nextDepth, nextVisitedCoordinate);
                            Q.Enqueue(w);
                        }
                    }
                }

                // Up
                if (y-1 >= 0) // Not exceeding top wall
                {
                    var yNext = y-1;
                    var xNext = x;
                    if (inputList[yNext][xNext] != '#') // Neighbour is not forest
                    {
                        if (!currentVisitedCoordinate.Contains((yNext, xNext)))
                        {
                            var nextVisitedCoordinate = new HashSet<(int, int)>(currentVisitedCoordinate);
                            nextVisitedCoordinate.Add((yNext, xNext));
                            var w = (yNext, xNext, nextDepth, nextVisitedCoordinate);
                            Q.Enqueue(w);
                        }
                    }
                }
            }
        }

        // Console.WriteLine("End BFS");

        return maxSteps;
    }

    public static long stepCounter = 0;

    public static long ProblemPart2(List<string> inputList)
    {
        var startCoordinate = (0, 1);
        var endCoordinate = (inputList.Count()-1, inputList[0].Length-2);

        var visitedCoordinates = new HashSet<(int, int)>();
        visitedCoordinates.Add((0, 1));

        var watch = new System.Diagnostics.Stopwatch();
        Console.WriteLine("Starting DFS, will take some time...");
        watch.Start();
        Traverse(startCoordinate, endCoordinate, inputList, visitedCoordinates, 0); // Time is my friend, brute force FTW!
        watch.Stop();
        Console.WriteLine("Finished DFS");
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

        return stepCounter;
    }

    public static void Traverse((int, int) currentCoordinate, (int, int) endCoordinate, List<string> inputList, 
        HashSet<(int, int)> visitedCoordinates, long steps)
    {
        if (currentCoordinate == endCoordinate) // Terminating condition, destination reached
        {
            if (steps > stepCounter)
            {
                Console.WriteLine($"Destination reached in {steps} steps.");
                stepCounter = steps;
            }
            return;
        }

        var y = currentCoordinate.Item1;
        var x = currentCoordinate.Item2;
        var yNextCandidate = y;
        var xNextCandidate = x;

        bool isJunction = false;
        while (!isJunction)
        {
            int possibleWays = 0;
            
            if (x-1 >= 0) // Not exceeding left wall
                if (inputList[y][x-1] != '#') // Neighbour is not forest
                {
                    if (!visitedCoordinates.Contains((y, x-1)))
                    {
                        yNextCandidate = y;
                        xNextCandidate = x-1;
                        possibleWays++;
                    }
                }

            if (y+1 < inputList.Count()) // Not exceeding bottom wall
                if (inputList[y+1][x] != '#') // Neighbour is not forest
                {
                    if (!visitedCoordinates.Contains((y+1, x)))
                    {
                        yNextCandidate = y+1;
                        xNextCandidate = x;
                        possibleWays++;
                    }
                }

            if (x+1 < inputList[0].Length) // Not exceeding right wall
                if (inputList[y][x+1] != '#') // Neighbour is not forest
                {
                    if (!visitedCoordinates.Contains((y, x+1)))
                    {
                        yNextCandidate = y;
                        xNextCandidate = x+1;
                        possibleWays++;
                    }
                }
            
            if (y-1 >= 0) // Not exceeding top wall
                if (inputList[y-1][x] != '#') // Neighbour is not forest
                {
                    if (!visitedCoordinates.Contains((y-1, x)))
                    {
                        yNextCandidate = y-1;
                        xNextCandidate = x;
                        possibleWays++;
                    }
                }

            if (possibleWays == 1)
            {
                visitedCoordinates.Add((y, x));
                y = yNextCandidate;
                x = xNextCandidate;
                steps = steps + 1;
                if ((y, x) == endCoordinate)
                {
                    if (steps > stepCounter)
                    {
                        Console.WriteLine($"Destination reached in {steps} steps.");
                        stepCounter = steps;
                    }
                    return;
                }
            }
            else if (possibleWays == 0) // No more way to go
            {
                visitedCoordinates.Add((y, x));
                return;
            }
            else
                isJunction = true;
        }

        // This is a junction
        visitedCoordinates.Add((y, x));

        // Left
        if (x-1 >= 0) // Not exceeding left wall
        {
            var yNext = y;
            var xNext = x-1;
            if (inputList[yNext][xNext] != '#') // Neighbour is not forest
            {
                if (!visitedCoordinates.Contains((yNext, xNext)))
                {
                    var nextVisitedCoordinates = new HashSet<(int, int)>(visitedCoordinates);
                    nextVisitedCoordinates.Add((yNext, xNext));
                    Traverse((yNext, xNext), endCoordinate, inputList, nextVisitedCoordinates, steps+1);
                }
            }
        }

        // Down
        if (y+1 < inputList.Count()) // Not exceeding bottom wall
        {
            var yNext = y+1;
            var xNext = x;
            if (inputList[yNext][xNext] != '#') // Neighbour is not forest
            {
                if (!visitedCoordinates.Contains((yNext, xNext)))
                {
                    var nextVisitedCoordinates = new HashSet<(int, int)>(visitedCoordinates);
                    nextVisitedCoordinates.Add((yNext, xNext));
                    Traverse((yNext, xNext), endCoordinate, inputList, nextVisitedCoordinates, steps+1);
                }
            }
        }

        // Right
        if (x+1 < inputList[0].Length) // Not exceeding right wall
        {
            var yNext = y;
            var xNext = x+1;
            if (inputList[yNext][xNext] != '#') // Neighbour is not forest
            {
                if (!visitedCoordinates.Contains((yNext, xNext)))
                {
                    var nextVisitedCoordinates = new HashSet<(int, int)>(visitedCoordinates);
                    nextVisitedCoordinates.Add((yNext, xNext));
                    Traverse((yNext, xNext), endCoordinate, inputList, nextVisitedCoordinates, steps+1);
                }
            }
        }

        // Up
        if (y-1 >= 0) // Not exceeding top wall
        {
            var yNext = y-1;
            var xNext = x;
            if (inputList[yNext][xNext] != '#') // Neighbour is not forest
            {
                if (!visitedCoordinates.Contains((yNext, xNext)))
                {
                    var nextVisitedCoordinates = new HashSet<(int, int)>(visitedCoordinates);
                    nextVisitedCoordinates.Add((yNext, xNext));
                    Traverse((yNext, xNext), endCoordinate, inputList, nextVisitedCoordinates, steps+1);
                }
            }
        }
    }
}
