namespace Problem;
public class Problem
{
    public static int ProblemPart1(List<string> inputArr)
    {
        var totalSum = 0;
        foreach (var line in inputArr)
        {
            var numList = new List<int>();
            foreach (var aChar in line)
            {
                if (Char.IsNumber(aChar))
                    numList.Add(Int32.Parse(aChar.ToString()));
            }
            var aNumberString = "" + numList.First() + numList.Last();
            var aNumber = Int32.Parse(aNumberString);
            totalSum += aNumber;
        }
        
        return totalSum;
    }

    public static int ProblemPart2(List<string> inputArr)
    {
        var digitMap = new Dictionary<string, int>
        {
            {"one", 1},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9}
        };
        var digitStringList = new List<string>
        {
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine"
        };
        var totalSum = 0;
        foreach (var line in inputArr)
        {
            var firstNumString = "";
            var lastNumString = "";
            var possibleNumber = "";

            // Find first
            for (int i = 0; i < line.Length; i++)
            {
                var aChar = line[i];
                if (Char.IsNumber(aChar))
                {
                    firstNumString = aChar.ToString();
                    possibleNumber = "";
                    break;
                }
                else
                {
                    possibleNumber += aChar;
                    foreach (var digitString in digitStringList)
                    {
                        if (possibleNumber.Contains(digitString))
                        {
                            firstNumString = digitMap[digitString].ToString();
                            possibleNumber = "";
                            goto FindLast;
                        }
                    }
                }
            }

            // Find last
            FindLast:
            for (int i = line.Length - 1; i >= 0; i--)
            {
                var aChar = line[i];
                if (Char.IsNumber(aChar))
                {
                    lastNumString = aChar.ToString();
                    possibleNumber = "";
                    break;
                }
                else
                {
                    possibleNumber = aChar + possibleNumber;
                    foreach (var digitString in digitStringList)
                    {
                        if (possibleNumber.Contains(digitString))
                        {
                            lastNumString = digitMap[digitString].ToString();
                            possibleNumber = "";
                            goto Finish;
                        }
                    }
                }
            }

            Finish:
            var aNumberString = firstNumString + lastNumString;
            var aNumber = Int32.Parse(aNumberString);
            totalSum += aNumber;
        }
        
        return totalSum;
    }
}
