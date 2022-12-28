let distancesMap = {};
let rateMap = {};
let valvesArr = [];
let maxTotalRates = 0;
let maxRate = 0;

const day16Part1 = (inputArr) => {
  let isClosed = {};

  for (const line of inputArr) {
    if (line.length === 0) continue;

    const lineSplit = line.split(" ");
    const valve = lineSplit[1];
    const rate = parseInt(lineSplit[4].split("=")[1].split(";")[0]);
    for (let i = 9; i < lineSplit.length; i++) {
      let neighbour = lineSplit[i].split(",")[0];
      distancesMap[valve + "-" + neighbour] = 1;
    }
    distancesMap[valve + "-" + valve] = 0;
    valvesArr.push(valve);
    rateMap[valve] = rate;
    isClosed[valve] = true;
    if (rate > maxRate) maxRate = rate;
  }

  // Set all other distance pairs to infinity/large number
  for (let i = 0; i <= valvesArr.length - 2; i++) {
    for (let j = i + 1; j <= valvesArr.length - 1; j++) {
      if (valvesArr[i] + "-" + valvesArr[j] in distancesMap) {
        // Distance exists, do nothing
      } else {
        distancesMap[valvesArr[i] + "-" + valvesArr[j]] = 1000000;
        distancesMap[valvesArr[j] + "-" + valvesArr[i]] = 1000000;
      }
    }
  }

  // Floyd-Warshall all valves' minimum distances to all other valves
  for (let k = 0; k < valvesArr.length; k++) {
    for (let i = 0; i < valvesArr.length; i++) {
      for (let j = 0; j < valvesArr.length; j++) {
        let alternativeDistance =
          distancesMap[valvesArr[i] + "-" + valvesArr[k]] +
          distancesMap[valvesArr[k] + "-" + valvesArr[j]];
        if (
          distancesMap[valvesArr[i] + "-" + valvesArr[j]] > alternativeDistance
        ) {
          distancesMap[valvesArr[i] + "-" + valvesArr[j]] = alternativeDistance;
          distancesMap[valvesArr[j] + "-" + valvesArr[i]] = alternativeDistance;
        }
      }
    }
  }

  // Removing 0 rate vertices from isClosed
  for (const valve of valvesArr) {
    if (rateMap[valve] === 0) {
      delete isClosed[valve];
    }
  }

  let totalRates = 0;
  let remainingTime = 30;
  let initialValve = "AA";
  let initialSequenceArr = []; // For debugging

  traverseTunnels(
    isClosed,
    totalRates,
    remainingTime,
    initialValve,
    initialSequenceArr
  );

  return maxTotalRates;
};

const traverseTunnels = (
  allValvesMap,
  totalRates,
  remainingTime,
  previousValve,
  sequenceArr
) => {
  for (const valve in allValvesMap) {
    let currentTotalRates = totalRates;
    let currentRemainingTime = remainingTime;
    let currentValve = previousValve;
    let currentSequenceArr = JSON.parse(JSON.stringify(sequenceArr));
    let currentAllValvesMap = JSON.parse(JSON.stringify(allValvesMap));
    delete currentAllValvesMap[valve];

    // Process open and move
    let distanceFromPreviousValve = distancesMap[currentValve + "-" + valve];
    currentRemainingTime = currentRemainingTime - distanceFromPreviousValve;
    if (currentRemainingTime <= 0) {
      if (currentTotalRates > maxTotalRates) {
        maxTotalRates = currentTotalRates;
      }
      continue; // Don't continue this path
    }
    currentValve = valve;
    currentSequenceArr.push(currentValve);
    currentRemainingTime--;
    if (currentRemainingTime <= 0) {
      if (currentTotalRates > maxTotalRates) {
        maxTotalRates = currentTotalRates;
      }
      continue; // Don't continue this path
    }
    currentTotalRates =
      currentTotalRates + currentRemainingTime * rateMap[currentValve];

    traverseTunnels(
      currentAllValvesMap,
      currentTotalRates,
      currentRemainingTime,
      currentValve,
      currentSequenceArr
    );
  }

  if (totalRates > maxTotalRates) {
    maxTotalRates = totalRates;
  }
};

const day16Part2 = (inputArr) => {
  return 0;
};

export { day16Part1, day16Part2 };
