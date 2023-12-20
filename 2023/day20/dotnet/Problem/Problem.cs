using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace Problem;
public class Problem
{
    public static long ProblemPart1(List<string> inputList)
    {
        var sourceDestinationsMap = new Dictionary<string, HashSet<string>>();
        var flipflopState = new Dictionary<string, bool>(); // false=off, true=on
        var conjunctionState = new Dictionary<string, Dictionary<string, bool>>(); // Value=(source name, high/low). true=high, false=low

        // Fill in initial states
        foreach (var line in inputList)
        {
            var lineSplit = line.Split(" -> ");
            var source = lineSplit[0]; // Always a single source
            var destinations = lineSplit[1]; // Can be multiple desinations
            
            if (source.Contains('%')) // Source is a flipflop module
            {
                var sourceName = source.Substring(1, source.Length-1);
                var destinationsArr = destinations.Split(", ");
                sourceDestinationsMap[sourceName] = new HashSet<string>(destinationsArr);
                flipflopState[sourceName] = false; // Default state is off
            }
            else if (source.Contains('&')) // Source is a conjunction module
            {
                var sourceName = source.Substring(1, source.Length-1);
                var destinationsArr = destinations.Split(", ");
                sourceDestinationsMap[sourceName] = new HashSet<string>(destinationsArr);
                conjunctionState[sourceName] = new Dictionary<string, bool>(); // Empty state since we don't know yet sources that point/send to this conjunction module
            }
            else // Source is a broadcaster module
            {
                var destinationsArr = destinations.Split(", ");
                sourceDestinationsMap[source] = new HashSet<string>(destinationsArr);
            }
        }

        // Update conjunction modules' initial states
        foreach (var sourceDestination in sourceDestinationsMap)
            foreach (var destination in sourceDestination.Value)
                if (conjunctionState.ContainsKey(destination))
                    conjunctionState[destination][sourceDestination.Key] = false; // Set the source state that point/send to this conjunction module to false/low

        // Done initialization of data struictures

        long sumLowCount = 0;
        long sumHighCount = 0;
        for (int i = 1; i <= 1000; i++)
        {
            var (lowCount, highCount) = PressButton(sourceDestinationsMap, flipflopState, conjunctionState);
            sumLowCount += lowCount;
            sumHighCount += highCount;
        }
        long totalCount = sumLowCount * sumHighCount;
        
        return totalCount;
    }

    public static (long, long) PressButton(Dictionary<string, HashSet<string>> sourceDestinationsMap, Dictionary<string, bool> flipflopState, 
        Dictionary<string, Dictionary<string, bool>> conjunctionState)
    {
        long lowCount = 1; // Button pressed is counted as well
        long highCount = 0;

        var Q = new Queue<(string, string, bool)>(); // (source, destination, low/high) false=low, true=high
        var initialSourceName = "broadcaster";
        var initialDestinations = sourceDestinationsMap[initialSourceName];
        
        foreach (var destination in initialDestinations)
        {
            Q.Enqueue((initialSourceName, destination, false));
            lowCount++;
        }

        while (Q.Count() > 0) // Do all steps until the queue is empty
        {
            var currentStep = Q.Dequeue();
            
            string sourcePulse = currentStep.Item1;
            string destionationPulse = currentStep.Item2;
            bool incomingPulse = currentStep.Item3;

            // Handle pulse sent to a flipflop module
            if (flipflopState.ContainsKey(destionationPulse))
            {
                if (!incomingPulse) // Incoming pulse is low
                {
                    bool oldState = flipflopState[destionationPulse];
                    bool newState = !oldState;
                    flipflopState[destionationPulse] = newState; // Switch the old state to new state (on -> off, off -> on)
                    
                    bool outgoingPulse = false;
                    if (newState)
                        outgoingPulse = true; // The new state is on, send high pulse
                    else
                        outgoingPulse = false; // The new state is off, send low pulse

                    var nextDestinationPulseSet = sourceDestinationsMap[destionationPulse];
                    foreach (string nextDestinationPulse in nextDestinationPulseSet)
                    {
                        Q.Enqueue((destionationPulse, nextDestinationPulse, outgoingPulse)); // Send pulse to all destinations
                        if (outgoingPulse)
                            highCount++;
                        else
                            lowCount++;
                    }
                }
            }

            // Handle pulse sent to a conjunction module
            if (conjunctionState.ContainsKey(destionationPulse))
            {
                conjunctionState[destionationPulse][sourcePulse] = incomingPulse; // Update conjunction module's state on incoming source with incoming pulse
                var conjunctionMemory = conjunctionState[destionationPulse];
                bool outgoingPulse = false; // Send low pulse if all states in the incoming source are high
                foreach (var incomingSource in conjunctionMemory)
                {
                    if (!incomingSource.Value) // There exists low pulse state in the incoming source
                    {
                        outgoingPulse = true; // Send high pulse
                        break;
                    }
                }

                var nextDestinationPulseSet = sourceDestinationsMap[destionationPulse];
                foreach (string nextDestinationPulse in nextDestinationPulseSet)
                {
                    Q.Enqueue((destionationPulse, nextDestinationPulse, outgoingPulse)); // Send pulse to all destinations
                    if (outgoingPulse)
                        highCount++;
                    else
                        lowCount++;
                }
            }
        }

        return (lowCount, highCount);
    }

    public static long ProblemPart2(List<string> inputList)
    {
        return 0;
    }
}
