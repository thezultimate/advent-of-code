const day6Part1 = (input) => {
  let currentPosition = 4;

  let lastFourteen = {};
  let duplicate = false;
  for (let i = 0; i < 4; i++) {
    const currentChar = input[i];
    if (lastFourteen[currentChar]) duplicate = true;
    lastFourteen[currentChar] = true;
  }
  if (!duplicate) return currentPosition;

  for (let i = 4; i < input.length; i++) {
    currentPosition++;
    const startIndex = i - 4 + 1;
    lastFourteen = {};
    duplicate = false;
    for (let j = startIndex; j <= i; j++) {
      const currentChar = input[j];
      if (lastFourteen[currentChar]) duplicate = true;
      lastFourteen[currentChar] = true;
    }
    if (!duplicate) return currentPosition;
  }
};

const day6Part2 = (input) => {
  let currentPosition = 14;

  let lastFourteen = {};
  let duplicate = false;
  for (let i = 0; i < 14; i++) {
    const currentChar = input[i];
    if (lastFourteen[currentChar]) duplicate = true;
    lastFourteen[currentChar] = true;
  }
  if (!duplicate) return currentPosition;

  for (let i = 14; i < input.length; i++) {
    currentPosition++;
    const startIndex = i - 14 + 1;
    lastFourteen = {};
    duplicate = false;
    for (let j = startIndex; j <= i; j++) {
      const currentChar = input[j];
      if (lastFourteen[currentChar]) duplicate = true;
      lastFourteen[currentChar] = true;
    }
    if (!duplicate) return currentPosition;
  }
};

export { day6Part1, day6Part2 };
