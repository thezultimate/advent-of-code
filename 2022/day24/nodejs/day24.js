let minSteps = 1000000;
let queue = [];
let minStepsFound = false;
let elvesGridStateMap = {};
let maxQueueLength = 0; // For debugging
let stepGridStateMap;

const day24Part1 = (inputArr) => {
  queue = [];
  minStepsFound = false;
  elvesGridStateMap = {};
  maxQueueLength = 0; // For debugging
  let grid = [];
  for (const line of inputArr) {
    if (line.length === 0) continue;

    let rowArr = [];
    for (const char of line) {
      rowArr.push(char);
    }
    grid.push(rowArr);
  }

  const rowLength = grid.length;
  const colLength = grid[0].length;

  let xStart, yStart, xEnd, yEnd;
  let startPositionMap = {};

  // Set start and end coordinates, fill in start position map
  for (let i = 0; i < rowLength; i++) {
    for (let j = 0; j < colLength; j++) {
      startPositionMap[i + "," + j] = [grid[i][j]];
      if (i === 0 && grid[i][j] === ".") {
        xStart = i;
        yStart = j;
      }
      if (i === rowLength - 1 && grid[i][j] === ".") {
        xEnd = i;
        yEnd = j;
      }
    }
  }

  // Set current coordinate to start coordinate
  let xCurrent = xStart;
  let yCurrent = yStart;
  let step = 0;

  // Get all possible grid states
  stepGridStateMap = getStepGridState(startPositionMap, rowLength, colLength);

  let rootNode = {
    xCurrent: xCurrent,
    yCurrent: yCurrent,
    step: step,
    xEnd: xEnd,
    yEnd: yEnd,
    rowLength: rowLength,
    colLength: colLength,
  };

  // BFS with array as queue
  queue.push(rootNode);

  while (queue.length > 0) {
    // For debugging to check how long the queue is to avoid loop
    if (queue.length > maxQueueLength) {
      maxQueueLength = queue.length;
    }

    let firstElement = queue[0];
    queue.shift();
    moveElves(
      firstElement.xCurrent,
      firstElement.yCurrent,
      firstElement.step,
      firstElement.xEnd,
      firstElement.yEnd,
      firstElement.rowLength,
      firstElement.colLength
    );
    if (minStepsFound) break;
  }

  return minSteps;
};

const moveElves = (
  xCurrent,
  yCurrent,
  step,
  xEnd,
  yEnd,
  rowLength,
  colLength
) => {
  if (xCurrent === xEnd && yCurrent === yEnd) {
    if (step < minSteps) minSteps = step;
    minStepsFound = true;
    return;
  }

  let nextStep = step + 1;
  let nextPositionMap = stepGridStateMap[nextStep];

  // If possible: move to 4 adjacent coordinate or wait
  const rightCoordinate = xCurrent + "," + (yCurrent + 1);
  if (nextPositionMap[rightCoordinate][0] === ".") {
    // Can move right
    let nextMoveState =
      xCurrent + "," + (yCurrent + 1) + "-" + JSON.stringify(nextPositionMap);
    if (nextMoveState in elvesGridStateMap) {
      // Do nothing, next move state had occurred before
    } else {
      elvesGridStateMap[nextMoveState] = true;
      // Move right
      let rightNode = {
        startPositionMap: nextPositionMap,
        xCurrent: xCurrent,
        yCurrent: yCurrent + 1,
        step: step + 1,
        xEnd,
        yEnd,
        rowLength,
        colLength,
      };
      queue.push(rightNode);
    }
  }
  const leftCoordinate = xCurrent + "," + (yCurrent - 1);
  if (nextPositionMap[leftCoordinate][0] === ".") {
    // Can move left
    let nextMoveState =
      xCurrent + "," + (yCurrent - 1) + "-" + JSON.stringify(nextPositionMap);
    if (nextMoveState in elvesGridStateMap) {
      // Do nothing, next move state had occurred before
    } else {
      elvesGridStateMap[nextMoveState] = true;
      // Move left
      let leftNode = {
        startPositionMap: nextPositionMap,
        xCurrent: xCurrent,
        yCurrent: yCurrent - 1,
        step: step + 1,
        xEnd,
        yEnd,
        rowLength,
        colLength,
      };
      queue.push(leftNode);
    }
  }
  if (xCurrent < rowLength - 1) {
    const downCoordinate = xCurrent + 1 + "," + yCurrent;
    if (nextPositionMap[downCoordinate][0] === ".") {
      // Can move down
      let nextMoveState =
        xCurrent + 1 + "," + yCurrent + "-" + JSON.stringify(nextPositionMap);
      if (nextMoveState in elvesGridStateMap) {
        // Do nothing, next move state had occurred before
      } else {
        elvesGridStateMap[nextMoveState] = true;
        // Move down
        let downNode = {
          startPositionMap: nextPositionMap,
          xCurrent: xCurrent + 1,
          yCurrent: yCurrent,
          step: step + 1,
          xEnd,
          yEnd,
          rowLength,
          colLength,
        };
        queue.push(downNode);
      }
    }
  }
  if (xCurrent > 0) {
    const upCoordinate = xCurrent - 1 + "," + yCurrent;
    if (nextPositionMap[upCoordinate][0] === ".") {
      // Can move up
      let nextMoveState =
        xCurrent - 1 + "," + yCurrent + "-" + JSON.stringify(nextPositionMap);
      if (nextMoveState in elvesGridStateMap) {
        // Do nothing, next move state had occurred before
      } else {
        elvesGridStateMap[nextMoveState] = true;
        // Move up
        let upNode = {
          startPositionMap: nextPositionMap,
          xCurrent: xCurrent - 1,
          yCurrent: yCurrent,
          step: step + 1,
          xEnd,
          yEnd,
          rowLength,
          colLength,
        };
        queue.push(upNode);
      }
    }
  }
  const currentCoordinate = xCurrent + "," + yCurrent;
  if (nextPositionMap[currentCoordinate][0] === ".") {
    // Can wait
    let nextMoveState =
      xCurrent + "," + yCurrent + "-" + JSON.stringify(nextPositionMap);
    if (nextMoveState in elvesGridStateMap) {
      // Do nothing, next move state had occurred before
    } else {
      elvesGridStateMap[nextMoveState] = true;
      // Wait
      let waitNode = {
        startPositionMap: nextPositionMap,
        xCurrent: xCurrent,
        yCurrent: yCurrent,
        step: step + 1,
        xEnd,
        yEnd,
        rowLength,
        colLength,
      };
      queue.push(waitNode);
    }
  }

  return;
};

const getStepGridState = (startPositionMap, rowLength, colLength) => {
  // Save blizzards state for the next maxStep rounds
  let maxStep = 2000;
  let stepGridStateMap = {};

  stepGridStateMap[0] = startPositionMap;

  for (let step = 1; step <= maxStep; step++) {
    let nextPositionMap = {};

    // First fill in nextPositionMap with # and .
    for (const [coordinate, occupants] of Object.entries(startPositionMap)) {
      if (occupants[0] === "#" || occupants[0] === ".") {
        nextPositionMap[coordinate] = occupants;
      }
    }

    // Fill in nextPositionMap with movements
    for (const [coordinate, occupants] of Object.entries(startPositionMap)) {
      if (occupants[0] !== "#" && occupants[0] !== ".") {
        // Occupants must be arrows
        for (const occupant of occupants) {
          // Right
          if (occupant === ">") {
            const coordinateSplit = coordinate.split(",");
            const x = parseInt(coordinateSplit[0]);
            const y = parseInt(coordinateSplit[1]);
            const yNext = y + 1;
            const nextCoordinate = x + "," + yNext;
            if (nextCoordinate in nextPositionMap) {
              if (
                nextPositionMap[nextCoordinate][0] !== "." &&
                nextPositionMap[nextCoordinate][0] !== "#"
              ) {
                // Append to next position
                nextPositionMap[nextCoordinate].push(">");
              }
              if (nextPositionMap[nextCoordinate][0] === ".") {
                // Next position is empty
                nextPositionMap[nextCoordinate] = [">"];
              }
              if (nextPositionMap[nextCoordinate][0] === "#") {
                // Wrap to left
                const leftMostCoordinate = x + "," + 1;
                if (leftMostCoordinate in nextPositionMap) {
                  if (nextPositionMap[leftMostCoordinate][0] === ".") {
                    // Left-most position is empty
                    nextPositionMap[leftMostCoordinate] = [">"];
                  } else {
                    // Append to next position
                    nextPositionMap[leftMostCoordinate].push(">");
                  }
                } else {
                  // Left-most coordinate is empty
                  nextPositionMap[leftMostCoordinate] = [">"];
                }
              }
            } else {
              // Next coordinate not yet occupied
              nextPositionMap[nextCoordinate] = [">"];
            }
          }

          // Left
          if (occupant === "<") {
            const coordinateSplit = coordinate.split(",");
            const x = parseInt(coordinateSplit[0]);
            const y = parseInt(coordinateSplit[1]);
            const yNext = y - 1;
            const nextCoordinate = x + "," + yNext;
            if (nextCoordinate in nextPositionMap) {
              if (
                nextPositionMap[nextCoordinate][0] !== "." &&
                nextPositionMap[nextCoordinate][0] !== "#"
              ) {
                // Append to next position
                nextPositionMap[nextCoordinate].push("<");
              }
              if (nextPositionMap[nextCoordinate][0] === ".") {
                // Next position is empty
                nextPositionMap[nextCoordinate] = ["<"];
              }
              if (nextPositionMap[nextCoordinate][0] === "#") {
                // Wrap to right
                const rightMostCoordinate = x + "," + (colLength - 2);
                if (rightMostCoordinate in nextPositionMap) {
                  if (nextPositionMap[rightMostCoordinate][0] === ".") {
                    // Right-most position is empty
                    nextPositionMap[rightMostCoordinate] = ["<"];
                  } else {
                    // Append to next position
                    nextPositionMap[rightMostCoordinate].push("<");
                  }
                } else {
                  // Right-most coordinate is empty
                  nextPositionMap[rightMostCoordinate] = ["<"];
                }
              }
            } else {
              // Next coordinate not yet occupied
              nextPositionMap[nextCoordinate] = ["<"];
            }
          }

          // Down
          if (occupant === "v") {
            const coordinateSplit = coordinate.split(",");
            const x = parseInt(coordinateSplit[0]);
            const y = parseInt(coordinateSplit[1]);
            const xNext = x + 1;
            const nextCoordinate = xNext + "," + y;
            if (nextCoordinate in nextPositionMap) {
              if (
                nextPositionMap[nextCoordinate][0] !== "." &&
                nextPositionMap[nextCoordinate][0] !== "#"
              ) {
                // Append to next position
                nextPositionMap[nextCoordinate].push("v");
              }
              if (nextPositionMap[nextCoordinate][0] === ".") {
                // Next position is empty
                nextPositionMap[nextCoordinate] = ["v"];
              }
              if (nextPositionMap[nextCoordinate][0] === "#") {
                // Wrap to top
                const topMostCoordinate = 1 + "," + y;
                if (topMostCoordinate in nextPositionMap) {
                  if (nextPositionMap[topMostCoordinate][0] === ".") {
                    // Top-most position is empty
                    nextPositionMap[topMostCoordinate] = ["v"];
                  } else {
                    // Append to next position
                    nextPositionMap[topMostCoordinate].push("v");
                  }
                } else {
                  // Top-most coordinate is empty
                  nextPositionMap[topMostCoordinate] = ["v"];
                }
              }
            } else {
              // Next coordinate not yet occupied
              nextPositionMap[nextCoordinate] = ["v"];
            }
          }

          // Up
          if (occupant === "^") {
            const coordinateSplit = coordinate.split(",");
            const x = parseInt(coordinateSplit[0]);
            const y = parseInt(coordinateSplit[1]);
            const xNext = x - 1;
            const nextCoordinate = xNext + "," + y;
            if (nextCoordinate in nextPositionMap) {
              if (
                nextPositionMap[nextCoordinate][0] !== "." &&
                nextPositionMap[nextCoordinate][0] !== "#"
              ) {
                // Append to next position
                nextPositionMap[nextCoordinate].push("^");
              }
              if (nextPositionMap[nextCoordinate][0] === ".") {
                // Next position is empty
                nextPositionMap[nextCoordinate] = ["^"];
              }
              if (nextPositionMap[nextCoordinate][0] === "#") {
                // Wrap to bottom
                const bottomMostCoordinate = rowLength - 2 + "," + y;
                if (bottomMostCoordinate in nextPositionMap) {
                  if (nextPositionMap[bottomMostCoordinate][0] === ".") {
                    // Bottom-most position is empty
                    nextPositionMap[bottomMostCoordinate] = ["^"];
                  } else {
                    // Append to next position
                    nextPositionMap[bottomMostCoordinate].push("^");
                  }
                } else {
                  // Bottom-most coordinate is empty
                  nextPositionMap[bottomMostCoordinate] = ["^"];
                }
              }
            } else {
              // Next coordinate not yet occupied
              nextPositionMap[nextCoordinate] = ["^"];
            }
          }
        }

        // After moving each occupant, the current coordinate must be emptied if not already occupied
        if (coordinate in nextPositionMap) {
        } else {
          nextPositionMap[coordinate] = ["."];
        }
      }
    }

    startPositionMap = nextPositionMap;
    stepGridStateMap[step] = nextPositionMap;
  }

  return stepGridStateMap;
};

const day24Part2 = (inputArr) => {
  let grid = [];
  for (const line of inputArr) {
    if (line.length === 0) continue;

    let rowArr = [];
    for (const char of line) {
      rowArr.push(char);
    }
    grid.push(rowArr);
  }

  const rowLength = grid.length;
  const colLength = grid[0].length;

  let xStart, yStart, xEnd, yEnd;
  let startPositionMap = {};

  // Set start and end coordinates, fill in start position map
  for (let i = 0; i < rowLength; i++) {
    for (let j = 0; j < colLength; j++) {
      startPositionMap[i + "," + j] = [grid[i][j]];
      if (i === 0 && grid[i][j] === ".") {
        xStart = i;
        yStart = j;
      }
      if (i === rowLength - 1 && grid[i][j] === ".") {
        xEnd = i;
        yEnd = j;
      }
    }
  }

  // Get all possible grid states
  stepGridStateMap = getStepGridState(startPositionMap, rowLength, colLength);

  // First section of the journey (forward)
  queue = [];
  minStepsFound = false;
  elvesGridStateMap = {};
  maxQueueLength = 0; // For debugging
  let xCurrent = xStart;
  let yCurrent = yStart;
  let step = 0;
  let rootNode = {
    xCurrent: xCurrent,
    yCurrent: yCurrent,
    step: step,
    xEnd: xEnd,
    yEnd: yEnd,
    rowLength: rowLength,
    colLength: colLength,
  };
  queue.push(rootNode);
  while (queue.length > 0) {
    // For debugging to check how long the queue is to avoid loop
    if (queue.length > maxQueueLength) {
      maxQueueLength = queue.length;
    }
    let firstElement = queue[0];
    queue.shift();
    moveElves(
      firstElement.xCurrent,
      firstElement.yCurrent,
      firstElement.step,
      firstElement.xEnd,
      firstElement.yEnd,
      firstElement.rowLength,
      firstElement.colLength
    );
    if (minStepsFound) break;
  }
  let minStepsFirstSection = minSteps;

  // Second section of the journey (backward)
  minSteps = 1000000;
  queue = [];
  minStepsFound = false;
  elvesGridStateMap = {};
  maxQueueLength = 0; // For debugging
  xCurrent = xEnd;
  yCurrent = yEnd;
  step = minStepsFirstSection;
  rootNode = {
    xCurrent: xCurrent,
    yCurrent: yCurrent,
    step: step,
    xEnd: xStart,
    yEnd: yStart,
    rowLength: rowLength,
    colLength: colLength,
  };
  queue.push(rootNode);
  while (queue.length > 0) {
    // For debugging to check how long the queue is to avoid loop
    if (queue.length > maxQueueLength) {
      maxQueueLength = queue.length;
    }
    let firstElement = queue[0];
    queue.shift();
    moveElves(
      firstElement.xCurrent,
      firstElement.yCurrent,
      firstElement.step,
      firstElement.xEnd,
      firstElement.yEnd,
      firstElement.rowLength,
      firstElement.colLength
    );
    if (minStepsFound) break;
  }
  let minStepsSecondSection = minSteps;

  // Third section of the journey (backward)
  minSteps = 1000000;
  queue = [];
  minStepsFound = false;
  elvesGridStateMap = {};
  maxQueueLength = 0; // For debugging
  xCurrent = xStart;
  yCurrent = yStart;
  step = minStepsSecondSection;
  rootNode = {
    xCurrent: xCurrent,
    yCurrent: yCurrent,
    step: step,
    xEnd: xEnd,
    yEnd: yEnd,
    rowLength: rowLength,
    colLength: colLength,
  };
  queue.push(rootNode);
  while (queue.length > 0) {
    // For debugging to check how long the queue is to avoid loop
    if (queue.length > maxQueueLength) {
      maxQueueLength = queue.length;
    }
    let firstElement = queue[0];
    queue.shift();
    moveElves(
      firstElement.xCurrent,
      firstElement.yCurrent,
      firstElement.step,
      firstElement.xEnd,
      firstElement.yEnd,
      firstElement.rowLength,
      firstElement.colLength
    );
    if (minStepsFound) break;
  }
  let minStepsThirdSection = minSteps;

  // Finally return
  return minStepsThirdSection;
};

export { day24Part1, day24Part2 };
