const day1Part1 = (inputArr) => {
  let increaseCount = 0;
  for (const [i, depth] of inputArr.entries()) {
    if (i > 0) {
      if (depth > inputArr[i - 1]) {
        increaseCount++;
      }
    }
  }
  return increaseCount;
};

const day1Part2 = (inputArr) => {
  let increaseCount = 0;
  let threeSumArr = [];
  for (const [i, depth] of inputArr.entries()) {
    if (i < inputArr.length - 2) {
      threeSumArr.push(depth + inputArr[i + 1] + inputArr[i + 2]);
    }
  }
  for (const [i, depth] of threeSumArr.entries()) {
    if (i > 0) {
      if (depth > threeSumArr[i - 1]) {
        increaseCount++;
      }
    }
  }
  return increaseCount;
};

export { day1Part1, day1Part2 };
