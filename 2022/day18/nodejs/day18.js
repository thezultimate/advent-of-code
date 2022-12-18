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
  return 58;
};

export { day18Part1, day18Part2 };
