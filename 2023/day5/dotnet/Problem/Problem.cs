using System.Diagnostics.Metrics;
using System.Globalization;
using System.Reflection.Metadata;

namespace Problem;
public class Problem
{
    public static long ProblemPart1(List<string> inputList)
    {
        var seedsList = new List<long>();
        var locationsList = new List<long>();
        var seedToSoilMapList = new List<(long, long, long)>();
        var soilToFertilizerMapList = new List<(long, long, long)>();
        var fertilizerToWaterMapList = new List<(long, long, long)>();
        var waterToLightMapList = new List<(long, long, long)>();
        var lightToTemperatureMapList = new List<(long, long, long)>();
        var temperatureToHumidityMapList = new List<(long, long, long)>();
        var humidityToLocationMapList = new List<(long, long, long)>();

        for (int i = 0; i < inputList.Count(); i++) // Parse input
        {
            if (inputList[i].Contains("seeds:"))
            {
                var seedsSplit = inputList[i].Split(":");
                var seedsString = seedsSplit[1].Trim();
                var seedsListString = seedsString.Split(" ");
                seedsList = seedsListString.Select(long.Parse).ToList();
            }

            if (inputList[i].Contains("seed-to-soil map:"))
            {
                var done = false;
                var j = i;
                while (!done)
                {
                    j++;
                    if (inputList[j] == "")
                    {
                        done = true;
                        break;
                    }
                    var tupleString = inputList[j].Split(" ");
                    var tuple = (long.Parse(tupleString[0]), long.Parse(tupleString[1]), long.Parse(tupleString[2]));
                    seedToSoilMapList.Add(tuple);
                }
            }

            if (inputList[i].Contains("soil-to-fertilizer map:"))
            {
                var done = false;
                var j = i;
                while (!done)
                {
                    j++;
                    if (inputList[j] == "")
                    {
                        done = true;
                        break;
                    }
                    var tupleString = inputList[j].Split(" ");
                    var tuple = (long.Parse(tupleString[0]), long.Parse(tupleString[1]), long.Parse(tupleString[2]));
                    soilToFertilizerMapList.Add(tuple);
                }
            }

            if (inputList[i].Contains("fertilizer-to-water map:"))
            {
                var done = false;
                var j = i;
                while (!done)
                {
                    j++;
                    if (inputList[j] == "")
                    {
                        done = true;
                        break;
                    }
                    var tupleString = inputList[j].Split(" ");
                    var tuple = (long.Parse(tupleString[0]), long.Parse(tupleString[1]), long.Parse(tupleString[2]));
                    fertilizerToWaterMapList.Add(tuple);
                }
            }

            if (inputList[i].Contains("water-to-light map:"))
            {
                var done = false;
                var j = i;
                while (!done)
                {
                    j++;
                    if (inputList[j] == "")
                    {
                        done = true;
                        break;
                    }
                    var tupleString = inputList[j].Split(" ");
                    var tuple = (long.Parse(tupleString[0]), long.Parse(tupleString[1]), long.Parse(tupleString[2]));
                    waterToLightMapList.Add(tuple);
                }
            }

            if (inputList[i].Contains("light-to-temperature map:"))
            {
                var done = false;
                var j = i;
                while (!done)
                {
                    j++;
                    if (inputList[j] == "")
                    {
                        done = true;
                        break;
                    }
                    var tupleString = inputList[j].Split(" ");
                    var tuple = (long.Parse(tupleString[0]), long.Parse(tupleString[1]), long.Parse(tupleString[2]));
                    lightToTemperatureMapList.Add(tuple);
                }
            }

            if (inputList[i].Contains("temperature-to-humidity map:"))
            {
                var done = false;
                var j = i;
                while (!done)
                {
                    j++;
                    if (inputList[j] == "")
                    {
                        done = true;
                        break;
                    }
                    var tupleString = inputList[j].Split(" ");
                    var tuple = (long.Parse(tupleString[0]), long.Parse(tupleString[1]), long.Parse(tupleString[2]));
                    temperatureToHumidityMapList.Add(tuple);
                }
            }

            if (inputList[i].Contains("humidity-to-location map:"))
            {
                var done = false;
                var j = i;
                while (!done)
                {
                    j++;
                    if (j == inputList.Count())
                    {
                        done = true;
                        break;
                    }
                    var tupleString = inputList[j].Split(" ");
                    var tuple = (long.Parse(tupleString[0]), long.Parse(tupleString[1]), long.Parse(tupleString[2]));
                    humidityToLocationMapList.Add(tuple);
                }
            }
        }

        foreach (var seed in seedsList) // Get locations corresponding to each initial seed
        {
            // Get soil
            var soil = seed;
            foreach (var (destination, source, range) in seedToSoilMapList)
            {
                if (seed >= source && seed <= source + range - 1)
                {
                    var delta = seed - source;
                    soil = destination + delta;
                }
            }

            // Get fertilizer
            var fertilizer = soil;
            foreach (var (destination, source, range) in soilToFertilizerMapList)
            {
                if (soil >= source && soil <= source + range - 1)
                {
                    var delta = soil - source;
                    fertilizer = destination + delta;
                }
            }

            // Get water
            var water = fertilizer;
            foreach (var (destination, source, range) in fertilizerToWaterMapList)
            {
                if (fertilizer >= source && fertilizer <= source + range - 1)
                {
                    var delta = fertilizer - source;
                    water = destination + delta;
                }
            }

            // Get light
            var light = water;
            foreach (var (destination, source, range) in waterToLightMapList)
            {
                if (water >= source && water <= source + range - 1)
                {
                    var delta = water - source;
                    light = destination + delta;
                }
            }

            // Get temperature
            var temperature = light;
            foreach (var (destination, source, range) in lightToTemperatureMapList)
            {
                if (light >= source && light <= source + range - 1)
                {
                    var delta = light - source;
                    temperature = destination + delta;
                }
            }

            // Get humidity
            var humidity = temperature;
            foreach (var (destination, source, range) in temperatureToHumidityMapList)
            {
                if (temperature >= source && temperature <= source + range - 1)
                {
                    var delta = temperature - source;
                    humidity = destination + delta;
                }
            }

            // Get location
            var location = humidity;
            foreach (var (destination, source, range) in humidityToLocationMapList)
            {
                if (humidity >= source && humidity <= source + range - 1)
                {
                    var delta = humidity - source;
                    location = destination + delta;
                }
            }

            locationsList.Add(location);
        }

        long minLocation = 999999999999;
        foreach (var location in locationsList)
        {
            if (location < minLocation)
            {
                minLocation = location;
            }
        }

        return minLocation;
    }

    public static long ProblemPart2(List<string> inputList)
    {
        var minLocation = 999999999999;
        var cache = new Dictionary<long, long>();
        var seedsList = new List<long>();
        var seedToSoilMapList = new List<(long, long, long)>();
        var soilToFertilizerMapList = new List<(long, long, long)>();
        var fertilizerToWaterMapList = new List<(long, long, long)>();
        var waterToLightMapList = new List<(long, long, long)>();
        var lightToTemperatureMapList = new List<(long, long, long)>();
        var temperatureToHumidityMapList = new List<(long, long, long)>();
        var humidityToLocationMapList = new List<(long, long, long)>();

        for (int i = 0; i < inputList.Count(); i++) // Parse input
        {
            if (inputList[i].Contains("seeds:"))
            {
                var seedsSplit = inputList[i].Split(":");
                var seedsString = seedsSplit[1].Trim();
                var seedsListString = seedsString.Split(" ");
                seedsList = seedsListString.Select(long.Parse).ToList();
            }

            if (inputList[i].Contains("seed-to-soil map:"))
            {
                var done = false;
                var j = i;
                while (!done)
                {
                    j++;
                    if (inputList[j] == "")
                    {
                        done = true;
                        break;
                    }
                    var tupleString = inputList[j].Split(" ");
                    var tuple = (long.Parse(tupleString[0]), long.Parse(tupleString[1]), long.Parse(tupleString[2]));
                    seedToSoilMapList.Add(tuple);
                }
            }

            if (inputList[i].Contains("soil-to-fertilizer map:"))
            {
                var done = false;
                var j = i;
                while (!done)
                {
                    j++;
                    if (inputList[j] == "")
                    {
                        done = true;
                        break;
                    }
                    var tupleString = inputList[j].Split(" ");
                    var tuple = (long.Parse(tupleString[0]), long.Parse(tupleString[1]), long.Parse(tupleString[2]));
                    soilToFertilizerMapList.Add(tuple);
                }
            }

            if (inputList[i].Contains("fertilizer-to-water map:"))
            {
                var done = false;
                var j = i;
                while (!done)
                {
                    j++;
                    if (inputList[j] == "")
                    {
                        done = true;
                        break;
                    }
                    var tupleString = inputList[j].Split(" ");
                    var tuple = (long.Parse(tupleString[0]), long.Parse(tupleString[1]), long.Parse(tupleString[2]));
                    fertilizerToWaterMapList.Add(tuple);
                }
            }

            if (inputList[i].Contains("water-to-light map:"))
            {
                var done = false;
                var j = i;
                while (!done)
                {
                    j++;
                    if (inputList[j] == "")
                    {
                        done = true;
                        break;
                    }
                    var tupleString = inputList[j].Split(" ");
                    var tuple = (long.Parse(tupleString[0]), long.Parse(tupleString[1]), long.Parse(tupleString[2]));
                    waterToLightMapList.Add(tuple);
                }
            }

            if (inputList[i].Contains("light-to-temperature map:"))
            {
                var done = false;
                var j = i;
                while (!done)
                {
                    j++;
                    if (inputList[j] == "")
                    {
                        done = true;
                        break;
                    }
                    var tupleString = inputList[j].Split(" ");
                    var tuple = (long.Parse(tupleString[0]), long.Parse(tupleString[1]), long.Parse(tupleString[2]));
                    lightToTemperatureMapList.Add(tuple);
                }
            }

            if (inputList[i].Contains("temperature-to-humidity map:"))
            {
                var done = false;
                var j = i;
                while (!done)
                {
                    j++;
                    if (inputList[j] == "")
                    {
                        done = true;
                        break;
                    }
                    var tupleString = inputList[j].Split(" ");
                    var tuple = (long.Parse(tupleString[0]), long.Parse(tupleString[1]), long.Parse(tupleString[2]));
                    temperatureToHumidityMapList.Add(tuple);
                }
            }

            if (inputList[i].Contains("humidity-to-location map:"))
            {
                var done = false;
                var j = i;
                while (!done)
                {
                    j++;
                    if (j == inputList.Count())
                    {
                        done = true;
                        break;
                    }
                    var tupleString = inputList[j].Split(" ");
                    var tuple = (long.Parse(tupleString[0]), long.Parse(tupleString[1]), long.Parse(tupleString[2]));
                    humidityToLocationMapList.Add(tuple);
                }
            }
        }

        // Time is my friend, brute force FTW!
        for (int i = 0; i < seedsList.Count(); i+=2)
        {
            var start = seedsList[i];
            var end = start + seedsList[i+1] - 1;
            for (long seed = start; seed <= end; seed++)
            {
                // Console.WriteLine(seed);
                long location = -1;
                if (cache.ContainsKey(seed))
                {
                    // location = cache[seed];
                    Console.WriteLine("DUP");
                    continue;
                }
                else {
                    location = GetLocation(seed, seedToSoilMapList, soilToFertilizerMapList, fertilizerToWaterMapList, 
                    waterToLightMapList, lightToTemperatureMapList, temperatureToHumidityMapList, humidityToLocationMapList);
                    cache[seed] = location;
                }
                
                if (location < minLocation) {
                    minLocation = location;
                    Console.WriteLine($"Seed: {seed}");
                    Console.WriteLine($"Location: {minLocation}");
                }
                    
            }
        }

        return minLocation;
    }

    public static long GetLocation(long seed, List<(long, long, long)> seedToSoilMapList, 
        List<(long, long, long)> soilToFertilizerMapList, List<(long, long, long)> fertilizerToWaterMapList, 
        List<(long, long, long)> waterToLightMapList, List<(long, long, long)> lightToTemperatureMapList, 
        List<(long, long, long)> temperatureToHumidityMapList, List<(long, long, long)> humidityToLocationMapList)
    {
        // Get soil
            var soil = seed;
            foreach (var (destination, source, range) in seedToSoilMapList)
            {
                if (seed >= source && seed <= source + range - 1)
                {
                    var delta = seed - source;
                    soil = destination + delta;
                }
            }

            // Get fertilizer
            var fertilizer = soil;
            foreach (var (destination, source, range) in soilToFertilizerMapList)
            {
                if (soil >= source && soil <= source + range - 1)
                {
                    var delta = soil - source;
                    fertilizer = destination + delta;
                }
            }

            // Get water
            var water = fertilizer;
            foreach (var (destination, source, range) in fertilizerToWaterMapList)
            {
                if (fertilizer >= source && fertilizer <= source + range - 1)
                {
                    var delta = fertilizer - source;
                    water = destination + delta;
                }
            }

            // Get light
            var light = water;
            foreach (var (destination, source, range) in waterToLightMapList)
            {
                if (water >= source && water <= source + range - 1)
                {
                    var delta = water - source;
                    light = destination + delta;
                }
            }

            // Get temperature
            var temperature = light;
            foreach (var (destination, source, range) in lightToTemperatureMapList)
            {
                if (light >= source && light <= source + range - 1)
                {
                    var delta = light - source;
                    temperature = destination + delta;
                }
            }

            // Get humidity
            var humidity = temperature;
            foreach (var (destination, source, range) in temperatureToHumidityMapList)
            {
                if (temperature >= source && temperature <= source + range - 1)
                {
                    var delta = temperature - source;
                    humidity = destination + delta;
                }
            }

            // Get location
            var location = humidity;
            foreach (var (destination, source, range) in humidityToLocationMapList)
            {
                if (humidity >= source && humidity <= source + range - 1)
                {
                    var delta = humidity - source;
                    location = destination + delta;
                }
            }

        return location;
    }
}
