namespace Problem;
public class Problem
{
    public const int Red = 12, Green = 13, Blue = 14;

    public static int ProblemPart1(List<string> inputList)
    {
        var totalSum = 0;

        foreach (var line in inputList)
        {
            var lineSplitColon = line.Split(":");
            var gameInfo = lineSplitColon[0].Split(" ");
            var gameNumber = Int32.Parse(gameInfo[1]);
            var roundInfo = lineSplitColon[1].Split(";");

            foreach (var round in roundInfo)
            {
                var subRoundInfo = round.Split(",");
                foreach (var colorCountInfo in subRoundInfo)
                {
                    var colorCountInfoSplit = colorCountInfo.Trim().Split(" ");
                    var count = Int32.Parse(colorCountInfoSplit[0].Trim());
                    var color = colorCountInfoSplit[1].Trim();
                    if (color.Equals("red"))
                        if (count > Red)
                            goto GameRound;
                    if (color.Equals("green"))
                        if (count > Green)
                            goto GameRound;
                    if (color.Equals("blue"))
                        if (count > Blue)
                            goto GameRound;
                }
            }
            
            totalSum += gameNumber;

            GameRound:
            continue;
        }

        return totalSum;
    }

    public static int ProblemPart2(List<string> inputList)
    {
        var totalSum = 0;

        foreach (var line in inputList)
        {
            var lineSplitColon = line.Split(":");
            var gameInfo = lineSplitColon[0].Split(" ");
            var gameNumber = Int32.Parse(gameInfo[1]);
            var roundInfo = lineSplitColon[1].Split(";");
            var maxRed = 0; 
            var maxGreen = 0;
            var maxBlue = 0;
            
            foreach (var round in roundInfo)
            {
                var subRoundInfo = round.Split(",");
                foreach (var colorCountInfo in subRoundInfo)
                {
                    var colorCountInfoSplit = colorCountInfo.Trim().Split(" ");
                    var count = Int32.Parse(colorCountInfoSplit[0].Trim());
                    var color = colorCountInfoSplit[1].Trim();
                    if (color.Equals("red"))
                        if (count > maxRed)
                            maxRed = count;
                    if (color.Equals("green"))
                        if (count > maxGreen)
                            maxGreen = count;
                    if (color.Equals("blue"))
                        if (count > maxBlue)
                            maxBlue = count;
                }
            }

            var powerSet = maxRed * maxGreen * maxBlue;
            totalSum += powerSet;
        }

        return totalSum;
    }
}
