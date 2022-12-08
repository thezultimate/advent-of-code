const day9Part1 = (inputArr) => {
  let tailCoordinateMap = {};
  let xHead = 0;
  let yHead = 0;
  let xTail = 0;
  let yTail = 0;

  const tailCoordinate = xTail + "," + yTail;
  tailCoordinateMap[tailCoordinate] = true;

  for (const line of inputArr) {
    if (line.length === 0) continue;
    const lineSplit = line.split(" ");
    const direction = lineSplit[0];
    const steps = parseInt(lineSplit[1]);

    // Iterate through each step
    for (let i = 1; i <= steps; i++) {
      // Left
      if (direction === "L") {
        xHead--;
        if (Math.abs(xHead - xTail) <= 1 && Math.abs(yHead - yTail) <= 1) {
          // Don't move tail
        } else {
          // Tail has to move
          xTail--;
          if (yHead < yTail) yTail--;
          if (yHead > yTail) yTail++;
          const tailCoordinate = xTail + "," + yTail;
          tailCoordinateMap[tailCoordinate] = true;
        }
        continue;
      }

      // Right
      if (direction === "R") {
        xHead++;
        if (Math.abs(xHead - xTail) <= 1 && Math.abs(yHead - yTail) <= 1) {
          // Don't move tail
        } else {
          // Tail has to move
          xTail++;
          if (yHead < yTail) yTail--;
          if (yHead > yTail) yTail++;
          const tailCoordinate = xTail + "," + yTail;
          tailCoordinateMap[tailCoordinate] = true;
        }
        continue;
      }

      // Down
      if (direction === "D") {
        yHead--;
        if (Math.abs(xHead - xTail) <= 1 && Math.abs(yHead - yTail) <= 1) {
          // Don't move tail
        } else {
          // Tail has to move
          yTail--;
          if (xHead < xTail) xTail--;
          if (xHead > xTail) xTail++;
          const tailCoordinate = xTail + "," + yTail;
          tailCoordinateMap[tailCoordinate] = true;
        }
        continue;
      }

      // Up
      if (direction === "U") {
        yHead++;
        if (Math.abs(xHead - xTail) <= 1 && Math.abs(yHead - yTail) <= 1) {
          // Don't move tail
        } else {
          yTail++;
          if (xHead < xTail) xTail--;
          if (xHead > xTail) xTail++;
          const tailCoordinate = xTail + "," + yTail;
          tailCoordinateMap[tailCoordinate] = true;
        }
        continue;
      }
    }
  }

  let tailPointSum = 0;
  for (const tailCoordinate in tailCoordinateMap) {
    tailPointSum++;
  }

  return tailPointSum;
};

const day9Part2 = (inputArr) => {
  let tailCoordinateMap = {};
  // Rope array: head at index 0, tail at index 9
  let ropeArr = [
    [0, 0],
    [0, 0],
    [0, 0],
    [0, 0],
    [0, 0],
    [0, 0],
    [0, 0],
    [0, 0],
    [0, 0],
    [0, 0],
  ];

  let tailCoordinate = 0 + "," + 0;
  tailCoordinateMap[tailCoordinate] = true;

  for (const line of inputArr) {
    if (line.length === 0) continue;
    const lineSplit = line.split(" ");
    const direction = lineSplit[0];
    const steps = parseInt(lineSplit[1]);

    // Iterate through each step
    for (let i = 1; i <= steps; i++) {
      let xHead;
      let yHead;
      let xTail;
      let yTail;

      // Iterate through rope array
      for (let j = 0; j < ropeArr.length; j++) {
        if (j === 0) {
          // Direction is only for the first head
          // Left
          if (direction === "L") {
            ropeArr[j][0]--;
            continue;
          }

          // Right
          if (direction === "R") {
            ropeArr[j][0]++;
            continue;
          }

          // Down
          if (direction === "D") {
            ropeArr[j][1]--;
            continue;
          }

          // Up
          if (direction === "U") {
            ropeArr[j][1]++;
            continue;
          }
        }

        // Not the first head
        xHead = ropeArr[j - 1][0];
        yHead = ropeArr[j - 1][1];
        xTail = ropeArr[j][0];
        yTail = ropeArr[j][1];
        if (Math.abs(xHead - xTail) <= 1 && Math.abs(yHead - yTail) <= 1) {
          // Don't move tail
        } else {
          if (Math.abs(xHead - xTail) > 1) {
            if (xHead > xTail) {
              xTail++;
              if (yHead > yTail) yTail++;
              if (yHead < yTail) yTail--;
            }
            if (xHead < xTail) {
              xTail--;
              if (yHead > yTail) yTail++;
              if (yHead < yTail) yTail--;
            }
          }
          if (Math.abs(yHead - yTail) > 1) {
            if (yHead > yTail) {
              yTail++;
              if (xHead > xTail) xTail++;
              if (xHead < xTail) xTail--;
            }
            if (yHead < yTail) {
              yTail--;
              if (xHead > xTail) xTail++;
              if (xHead < xTail) xTail--;
            }
          }
          ropeArr[j][0] = xTail;
          ropeArr[j][1] = yTail;
        }

        if (j === ropeArr.length - 1) {
          // This is the last tail
          const tailCoordinate = xTail + "," + yTail;
          tailCoordinateMap[tailCoordinate] = true;
        }
      }
    }
  }

  let tailPointSum = 0;
  for (const tailCoordinate in tailCoordinateMap) {
    tailPointSum++;
  }

  return tailPointSum;
};

export { day9Part1, day9Part2 };
