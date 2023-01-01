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

// Permutation 2 out of 15 is ~= 210*156*110*72*42*20*6 = 1307674368000
// The program eventually terminates after several hours of execution (left it overnight and it terminated correctly)
// A better solution definitely exists
const day16Part2 = (inputArr) => {
  distancesMap = {};
  rateMap = {};
  valvesArr = [];
  maxTotalRates = 0;
  maxRate = 0;
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
  let remainingTimeHuman = 26;
  let remainingTimeElephant = 26;
  let initialValveHuman = "AA";
  let initialValveElephant = "AA";
  let canContinueHuman = true;
  let canContinueElephant = true;
  let initialHumanArr = [];
  let initialElephantArr = [];

  traverseTunnels2(
    isClosed,
    totalRates,
    remainingTimeHuman,
    remainingTimeElephant,
    initialValveHuman,
    initialValveElephant,
    canContinueHuman,
    canContinueElephant,
    initialHumanArr,
    initialElephantArr
  );

  return maxTotalRates;
};

const traverseTunnels2 = (
  allValvesMap,
  totalRates,
  remainingTimeHuman,
  remainingTimeElephant,
  previousValveHuman,
  previousValveElephant,
  canContinueHuman,
  canContinueElephant,
  humanArr,
  elephantArr
) => {
  if (!canContinueHuman && !canContinueElephant) {
    // Both human and elephant can't continue
    if (totalRates > maxTotalRates) {
      maxTotalRates = totalRates;
      console.log("Max rates: " + totalRates);
      console.log("Human: " + humanArr);
      console.log("Elephant " + elephantArr);
      console.log();
    }
  } else if (canContinueHuman && canContinueElephant) {
    // Both human and elephant can continue
    if (
      Object.keys(allValvesMap).length === 0 &&
      allValvesMap.constructor === Object
    ) {
      // No more valve to traverse
      if (totalRates > maxTotalRates) {
        maxTotalRates = totalRates;
        console.log("Max rates: " + totalRates);
        console.log("Human: " + humanArr);
        console.log("Elephant: " + elephantArr);
        console.log();
      }
    } else if (Object.keys(allValvesMap).length === 1) {
      // Exactly one valve left to traverse
      for (let i = 1; i <= 2; i++) {
        if (i === 1) {
          // Human gets to open the last valve
          let currentHumanArr = JSON.parse(JSON.stringify(humanArr));
          let valve = Object.keys(allValvesMap)[0];
          let currentTotalRates = totalRates;
          let currentRemainingTimeHuman = remainingTimeHuman;
          let currentValveHuman = previousValveHuman;
          let distanceFromPreviousValveHuman =
            distancesMap[currentValveHuman + "-" + valve];
          currentRemainingTimeHuman =
            currentRemainingTimeHuman - distanceFromPreviousValveHuman;
          if (currentRemainingTimeHuman <= 0) {
            if (currentTotalRates > maxTotalRates) {
              maxTotalRates = currentTotalRates;
              console.log("Max rates: " + currentTotalRates);
              console.log("Human: " + currentHumanArr);
              console.log("Elephant: " + elephantArr);
              console.log();
            }
            continue; // Don't continue this path
          }
          currentValveHuman = valve;
          currentRemainingTimeHuman--;
          if (currentRemainingTimeHuman <= 0) {
            if (currentTotalRates > maxTotalRates) {
              maxTotalRates = currentTotalRates;
              console.log("Max rates: " + currentTotalRates);
              console.log("Human: " + currentHumanArr);
              console.log("Elephant: " + elephantArr);
              console.log();
            }
            continue; // Don't continue this path
          }
          currentHumanArr.push(currentValveHuman);
          currentTotalRates =
            currentTotalRates +
            currentRemainingTimeHuman * rateMap[currentValveHuman];
          if (currentTotalRates > maxTotalRates) {
            maxTotalRates = currentTotalRates;
            console.log("Max rates: " + currentTotalRates);
            console.log("Human: " + currentHumanArr);
            console.log("Elephant: " + elephantArr);
            console.log();
          }
        } else {
          // Elephant gets to open the last valve
          let currentElephantArr = JSON.parse(JSON.stringify(elephantArr));
          let valve = Object.keys(allValvesMap)[0];
          let currentTotalRates = totalRates;
          let currentRemainingTimeElephant = remainingTimeElephant;
          let currentValveElephant = previousValveElephant;
          let distanceFromPreviousValveElephant =
            distancesMap[currentValveElephant + "-" + valve];
          currentRemainingTimeElephant =
            currentRemainingTimeElephant - distanceFromPreviousValveElephant;
          if (currentRemainingTimeElephant <= 0) {
            if (currentTotalRates > maxTotalRates) {
              maxTotalRates = currentTotalRates;
              console.log("Max rates: " + currentTotalRates);
              console.log("Human: " + humanArr);
              console.log("Elephant" + currentElephantArr);
              console.log();
            }
            continue; // Don't continue this path
          }
          currentValveElephant = valve;
          currentRemainingTimeElephant--;
          if (currentRemainingTimeElephant <= 0) {
            if (currentTotalRates > maxTotalRates) {
              maxTotalRates = currentTotalRates;
              console.log("Max rates: " + currentTotalRates);
              console.log("Human: " + humanArr);
              console.log("Elephant: " + currentElephantArr);
              console.log();
            }
            continue; // Don't continue this path
          }
          currentElephantArr.push(currentValveElephant);
          currentTotalRates =
            currentTotalRates +
            currentRemainingTimeElephant * rateMap[currentValveElephant];
          if (currentTotalRates > maxTotalRates) {
            maxTotalRates = currentTotalRates;
            console.log("Max rates: " + currentTotalRates);
            console.log("Human: " + humanArr);
            console.log("Elephant: " + currentElephantArr);
            console.log();
          }
        }
      }
    } else {
      // Two or more valves left to traverse
      let permuteTwoArr = getPermuteTwo(allValvesMap);
      for (let i = 0; i < permuteTwoArr.length; i++) {
        let valveOne = permuteTwoArr[i].twoValves[0];
        let valveTwo = permuteTwoArr[i].twoValves[1];
        let remainingValvesMap = permuteTwoArr[i].remainingValves;

        let currentTotalRates = totalRates;
        let currentRemainingTimeHuman = remainingTimeHuman;
        let currentRemainingTimeElephant = remainingTimeElephant;
        let currentValveHuman = previousValveHuman;
        let currentValveElephant = previousValveElephant;
        let currentCanContinueHuman = canContinueHuman;
        let currentCanContinueElephant = canContinueElephant;
        let currentHumanArr = JSON.parse(JSON.stringify(humanArr));
        let currentElephantArr = JSON.parse(JSON.stringify(elephantArr));

        for (let i = 1; i <= 2; i++) {
          if (i === 1) {
            // Process human with valveOne
            let distanceFromPreviousValveHuman =
              distancesMap[currentValveHuman + "-" + valveOne];
            currentRemainingTimeHuman =
              currentRemainingTimeHuman - distanceFromPreviousValveHuman;
            if (currentRemainingTimeHuman <= 0) {
              if (currentTotalRates > maxTotalRates) {
                maxTotalRates = currentTotalRates;
                console.log("Max rates: " + currentTotalRates);
                console.log("Human: " + currentHumanArr);
                console.log("Elephant: " + currentElephantArr);
                // console.log("Counter: " + permuteTwoIterationCounter);
                if (permuteTwoIterationCounter > maxPermuteTwoIterationCounter)
                  maxPermuteTwoIterationCounter = permuteTwoIterationCounter;
                // console.log("Max counter: " + maxPermuteTwoIterationCounter);
                console.log();
                permuteTwoIterationCounter = 0;
              }
              currentCanContinueHuman = false; // Human cannot continue this path
              remainingValvesMap[valveOne] = true; // valveOne has not been traversed
              continue; // Don't continue this path
            }
            currentValveHuman = valveOne;
            currentRemainingTimeHuman--;
            if (currentRemainingTimeHuman <= 0) {
              if (currentTotalRates > maxTotalRates) {
                maxTotalRates = currentTotalRates;
                console.log("Max rates: " + currentTotalRates);
                console.log("Human: " + currentHumanArr);
                console.log("Elephant: " + currentElephantArr);
                console.log();
              }
              currentCanContinueHuman = false; // Human cannot continue this path
              remainingValvesMap[valveOne] = true; // valveOne has not been traversed
              continue; // Don't continue this path
            }
            currentHumanArr.push(currentValveHuman);
            currentTotalRates =
              currentTotalRates +
              currentRemainingTimeHuman * rateMap[currentValveHuman];
            if (currentTotalRates > maxTotalRates) {
              maxTotalRates = currentTotalRates;
              console.log("Max rates: " + currentTotalRates);
              console.log("Human: " + currentHumanArr);
              console.log("Elephant: " + currentElephantArr);
              console.log();
            }
          } else {
            // Process elephant with valveTwo
            let distanceFromPreviousValveElephant =
              distancesMap[currentValveElephant + "-" + valveTwo];
            currentRemainingTimeElephant =
              currentRemainingTimeElephant - distanceFromPreviousValveElephant;
            if (currentRemainingTimeElephant <= 0) {
              if (currentTotalRates > maxTotalRates) {
                maxTotalRates = currentTotalRates;
                console.log("Max rates: " + currentTotalRates);
                console.log("Human: " + currentHumanArr);
                console.log("Elephant: " + currentElephantArr);
                console.log();
              }
              currentCanContinueElephant = false; // Elephant cannot continue this path
              remainingValvesMap[valveTwo] = true; // valveTwo has not been traversed
              continue; // Don't continue this path
            }
            currentValveElephant = valveTwo;
            currentRemainingTimeElephant--;
            if (currentRemainingTimeElephant <= 0) {
              if (currentTotalRates > maxTotalRates) {
                maxTotalRates = currentTotalRates;
                console.log("Max rates: " + currentTotalRates);
                console.log("Human: " + currentHumanArr);
                console.log("Elephant: " + currentElephantArr);
                console.log();
              }
              currentCanContinueElephant = false; // Elephant cannot continue this path
              remainingValvesMap[valveTwo] = true; // valveTwo has not been traversed
              continue; // Don't continue this path
            }
            currentElephantArr.push(currentValveElephant);
            currentTotalRates =
              currentTotalRates +
              currentRemainingTimeElephant * rateMap[currentValveElephant];
            if (currentTotalRates > maxTotalRates) {
              maxTotalRates = currentTotalRates;
              console.log("Max rates: " + currentTotalRates);
              console.log("Human: " + currentHumanArr);
              console.log("Elephant: " + currentElephantArr);
              console.log();
            }
          }
        }
        traverseTunnels2(
          remainingValvesMap,
          currentTotalRates,
          currentRemainingTimeHuman,
          currentRemainingTimeElephant,
          currentValveHuman,
          currentValveElephant,
          currentCanContinueHuman,
          currentCanContinueElephant,
          currentHumanArr,
          currentElephantArr
        );
      }
    }
  } else if (canContinueHuman) {
    // Only human can continue
    for (const valve in allValvesMap) {
      let currentHumanArr = JSON.parse(JSON.stringify(humanArr));
      let currentTotalRates = totalRates;
      let currentRemainingTimeHuman = remainingTimeHuman;
      let currentValveHuman = previousValveHuman;
      let currentAllValvesMap = JSON.parse(JSON.stringify(allValvesMap));
      delete currentAllValvesMap[valve];

      // Process open and move human
      let distanceFromPreviousValveHuman =
        distancesMap[currentValveHuman + "-" + valve];
      currentRemainingTimeHuman =
        currentRemainingTimeHuman - distanceFromPreviousValveHuman;
      if (currentRemainingTimeHuman <= 0) {
        if (currentTotalRates > maxTotalRates) {
          maxTotalRates = currentTotalRates;
          console.log("Max rates: " + currentTotalRates);
          console.log("Human: " + currentHumanArr);
          console.log("Elephant" + elephantArr);
          console.log();
        }
        continue; // Don't continue this path
      }
      currentValveHuman = valve;
      currentRemainingTimeHuman--;
      if (currentRemainingTimeHuman <= 0) {
        if (currentTotalRates > maxTotalRates) {
          maxTotalRates = currentTotalRates;
          console.log("Max rates: " + currentTotalRates);
          console.log("Human: " + currentHumanArr);
          console.log("Elephant: " + elephantArr);
          console.log();
        }
        continue; // Don't continue this path
      }
      currentHumanArr.push(currentValveHuman);
      currentTotalRates =
        currentTotalRates +
        currentRemainingTimeHuman * rateMap[currentValveHuman];
      if (currentTotalRates > maxTotalRates) {
        maxTotalRates = currentTotalRates;
        console.log("Max rates: " + currentTotalRates);
        console.log("Human: " + currentHumanArr);
        console.log("Elephant: " + elephantArr);
        console.log();
      }

      traverseTunnels2(
        currentAllValvesMap,
        currentTotalRates,
        currentRemainingTimeHuman,
        remainingTimeElephant,
        currentValveHuman,
        previousValveElephant,
        canContinueHuman,
        canContinueElephant,
        currentHumanArr,
        elephantArr
      );
    }
  } else if (canContinueElephant) {
    // Only elephant can continue
    for (const valve in allValvesMap) {
      let currentElephantArr = JSON.parse(JSON.stringify(elephantArr));
      let currentTotalRates = totalRates;
      let currentRemainingTimeElephant = remainingTimeElephant;
      let currentValveElephant = previousValveElephant;
      let currentAllValvesMap = JSON.parse(JSON.stringify(allValvesMap));
      delete currentAllValvesMap[valve];

      // Process open and move elephant
      let distanceFromPreviousValveElephant =
        distancesMap[currentValveElephant + "-" + valve];
      currentRemainingTimeElephant =
        currentRemainingTimeElephant - distanceFromPreviousValveElephant;
      if (currentRemainingTimeElephant <= 0) {
        if (currentTotalRates > maxTotalRates) {
          maxTotalRates = currentTotalRates;
          console.log("Max rates: " + currentTotalRates);
          console.log("Human: " + humanArr);
          console.log("Elephant: " + currentElephantArr);
          console.log();
        }
        continue; // Don't continue this path
      }
      currentValveElephant = valve;
      currentRemainingTimeElephant--;
      if (currentRemainingTimeElephant <= 0) {
        if (currentTotalRates > maxTotalRates) {
          maxTotalRates = currentTotalRates;
          console.log("Max rates: " + currentTotalRates);
          console.log("Human: " + humanArr);
          console.log("Elephant: " + currentElephantArr);
          console.log();
        }
        continue; // Don't continue this path
      }
      currentElephantArr.push(currentValveElephant);
      currentTotalRates =
        currentTotalRates +
        currentRemainingTimeElephant * rateMap[currentValveElephant];
      if (currentTotalRates > maxTotalRates) {
        maxTotalRates = currentTotalRates;
        console.log("Max rates: " + currentTotalRates);
        console.log("Human: " + humanArr);
        console.log("Elephant: " + currentElephantArr);
        console.log();
      }

      traverseTunnels2(
        currentAllValvesMap,
        currentTotalRates,
        remainingTimeHuman,
        currentRemainingTimeElephant,
        previousValveHuman,
        currentValveElephant,
        canContinueHuman,
        canContinueElephant,
        humanArr,
        currentElephantArr
      );
    }
  }
};

const getPermuteTwo = (valvesMap) => {
  let initialPermuteTwoArr = [];
  let initialSequenceArr = [];
  permuteTwo(valvesMap, initialSequenceArr, initialPermuteTwoArr);
  return initialPermuteTwoArr;
};

const permuteTwo = (valvesMap, sequenceArr, permuteTwoArr) => {
  for (const valve in valvesMap) {
    let valvesMapCopy = JSON.parse(JSON.stringify(valvesMap));
    delete valvesMapCopy[valve];
    let sequenceArrCopy = JSON.parse(JSON.stringify(sequenceArr));
    sequenceArrCopy.push(valve);
    if (sequenceArrCopy.length === 2) {
      permuteTwoArr.push({
        twoValves: sequenceArrCopy,
        remainingValves: valvesMapCopy,
      });
      // console.log(sequenceArrCopy);
      continue;
    }
    permuteTwo(valvesMapCopy, sequenceArrCopy, permuteTwoArr);
  }
};

export { day16Part1, day16Part2, getPermuteTwo };
