const day15Part1 = (inputArr, lineRequested) => {
  let lineCoordinateMap = {};
  let sensorCoordinateMap = {};
  let beaconCoordinateMap = {};

  // Fill sensor and beacon maps
  for (const line of inputArr) {
    if (line.length === 0) continue;

    const lineSplit = line.split(" ");
    const Sx = parseInt(lineSplit[2].split("=")[1]);
    const Sy = parseInt(lineSplit[3].split("=")[1]);
    const Bx = parseInt(lineSplit[8].split("=")[1]);
    const By = parseInt(lineSplit[9].split("=")[1]);

    sensorCoordinateMap[Sx + "," + Sy] = true;
    beaconCoordinateMap[Bx + "," + By] = true;
  }

  for (const line of inputArr) {
    if (line.length === 0) continue;

    const lineSplit = line.split(" ");
    const Sx = parseInt(lineSplit[2].split("=")[1]);
    const Sy = parseInt(lineSplit[3].split("=")[1]);
    const Bx = parseInt(lineSplit[8].split("=")[1]);
    const By = parseInt(lineSplit[9].split("=")[1]);

    const distance = Math.abs(Sy - By) + Math.abs(Sx - Bx);

    let currentX;
    let currentY;
    let currentCoordinate;
    let horizontalDistance;

    if (lineRequested === Sy) {
      // Sensor is in the line
      for (let i = Sx - distance; i <= Sx + distance; i++) {
        currentCoordinate = i + "," + Sy;
        if (
          !sensorCoordinateMap[currentCoordinate] &&
          !beaconCoordinateMap[currentCoordinate]
        ) {
          lineCoordinateMap[currentCoordinate] = true;
        }
      }
    }

    if (lineRequested > Sy && lineRequested <= Sy + distance) {
      // Sensor is above the line
      let deltaDown = lineRequested - Sy;
      horizontalDistance = distance - deltaDown;
      for (let i = Sx - horizontalDistance; i <= Sx + horizontalDistance; i++) {
        currentCoordinate = i + "," + lineRequested;
        if (
          !sensorCoordinateMap[currentCoordinate] &&
          !beaconCoordinateMap[currentCoordinate]
        ) {
          lineCoordinateMap[currentCoordinate] = true;
        }
      }
    }

    if (lineRequested < Sy && lineRequested >= Sy - distance) {
      // Sensor is below the line
      let deltaUp = Sy - lineRequested;
      horizontalDistance = distance - deltaUp;
      for (let i = Sx - horizontalDistance; i <= Sx + horizontalDistance; i++) {
        currentCoordinate = i + "," + lineRequested;
        if (
          !sensorCoordinateMap[currentCoordinate] &&
          !beaconCoordinateMap[currentCoordinate]
        ) {
          lineCoordinateMap[currentCoordinate] = true;
        }
      }
    }
  }

  return Object.keys(lineCoordinateMap).length;
};

class Sensor {
  constructor(X, Y, distance) {
    this.X = X;
    this.Y = Y;
    this.distance = distance;
  }
}

const day15Part2 = (inputArr, maxGridSize) => {
  let sensorArr = [];

  // Fill sensors to sensorArr
  for (const line of inputArr) {
    if (line.length === 0) continue;
    const lineSplit = line.split(" ");
    const Sx = parseInt(lineSplit[2].split("=")[1]);
    const Sy = parseInt(lineSplit[3].split("=")[1]);
    const Bx = parseInt(lineSplit[8].split("=")[1]);
    const By = parseInt(lineSplit[9].split("=")[1]);
    const distance = Math.abs(Sy - By) + Math.abs(Sx - Bx);
    let currentSensor = new Sensor(Sx, Sy, distance);
    sensorArr.push(currentSensor);
  }

  // Check each sensor edges
  for (let i = 0; i < sensorArr.length; i++) {
    let Sx = sensorArr[i].X;
    let Sy = sensorArr[i].Y;
    let distance = sensorArr[i].distance;

    // Left to right
    for (let j = Sx - distance - 1; j <= Sx + distance + 1; j++) {
      let delta = Math.abs(Math.abs(Sx - j) - (distance + 1));
      let upX = j;
      let upY = Sy - delta;
      let downX = j;
      let downY = Sy + delta;

      if (upX >= 0 && upX <= maxGridSize && upY >= 0 && upY <= maxGridSize) {
        // Check if up point is covered by other sensor
        let isUpPointEmpty = true;
        for (let k = 0; k < sensorArr.length; k++) {
          if (i === k) continue; // Same sensor, don't check
          let isThisPointEmpty = isPointEmpty(upX, upY, sensorArr[k]);
          if (!isThisPointEmpty) {
            isUpPointEmpty = false;
            break; // Up point is covered by one of the other sensors
          }
        }
        if (isUpPointEmpty) {
          // Bingo! Found the empty point
          return upX * 4000000 + upY;
        }
      }

      if (
        downX >= 0 &&
        downX <= maxGridSize &&
        downY >= 0 &&
        downY <= maxGridSize
      ) {
        // Check if down point is covered by other sensor
        let isDownPointEmpty = true;
        for (let k = 0; k < sensorArr.length; k++) {
          if (i === k) continue; // Same sensor, don't check
          let isThisPointEmpty = isPointEmpty(downX, downY, sensorArr[k]);
          if (!isThisPointEmpty) {
            isDownPointEmpty = false;
            break; // Down point is covered by one of the other sensors
          }
        }
        if (isDownPointEmpty) {
          // Bingo! Found the empty point
          return downX * 4000000 + downY;
        }
      }
    }
  }
};

const isPointEmpty = (X, Y, sensor) => {
  if (X >= sensor.X - sensor.distance && X <= sensor.X + sensor.distance) {
    // X is within range
    let delta = Math.abs(sensor.distance - Math.abs(X - sensor.X));
    let yMin = sensor.Y - delta;
    let yMax = sensor.Y + delta;
    if (Y >= yMin && Y <= yMax) {
      // Y is within range
      // Both X and Y are within range, this point is covered (i.e. not empty)
      return false;
    }
  }
  // This point is not covered (i.e. empty)
  return true;
};

export { day15Part1, day15Part2 };
