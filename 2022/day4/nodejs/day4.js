const day4Part1 = (inputArr) => {
  let counter = 0;
  for (const line of inputArr) {
    if (line.length === 0) continue;
    const pairsString = line.split(",");
    const firstPairString = pairsString[0].split("-");
    const secondPairString = pairsString[1].split("-");
    const firstPairLow = parseInt(firstPairString[0]);
    const firstPairHigh = parseInt(firstPairString[1]);
    const secondPairLow = parseInt(secondPairString[0]);
    const secondPairHigh = parseInt(secondPairString[1]);
    if (firstPairLow >= secondPairLow && firstPairHigh <= secondPairHigh) {
      counter++;
      continue;
    }
    if (secondPairLow >= firstPairLow && secondPairHigh <= firstPairHigh) {
      counter++;
      continue;
    }
  }

  return counter;
};

const day4Part2 = (inputArr) => {
  let counter = 0;
  for (const line of inputArr) {
    if (line.length === 0) continue;
    const pairsString = line.split(",");
    const firstPairString = pairsString[0].split("-");
    const secondPairString = pairsString[1].split("-");
    const firstPairLow = parseInt(firstPairString[0]);
    const firstPairHigh = parseInt(firstPairString[1]);
    const secondPairLow = parseInt(secondPairString[0]);
    const secondPairHigh = parseInt(secondPairString[1]);
    if (firstPairHigh >= secondPairLow && firstPairLow <= secondPairHigh) {
      counter++;
      continue;
    }
    if (firstPairLow <= secondPairHigh && firstPairHigh >= secondPairLow) {
      counter++;
      continue;
    }
  }

  return counter;
};

export { day4Part1, day4Part2 };
