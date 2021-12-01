const day23Part1 = (inputArr) => {
  const inputSize = inputArr[0].length;
  const padding = 10; // Can be changed as needed
  const gridSize = inputSize + 2 * padding;
  let elvesPositionsMap = {};
  let elvesMoveMap = {};

  let grid = [];
  // Create an empty grid
  for (let i = 0; i < gridSize; i++) {
    let rowArr = [];
    for (let j = 0; j < gridSize; j++) {
      rowArr.push(".");
    }
    grid.push(rowArr);
  }

  // Put initial Elves' locations in the grid
  let currentRow = 0;
  for (const line of inputArr) {
    if (line.length === 0) continue;

    for (let i = 0; i < line.length; i++) {
      const currentChar = line[i];
      if (currentChar === "#") {
        grid[currentRow + padding][i + padding] = "#";
        elvesPositionsMap[currentRow + padding + "," + (i + padding)] = true;
      }
    }
    currentRow++;
  }

  let totalRound = 10;
  let direction = ["N", "S", "W", "E"];

  for (let round = 1; round <= totalRound; round++) {
    for (const elv in elvesPositionsMap) {
      const elvPosition = elv.split(",");
      const xElv = parseInt(elvPosition[0]);
      const yElv = parseInt(elvPosition[1]);
      if (
        grid[xElv - 1][yElv - 1] !== "#" &&
        grid[xElv - 1][yElv] !== "#" &&
        grid[xElv - 1][yElv + 1] !== "#" &&
        grid[xElv][yElv + 1] !== "#" &&
        grid[xElv + 1][yElv + 1] !== "#" &&
        grid[xElv + 1][yElv] !== "#" &&
        grid[xElv + 1][yElv - 1] !== "#" &&
        grid[xElv][yElv - 1] !== "#"
      ) {
        continue; // This elv is surrounded by empty space, don't move
      }

      // Consider a point to move
      let consideredPosition = "";
      for (const currentDirection of direction) {
        if (currentDirection === "N") {
          if (
            grid[xElv - 1][yElv - 1] !== "#" &&
            grid[xElv - 1][yElv] !== "#" &&
            grid[xElv - 1][yElv + 1] !== "#"
          ) {
            consideredPosition = xElv - 1 + "," + yElv;
            break;
          }
        }
        if (currentDirection === "S") {
          if (
            grid[xElv + 1][yElv - 1] !== "#" &&
            grid[xElv + 1][yElv] !== "#" &&
            grid[xElv + 1][yElv + 1] !== "#"
          ) {
            consideredPosition = xElv + 1 + "," + yElv;
            break;
          }
        }
        if (currentDirection === "W") {
          if (
            grid[xElv - 1][yElv - 1] !== "#" &&
            grid[xElv][yElv - 1] !== "#" &&
            grid[xElv + 1][yElv - 1] !== "#"
          ) {
            consideredPosition = xElv + "," + (yElv - 1);
            break;
          }
        }
        if (currentDirection === "E") {
          if (
            grid[xElv - 1][yElv + 1] !== "#" &&
            grid[xElv][yElv + 1] !== "#" &&
            grid[xElv + 1][yElv + 1] !== "#"
          ) {
            consideredPosition = xElv + "," + (yElv + 1);
            break;
          }
        }
      }

      if (consideredPosition.length > 0) {
        if (!elvesMoveMap[consideredPosition]) {
          // Target position doesn't exist yet
          let source = [elv];
          elvesMoveMap[consideredPosition] = source;
        } else {
          // Target position already exists
          elvesMoveMap[consideredPosition].push(elv);
        }
      }
    }

    // Move simultaneously
    for (const [target, source] of Object.entries(elvesMoveMap)) {
      if (source.length === 1) {
        // Only one elv moves to target
        elvesPositionsMap[target] = true;
        delete elvesPositionsMap[source[0]];
        let targetCoordinate = target.split(",");
        let xTarget = parseInt(targetCoordinate[0]);
        let yTarget = parseInt(targetCoordinate[1]);
        let sourceCoordinate = source[0].split(",");
        let xSource = parseInt(sourceCoordinate[0]);
        let ySource = parseInt(sourceCoordinate[1]);
        grid[xTarget][yTarget] = "#";
        grid[xSource][ySource] = ".";
      }
    }

    elvesMoveMap = {};
    direction.push(direction[0]);
    direction.shift();
  }

  // Get the edges of the square
  let xMin = gridSize;
  let xMax = 0;
  let yMin = gridSize;
  let yMax = 0;
  for (let i = 0; i < gridSize; i++) {
    for (let j = 0; j < gridSize; j++) {
      if (grid[i][j] === "#") {
        if (i < xMin) xMin = i;
        if (i > xMax) xMax = i;
        if (j < yMin) yMin = j;
        if (j > yMax) yMax = j;
      }
    }
  }

  let dotCount = 0;
  for (let i = xMin; i <= xMax; i++) {
    for (let j = yMin; j <= yMax; j++) {
      if (grid[i][j] === ".") dotCount++;
    }
  }

  return dotCount;
};

const day23Part2 = (inputArr) => {
  const inputSize = inputArr[0].length;
  const padding = 50; // Can be changed as needed
  const gridSize = inputSize + 2 * padding;
  let elvesPositionsMap = {};
  let elvesMoveMap = {};

  let grid = [];
  // Create an empty grid
  for (let i = 0; i < gridSize; i++) {
    let rowArr = [];
    for (let j = 0; j < gridSize; j++) {
      rowArr.push(".");
    }
    grid.push(rowArr);
  }

  // Put initial Elves' locations in the grid
  let currentRow = 0;
  for (const line of inputArr) {
    if (line.length === 0) continue;

    for (let i = 0; i < line.length; i++) {
      const currentChar = line[i];
      if (currentChar === "#") {
        grid[currentRow + padding][i + padding] = "#";
        elvesPositionsMap[currentRow + padding + "," + (i + padding)] = true;
      }
    }
    currentRow++;
  }

  let totalRound = 1000;
  let direction = ["N", "S", "W", "E"];

  for (let round = 1; round <= totalRound; round++) {
    for (const elv in elvesPositionsMap) {
      const elvPosition = elv.split(",");
      const xElv = parseInt(elvPosition[0]);
      const yElv = parseInt(elvPosition[1]);
      if (
        grid[xElv - 1][yElv - 1] !== "#" &&
        grid[xElv - 1][yElv] !== "#" &&
        grid[xElv - 1][yElv + 1] !== "#" &&
        grid[xElv][yElv + 1] !== "#" &&
        grid[xElv + 1][yElv + 1] !== "#" &&
        grid[xElv + 1][yElv] !== "#" &&
        grid[xElv + 1][yElv - 1] !== "#" &&
        grid[xElv][yElv - 1] !== "#"
      ) {
        continue; // This elv is surrounded by empty space, don't move
      }

      // Consider a point to move
      let consideredPosition = "";
      for (const currentDirection of direction) {
        if (currentDirection === "N") {
          if (
            grid[xElv - 1][yElv - 1] !== "#" &&
            grid[xElv - 1][yElv] !== "#" &&
            grid[xElv - 1][yElv + 1] !== "#"
          ) {
            consideredPosition = xElv - 1 + "," + yElv;
            break;
          }
        }
        if (currentDirection === "S") {
          if (
            grid[xElv + 1][yElv - 1] !== "#" &&
            grid[xElv + 1][yElv] !== "#" &&
            grid[xElv + 1][yElv + 1] !== "#"
          ) {
            consideredPosition = xElv + 1 + "," + yElv;
            break;
          }
        }
        if (currentDirection === "W") {
          if (
            grid[xElv - 1][yElv - 1] !== "#" &&
            grid[xElv][yElv - 1] !== "#" &&
            grid[xElv + 1][yElv - 1] !== "#"
          ) {
            consideredPosition = xElv + "," + (yElv - 1);
            break;
          }
        }
        if (currentDirection === "E") {
          if (
            grid[xElv - 1][yElv + 1] !== "#" &&
            grid[xElv][yElv + 1] !== "#" &&
            grid[xElv + 1][yElv + 1] !== "#"
          ) {
            consideredPosition = xElv + "," + (yElv + 1);
            break;
          }
        }
      }

      if (consideredPosition.length > 0) {
        if (!elvesMoveMap[consideredPosition]) {
          // Target position doesn't exist yet
          let source = [elv];
          elvesMoveMap[consideredPosition] = source;
        } else {
          // Target position already exists
          elvesMoveMap[consideredPosition].push(elv);
        }
      }
    }

    // Move simultaneously
    for (const [target, source] of Object.entries(elvesMoveMap)) {
      if (source.length === 1) {
        // Only one elv moves to target
        elvesPositionsMap[target] = true;
        delete elvesPositionsMap[source[0]];
        let targetCoordinate = target.split(",");
        let xTarget = parseInt(targetCoordinate[0]);
        let yTarget = parseInt(targetCoordinate[1]);
        let sourceCoordinate = source[0].split(",");
        let xSource = parseInt(sourceCoordinate[0]);
        let ySource = parseInt(sourceCoordinate[1]);
        grid[xTarget][yTarget] = "#";
        grid[xSource][ySource] = ".";
      }
    }

    if (
      Object.keys(elvesMoveMap).length === 0 &&
      elvesMoveMap.constructor === Object
    ) {
      // Empty object, nobody moves
      return round;
    }

    elvesMoveMap = {};
    direction.push(direction[0]);
    direction.shift();
  }

  return -1;
};

export { day23Part1, day23Part2 };
