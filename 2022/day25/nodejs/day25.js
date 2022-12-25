const snafuToDec = (snafu) => {
  let snafuDecimal = 0;
  const snafuLength = snafu.length;
  for (let i = snafuLength - 1; i >= 0; i--) {
    let currentSnafu;
    const charIndex = snafuLength - 1 - i;
    const currentChar = snafu[charIndex];
    if (currentChar === "-") currentSnafu = -1;
    else if (currentChar === "=") currentSnafu = -2;
    else currentSnafu = parseInt(currentChar);
    const currentDecimal = Math.pow(5, i) * currentSnafu;
    snafuDecimal += currentDecimal;
  }
  return snafuDecimal;
};

const decToSnafu = (number) => {
  let snafu = "";
  while (number !== 0) {
    const remainder = number % 5;
    number = Math.floor(number / 5);
    if (remainder === 0 || remainder === 1 || remainder === 2) {
      snafu = remainder + snafu;
    }
    if (remainder === 3) {
      number++;
      snafu = "=" + snafu;
    }
    if (remainder === 4) {
      number++;
      snafu = "-" + snafu;
    }
  }

  return snafu;
};

const day25Part1 = (inputArr) => {
  let snafuDecimalSum = 0;

  for (const line of inputArr) {
    if (line.length === 0) continue;

    let snafuDecimal = snafuToDec(line);
    snafuDecimalSum += snafuDecimal;
  }

  return decToSnafu(snafuDecimalSum);
};

const day25Part2 = (inputArr) => {
  return 0;
};

export { day25Part1, day25Part2, decToSnafu };
