const getRight = (currentDirection) => {
  if (currentDirection === ">") return "v";
  if (currentDirection === "v") return "<";
  if (currentDirection === "<") return "^";
  if (currentDirection === "^") return ">";
};

const getLeft = (currentDirection) => {
  if (currentDirection === ">") return "^";
  if (currentDirection === "^") return "<";
  if (currentDirection === "<") return "v";
  if (currentDirection === "v") return ">";
};

const getCurrentDirectionScore = (currentDirection) => {
  if (currentDirection === ">") return 0;
  if (currentDirection === "v") return 1;
  if (currentDirection === "<") return 2;
  if (currentDirection === "^") return 3;
};

const move = (grid, currentDirection, steps, xCurrent, yCurrent) => {
  let xNew = xCurrent;
  let yNew = yCurrent;

  // Right
  if (currentDirection === ">") {
    for (let i = 1; i <= steps; i++) {
      if (yNew + 1 > grid[xNew].length - 1) {
        // Wrap to left-most
        let yWrap = 0;
        for (let j = yWrap; j < grid[xNew].length; j++) {
          if (grid[xNew][j] === "." || grid[xNew][j] === "#") {
            yWrap = j;
            break;
          }
        }
        if (grid[xNew][yWrap] === ".") {
          // Move to wrapped left-most
          yNew = yWrap;
          continue;
        }
        if (grid[xNew][yWrap] === "#") break; // Wall, stop
      }

      if (grid[xNew][yNew + 1] === ".") {
        // Move to right
        yNew++;
        continue;
      }
      if (grid[xNew][yNew + 1] === "#") break; // Wall, stop
      if (grid[xNew][yNew + 1] === "@" || grid[xNew][yNew + 1] === undefined) {
        // Wrap to left-most
        let yWrap = 0;
        for (let j = yWrap; j < grid[xNew].length; j++) {
          if (grid[xNew][j] === "." || grid[xNew][j] === "#") {
            yWrap = j;
            break;
          }
        }
        if (grid[xNew][yWrap] === ".") {
          // Move to wrapped left-most
          yNew = yWrap;
          continue;
        }
        if (grid[xNew][yWrap] === "#") break; // Wall, stop
      }
    }
  }

  // Left
  if (currentDirection === "<") {
    for (let i = 1; i <= steps; i++) {
      if (yNew - 1 < 0) {
        // Wrap to right-most
        let yWrap = grid[xNew].length - 1;
        for (let j = yWrap; j >= 0; j--) {
          if (grid[xNew][j] === "." || grid[xNew][j] === "#") {
            yWrap = j;
            break;
          }
        }
        if (grid[xNew][yWrap] === ".") {
          // Move to wrapped right-most
          yNew = yWrap;
          continue;
        }
        if (grid[xNew][yWrap] === "#") break; // Wall, stop
      }

      if (grid[xNew][yNew - 1] === ".") {
        // Move to left
        yNew--;
        continue;
      }
      if (grid[xNew][yNew - 1] === "#") break; // Wall, stop
      if (grid[xNew][yNew - 1] === "@" || grid[xNew][yNew - 1] === undefined) {
        // Wrap to right-most
        let yWrap = grid[xNew].length - 1;
        for (let j = yWrap; j >= 0; j--) {
          if (grid[xNew][j] === "." || grid[xNew][j] === "#") {
            yWrap = j;
            break;
          }
        }
        if (grid[xNew][yWrap] === ".") {
          // Move to wrapped right-most
          yNew = yWrap;
          continue;
        }
        if (grid[xNew][yWrap] === "#") break; // Wall, stop
      }
    }
  }

  // Down
  if (currentDirection === "v") {
    for (let i = 1; i <= steps; i++) {
      if (xNew + 1 > grid.length - 1) {
        // Wrap to top-most
        let xWrap = 0;
        for (let j = xWrap; j < grid.length; j++) {
          if (grid[j][yNew] === "." || grid[j][yNew] === "#") {
            xWrap = j;
            break;
          }
        }
        if (grid[xWrap][yNew] === ".") {
          // Move to wrapped top-most
          xNew = xWrap;
          continue;
        }
        if (grid[xWrap][yNew] === "#") break; // Wall, stop
      }

      if (grid[xNew + 1][yNew] === ".") {
        // Move to down
        xNew++;
        continue;
      }
      if (grid[xNew + 1][yNew] === "#") break; // Wall, stop
      if (grid[xNew + 1][yNew] === "@" || grid[xNew + 1][yNew] === undefined) {
        // Wrap to top-most
        let xWrap = 0;
        for (let j = xWrap; j < grid.length; j++) {
          if (grid[j][yNew] === "." || grid[j][yNew] === "#") {
            xWrap = j;
            break;
          }
        }
        if (grid[xWrap][yNew] === ".") {
          // Move to wrapped top-most
          xNew = xWrap;
          continue;
        }
        if (grid[xWrap][yNew] === "#") break; // Wall, stop
      }
    }
  }

  // Up
  if (currentDirection === "^") {
    for (let i = 1; i <= steps; i++) {
      if (xNew - 1 < 0) {
        // Wrap to bottom-most
        let xWrap = grid.length - 1;
        for (let j = xWrap; j >= 0; j--) {
          if (grid[j][yNew] === "." || grid[j][yNew] === "#") {
            xWrap = j;
            break;
          }
        }
        if (grid[xWrap][yNew] === ".") {
          // Move to wrapped bottom-most
          xNew = xWrap;
          continue;
        }
        if (grid[xWrap][yNew] === "#") break; // Wall, stop
      }

      if (grid[xNew - 1][yNew] === ".") {
        // Move to up
        xNew--;
        continue;
      }
      if (grid[xNew - 1][yNew] === "#") break; // Wall, stop
      if (grid[xNew - 1][yNew] === "@" || grid[xNew - 1][yNew] === undefined) {
        // Wrap to bottom-most
        let xWrap = grid.length - 1;
        for (let j = xWrap; j >= 0; j--) {
          if (grid[j][yNew] === "." || grid[j][yNew] === "#") {
            xWrap = j;
            break;
          }
        }
        if (grid[xWrap][yNew] === ".") {
          // Move to wrapped bottom-most
          xNew = xWrap;
          continue;
        }
        if (grid[xWrap][yNew] === "#") break; // Wall, stop
      }
    }
  }

  return [xNew, yNew];
};

const day22Part1 = (inputArr, inputPathArr) => {
  let numRows = 0,
    numCols = 0;
  for (const line of inputArr) {
    if (line.length === 0) continue;

    numRows++;
    if (line.length > numCols) numCols = line.length;
  }

  let grid = [];
  for (let i = 0; i < numRows; i++) {
    let rowArr = [];
    for (let j = 0; j < numCols; j++) {
      rowArr.push("@");
    }
    grid.push(rowArr);
  }

  let currentRow = 0;
  for (const line of inputArr) {
    if (line.length === 0) continue;

    for (let i = 0; i < line.length; i++) {
      const currentChar = line[i];
      if (currentChar === "#" || currentChar === ".") {
        grid[currentRow][i] = currentChar;
      }
    }
    currentRow++;
  }

  // Get starting coordinate
  let xStart = 0;
  let yStart = 0;
  for (let j = 0; j < grid[0].length; j++) {
    if (grid[0][j] === ".") {
      yStart = j;
      break;
    }
  }
  let xCurrent = xStart;
  let yCurrent = yStart;

  // Set current direction
  let currentDirection = ">";

  let currentCommand;
  for (const line of inputPathArr) {
    if (line.length === 0) continue;

    let numChar = "";
    for (let i = 0; i < line.length; i++) {
      let currentChar = line[i];
      if (currentChar === "R") {
        // Execute previous command
        const steps = parseInt(numChar);
        numChar = "";
        let [xNew, yNew] = move(
          grid,
          currentDirection,
          steps,
          xCurrent,
          yCurrent
        );
        xCurrent = xNew;
        yCurrent = yNew;
        // Set direction
        currentDirection = getRight(currentDirection);
        continue;
      }
      if (currentChar === "L") {
        // Execute previous command
        const steps = parseInt(numChar);
        numChar = "";
        let [xNew, yNew] = move(
          grid,
          currentDirection,
          steps,
          xCurrent,
          yCurrent
        );
        xCurrent = xNew;
        yCurrent = yNew;
        // Set direction
        currentDirection = getLeft(currentDirection);
        continue;
      }
      // Number (be careful, it can be more than 1 digit)
      numChar += currentChar;
    }
    if (numChar !== "") {
      // Execute previous command
      const steps = parseInt(numChar);
      numChar = "";
      let [xNew, yNew] = move(
        grid,
        currentDirection,
        steps,
        xCurrent,
        yCurrent
      );
      xCurrent = xNew;
      yCurrent = yNew;
    }
  }

  let currentDirectionScore = getCurrentDirectionScore(currentDirection);
  return 1000 * (xCurrent + 1) + 4 * (yCurrent + 1) + currentDirectionScore;
};

// This will only work for the given input
const newMove = (grid, currentDirection, steps, xCurrent, yCurrent) => {
  let xNew = xCurrent;
  let yNew = yCurrent;
  let xNext = xCurrent;
  let yNext = yCurrent;
  let directionNew = currentDirection;
  let directionNext = currentDirection;

  for (let step = 1; step <= steps; step++) {
    if (directionNew === ">") {
      yNext = yNew + 1;
      xNext = xNew;
      directionNext = directionNew;
      if (yNext === 150 && xNext >= 0 && xNext <= 49) {
        // Right-end of 2
        yNext = 99;
        xNext = 149 - xNext;
        directionNext = "<";
      }
      if (yNext === 100 && xNext >= 50 && xNext <= 99) {
        // Right-end of 3
        yNext = xNext - 50 + 100;
        xNext = 49;
        directionNext = "^";
      }
      if (yNext === 100 && xNext >= 100 && xNext <= 149) {
        // Right-end of 5
        yNext = 149;
        xNext = 49 - (xNext - 100);
        directionNext = "<";
      }
      if (yNext === 50 && xNext >= 150 && xNext <= 199) {
        // Right-end of 6
        yNext = 50 + (xNext - 150);
        xNext = 149;
        directionNext = "^";
      }
      if (grid[xNext][yNext] !== "#") {
        // Move
        yNew = yNext;
        xNew = xNext;
        directionNew = directionNext;
        grid[xNew][yNew] = directionNew;
        continue;
      }
      if (grid[xNext][yNext] === "#") {
        // Stop
        grid[xNew][yNew] = directionNew;
        break;
      }
    }

    if (directionNew === "<") {
      yNext = yNew - 1;
      xNext = xNew;
      directionNext = directionNew;
      if (yNext === 49 && xNext >= 0 && xNext <= 49) {
        // Left-end of 1
        yNext = 0;
        xNext = 149 - xNext;
        directionNext = ">";
      }
      if (yNext === 49 && xNext >= 50 && xNext <= 99) {
        // Left-end of 3
        yNext = xNext - 50;
        xNext = 100;
        directionNext = "v";
      }
      if (yNext === -1 && xNext >= 100 && xNext <= 149) {
        // Left-end of 4
        yNext = 50;
        xNext = 149 - xNext;
        directionNext = ">";
      }
      if (yNext === -1 && xNext >= 150 && xNext <= 199) {
        // Left-end of 6
        yNext = xNext - 100;
        xNext = 0;
        directionNext = "v";
      }
      if (grid[xNext][yNext] !== "#") {
        // Move
        yNew = yNext;
        xNew = xNext;
        directionNew = directionNext;
        grid[xNew][yNew] = directionNew;
        continue;
      }
      if (grid[xNext][yNext] === "#") {
        // Stop
        grid[xNew][yNew] = directionNew;
        break;
      }
    }

    if (directionNew === "v") {
      yNext = yNew;
      xNext = xNew + 1;
      directionNext = directionNew;

      if (xNext === 200 && yNext >= 0 && yNext <= 49) {
        // Bottom-end of 6
        yNext = yNext + 100;
        xNext = 0;
        directionNext = "v";
      }
      if (xNext === 150 && yNext >= 50 && yNext <= 99) {
        // Bottom-end of 5
        xNext = yNext + 100;
        yNext = 49;
        directionNext = "<";
      }
      if (xNext === 50 && yNext >= 100 && yNext <= 149) {
        // Bottom-end of 2
        xNext = yNext - 50;
        yNext = 99;
        directionNext = "<";
      }
      if (grid[xNext][yNext] !== "#") {
        // Move
        yNew = yNext;
        xNew = xNext;
        directionNew = directionNext;
        grid[xNew][yNew] = directionNew;
        continue;
      }
      if (grid[xNext][yNext] === "#") {
        // Stop
        grid[xNew][yNew] = directionNew;
        break;
      }
    }

    if (directionNew === "^") {
      yNext = yNew;
      xNext = xNew - 1;
      directionNext = directionNew;

      if (xNext === 99 && yNext >= 0 && yNext <= 49) {
        // Top-end of 4
        xNext = yNext + 50;
        yNext = 50;
        directionNext = ">";
      }
      if (xNext === -1 && yNext >= 50 && yNext <= 99) {
        // Top-end of 1
        xNext = yNext + 100;
        yNext = 0;
        directionNext = ">";
      }
      if (xNext === -1 && yNext >= 100 && yNext <= 149) {
        // Top-end of 2
        yNext = yNext - 100;
        xNext = 199;
        directionNext = "^";
      }
      if (grid[xNext][yNext] !== "#") {
        // Move
        yNew = yNext;
        xNew = xNext;
        directionNew = directionNext;
        grid[xNew][yNew] = directionNew;
        continue;
      }
      if (grid[xNext][yNext] === "#") {
        // Stop
        grid[xNew][yNew] = directionNew;
        break;
      }
    }
  }

  return [xNew, yNew, directionNew];
};

const day22Part2 = (inputArr, inputPathArr) => {
  let numRows = 0,
    numCols = 0;
  for (const line of inputArr) {
    if (line.length === 0) continue;

    numRows++;
    if (line.length > numCols) numCols = line.length;
  }

  let grid = [];
  for (let i = 0; i < numRows; i++) {
    let rowArr = [];
    for (let j = 0; j < numCols; j++) {
      rowArr.push("@");
    }
    grid.push(rowArr);
  }

  let currentRow = 0;
  for (const line of inputArr) {
    if (line.length === 0) continue;

    for (let i = 0; i < line.length; i++) {
      const currentChar = line[i];
      if (currentChar === "#" || currentChar === ".") {
        grid[currentRow][i] = currentChar;
      }
    }
    currentRow++;
  }

  // Get starting coordinate
  let xStart = 0;
  let yStart = 0;
  for (let j = 0; j < grid[0].length; j++) {
    if (grid[0][j] === ".") {
      yStart = j;
      break;
    }
  }
  let xCurrent = xStart;
  let yCurrent = yStart;

  // Set current direction
  let currentDirection = ">";

  grid[xCurrent][yCurrent] = currentDirection;

  for (const line of inputPathArr) {
    if (line.length === 0) continue;

    let numChar = "";
    for (let i = 0; i < line.length; i++) {
      let currentChar = line[i];
      if (currentChar === "R") {
        // Execute previous command
        const steps = parseInt(numChar);
        numChar = "";
        let [xNew, yNew, newDirection] = newMove(
          grid,
          currentDirection,
          steps,
          xCurrent,
          yCurrent
        );
        xCurrent = xNew;
        yCurrent = yNew;
        currentDirection = newDirection;
        // Set direction
        currentDirection = getRight(currentDirection);
        grid[xCurrent][yCurrent] = currentDirection;
        continue;
      }
      if (currentChar === "L") {
        // Execute previous command
        const steps = parseInt(numChar);
        numChar = "";
        let [xNew, yNew, newDirection] = newMove(
          grid,
          currentDirection,
          steps,
          xCurrent,
          yCurrent
        );
        xCurrent = xNew;
        yCurrent = yNew;
        currentDirection = newDirection;
        // Set direction
        currentDirection = getLeft(currentDirection);
        grid[xCurrent][yCurrent] = currentDirection;
        continue;
      }
      // Number (be careful, it can be more than 1 digit)
      numChar += currentChar;
    }
    if (numChar !== "") {
      // Execute previous command
      const steps = parseInt(numChar);
      numChar = "";
      let [xNew, yNew, newDirection] = newMove(
        grid,
        currentDirection,
        steps,
        xCurrent,
        yCurrent
      );
      xCurrent = xNew;
      yCurrent = yNew;
      currentDirection = newDirection;
    }
  }

  let currentDirectionScore = getCurrentDirectionScore(currentDirection);
  return 1000 * (xCurrent + 1) + 4 * (yCurrent + 1) + currentDirectionScore;
};

// For debugging
const printGrid = (grid, numRows, numCols) => {
  for (let i = 0; i < numRows; i++) {
    for (let j = 0; j < numCols; j++) {
      process.stdout.write(grid[i][j]);
    }
    console.log();
  }
};

export { day22Part1, day22Part2 };
