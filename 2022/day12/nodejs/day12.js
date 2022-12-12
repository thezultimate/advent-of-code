const nextMap = {
  S: "a",
  a: "b",
  b: "c",
  c: "d",
  d: "e",
  e: "f",
  f: "g",
  g: "h",
  h: "i",
  i: "j",
  j: "k",
  k: "l",
  l: "m",
  m: "n",
  n: "o",
  o: "p",
  p: "q",
  q: "r",
  r: "s",
  s: "t",
  t: "u",
  u: "v",
  v: "w",
  w: "x",
  x: "y",
  y: "z",
  z: "z",
};

const day12Part1 = (inputArr) => {
  // Create grid
  let grid = [];

  for (const line of inputArr) {
    if (line.length === 0) continue;

    let rowArr = [];
    for (let i = 0; i < line.length; i++) {
      rowArr.push(line[i]);
    }
    grid.push(rowArr);
  }

  const rowLength = grid.length;
  const colLength = grid[0].length;

  // Create distanceMap, previousMap, vertexMap
  let distanceMap = {};
  let previousMap = {};
  let vertexMap = {};

  let endingVertexCoordinate;

  for (let i = 0; i < rowLength; i++) {
    for (let j = 0; j < colLength; j++) {
      const coordinateString = i + "," + j;
      vertexMap[coordinateString] = true;
      previousMap[coordinateString] = "UNDEFINED";
      if (grid[i][j] === "S") {
        // Starting vertex
        distanceMap[coordinateString] = 0;
        grid[i][j] = "a"; // Starting vertex has elevation a
      } else if (grid[i][j] === "E") {
        // Ending vertex
        endingVertexCoordinate = coordinateString;
        grid[i][j] = "z"; // Ending vertex has elevation z
        distanceMap[coordinateString] = 999999999999;
      } else {
        distanceMap[coordinateString] = 999999999999;
      }
    }
  }

  let vertexMapLength = Object.keys(vertexMap).length;

  outerloop: while (vertexMapLength > 0) {
    let vertexWithMinDistance; // Default is undefined
    let minDistance = 999999999999;
    for (const k in vertexMap) {
      const v = distanceMap[k];
      if (v < minDistance) {
        minDistance = v;
        vertexWithMinDistance = k;
      }
    }
    delete vertexMap[vertexWithMinDistance];
    vertexMapLength--;

    // Check each neighbor
    const currentCoordinate = vertexWithMinDistance.split(",");
    const X = parseInt(currentCoordinate[0]);
    const Y = parseInt(currentCoordinate[1]);
    const currentLetter = grid[X][Y];

    if (vertexWithMinDistance === endingVertexCoordinate) {
      break outerloop; // Found target vertex, no point going further
    }

    // Left
    const yLeft = Y - 1;
    if (yLeft >= 0) {
      const leftLetter = grid[X][yLeft];
      if (leftLetter <= nextMap[currentLetter]) {
        // Valid left neighbor
        const leftNeighbor = X + "," + yLeft;
        if (vertexMap[leftNeighbor]) {
          // Left neighbor still in vertexMap
          const tempDistance = distanceMap[vertexWithMinDistance] + 1;
          if (tempDistance < distanceMap[leftNeighbor]) {
            distanceMap[leftNeighbor] = tempDistance;
            previousMap[leftNeighbor] = vertexWithMinDistance;
          }
        }
      }
    }

    // Right
    const yRight = Y + 1;
    if (yRight < colLength) {
      const rightLetter = grid[X][yRight];
      if (rightLetter <= nextMap[currentLetter]) {
        // Valid right neighbor
        const rightNeighbor = X + "," + yRight;
        if (vertexMap[rightNeighbor]) {
          // Right neighbor still in vertexMap
          const tempDistance = distanceMap[vertexWithMinDistance] + 1;
          if (tempDistance < distanceMap[rightNeighbor]) {
            distanceMap[rightNeighbor] = tempDistance;
            previousMap[rightNeighbor] = vertexWithMinDistance;
          }
        }
      }
    }

    // Down
    const xDown = X + 1;
    if (xDown < rowLength) {
      const downLetter = grid[xDown][Y];
      if (downLetter <= nextMap[currentLetter]) {
        // Valid down neighbor
        const downNeighbor = xDown + "," + Y;
        if (vertexMap[downNeighbor]) {
          // Down neighbor still in vertexMap
          const tempDistance = distanceMap[vertexWithMinDistance] + 1;
          if (tempDistance < distanceMap[downNeighbor]) {
            distanceMap[downNeighbor] = tempDistance;
            previousMap[downNeighbor] = vertexWithMinDistance;
          }
        }
      }
    }

    // Up
    const xUp = X - 1;
    if (xUp >= 0) {
      const upLetter = grid[xUp][Y];
      if (upLetter <= nextMap[currentLetter]) {
        // Valid up neighbor
        const upNeighbor = xUp + "," + Y;
        if (vertexMap[upNeighbor]) {
          // Up neighbor still in vertexMap
          const tempDistance = distanceMap[vertexWithMinDistance] + 1;
          if (tempDistance < distanceMap[upNeighbor]) {
            distanceMap[upNeighbor] = tempDistance;
            previousMap[upNeighbor] = vertexWithMinDistance;
          }
        }
      }
    }
  }

  return distanceMap[endingVertexCoordinate];
};

const day12Part2 = (inputArr) => {
  // Create grid
  let grid = [];

  for (const line of inputArr) {
    if (line.length === 0) continue;

    let rowArr = [];
    for (let i = 0; i < line.length; i++) {
      rowArr.push(line[i]);
    }
    grid.push(rowArr);
  }

  const rowLength = grid.length;
  const colLength = grid[0].length;

  let startingCoordinates = [];
  for (let i = 0; i < rowLength; i++) {
    for (let j = 0; j < colLength; j++) {
      if (grid[i][j] === "a" || grid[i][j] === "S") {
        startingCoordinates.push(i + "," + j);
      }
    }
  }

  let minTotalSteps = 999999999999;
  let endingVertexCoordinate;

  // For each starting coordinate, the big loop (takes a while to execute)
  for (const startingCoordinate of startingCoordinates) {
    // Create distanceMap, previousMap, vertexMap
    let distanceMap = {};
    let previousMap = {};
    let vertexMap = {};

    for (let i = 0; i < rowLength; i++) {
      for (let j = 0; j < colLength; j++) {
        const coordinateString = i + "," + j;
        vertexMap[coordinateString] = true;
        previousMap[coordinateString] = "UNDEFINED";
        // if (grid[i][j] === "S") {
        if (coordinateString === startingCoordinate) {
          // Starting vertex
          distanceMap[coordinateString] = 0;
          grid[i][j] = "a"; // Starting vertex has elevation a
        } else if (grid[i][j] === "E") {
          // Ending vertex
          endingVertexCoordinate = coordinateString;
          grid[i][j] = "z"; // Ending vertex has elevation z
          distanceMap[coordinateString] = 999999999999;
        } else {
          distanceMap[coordinateString] = 999999999999;
        }
      }
    }

    let vertexMapLength = Object.keys(vertexMap).length;

    outerloop: while (vertexMapLength > 0) {
      let vertexWithMinDistance; // Default is undefined
      let minDistance = 999999999999;
      for (const k in vertexMap) {
        const v = distanceMap[k];
        if (v < minDistance) {
          minDistance = v;
          vertexWithMinDistance = k;
        }
      }
      delete vertexMap[vertexWithMinDistance];
      vertexMapLength--;

      let currentVertexMapLength = Object.keys(vertexMap).length;
      if (currentVertexMapLength !== vertexMapLength) {
        break outerloop; // Dead end in the path
      }

      // Check each neighbor
      const currentCoordinate = vertexWithMinDistance.split(",");
      const X = parseInt(currentCoordinate[0]);
      const Y = parseInt(currentCoordinate[1]);
      const currentLetter = grid[X][Y];

      if (vertexWithMinDistance === endingVertexCoordinate) {
        break outerloop; // Found target vertex, no point going further
      }

      // Left
      const yLeft = Y - 1;
      if (yLeft >= 0) {
        const leftLetter = grid[X][yLeft];
        if (leftLetter <= nextMap[currentLetter]) {
          // Valid left neighbor
          const leftNeighbor = X + "," + yLeft;
          if (vertexMap[leftNeighbor]) {
            // Left neighbor still in vertexMap
            const tempDistance = distanceMap[vertexWithMinDistance] + 1;
            if (tempDistance < distanceMap[leftNeighbor]) {
              distanceMap[leftNeighbor] = tempDistance;
              previousMap[leftNeighbor] = vertexWithMinDistance;
            }
          }
        }
      }

      // Right
      const yRight = Y + 1;
      if (yRight < colLength) {
        const rightLetter = grid[X][yRight];
        if (rightLetter <= nextMap[currentLetter]) {
          // Valid right neighbor
          const rightNeighbor = X + "," + yRight;
          if (vertexMap[rightNeighbor]) {
            // Right neighbor still in vertexMap
            const tempDistance = distanceMap[vertexWithMinDistance] + 1;
            if (tempDistance < distanceMap[rightNeighbor]) {
              distanceMap[rightNeighbor] = tempDistance;
              previousMap[rightNeighbor] = vertexWithMinDistance;
            }
          }
        }
      }

      // Down
      const xDown = X + 1;
      if (xDown < rowLength) {
        const downLetter = grid[xDown][Y];
        if (downLetter <= nextMap[currentLetter]) {
          // Valid down neighbor
          const downNeighbor = xDown + "," + Y;
          if (vertexMap[downNeighbor]) {
            // Down neighbor still in vertexMap
            const tempDistance = distanceMap[vertexWithMinDistance] + 1;
            if (tempDistance < distanceMap[downNeighbor]) {
              distanceMap[downNeighbor] = tempDistance;
              previousMap[downNeighbor] = vertexWithMinDistance;
            }
          }
        }
      }

      // Up
      const xUp = X - 1;
      if (xUp >= 0) {
        const upLetter = grid[xUp][Y];
        if (upLetter <= nextMap[currentLetter]) {
          // Valid up neighbor
          const upNeighbor = xUp + "," + Y;
          if (vertexMap[upNeighbor]) {
            // Up neighbor still in vertexMap
            const tempDistance = distanceMap[vertexWithMinDistance] + 1;
            if (tempDistance < distanceMap[upNeighbor]) {
              distanceMap[upNeighbor] = tempDistance;
              previousMap[upNeighbor] = vertexWithMinDistance;
            }
          }
        }
      }
    } // End outerloop

    if (distanceMap[endingVertexCoordinate] < minTotalSteps) {
      minTotalSteps = distanceMap[endingVertexCoordinate];
    }
  }

  return minTotalSteps;
};

export { day12Part1, day12Part2 };
