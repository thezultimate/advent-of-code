const day5Part1 = (initialStack, inputArr) => {
  const stack = initialStack;
  for (const line of inputArr) {
    if (line.length === 0) continue;
    const lineSplit = line.split(" ");
    const count = parseInt(lineSplit[1]);
    const source = parseInt(lineSplit[3]);
    const destination = parseInt(lineSplit[5]);
    for (let i = 1; i <= count; i++) {
      const item = stack[source].pop();
      let destinationArr = stack[destination];
      destinationArr.push(item);
      stack[destination] = destinationArr;
    }
  }

  let topStacks = "";
  for (const i in stack) {
    const topItem = stack[i].pop();
    topStacks += topItem;
  }

  return topStacks;
};

const day5Part2 = (initialStack, inputArr) => {
  const stack = initialStack;
  for (const line of inputArr) {
    if (line.length === 0) continue;
    const lineSplit = line.split(" ");
    const count = parseInt(lineSplit[1]);
    const source = parseInt(lineSplit[3]);
    const destination = parseInt(lineSplit[5]);
    const srcArr = stack[source];
    const dstArr = stack[destination];
    let tempStack = [];
    for (let i = 1; i <= count; i++) {
      const item = srcArr.pop();
      tempStack.push(item);
    }
    stack[source] = srcArr;
    for (let i = 1; i <= count; i++) {
      const item = tempStack.pop();
      dstArr.push(item);
    }
    stack[destination] = dstArr;
  }

  let topStacks = "";
  for (const i in stack) {
    const topItem = stack[i].pop();
    topStacks += topItem;
  }

  return topStacks;
};

export { day5Part1, day5Part2 };
