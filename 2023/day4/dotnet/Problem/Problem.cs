using System.Diagnostics.Metrics;

namespace Problem;
public class Problem
{
    public static int ProblemPart1(List<string> inputList)
    {
        var totalSum = 0;

        foreach (var line in inputList)
        {
            var winningNumberSet = new HashSet<int>();
            var roundPoints = 1;
            var winningCount = 0;
            var found = false;
            var cardInfo = line.Split(":");
            var numberSplit = cardInfo[1].Split("|");
            var winningNumbers = numberSplit[0].Trim().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            var myNumbers = numberSplit[1].Trim().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            foreach (var winningNumber in winningNumbers)
                winningNumberSet.Add(Int32.Parse(winningNumber));

            for (int i = 0; i < myNumbers.Length; i++)
            {
                var currentNumber = Int32.Parse(myNumbers[i]);
                if (winningNumberSet.Contains(currentNumber))
                {
                    found = true;
                    winningCount++;
                    if (winningCount == 1)
                        roundPoints *= 1;
                    else
                        roundPoints *= 2;
                }
            }

            if (found)
                totalSum += roundPoints;
        }

        return totalSum;
    }

    public static int ProblemPart2(List<string> inputList)
    {
        var totalSum = 0;

        var cardCountMapping = new Dictionary<int, int>();
        for (int i = 0; i < inputList.Count(); i++)
            cardCountMapping[i+1] = 1;

        foreach (var line in inputList)
        {
            var winningNumberSet = new HashSet<int>();
            var winningCount = 0;
            var cardInfo = line.Split(":");
            var cardNumberInfo = cardInfo[0].Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            var cardNumber = Int32.Parse(cardNumberInfo[1]);
            var numberSplit = cardInfo[1].Split("|");
            var winningNumbers = numberSplit[0].Trim().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            var myNumbers = numberSplit[1].Trim().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            foreach (var winningNumber in winningNumbers)
                winningNumberSet.Add(Int32.Parse(winningNumber));

            for (int i = 0; i < myNumbers.Length; i++)
            {
                var currentNumber = Int32.Parse(myNumbers[i]);
                if (winningNumberSet.Contains(currentNumber))
                    winningCount++;
            }

            for (int i = 0; i < winningCount; i++)
            {
                var currentCardNumberCount = cardCountMapping[cardNumber];
                var additionalCard = cardNumber + i + 1;
                if (additionalCard <= inputList.Count())
                    cardCountMapping[additionalCard] += currentCardNumberCount;
            }
        }

        foreach (var card in cardCountMapping)
            totalSum += card.Value;

        return totalSum;
    }
}
