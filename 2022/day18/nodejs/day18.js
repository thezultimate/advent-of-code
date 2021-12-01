const day18Part1 = (inputArr) => {
  let coordinateMap = {};
  let totalSurfaceArea = 0;

  for (const line of inputArr) {
    if (line.length === 0) continue;

    if (!coordinateMap[line]) {
      coordinateMap[line] = true;
      totalSurfaceArea += 6;
    }

    const splitLine = line.split(",");
    const x = parseInt(splitLine[0]);
    const y = parseInt(splitLine[1]);
    const z = parseInt(splitLine[2]);

    if (coordinateMap[x + 1 + "," + y + "," + z]) {
      totalSurfaceArea -= 2;
    }
    if (coordinateMap[x - 1 + "," + y + "," + z]) {
      totalSurfaceArea -= 2;
    }
    if (coordinateMap[x + "," + (y + 1) + "," + z]) {
      totalSurfaceArea -= 2;
    }
    if (coordinateMap[x + "," + (y - 1) + "," + z]) {
      totalSurfaceArea -= 2;
    }
    if (coordinateMap[x + "," + y + "," + (z + 1)]) {
      totalSurfaceArea -= 2;
    }
    if (coordinateMap[x + "," + y + "," + (z - 1)]) {
      totalSurfaceArea -= 2;
    }
  }

  return totalSurfaceArea;
};

const day18Part2 = (inputArr) => {
  let coordinateMap = {};
  let totalSurfaceArea = 0;
  let x, y, z;
  let xMin = 100,
    yMin = 100,
    zMin = 100;
  let xMax = 0,
    yMax = 0,
    zMax = 0;

  // Create 23x23x23 cube and fill with dots
  let cube = [];
  for (let i = 0; i < 23; i++) {
    let plane = [];
    for (let j = 0; j < 23; j++) {
      let line = [];
      for (let k = 0; k < 23; k++) {
        line.push(".");
      }
      plane.push(line);
    }
    cube.push(plane);
  }

  for (const line of inputArr) {
    if (line.length === 0) continue;

    const splitLine = line.split(",");
    x = parseInt(splitLine[0]);
    y = parseInt(splitLine[1]) + 1; // Shift y since yMin is 0 (for filling water)
    z = parseInt(splitLine[2]);

    // Set current point in cube with #
    cube[x][y][z] = "#";

    if (!coordinateMap[x + "," + y + "," + z]) {
      coordinateMap[x + "," + y + "," + z] = true;
      totalSurfaceArea += 6;
    }

    if (x < xMin) xMin = x;
    if (y < yMin) yMin = y;
    if (z < zMin) zMin = z;

    if (x > xMax) xMax = x;
    if (y > yMax) yMax = y;
    if (z > zMax) zMax = z;

    if (coordinateMap[x + 1 + "," + y + "," + z]) {
      totalSurfaceArea -= 2;
    }
    if (coordinateMap[x - 1 + "," + y + "," + z]) {
      totalSurfaceArea -= 2;
    }
    if (coordinateMap[x + "," + (y + 1) + "," + z]) {
      totalSurfaceArea -= 2;
    }
    if (coordinateMap[x + "," + (y - 1) + "," + z]) {
      totalSurfaceArea -= 2;
    }
    if (coordinateMap[x + "," + y + "," + (z + 1)]) {
      totalSurfaceArea -= 2;
    }
    if (coordinateMap[x + "," + y + "," + (z - 1)]) {
      totalSurfaceArea -= 2;
    }
  }

  // Fill in the cube with water
  fillWater(cube, 0, 0, 0);

  for (let i = 0; i < 23; i++) {
    for (let j = 0; j < 23; j++) {
      for (let k = 0; k < 23; k++) {
        if (cube[i][j][k] === ".") {
          // Empty trapped point
          let areaReduction = 0;
          for (let l = k; l < 23; l++) {
            if (cube[i][j][l] === "#") {
              if (l === k + 1) {
                areaReduction++; // Non-empty point is right next to empty trapped point
              }
              break;
            }
          }
          for (let l = k; l >= 0; l--) {
            if (cube[i][j][l] === "#") {
              if (l === k - 1) {
                areaReduction++; // Non-empty point is right next to empty trapped point
              }
              break;
            }
          }
          for (let l = j; l < 23; l++) {
            if (cube[i][l][k] === "#") {
              if (l === j + 1) {
                areaReduction++; // Non-empty point is right next to empty trapped point
              }
              break;
            }
          }
          for (let l = j; l >= 0; l--) {
            if (cube[i][l][k] === "#") {
              if (l === j - 1) {
                areaReduction++; // Non-empty point is right next to empty trapped point
              }
              break;
            }
          }
          for (let l = i; l < 23; l++) {
            if (cube[l][j][k] === "#") {
              if (l === i + 1) {
                areaReduction++; // Non-empty point is right next to empty trapped point
              }
              break;
            }
          }
          for (let l = i; l >= 0; l--) {
            if (cube[l][j][k] === "#") {
              if (l === i - 1) {
                areaReduction++; // Non-empty point is right next to empty trapped point
              }
              break;
            }
          }

          totalSurfaceArea -= areaReduction;
        }
      }
    }
  }

  return totalSurfaceArea;
};

const fillWater = (cube, x, y, z) => {
  if (cube[x][y][z] === "#") return;
  else cube[x][y][z] = "#"; // # is water

  let currentX, currentY, currentZ;

  if (z < 22) {
    currentZ = z + 1;
    fillWater(cube, x, y, currentZ);
  }
  if (z > 0) {
    currentZ = z - 1;
    fillWater(cube, x, y, currentZ);
  }
  if (y < 22) {
    currentY = y + 1;
    fillWater(cube, x, currentY, z);
  }
  if (y > 0) {
    currentY = y - 1;
    fillWater(cube, x, currentY, z);
  }
  if (x < 22) {
    currentX = x + 1;
    fillWater(cube, currentX, y, z);
  }
  if (x > 0) {
    currentX = x - 1;
    fillWater(cube, currentX, y, z);
  }
};

export { day18Part1, day18Part2 };
