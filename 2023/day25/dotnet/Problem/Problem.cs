using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace Problem;
public class Problem
{
    public static long ProblemPart1(List<string> inputList)
    {
        var connectionsMap = new Dictionary<string, HashSet<string>>();
        var edgesMap = new Dictionary<(string, string), long>();

        foreach (var line in inputList)
        {
            var lineSplit = line.Split(": ");
            var source = lineSplit[0];
            var destinationsArr = lineSplit[1].Split(" ");
            if (!connectionsMap.ContainsKey(source))
                connectionsMap[source] = new HashSet<string>();
            foreach (var destination in destinationsArr)
            {
                connectionsMap[source].Add(destination);
                if (connectionsMap.ContainsKey(destination))
                    connectionsMap[destination].Add(source);
                else
                    connectionsMap[destination] = new HashSet<string>{source};

                edgesMap[(source, destination)] = 0;
            }
        }

        foreach (var connection in connectionsMap) // BFS through all nodes, update visited edges counts
            Bfs(connection.Key, connectionsMap, edgesMap);

        // Get first max edge count
        var maxEdge = ("", "");
        long maxEdgeCount = -1;
        foreach (var edge in edgesMap)
        {
            if (edge.Value > maxEdgeCount)
            {
                maxEdgeCount = edge.Value;
                maxEdge = edge.Key;
            }
        }

        // Remove first edge
        connectionsMap[maxEdge.Item1].Remove(maxEdge.Item2);
        connectionsMap[maxEdge.Item2].Remove(maxEdge.Item1);
        edgesMap.Remove(maxEdge);

        foreach (var connection in connectionsMap) // BFS through all nodes, update visited edges counts
            Bfs(connection.Key, connectionsMap, edgesMap);

        // Get second max edge count
        maxEdge = ("", "");
        maxEdgeCount = -1;
        foreach (var edge in edgesMap)
        {
            if (edge.Value > maxEdgeCount)
            {
                maxEdgeCount = edge.Value;
                maxEdge = edge.Key;
            }
        }

        // Remove second edge
        connectionsMap[maxEdge.Item1].Remove(maxEdge.Item2);
        connectionsMap[maxEdge.Item2].Remove(maxEdge.Item1);
        edgesMap.Remove(maxEdge);

        foreach (var connection in connectionsMap) // BFS through all nodes, update visited edges counts
            Bfs(connection.Key, connectionsMap, edgesMap);

        // Get third max edge count
        maxEdge = ("", "");
        maxEdgeCount = -1;
        foreach (var edge in edgesMap)
        {
            if (edge.Value > maxEdgeCount)
            {
                maxEdgeCount = edge.Value;
                maxEdge = edge.Key;
            }
        }

        // Remove third edge
        connectionsMap[maxEdge.Item1].Remove(maxEdge.Item2);
        connectionsMap[maxEdge.Item2].Remove(maxEdge.Item1);
        edgesMap.Remove(maxEdge);

        // Count visited nodes from the last removed edge
        long edgeCount1 = Bfs(maxEdge.Item1, connectionsMap, edgesMap);
        long edgeCount2 = Bfs(maxEdge.Item2, connectionsMap, edgesMap);

        return edgeCount1 * edgeCount2;
    }

    public static long Bfs(string rootNode, Dictionary<string, HashSet<string>> connectionsMap, Dictionary<(string, string), long> edgesMap)
    {
        var explored = new HashSet<string>();
        var Q = new Queue<string>();
        explored.Add(rootNode);
        Q.Enqueue(rootNode);
        while (Q.Count() > 0)
        {
            var v = Q.Dequeue();
            foreach (var w in connectionsMap[v])
            {
                if (!explored.Contains(w))
                {
                    explored.Add(w);
                    Q.Enqueue(w);
                    
                    if (edgesMap.ContainsKey((v, w)))
                        edgesMap[(v, w)]++;
                    if (edgesMap.ContainsKey((w, v)))
                        edgesMap[(w, v)]++;
                }
            }
        }

        return explored.Count();
    }

    public static long ProblemPart2(List<string> inputList)
    {
        return 0;
    }
}
