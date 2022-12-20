const day20Part1 = (inputArr) => {
  let numberStringMap = {};
  let numberArrOrig = [];
  let numberArr = [];
  let duplicateSuffix = 0;
  let index = 0;
  for (const line of inputArr) {
    if (line.length === 0) continue;

    if (line in numberStringMap) {
      // Duplicate number string
      duplicateSuffix++;
      numberStringMap[line + "-" + duplicateSuffix] = index;
      numberArrOrig.push(line + "-" + duplicateSuffix);
      numberArr.push(line + "-" + duplicateSuffix);
    } else {
      numberStringMap[line] = index;
      numberArrOrig.push(line);
      numberArr.push(line);
    }
    index++;
  }

  for (let i = 0; i < numberArrOrig.length; i++) {
    const currentNumberString = numberArrOrig[i];
    let currentPosition = numberStringMap[currentNumberString];
    const currentNumber = parseInt(currentNumberString);

    if (currentNumber === 0) {
      continue;
    }

    let targetPosition;

    targetPosition = currentPosition + currentNumber;

    if (targetPosition === 0) {
      targetPosition = numberArr.length - 1;
    } else if (targetPosition === numberArr.length - 1) {
      targetPosition = 0;
    } else if (targetPosition < 0) {
      targetPosition =
        numberArr.length - 1 + (targetPosition % (numberArr.length - 1));
    } else if (targetPosition > numberArr.length - 1) {
      targetPosition = targetPosition % (numberArr.length - 1);
    }

    if (targetPosition > currentPosition) {
      for (let j = currentPosition; j < targetPosition; j++) {
        numberArr[j] = numberArr[j + 1]; // Shift left
        numberStringMap[numberArr[j + 1]]--;
      }
      numberArr[targetPosition] = currentNumberString;
      numberStringMap[currentNumberString] = targetPosition;
    }

    if (targetPosition < currentPosition) {
      for (let j = currentPosition; j > targetPosition; j--) {
        numberArr[j] = numberArr[j - 1]; // Shift right
        numberStringMap[numberArr[j - 1]]++;
      }
      numberArr[targetPosition] = currentNumberString;
      numberStringMap[currentNumberString] = targetPosition;
    }

    if (targetPosition === currentPosition) {
      continue;
    }
  }

  let firstAddition = 1000 % numberArr.length;
  let secondAddition = 2000 % numberArr.length;
  let thirdAddition = 3000 % numberArr.length;
  let firstIndex = numberStringMap["0"] + firstAddition;
  if (firstIndex > numberArr.length - 1) {
    firstIndex -= numberArr.length;
  }
  let secondIndex = numberStringMap["0"] + secondAddition;
  if (secondIndex > numberArr.length - 1) {
    secondIndex -= numberArr.length;
  }
  let thirdIndex = numberStringMap["0"] + thirdAddition;
  if (thirdIndex > numberArr.length - 1) {
    thirdIndex -= numberArr.length;
  }

  return (
    parseInt(numberArr[firstIndex]) +
    parseInt(numberArr[secondIndex]) +
    parseInt(numberArr[thirdIndex])
  );
};

const day20Part2 = (inputArr) => {
  let numberStringMap = {};
  let numberArrOrig = [];
  let numberArr = [];
  let duplicateSuffix = 0;
  let index = 0;
  for (const line of inputArr) {
    if (line.length === 0) continue;

    const lineNumber = parseInt(line);
    const bigLineNumber = lineNumber * 811589153; // Bigger
    const bigLine = bigLineNumber.toString();

    if (bigLine in numberStringMap) {
      // Duplicate number string
      duplicateSuffix++;
      numberStringMap[bigLine + "-" + duplicateSuffix] = index;
      numberArrOrig.push(bigLine + "-" + duplicateSuffix);
      numberArr.push(bigLine + "-" + duplicateSuffix);
    } else {
      numberStringMap[bigLine] = index;
      numberArrOrig.push(bigLine);
      numberArr.push(bigLine);
    }
    index++;
  }

  // 10X
  for (let j = 1; j <= 10; j++) {
    for (let i = 0; i < numberArrOrig.length; i++) {
      const currentNumberString = numberArrOrig[i];
      let currentPosition = numberStringMap[currentNumberString];
      const currentNumber = parseInt(currentNumberString);

      if (currentNumber === 0) {
        continue;
      }

      let targetPosition;

      targetPosition = currentPosition + currentNumber;

      if (targetPosition === 0) {
        targetPosition = numberArr.length - 1;
      } else if (targetPosition === numberArr.length - 1) {
        targetPosition = 0;
      } else if (targetPosition < 0) {
        targetPosition =
          numberArr.length - 1 + (targetPosition % (numberArr.length - 1));
      } else if (targetPosition > numberArr.length - 1) {
        targetPosition = targetPosition % (numberArr.length - 1);
      }

      if (targetPosition > currentPosition) {
        for (let j = currentPosition; j < targetPosition; j++) {
          numberArr[j] = numberArr[j + 1]; // Shift left
          numberStringMap[numberArr[j + 1]]--;
        }
        numberArr[targetPosition] = currentNumberString;
        numberStringMap[currentNumberString] = targetPosition;
      }

      if (targetPosition < currentPosition) {
        for (let j = currentPosition; j > targetPosition; j--) {
          numberArr[j] = numberArr[j - 1]; // Shift right
          numberStringMap[numberArr[j - 1]]++;
        }
        numberArr[targetPosition] = currentNumberString;
        numberStringMap[currentNumberString] = targetPosition;
      }

      if (targetPosition === currentPosition) {
        continue;
      }
    }
  }

  let firstAddition = 1000 % numberArr.length;
  let secondAddition = 2000 % numberArr.length;
  let thirdAddition = 3000 % numberArr.length;
  let firstIndex = numberStringMap["0"] + firstAddition;
  if (firstIndex > numberArr.length - 1) {
    firstIndex -= numberArr.length;
  }
  let secondIndex = numberStringMap["0"] + secondAddition;
  if (secondIndex > numberArr.length - 1) {
    secondIndex -= numberArr.length;
  }
  let thirdIndex = numberStringMap["0"] + thirdAddition;
  if (thirdIndex > numberArr.length - 1) {
    thirdIndex -= numberArr.length;
  }

  return (
    parseInt(numberArr[firstIndex]) +
    parseInt(numberArr[secondIndex]) +
    parseInt(numberArr[thirdIndex])
  );
};

export { day20Part1, day20Part2 };
