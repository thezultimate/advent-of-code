using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace Problem;
public class Problem
{
    public enum CardType
    {
        FiveOfAKind,
        FourOfAKind,
        FullHouse,
        ThreeOfAKind,
        TwoPair,
        OnePair,
        HighCard
    }

    public static CardType GetCardType(string card)
    {
        var charCountMap = new Dictionary<char, int>();
        var countCountMap = new Dictionary<int, int>()
        {
            {1, 0},
            {2, 0},
            {3, 0},
            {4, 0},
            {5, 0}
        };

        foreach (var aChar in card)
        {
            if (charCountMap.ContainsKey(aChar))
                charCountMap[aChar]++;
            else
                charCountMap[aChar] = 1;
        }

        foreach (var aChar in charCountMap)
        {
            if (aChar.Value == 1)
                countCountMap[1]++;
            if (aChar.Value == 2)
                countCountMap[2]++;
            if (aChar.Value == 3)
                countCountMap[3]++;
            if (aChar.Value == 4)
                countCountMap[4]++;
            if (aChar.Value == 5)
                countCountMap[5]++;
        }

        if (countCountMap[5] > 0)
            return CardType.FiveOfAKind;
        if (countCountMap[4] > 0)
            return CardType.FourOfAKind;
        if (countCountMap[3] > 0 && countCountMap[2] > 0)
            return CardType.FullHouse;
        if (countCountMap[3] > 0)
            return CardType.ThreeOfAKind;
        if (countCountMap[2] == 2)
            return CardType.TwoPair;
        if (countCountMap[2] == 1)
            return CardType.OnePair;

        return CardType.HighCard;
    }

    public static string GetCharValueMap(char aChar)
    {
        switch (aChar)
        {
            case '2':
                return "10";
            case '3':
                return "11";
            case '4':
                return "12";
            case '5':
                return "13";
            case '6':
                return "14";
            case '7':
                return "15";
            case '8':
                return "16";
            case '9':
                return "17";
            case 'T':
                return "18";
            case 'J':
                return "19";
            case 'Q':
                return "20";
            case 'K':
                return "21";
            case 'A':
                return "22";
        }

        return "--";
    }

    public static long GetCardValue(string card)
    {
        var cardValue = "";
        foreach (var aChar in card)
        {
            var aCharValue = GetCharValueMap(aChar);
            cardValue += aCharValue;
        }
        return long.Parse(cardValue);
    }

    public static long ProblemPart1(List<string> inputList)
    {
        var cardValueBidMap = new Dictionary<long, int>();
        var fiveOfAKindList = new List<long>();
        var fourOfAKindList = new List<long>();
        var fullHouseList = new List<long>();
        var threeOfAKindList = new List<long>();
        var twoPairList = new List<long>();
        var onePairList = new List<long>();
        var highCardList = new List<long>();

        foreach (var cardInfo in inputList)
        {
            var cardSplit = cardInfo.Split(" ");
            var card = cardSplit[0];
            var bid = cardSplit[1];
            var cardType = GetCardType(card);
            var cardValue = GetCardValue(card);
            cardValueBidMap[cardValue] = int.Parse(bid);

            if (cardType.Equals(CardType.FiveOfAKind))
                fiveOfAKindList.Add(cardValue);
            if (cardType.Equals(CardType.FourOfAKind))
                fourOfAKindList.Add(cardValue);
            if (cardType.Equals(CardType.FullHouse))
                fullHouseList.Add(cardValue);
            if (cardType.Equals(CardType.ThreeOfAKind))
                threeOfAKindList.Add(cardValue);
            if (cardType.Equals(CardType.TwoPair))
                twoPairList.Add(cardValue);
            if (cardType.Equals(CardType.OnePair))
                onePairList.Add(cardValue);
            if (cardType.Equals(CardType.HighCard))
                highCardList.Add(cardValue);
        }

        // Sort the lists in ascending order
        fiveOfAKindList.Sort();
        fourOfAKindList.Sort();
        fullHouseList.Sort();
        threeOfAKindList.Sort();
        twoPairList.Sort();
        onePairList.Sort();
        highCardList.Sort();

        long totalSum = 0;
        var counter = 1;

        foreach (var cardValue in highCardList)
        {
            totalSum += (counter * cardValueBidMap[cardValue]);
            counter++;
        }
        foreach (var cardValue in onePairList)
        {
            totalSum += (counter * cardValueBidMap[cardValue]);
            counter++;
        }
        foreach (var cardValue in twoPairList)
        {
            totalSum += (counter * cardValueBidMap[cardValue]);
            counter++;
        }
        foreach (var cardValue in threeOfAKindList)
        {
            totalSum += (counter * cardValueBidMap[cardValue]);
            counter++;
        }
        foreach (var cardValue in fullHouseList)
        {
            totalSum += (counter * cardValueBidMap[cardValue]);
            counter++;
        }
        foreach (var cardValue in fourOfAKindList)
        {
            totalSum += (counter * cardValueBidMap[cardValue]);
            counter++;
        }
        foreach (var cardValue in fiveOfAKindList)
        {
            totalSum += (counter * cardValueBidMap[cardValue]);
            counter++;
        }

        return totalSum;
    }

    public static CardType  GetCardTypeJoker(string card)
    {
        var charCountMap = new Dictionary<char, int>();
        var countCountMap = new Dictionary<int, int>()
        {
            {1, 0},
            {2, 0},
            {3, 0},
            {4, 0},
            {5, 0}
        };

        foreach (var aChar in card)
        {
            if (charCountMap.ContainsKey(aChar))
                charCountMap[aChar]++;
            else
                charCountMap[aChar] = 1;
        }

        // Check if card contains Joker
        if (charCountMap.ContainsKey('J') && charCountMap['J'] < 5)
        {
            var jokerCharCount = charCountMap['J'];
            var maxCount = 0;
            var maxCountChar = '-';
            foreach (var aCharMap in charCountMap)
            {
                if (!aCharMap.Key.Equals('J'))
                {
                    if (aCharMap.Value > maxCount)
                    {
                        maxCount = aCharMap.Value;
                        maxCountChar = aCharMap.Key;
                    }
                }
            }
            charCountMap[maxCountChar] += jokerCharCount; // Set the highest count char plus Jokers
            charCountMap['J'] = 0; // Remove Jokers
        }

        foreach (var aChar in charCountMap)
        {
            if (aChar.Value == 1)
                countCountMap[1]++;
            if (aChar.Value == 2)
                countCountMap[2]++;
            if (aChar.Value == 3)
                countCountMap[3]++;
            if (aChar.Value == 4)
                countCountMap[4]++;
            if (aChar.Value == 5)
                countCountMap[5]++;
        }

        if (countCountMap[5] > 0)
            return CardType.FiveOfAKind;
        if (countCountMap[4] > 0)
            return CardType.FourOfAKind;
        if (countCountMap[3] > 0 && countCountMap[2] > 0)
            return CardType.FullHouse;
        if (countCountMap[3] > 0)
            return CardType.ThreeOfAKind;
        if (countCountMap[2] == 2)
            return CardType.TwoPair;
        if (countCountMap[2] == 1)
            return CardType.OnePair;

        return CardType.HighCard;
    }

    public static long GetCardValueJoker(string card)
    {
        var cardValue = "";
        foreach (var aChar in card)
        {
            var aCharValue = GetCharValueMapJoker(aChar);
            cardValue += aCharValue;
        }
        return long.Parse(cardValue);
    }

    public static string GetCharValueMapJoker(char aChar)
    {
        switch (aChar)
        {
            case 'J':
                return "10";
            case '2':
                return "11";
            case '3':
                return "12";
            case '4':
                return "13";
            case '5':
                return "14";
            case '6':
                return "15";
            case '7':
                return "16";
            case '8':
                return "17";
            case '9':
                return "18";
            case 'T':
                return "19";
            case 'Q':
                return "20";
            case 'K':
                return "21";
            case 'A':
                return "22";
        }

        return "--";
    }

    public static long ProblemPart2(List<string> inputList)
    {
        var cardValueBidMap = new Dictionary<long, int>();
        var fiveOfAKindList = new List<long>();
        var fourOfAKindList = new List<long>();
        var fullHouseList = new List<long>();
        var threeOfAKindList = new List<long>();
        var twoPairList = new List<long>();
        var onePairList = new List<long>();
        var highCardList = new List<long>();

        foreach (var cardInfo in inputList)
        {
            var cardSplit = cardInfo.Split(" ");
            var card = cardSplit[0];
            var bid = cardSplit[1];
            var cardType = GetCardTypeJoker(card);
            var cardValue = GetCardValueJoker(card);
            cardValueBidMap[cardValue] = int.Parse(bid);

            if (cardType.Equals(CardType.FiveOfAKind))
                fiveOfAKindList.Add(cardValue);
            if (cardType.Equals(CardType.FourOfAKind))
                fourOfAKindList.Add(cardValue);
            if (cardType.Equals(CardType.FullHouse))
                fullHouseList.Add(cardValue);
            if (cardType.Equals(CardType.ThreeOfAKind))
                threeOfAKindList.Add(cardValue);
            if (cardType.Equals(CardType.TwoPair))
                twoPairList.Add(cardValue);
            if (cardType.Equals(CardType.OnePair))
                onePairList.Add(cardValue);
            if (cardType.Equals(CardType.HighCard))
                highCardList.Add(cardValue);
        }

        // Sort the lists in ascending order
        fiveOfAKindList.Sort();
        fourOfAKindList.Sort();
        fullHouseList.Sort();
        threeOfAKindList.Sort();
        twoPairList.Sort();
        onePairList.Sort();
        highCardList.Sort();

        long totalSum = 0;
        var counter = 1;

        foreach (var cardValue in highCardList)
        {
            totalSum += (counter * cardValueBidMap[cardValue]);
            counter++;
        }
        foreach (var cardValue in onePairList)
        {
            totalSum += (counter * cardValueBidMap[cardValue]);
            counter++;
        }
        foreach (var cardValue in twoPairList)
        {
            totalSum += (counter * cardValueBidMap[cardValue]);
            counter++;
        }
        foreach (var cardValue in threeOfAKindList)
        {
            totalSum += (counter * cardValueBidMap[cardValue]);
            counter++;
        }
        foreach (var cardValue in fullHouseList)
        {
            totalSum += (counter * cardValueBidMap[cardValue]);
            counter++;
        }
        foreach (var cardValue in fourOfAKindList)
        {
            totalSum += (counter * cardValueBidMap[cardValue]);
            counter++;
        }
        foreach (var cardValue in fiveOfAKindList)
        {
            totalSum += (counter * cardValueBidMap[cardValue]);
            counter++;
        }

        return totalSum;
    }
}
