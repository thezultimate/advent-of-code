const getRocks = () => {
  let rocksArr = [];
  let rockOne = [
    [0, 0],
    [0, 1],
    [0, 2],
    [0, 3],
  ];
  rocksArr.push(rockOne);
  let rockTwo = [
    [0, 1],
    [1, 0],
    [1, 1],
    [1, 2],
    [2, 1],
  ];
  rocksArr.push(rockTwo);
  let rockThree = [
    [0, 2],
    [1, 2],
    [2, 0],
    [2, 1],
    [2, 2],
  ];
  rocksArr.push(rockThree);
  let rockFour = [
    [0, 0],
    [1, 0],
    [2, 0],
    [3, 0],
  ];
  rocksArr.push(rockFour);
  let rockFive = [
    [0, 0],
    [0, 1],
    [1, 0],
    [1, 1],
  ];
  rocksArr.push(rockFive);
  return rocksArr;
};

const canMoveDown = (grid, rock) => {
  let isDownEmpty = true;
  for (let j = 0; j < rock.length; j++) {
    if (
      grid[rock[j][0] + 1][rock[j][1]] === "#" ||
      grid[rock[j][0] + 1][rock[j][1]] === "-"
    ) {
      // Below point is occupied
      isDownEmpty = false;
      return isDownEmpty;
    }
  }
  return isDownEmpty;
};

const canMoveRight = (grid, rock) => {
  let isRightEmpty = true;
  for (let j = 0; j < rock.length; j++) {
    if (
      grid[rock[j][0]][rock[j][1] + 1] === "#" ||
      grid[rock[j][0]][rock[j][1] + 1] === "|"
    ) {
      // Right point is occupied
      isRightEmpty = false;
      return isRightEmpty;
    }
  }
  return isRightEmpty;
};

const canMoveLeft = (grid, rock) => {
  let isLeftEmpty = true;
  for (let j = 0; j < rock.length; j++) {
    if (
      grid[rock[j][0]][rock[j][1] - 1] === "#" ||
      grid[rock[j][0]][rock[j][1] - 1] === "|"
    ) {
      // Left point is occupied
      isLeftEmpty = false;
      return isLeftEmpty;
    }
  }
  return isLeftEmpty;
};

const moveRight = (rock) => {
  for (let j = 0; j < rock.length; j++) {
    rock[j][1] = rock[j][1] + 1;
  }
};

const moveLeft = (rock) => {
  for (let j = 0; j < rock.length; j++) {
    rock[j][1] = rock[j][1] - 1;
  }
};

const moveDown = (rock) => {
  for (let j = 0; j < rock.length; j++) {
    rock[j][0] = rock[j][0] + 1;
  }
};

const day17Part1 = (input, maxNumRocks) => {
  const towerWidth = 9;
  const towerHeight = 8100;
  let grid = [];

  // Build initial grid
  for (let i = 0; i < towerHeight - 1; i++) {
    let rowArr = [];
    for (let j = 0; j < towerWidth; j++) {
      if (j === 0 || j === towerWidth - 1) rowArr.push("|");
      else rowArr.push(".");
    }
    grid.push(rowArr);
  }
  let rowArr = [];
  for (let j = 0; j < towerWidth; j++) {
    if (j === 0 || j === towerWidth - 1) rowArr.push("+");
    else rowArr.push("-");
  }
  grid.push(rowArr);

  let rocksArr = getRocks();
  let highestRock = towerHeight - 1;

  // Arrow state
  let arrowIndex = 0;
  let maxArrowIndex = input.length - 1;

  // Iterate up to maxNumRocks
  for (let i = 1; i <= maxNumRocks; i++) {
    let currentNumRock = i;
    if (i > 5) {
      currentNumRock = i % 5;
      if (currentNumRock === 0) {
        currentNumRock = 5;
      }
    }

    let currentRock = rocksArr[currentNumRock - 1];
    let currentRockOperational = JSON.parse(JSON.stringify(currentRock));

    // Get left-most and bottom-most coordinate of the initial rock
    let rockLeftMostCoordinate = 10;
    let rockBottomMostCoordinate = 0;
    for (let j = 0; j < currentRockOperational.length; j++) {
      if (currentRockOperational[j][0] > rockBottomMostCoordinate) {
        rockBottomMostCoordinate = currentRockOperational[j][0];
      }
      if (currentRockOperational[j][1] < rockLeftMostCoordinate) {
        rockLeftMostCoordinate = currentRockOperational[j][1];
      }
    }

    // Initial positioning of current rock
    for (let j = 0; j < currentRockOperational.length; j++) {
      currentRockOperational[j][0] =
        currentRockOperational[j][0] +
        (highestRock - 4 - rockBottomMostCoordinate); // Adjusted height
      currentRockOperational[j][1] = currentRockOperational[j][1] + 3; // Adjusted left
    }

    let hasRockStopped = false;

    // While rock hasn't stopped moving
    while (!hasRockStopped) {
      // Get next move arrow
      let nextArrow = input[arrowIndex];
      // Update arrow index
      if (arrowIndex === maxArrowIndex) arrowIndex = 0;
      else arrowIndex++;

      if (nextArrow === ">") {
        // Try move right
        let isRightMovable = canMoveRight(grid, currentRockOperational);
        if (isRightMovable) moveRight(currentRockOperational); // Move rock to the right
      }

      if (nextArrow === "<") {
        // Try move left
        let isLeftMovable = canMoveLeft(grid, currentRockOperational);
        if (isLeftMovable) moveLeft(currentRockOperational);
      }

      // Try move down
      let isDownMovable = canMoveDown(grid, currentRockOperational);
      if (isDownMovable) moveDown(currentRockOperational);
      else {
        // Can't move down
        hasRockStopped = true;
        let highestCurrentRockPoint = 10000;
        // Draw rock in grid
        for (let j = 0; j < currentRockOperational.length; j++) {
          grid[currentRockOperational[j][0]][currentRockOperational[j][1]] =
            "#";
          if (currentRockOperational[j][0] < highestCurrentRockPoint)
            highestCurrentRockPoint = currentRockOperational[j][0];
        }
        // Update highest rock position if needed
        if (highestCurrentRockPoint < highestRock)
          highestRock = highestCurrentRockPoint;
      }
    }
  }

  return towerHeight - 1 - highestRock;
};

const day17Part2 = (input, maxNumRocks) => {
  const towerWidth = 9;
  const towerHeight = 50000; // Probably this height is overkill
  let grid = [];

  // Build initial grid
  for (let i = 0; i < towerHeight - 1; i++) {
    let rowArr = [];
    for (let j = 0; j < towerWidth; j++) {
      if (j === 0 || j === towerWidth - 1) rowArr.push("|");
      else rowArr.push(".");
    }
    grid.push(rowArr);
  }
  let rowArr = [];
  for (let j = 0; j < towerWidth; j++) {
    if (j === 0 || j === towerWidth - 1) rowArr.push("+");
    else rowArr.push("-");
  }
  grid.push(rowArr);

  let rocksArr = getRocks();
  let highestRock = towerHeight - 1;

  // Arrow state
  let arrowIndex = 0;
  let maxArrowIndex = input.length - 1;

  // Cycle detection params
  let rockArrowIndexMap = {};
  let isCycleFoundFirst = false;
  let isCycleFoundSecond = false;
  let cycleRoundFirst;
  let cycleRoundSecond;
  let cycleMaxHeightFirst;
  let cycleMaxHeightSecond;
  let rockArrowKey;
  let cycleHeightDelta;
  let cycleRoundDelta;
  let remainingTotalRound;
  let potentialMaxHeight;
  let remainingTotalRoundDiff;

  // Iterate up to a reasonably enough rock rounds
  let reasonableRound = 10000;
  rockRoundIteration: for (let i = 1; i <= reasonableRound; i++) {
    let currentNumRock = i;
    if (i > 5) {
      currentNumRock = i % 5;
      if (currentNumRock === 0) {
        currentNumRock = 5;
      }
    }

    let currentRock = rocksArr[currentNumRock - 1];
    let currentRockOperational = JSON.parse(JSON.stringify(currentRock));

    // Get left-most and bottom-most coordinate of the initial rock
    let rockLeftMostCoordinate = 10;
    let rockBottomMostCoordinate = 0;
    for (let j = 0; j < currentRockOperational.length; j++) {
      if (currentRockOperational[j][0] > rockBottomMostCoordinate) {
        rockBottomMostCoordinate = currentRockOperational[j][0];
      }
      if (currentRockOperational[j][1] < rockLeftMostCoordinate) {
        rockLeftMostCoordinate = currentRockOperational[j][1];
      }
    }

    // Initial positioning of current rock
    for (let j = 0; j < currentRockOperational.length; j++) {
      currentRockOperational[j][0] =
        currentRockOperational[j][0] +
        (highestRock - 4 - rockBottomMostCoordinate); // Adjusted height
      currentRockOperational[j][1] = currentRockOperational[j][1] + 3; // Adjusted left
    }

    let hasRockStopped = false;

    // While rock hasn't stopped moving
    while (!hasRockStopped) {
      // Get next move arrow
      let nextArrow = input[arrowIndex];
      // Update arrow index
      if (arrowIndex === maxArrowIndex) arrowIndex = 0;
      else arrowIndex++;

      if (nextArrow === ">") {
        // Try move right
        let isRightMovable = canMoveRight(grid, currentRockOperational);
        if (isRightMovable) moveRight(currentRockOperational); // Move rock to the right
      }

      if (nextArrow === "<") {
        // Try move left
        let isLeftMovable = canMoveLeft(grid, currentRockOperational);
        if (isLeftMovable) moveLeft(currentRockOperational);
      }

      // Try move down
      let isDownMovable = canMoveDown(grid, currentRockOperational);
      if (isDownMovable) moveDown(currentRockOperational);
      else {
        // Can't move down
        hasRockStopped = true;
        let highestCurrentRockPoint = 50001;
        // Draw rock in grid
        for (let j = 0; j < currentRockOperational.length; j++) {
          grid[currentRockOperational[j][0]][currentRockOperational[j][1]] =
            "#";
          if (currentRockOperational[j][0] < highestCurrentRockPoint)
            highestCurrentRockPoint = currentRockOperational[j][0];
        }
        // Update highest rock position if needed
        if (highestCurrentRockPoint < highestRock)
          highestRock = highestCurrentRockPoint;

        // Check cycles after part 1 is completed
        if (i > 2022) {
          let currentRockArrowKey = currentNumRock + "-" + arrowIndex;
          if (currentRockArrowKey in rockArrowIndexMap) {
            // Cycle detected
            if (!isCycleFoundFirst) {
              // First cycle breakpoint
              rockArrowKey = currentRockArrowKey;
              cycleMaxHeightFirst = towerHeight - 1 - highestRock;
              cycleRoundFirst = i;
              isCycleFoundFirst = true;
              continue rockRoundIteration;
            }
            if (!isCycleFoundSecond) {
              // Second cycle breakpoint
              if (currentRockArrowKey === rockArrowKey) {
                cycleMaxHeightSecond = towerHeight - 1 - highestRock;
                cycleRoundSecond = i;
                isCycleFoundSecond = true;

                // Update cycle params
                cycleHeightDelta = cycleMaxHeightSecond - cycleMaxHeightFirst;
                cycleRoundDelta = cycleRoundSecond - cycleRoundFirst;

                remainingTotalRound = maxNumRocks - cycleRoundSecond; // Remaining total round to maxNumRocks
                potentialMaxHeight =
                  cycleMaxHeightSecond +
                  Math.floor(remainingTotalRound / cycleRoundDelta) *
                    cycleHeightDelta;
                remainingTotalRoundDiff = remainingTotalRound % cycleRoundDelta; // Remaining round needed for getting additional height
                reasonableRound = i + remainingTotalRoundDiff; // Update when to stop
              }
            }
          } else {
            rockArrowIndexMap[currentNumRock + "-" + arrowIndex] = true; // Insert rock and arrow indices
          }
        }
      }
    }
  }

  let endRoundMaxHeight = towerHeight - 1 - highestRock;
  let additionalHeight = endRoundMaxHeight - cycleMaxHeightSecond;
  let finalMaxHeight = potentialMaxHeight + additionalHeight;

  return finalMaxHeight;
};

export { day17Part1, day17Part2 };
