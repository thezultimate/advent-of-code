let grid;
let gridLength;
let maxY;

const day14Part1 = (inputArr) => {
  grid = [];
  let sandStartCoordinate = [500, 0];
  gridLength = 600;

  // Fill grid with air
  for (let i = 0; i < gridLength; i++) {
    let rowArr = [];
    for (let j = 0; j < gridLength; j++) {
      rowArr.push(".");
    }
    grid.push(rowArr);
  }

  for (const line of inputArr) {
    if (line.length === 0) continue;
    const lineSplit = line.split(" -> ");

    // Draw rocks per line input
    for (let i = 0; i < lineSplit.length - 1; i++) {
      const pointStart = lineSplit[i];
      const pointEnd = lineSplit[i + 1];
      const pointStartSplit = pointStart.split(",");
      const pointEndSplit = pointEnd.split(",");
      let xStart = parseInt(pointStartSplit[1]);
      let yStart = parseInt(pointStartSplit[0]);
      let xEnd = parseInt(pointEndSplit[1]);
      let yEnd = parseInt(pointEndSplit[0]);
      if (yStart === yEnd) {
        // Horizontal rocks
        if (xStart > xEnd) {
          // End should be bigger than start
          const temp = xStart;
          xStart = xEnd;
          xEnd = temp;
        }
        for (let j = xStart; j <= xEnd; j++) {
          grid[j][yStart] = "#";
        }
      }
      if (xStart === xEnd) {
        // Vertical rocks
        if (yStart > yEnd) {
          // End should be bigger than start
          const temp = yStart;
          yStart = yEnd;
          yEnd = temp;
        }
        for (let j = yStart; j <= yEnd; j++) {
          grid[xStart][j] = "#";
        }
      }
    }
  }

  let dropLimit = 10000;
  let restSandCounter = 0;
  for (let i = 0; i < dropLimit; i++) {
    let dropResult = dropSand(sandStartCoordinate);
    if (dropResult === "REST") restSandCounter++;
  }

  return restSandCounter;
};

const dropSand = (startCoordinateArr) => {
  // startCoordinateArr is [500,0] at first
  const xSand = startCoordinateArr[0];
  for (let ySand = startCoordinateArr[1]; ySand < gridLength; ySand++) {
    let currentPosition = grid[ySand][xSand];
    // Check if current position is occupied
    if (currentPosition === "#" || currentPosition === "o") {
      // Current position is occupied, check left
      if (grid[ySand][xSand - 1] === ".") {
        // Left is air
        return dropSand([xSand - 1, ySand]);
      } else {
        // Left is occupied, check right
        if (grid[ySand][xSand + 1] === ".") {
          // Right is air
          return dropSand([xSand + 1, ySand]);
        } else {
          // Right is occupied, rest the sand above
          grid[ySand - 1][xSand] = "o";
          return "REST";
        }
      }
    } else {
      // Current position is air
      continue; // Do nothing until blocked or the abyss (end of grid)
    }
  }
  return "ABYSS";
};

const day14Part2 = (inputArr) => {
  grid = [];
  let sandStartCoordinate = [500, 0];
  gridLength = 700;
  maxY = 0;

  // Fill grid with air
  for (let i = 0; i < gridLength; i++) {
    let rowArr = [];
    for (let j = 0; j < gridLength; j++) {
      rowArr.push(".");
    }
    grid.push(rowArr);
  }

  for (const line of inputArr) {
    if (line.length === 0) continue;
    const lineSplit = line.split(" -> ");

    // Draw rocks per line input
    for (let i = 0; i < lineSplit.length - 1; i++) {
      const pointStart = lineSplit[i];
      const pointEnd = lineSplit[i + 1];
      const pointStartSplit = pointStart.split(",");
      const pointEndSplit = pointEnd.split(",");
      let xStart = parseInt(pointStartSplit[1]);
      let yStart = parseInt(pointStartSplit[0]);
      let xEnd = parseInt(pointEndSplit[1]);
      let yEnd = parseInt(pointEndSplit[0]);
      if (yStart === yEnd) {
        // Horizontal rocks
        if (xStart > xEnd) {
          // End should be bigger than start
          const temp = xStart;
          xStart = xEnd;
          xEnd = temp;
        }
        for (let j = xStart; j <= xEnd; j++) {
          grid[j][yStart] = "#";
        }
      }
      if (xStart === xEnd) {
        // Vertical rocks
        if (yStart > yEnd) {
          // End should be bigger than start
          const temp = yStart;
          yStart = yEnd;
          yEnd = temp;
        }
        for (let j = yStart; j <= yEnd; j++) {
          grid[xStart][j] = "#";
        }
      }

      // Get max Y (the bottom)
      if (xStart > maxY) maxY = xStart;
      if (xEnd > maxY) maxY = xEnd;
    }
  }

  maxY += 2;

  // Draw rocks at maxY
  for (let i = 0; i < gridLength; i++) {
    grid[maxY][i] = "#";
  }

  let dropLimit = 100000;
  let restSandCounter = 0;
  for (let i = 0; i < dropLimit; i++) {
    let dropResult = dropSandPartTwo(sandStartCoordinate);
    if (dropResult === "RESTLAST") {
      restSandCounter++;
      break;
    }
    if (dropResult === "REST") restSandCounter++;
  }

  return restSandCounter;
};

const dropSandPartTwo = (startCoordinateArr) => {
  // startCoordinateArr is [500,0] at first
  const xSand = startCoordinateArr[0];
  for (let ySand = startCoordinateArr[1]; ySand < gridLength; ySand++) {
    let currentPosition = grid[ySand][xSand];
    // Check if current position is occupied
    if (currentPosition === "#" || currentPosition === "o") {
      // Current position is occupied, check left
      if (grid[ySand][xSand - 1] === ".") {
        // Left is air
        return dropSandPartTwo([xSand - 1, ySand]);
      } else {
        // Left is occupied, check right
        if (grid[ySand][xSand + 1] === ".") {
          // Right is air
          return dropSandPartTwo([xSand + 1, ySand]);
        } else {
          // Right is occupied, rest the sand above
          grid[ySand - 1][xSand] = "o";
          if (ySand - 1 === 0 && xSand === 500) {
            // If above point is [500,0], stop pouring sand
            return "RESTLAST";
          }
          return "REST";
        }
      }
    } else {
      // Current position is air
      continue; // Do nothing until blocked or the abyss (end of grid)
    }
  }
  return "ABYSS";
};

export { day14Part1, day14Part2 };
