using System.Diagnostics.Metrics;

namespace Problem;
public class Problem
{

    public static bool checkAdjacentToSymbol(int i, int j, List<string> inputList)
    {
        // Check left
        if (j-1 >= 0)
        {
            var itemToBeChecked = inputList[i][j-1];
            if (!Char.IsNumber(itemToBeChecked) && !itemToBeChecked.Equals('.'))
                return true;
        }

        // Check down
        if (i+1 < inputList.Count)
        {
            var itemToBeChecked = inputList[i+1][j];
            if (!Char.IsNumber(itemToBeChecked) && !itemToBeChecked.Equals('.'))
                return true;
        }

        // Check right
        if (j+1 < inputList[i].Length)
        {
            var itemToBeChecked = inputList[i][j+1];
            if (!Char.IsNumber(itemToBeChecked) && !itemToBeChecked.Equals('.'))
                return true;
        }

        // Check up
        if (i-1 >= 0)
        {
            var itemToBeChecked = inputList[i-1][j];
            if (!Char.IsNumber(itemToBeChecked) && !itemToBeChecked.Equals('.'))
                return true;
        }

        // Check up left
        if ((i-1 >= 0) && (j-1 >= 0))
        {
            var itemToBeChecked = inputList[i-1][j-1];
            if (!Char.IsNumber(itemToBeChecked) && !itemToBeChecked.Equals('.'))
                return true;
        }

        // Check down left
        if ((i+1 < inputList.Count) && (j-1 >= 0))
        {
            var itemToBeChecked = inputList[i+1][j-1];
            if (!Char.IsNumber(itemToBeChecked) && !itemToBeChecked.Equals('.'))
                return true;
        }

        // Check down right
        if ((i+1 < inputList.Count) && (j+1 < inputList[i].Length))
        {
            var itemToBeChecked = inputList[i+1][j+1];
            if (!Char.IsNumber(itemToBeChecked) && !itemToBeChecked.Equals('.'))
                return true;
        }

        // Check up right
        if ((i-1 >= 0) && (j+1 < inputList[i].Length))
        {
            var itemToBeChecked = inputList[i-1][j+1];
            if (!Char.IsNumber(itemToBeChecked) && !itemToBeChecked.Equals('.'))
                return true;
        }

        return false;
    }

    public static int ProblemPart1(List<string> inputList)
    {
        var totalSum = 0;

        for (int i = 0; i < inputList.Count; i++) // Iterate through lines of the input
        {
            var isPartNumber = false;
            var numString = "";
            
            for (int j = 0; j < inputList[i].Length; j++) // Iterate through characters in a line
            {
                var aChar = inputList[i][j];
                if (Char.IsNumber(aChar))
                {
                    // aChar is a number
                    numString += aChar;
                    var isAdjacentToSymbol = checkAdjacentToSymbol(i, j, inputList);
                    if (isAdjacentToSymbol)
                        isPartNumber = true;
                }
                else
                {
                    // aChar is not a number
                    if (!numString.Equals(""))
                    {
                        if (isPartNumber)
                        {
                            totalSum += Int32.Parse(numString);
                            isPartNumber = false;
                        }
                        numString = "";
                    }
                }
                if (j == inputList[i].Length - 1)
                {
                    // This is the last char in the current line
                    if (!numString.Equals(""))
                    {
                        if (isPartNumber)
                        {
                            totalSum += Int32.Parse(numString);
                            isPartNumber = false;
                        }
                        numString = "";
                    }
                }
            }
        }

        return totalSum;
    }

    public static (bool, int, int) checkAdjacentToSymbolStar(int i, int j, List<string> inputList)
    {
        // Check left
        if (j-1 >= 0)
        {
            var itemToBeChecked = inputList[i][j-1];
            if (!Char.IsNumber(itemToBeChecked) && itemToBeChecked.Equals('*'))
                return (true, i, j-1);
        }

        // Check down
        if (i+1 < inputList.Count)
        {
            var itemToBeChecked = inputList[i+1][j];
            if (!Char.IsNumber(itemToBeChecked) && itemToBeChecked.Equals('*'))
                return (true, i+1, j);
        }

        // Check right
        if (j+1 < inputList[i].Length)
        {
            var itemToBeChecked = inputList[i][j+1];
            if (!Char.IsNumber(itemToBeChecked) && itemToBeChecked.Equals('*'))
                return (true, i, j+1);
        }

        // Check up
        if (i-1 >= 0)
        {
            var itemToBeChecked = inputList[i-1][j];
            if (!Char.IsNumber(itemToBeChecked) && itemToBeChecked.Equals('*'))
                return (true, i-1, j);
        }

        // Check up left
        if ((i-1 >= 0) && (j-1 >= 0))
        {
            var itemToBeChecked = inputList[i-1][j-1];
            if (!Char.IsNumber(itemToBeChecked) && itemToBeChecked.Equals('*'))
                return (true, i-1, j-1);
        }

        // Check down left
        if ((i+1 < inputList.Count) && (j-1 >= 0))
        {
            var itemToBeChecked = inputList[i+1][j-1];
            if (!Char.IsNumber(itemToBeChecked) && itemToBeChecked.Equals('*'))
                return (true, i+1, j-1);
        }

        // Check down right
        if ((i+1 < inputList.Count) && (j+1 < inputList[i].Length))
        {
            var itemToBeChecked = inputList[i+1][j+1];
            if (!Char.IsNumber(itemToBeChecked) && itemToBeChecked.Equals('*'))
                return (true, i+1, j+1);
        }

        // Check up right
        if ((i-1 >= 0) && (j+1 < inputList[i].Length))
        {
            var itemToBeChecked = inputList[i-1][j+1];
            if (!Char.IsNumber(itemToBeChecked) && itemToBeChecked.Equals('*'))
                return (true, i-1, j+1);
        }

        return (false, -1, -1);
    }

    public static int ProblemPart2(List<string> inputList)
    {
        var totalSum = 0;

        var twoGearsMap = new Dictionary<string, List<int>>();

        for (int i = 0; i < inputList.Count; i++) // Iterate through lines of the input
        {
            var isPartNumberStar = false;
            var starX = -1;
            var starY = -1;
            var numString = "";
            
            for (int j = 0; j < inputList[i].Length; j++) // Iterate through characters in a line
            {
                var aChar = inputList[i][j];
                if (Char.IsNumber(aChar))
                {
                    // aChar is a number
                    numString += aChar;
                    var (isAdjacentToSymbolStar, x, y) = checkAdjacentToSymbolStar(i, j, inputList);
                    if (isAdjacentToSymbolStar)
                    {
                        isPartNumberStar = true;
                        starX = x;
                        starY = y;
                    }
                }
                else
                {
                    // aChar is not a number
                    if (!numString.Equals(""))
                    {
                        if (isPartNumberStar)
                        {
                            var coordinateString = "" + starX + "," + starY;
                            var currentNumber = Int32.Parse(numString);
                            if (twoGearsMap.ContainsKey(coordinateString))
                            {
                                var existingList = twoGearsMap[coordinateString];
                                existingList.Add(currentNumber);
                            }
                            else{
                                var newList = new List<int>{currentNumber};
                                twoGearsMap[coordinateString] = newList;
                            }
                            isPartNumberStar = false;
                            starX = -1;
                            starY = -1;
                        }
                        numString = "";
                    }
                }
                if (j == inputList[i].Length - 1)
                {
                    // This is the last char in the current line
                    if (!numString.Equals(""))
                    {
                        if (isPartNumberStar)
                        {
                            var coordinateString = "" + starX + "," + starY;
                            var currentNumber = Int32.Parse(numString);
                            if (twoGearsMap.ContainsKey(coordinateString))
                            {
                                var existingList = twoGearsMap[coordinateString];
                                existingList.Add(currentNumber);
                            }
                            else{
                                var newList = new List<int>{currentNumber};
                                twoGearsMap[coordinateString] = newList;
                            }
                            isPartNumberStar = false;
                            starX = -1;
                            starY = -1;
                        }
                        numString = "";
                    }
                }
            }
        }

        foreach (var starAdjacent in twoGearsMap)
        {
            var listOfNumbers = starAdjacent.Value;
            if (listOfNumbers.Count == 2)
            {
                var gearRatio = listOfNumbers[0] * listOfNumbers[1];
                totalSum += gearRatio;
            }
        }

        return totalSum;
    }
}
