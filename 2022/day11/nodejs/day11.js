class Monkey {
  constructor(
    number,
    startingItems,
    operation,
    divisibleNumber,
    yesDivisible,
    noDivisible
  ) {
    this.number = number;
    this.startingItems = startingItems;
    this.operation = operation;
    this.divisibleNumber = divisibleNumber;
    this.yesDivisible = yesDivisible;
    this.noDivisible = noDivisible;
  }
}

const day11Part1 = (inputArr) => {
  let monkeyInspections = [];
  let monkeyList = [];
  let number;
  let startingItems = [];
  let operation = [];
  let divisibleNumber;
  let yesDivisible;
  let noDivisible;
  for (const line of inputArr) {
    // Parse input
    if (line.includes("Monkey")) {
      const lineSplit = line.split(" ");
      const numberSplit = lineSplit[1].split(":");
      number = parseInt(numberSplit[0]);
    }
    if (line.includes("Starting")) {
      startingItems = [];
      const lineSplit = line.split(" ");
      for (let i = 4; i < lineSplit.length; i++) {
        startingItems.push(parseInt(lineSplit[i]));
      }
    }
    if (line.includes("Operation")) {
      operation = [];
      const lineSplit = line.split(" ");
      operation.push(lineSplit[6]);
      operation.push(lineSplit[7]); // Can be number or string "old"
    }
    if (line.includes("Test")) {
      const lineSplit = line.split(" ");
      divisibleNumber = parseInt(lineSplit[5]);
    }
    if (line.includes("If")) {
      const lineSplit = line.split(" ");
      if (lineSplit[5] === "true:") {
        yesDivisible = parseInt(lineSplit[9]);
      }
      if (lineSplit[5] === "false:") {
        noDivisible = parseInt(lineSplit[9]);
      }
    }
    if (line.length === 0) {
      // Instantiate Monkey object and add to monkeyList and initiate monkeyInspections for this monkey
      let monkey = new Monkey(
        number,
        startingItems,
        operation,
        divisibleNumber,
        yesDivisible,
        noDivisible
      );
      monkeyList.push(monkey);
      monkeyInspections.push(0); // 0 inspections at the beginning
    }
  }

  // Iterate 20 rounds
  for (let round = 1; round <= 20; round++) {
    // Iterate through monkeyList
    for (let i = 0; i < monkeyList.length; i++) {
      let currentMonkey = monkeyList[i];
      let startingItems = currentMonkey.startingItems;
      let startingItemsLength = startingItems.length;
      monkeyInspections[i] += startingItemsLength; // Add inspections as the starting items

      // Iterate through starting items
      for (let j = 0; j < startingItemsLength; j++) {
        let currentStartingItem = startingItems[j];

        // startingItems.shift(); // Remove the first array element (current item)
        let operator = currentMonkey.operation[0];
        let targetOperator = parseInt(currentMonkey.operation[1]);
        let operationResult;
        if (operator === "*") {
          if (isNaN(targetOperator)) {
            // Target operator is "old"
            operationResult = currentStartingItem * currentStartingItem;
          } else {
            operationResult = currentStartingItem * targetOperator;
          }
        }
        if (operator === "+") {
          if (isNaN(targetOperator)) {
            // Target operator is "old"
            operationResult = currentStartingItem + currentStartingItem;
          } else {
            operationResult = currentStartingItem + targetOperator;
          }
        }
        operationResult = Math.floor(operationResult / 3); // Divide by 3

        if (operationResult % currentMonkey.divisibleNumber === 0) {
          // Throw to monkey yesDivisible
          yesDivisible = currentMonkey.yesDivisible;
          monkeyList[yesDivisible].startingItems.push(operationResult);
        } else {
          // Throw to monkey noDivisible
          noDivisible = currentMonkey.noDivisible;
          monkeyList[noDivisible].startingItems.push(operationResult);
        }
      }
      currentMonkey.startingItems = [];
      monkeyList[i] = currentMonkey;
    }
  }

  monkeyInspections.sort((a, b) => b - a);

  return monkeyInspections[0] * monkeyInspections[1];
};

const day11Part2 = (inputArr) => {
  let monkeyInspections = [];
  let monkeyList = [];
  let number;
  let startingItems = [];
  let operation = [];
  let divisibleNumber;
  let yesDivisible;
  let noDivisible;
  let multipliedDivisibleNumbers = 1; // Multiplication of all dividers for all monkeys
  for (const line of inputArr) {
    // Parse input
    if (line.includes("Monkey")) {
      const lineSplit = line.split(" ");
      const numberSplit = lineSplit[1].split(":");
      number = parseInt(numberSplit[0]);
    }
    if (line.includes("Starting")) {
      startingItems = [];
      const lineSplit = line.split(" ");
      for (let i = 4; i < lineSplit.length; i++) {
        startingItems.push(parseInt(lineSplit[i]));
      }
    }
    if (line.includes("Operation")) {
      operation = [];
      const lineSplit = line.split(" ");
      operation.push(lineSplit[6]);
      operation.push(lineSplit[7]); // Can be number or string "old"
    }
    if (line.includes("Test")) {
      const lineSplit = line.split(" ");
      divisibleNumber = parseInt(lineSplit[5]);
      multipliedDivisibleNumbers *= divisibleNumber;
    }
    if (line.includes("If")) {
      const lineSplit = line.split(" ");
      if (lineSplit[5] === "true:") {
        yesDivisible = parseInt(lineSplit[9]);
      }
      if (lineSplit[5] === "false:") {
        noDivisible = parseInt(lineSplit[9]);
      }
    }
    if (line.length === 0) {
      // Instantiate Monkey object and add to monkeyList and initiate monkeyInspections for this monkey
      let monkey = new Monkey(
        number,
        startingItems,
        operation,
        divisibleNumber,
        yesDivisible,
        noDivisible
      );
      monkeyList.push(monkey);
      monkeyInspections.push(0); // 0 inspections at the beginning
    }
  }

  // Iterate 10000 rounds
  const roundLimit = 10000;
  for (let round = 1; round <= roundLimit; round++) {
    // Iterate through monkeyList
    for (let i = 0; i < monkeyList.length; i++) {
      let currentMonkey = monkeyList[i];
      let startingItems = currentMonkey.startingItems;
      let startingItemsLength = startingItems.length;
      monkeyInspections[i] += startingItemsLength; // Add inspections as the starting items

      // Iterate through starting items
      for (let j = 0; j < startingItemsLength; j++) {
        let currentStartingItem = startingItems[j];
        currentStartingItem %= multipliedDivisibleNumbers; // Reduce the value of current starting item

        // startingItems.shift(); // Remove the first array element (current item)
        let operator = currentMonkey.operation[0];
        let targetOperator = parseInt(currentMonkey.operation[1]);
        let operationResult;
        if (operator === "*") {
          if (isNaN(targetOperator)) {
            // Target operator is "old"
            operationResult = currentStartingItem * currentStartingItem;
          } else {
            operationResult = currentStartingItem * targetOperator;
          }
        }
        if (operator === "+") {
          if (isNaN(targetOperator)) {
            // Target operator is "old"
            operationResult = currentStartingItem + currentStartingItem;
          } else {
            operationResult = currentStartingItem + targetOperator;
          }
        }

        if (operationResult % currentMonkey.divisibleNumber === 0) {
          // Throw to monkey yesDivisible
          yesDivisible = currentMonkey.yesDivisible;
          monkeyList[yesDivisible].startingItems.push(operationResult);
        } else {
          // Throw to monkey noDivisible
          noDivisible = currentMonkey.noDivisible;
          monkeyList[noDivisible].startingItems.push(operationResult);
        }
      }
      currentMonkey.startingItems = [];
      monkeyList[i] = currentMonkey;
    }
  }

  monkeyInspections.sort((a, b) => b - a);

  return monkeyInspections[0] * monkeyInspections[1];
};

export { day11Part1, day11Part2 };
