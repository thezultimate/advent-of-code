const day10Part1 = (inputArr) => {
  let sumSignalStrength = 0;
  let cycle = 0;
  let X = 1;

  for (const line of inputArr) {
    if (line.length === 0) continue;

    const lineSplit = line.split(" ");
    const numCycles = lineSplit.length;

    if (numCycles === 1) {
      // noop operation
      cycle++;
      // Check
      if (
        cycle === 20 ||
        cycle === 60 ||
        cycle === 100 ||
        cycle === 140 ||
        cycle === 180 ||
        cycle === 220
      ) {
        const signalStrength = cycle * X;
        sumSignalStrength += signalStrength;
      }
      continue;
    }

    if (numCycles === 2) {
      // addx V operation
      const deltaX = parseInt(lineSplit[1]);
      cycle++;
      // Check
      if (
        cycle === 20 ||
        cycle === 60 ||
        cycle === 100 ||
        cycle === 140 ||
        cycle === 180 ||
        cycle === 220
      ) {
        const signalStrength = cycle * X;
        sumSignalStrength += signalStrength;
      }
      cycle++;
      // Check
      if (
        cycle === 20 ||
        cycle === 60 ||
        cycle === 100 ||
        cycle === 140 ||
        cycle === 180 ||
        cycle === 220
      ) {
        const signalStrength = cycle * X;
        sumSignalStrength += signalStrength;
      }
      X += deltaX;
      continue;
    }
  }

  return sumSignalStrength;
};

const day10Part2 = (inputArr) => {
  let cycle = 0;
  let X = 1;
  let spriteIndex = X;
  let crtArr = [];
  let currentRowArr = [];

  for (const line of inputArr) {
    if (line.length === 0) continue;

    const lineSplit = line.split(" ");
    const numCycles = lineSplit.length;

    if (numCycles === 1) {
      // noop operation
      cycle++;
      // Draw
      if (
        cycle === spriteIndex ||
        cycle === spriteIndex + 1 ||
        cycle === spriteIndex + 2
      ) {
        currentRowArr.push("#");
      } else {
        currentRowArr.push(".");
      }
      // Check if row is full
      if (cycle % 40 === 0) {
        crtArr.push(currentRowArr);
        currentRowArr = [];
        cycle = 0;
      }
      continue;
    }

    if (numCycles === 2) {
      // addx V operation
      const deltaX = parseInt(lineSplit[1]);
      cycle++;
      // Draw
      if (
        cycle === spriteIndex ||
        cycle === spriteIndex + 1 ||
        cycle === spriteIndex + 2
      ) {
        currentRowArr.push("#");
      } else {
        currentRowArr.push(".");
      }
      // Check if row is full
      if (cycle % 40 === 0) {
        crtArr.push(currentRowArr);
        currentRowArr = [];
        cycle = 0;
      }
      cycle++;
      // Draw
      if (
        cycle === spriteIndex ||
        cycle === spriteIndex + 1 ||
        cycle === spriteIndex + 2
      ) {
        currentRowArr.push("#");
      } else {
        currentRowArr.push(".");
      }
      // Check if row is full
      if (cycle % 40 === 0) {
        crtArr.push(currentRowArr);
        currentRowArr = [];
        cycle = 0;
      }
      X += deltaX;
      spriteIndex = X;
      continue;
    }
  }

  // Draw CRT
  for (const row of crtArr) {
    for (const point of row) {
      process.stdout.write(point);
    }
    console.log();
  }
};

export { day10Part1, day10Part2 };
