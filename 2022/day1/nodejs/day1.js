const day1Part1 = (inputArr) => {
  let maxCalories = 0;
  let localSum = 0;
  for (const i of inputArr) {
    if (i === -1) {
      if (localSum > maxCalories) {
        maxCalories = localSum;
      }
      localSum = 0;
    } else {
      localSum += i;
    }
  }
  if (localSum > 0) {
    if (localSum > maxCalories) {
      maxCalories = localSum;
    }
  }
  return maxCalories;
};

const day1Part2 = (inputArr) => {
  let sumArr = [];
  let localSum = 0;
  for (const i of inputArr) {
    if (i === -1) {
      sumArr.push(localSum);
      localSum = 0;
    } else {
      localSum += i;
    }
  }
  if (localSum > 0) {
    sumArr.push(localSum);
  }
  sumArr.sort((a, b) => {
    return b - a;
  });
  return sumArr[0] + sumArr[1] + sumArr[2];
};

export { day1Part1, day1Part2 };
