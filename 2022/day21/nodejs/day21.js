const day21Part1 = (inputArr) => {
  let monkeyYellMap = {};

  for (const line of inputArr) {
    if (line.length === 0) continue;

    const lineSplit = line.split(":");
    const monkeyName = lineSplit[0];
    const yell = lineSplit[1].trim();
    monkeyYellMap[monkeyName] = yell;
  }

  let isFinishedYelling = false;
  while (!isFinishedYelling) {
    isFinishedYelling = true;
    for (const monkeyName in monkeyYellMap) {
      const yellNumber = parseInt(monkeyYellMap[monkeyName]);
      if (isNaN(yellNumber)) {
        // Not yelling a number
        isFinishedYelling = false;
        const yell = monkeyYellMap[monkeyName];
        let operator;
        if (yell.includes("+")) operator = "+";
        if (yell.includes("-")) operator = "-";
        if (yell.includes("*")) operator = "*";
        if (yell.includes("/")) operator = "/";
        const yellSplit = yell.split(operator);
        const leftOperand = yellSplit[0].trim();
        const rightOperand = yellSplit[1].trim();
        const leftOperandValueNumber = parseInt(monkeyYellMap[leftOperand]);
        const rightOperandValueNumber = parseInt(monkeyYellMap[rightOperand]);
        if (!isNaN(leftOperandValueNumber) && !isNaN(rightOperandValueNumber)) {
          let operationResult;
          if (operator === "+")
            operationResult = leftOperandValueNumber + rightOperandValueNumber;
          if (operator === "-")
            operationResult = leftOperandValueNumber - rightOperandValueNumber;
          if (operator === "*")
            operationResult = leftOperandValueNumber * rightOperandValueNumber;
          if (operator === "/")
            operationResult = leftOperandValueNumber / rightOperandValueNumber;
          monkeyYellMap[monkeyName] = operationResult.toString();
        }
      }
    }
  }

  return parseInt(monkeyYellMap["root"]);
};

// Too lazy to think, brute-force from a manually picked starting humn value
const day21Part2 = (inputArr, humn) => {
  let monkeyYellMapOrig = {};
  let rootLeft, rootRight;

  for (const line of inputArr) {
    if (line.length === 0) continue;

    const lineSplit = line.split(":");
    const monkeyName = lineSplit[0];
    const yell = lineSplit[1].trim();

    if (monkeyName === "root") {
      let operator;
      if (yell.includes("+")) operator = "+";
      if (yell.includes("-")) operator = "-";
      if (yell.includes("*")) operator = "*";
      if (yell.includes("/")) operator = "/";
      const yellSplit = yell.split(operator);
      rootLeft = yellSplit[0].trim();
      rootRight = yellSplit[1].trim();
      continue;
    }

    monkeyYellMapOrig[monkeyName] = yell;
  }

  let isRootBalanced = false;

  while (!isRootBalanced) {
    humn++;
    let monkeyYellMap = JSON.parse(JSON.stringify(monkeyYellMapOrig));
    monkeyYellMap["humn"] = humn.toString();
    let isFinishedYelling = false;
    while (!isFinishedYelling) {
      isFinishedYelling = true;
      for (const monkeyName in monkeyYellMap) {
        const yellNumber = parseInt(monkeyYellMap[monkeyName]);
        if (isNaN(yellNumber)) {
          // Not yelling a number
          isFinishedYelling = false;
          const yell = monkeyYellMap[monkeyName];
          let operator;
          if (yell.includes("+")) operator = "+";
          if (yell.includes("-")) operator = "-";
          if (yell.includes("*")) operator = "*";
          if (yell.includes("/")) operator = "/";
          const yellSplit = yell.split(operator);
          const leftOperand = yellSplit[0].trim();
          const rightOperand = yellSplit[1].trim();
          const leftOperandValueNumber = parseInt(monkeyYellMap[leftOperand]);
          const rightOperandValueNumber = parseInt(monkeyYellMap[rightOperand]);
          if (
            !isNaN(leftOperandValueNumber) &&
            !isNaN(rightOperandValueNumber)
          ) {
            let operationResult;
            if (operator === "+")
              operationResult =
                leftOperandValueNumber + rightOperandValueNumber;
            if (operator === "-")
              operationResult =
                leftOperandValueNumber - rightOperandValueNumber;
            if (operator === "*")
              operationResult =
                leftOperandValueNumber * rightOperandValueNumber;
            if (operator === "/")
              operationResult =
                leftOperandValueNumber / rightOperandValueNumber;
            monkeyYellMap[monkeyName] = operationResult.toString();
          }
        }
      }
    }

    if (monkeyYellMap[rootLeft] === monkeyYellMap[rootRight]) {
      return humn;
    }
  }

  return 0;
};

export { day21Part1, day21Part2 };
