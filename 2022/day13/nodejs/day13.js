const compare = (leftJson, rightJson) => {
  const leftJsonLength = leftJson.length;
  const rightJsonLength = rightJson.length;

  let maxLength = leftJsonLength;
  if (rightJsonLength > maxLength) maxLength = rightJsonLength;

  for (let i = 0; i < maxLength; i++) {
    let leftItem = leftJson[i];
    let rightItem = rightJson[i];
    let isLeftItemArray = Array.isArray(leftItem);
    let isRightItemArray = Array.isArray(rightItem);

    if (!isLeftItemArray && !isRightItemArray) {
      // Left and right are both numbers or undefined
      if (typeof leftItem === "undefined") return true; // Left item is empty first
      if (typeof rightItem === "undefined") return false; // Right item is empty first
      if (leftItem === rightItem) continue;
      if (leftItem < rightItem) return true;
      else return false;
    }

    if (isLeftItemArray && !isRightItemArray) {
      // Left is array and right is number or undefined
      if (typeof rightItem === "undefined") return false; // Right item is empty first
      let compareResult = compare(leftItem, [rightItem]); // compareResult can be true, false, undefined. Do nothing if undefined.
      if (typeof compareResult !== "undefined") return compareResult;
    }

    if (!isLeftItemArray && isRightItemArray) {
      // Left is number or undefined and right is array
      if (typeof leftItem === "undefined") return true; // Left item is empty first
      let compareResult = compare([leftItem], rightItem); // compareResult can be true, false, undefined. Do nothing if undefined.
      if (typeof compareResult !== "undefined") return compareResult;
    }

    if (isLeftItemArray && isRightItemArray) {
      // Both left and right are arrays
      let compareResult = compare(leftItem, rightItem); // compareResult can be true, false, undefined. Do nothing if undefined.
      if (typeof compareResult !== "undefined") return compareResult;
    }
  }

  return;
};

const day13Part1 = (inputArr) => {
  let rightOrderSum = 0;
  let input = [];
  let index = 0;

  for (const line of inputArr) {
    if (line.length === 0) {
      const left = input[0];
      const right = input[1];
      input = [];
      index++;

      const compareResult = compare(JSON.parse(left), JSON.parse(right));
      if (typeof compareResult === "boolean") {
        if (compareResult) rightOrderSum += index;
      }

      continue;
    }

    input.push(line);
  }

  return rightOrderSum;
};

const day13Part2 = (inputArr) => {
  let allPackets = [];
  for (const line of inputArr) {
    if (line.length === 0) continue;
    allPackets.push(line);
  }
  const dividerPacketOne = "[[2]]";
  const dividerPacketTwo = "[[6]]";
  allPackets.push(dividerPacketOne);
  allPackets.push(dividerPacketTwo);

  // Sort packets (bubble sort)
  const allPacketsLength = allPackets.length;
  for (let i = 0; i < allPacketsLength; i++) {
    for (let j = 0; j < allPacketsLength - i - 1; j++) {
      const compareResult = compare(
        JSON.parse(allPackets[j]),
        JSON.parse(allPackets[j + 1])
      );
      if (!compareResult) {
        const temp = allPackets[j];
        allPackets[j] = allPackets[j + 1];
        allPackets[j + 1] = temp;
      }
    }
  }

  let decoderKey = 1;
  for (let i = 0; i < allPacketsLength; i++) {
    if (
      allPackets[i] === dividerPacketOne ||
      allPackets[i] === dividerPacketTwo
    ) {
      decoderKey *= i + 1;
    }
  }

  return decoderKey;
};

export { day13Part1, day13Part2, compare };
