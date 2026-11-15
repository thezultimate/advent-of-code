public class Problem {
    
    public int problemPart1(String[] input) {
        int zeroLeftCounter = 0;
        int currentPos = 50;
        for (String line : input) {
            int numTurn = -1;
            char direction;
            if (line.charAt(0) == 'L') {
                String[] splitLine = line.split("L");
                numTurn = Integer.parseInt(splitLine[1]);
                direction = 'L';
            } else {
                String[] splitLine = line.split("R");
                numTurn = Integer.parseInt(splitLine[1]);
                direction = 'R';
            }
            if (direction == 'L') {
                currentPos -= numTurn;
                currentPos %= 100;
            } else {
                currentPos += numTurn;
                currentPos %= 100;
            }
            if (currentPos == 0) {
                zeroLeftCounter++;
            }
        }
        return zeroLeftCounter;
    }

    public int problemPart2(String[] input) {
        int newCounter = 0;
        int currentPos = 50;
        for (String line : input) {
            int numTurn = -1;
            char direction;
            if (line.charAt(0) == 'L') {
                String[] splitLine = line.split("L");
                numTurn = Integer.parseInt(splitLine[1]);
                direction = 'L';
            } else {
                String[] splitLine = line.split("R");
                numTurn = Integer.parseInt(splitLine[1]);
                direction = 'R';
            }
            
            int divTurn = numTurn / 100;
            newCounter += divTurn;
            int modTurn = numTurn % 100;

            if (direction == 'L') {
                int prevPos = currentPos;
                currentPos -= modTurn;
                if (currentPos < 0 && prevPos != 0)
                    newCounter++;
                currentPos = Math.floorMod(currentPos, 100);
            } else { // right direction
                int prevPos = currentPos;
                currentPos += modTurn;
                if (currentPos > 100 && prevPos != 0)
                    newCounter++;
                currentPos = Math.floorMod(currentPos, 100);
            }
            if (currentPos == 0)
                newCounter++;
        }

        return newCounter;
    }
}