const day3Part1 = (inputArr) => {
  const priorityMap = getPriorityMap();
  let sumPriorities = 0;
  for (const rucksack of inputArr) {
    const itemsLength = rucksack.length;
    if (itemsLength === 0) continue;
    const halfLength = itemsLength / 2;
    const leftCompartment = {};
    const rightCompartment = {};
    for (let i = 0; i < itemsLength; i++) {
      let commonItem, commonItemPriority;
      const leftItem = rucksack[i];
      const rightItem = rucksack[i + halfLength];
      leftCompartment[leftItem] = true;
      rightCompartment[rightItem] = true;
      if (rightCompartment[leftItem]) {
        commonItem = leftItem;
        commonItemPriority = priorityMap[commonItem];
        sumPriorities += commonItemPriority;
        break;
      }
      if (leftCompartment[rightItem]) {
        commonItem = rightItem;
        commonItemPriority = priorityMap[rightItem];
        sumPriorities += commonItemPriority;
        break;
      }
    }
  }

  return sumPriorities;
};

const getPriorityMap = () => {
  return {
    a: 1,
    b: 2,
    c: 3,
    d: 4,
    e: 5,
    f: 6,
    g: 7,
    h: 8,
    i: 9,
    j: 10,
    k: 11,
    l: 12,
    m: 13,
    n: 14,
    o: 15,
    p: 16,
    q: 17,
    r: 18,
    s: 19,
    t: 20,
    u: 21,
    v: 22,
    w: 23,
    x: 24,
    y: 25,
    z: 26,
    A: 27,
    B: 28,
    C: 29,
    D: 30,
    E: 31,
    F: 32,
    G: 33,
    H: 34,
    I: 35,
    J: 36,
    K: 37,
    L: 38,
    M: 39,
    N: 40,
    O: 41,
    P: 42,
    Q: 43,
    R: 44,
    S: 45,
    T: 46,
    U: 47,
    V: 48,
    W: 49,
    X: 50,
    Y: 51,
    Z: 52,
  };
};

const day3Part2 = (inputArr) => {
  const priorityMap = getPriorityMap();
  let sumPriorities = 0;
  let firstRucksackContentsMap = {};
  let secondRucksackContentsMap = {};
  let thirdRucksackContentsMap = {};
  let lineCounter = 0;
  for (const rucksack of inputArr) {
    if (rucksack.length === 0) continue;
    lineCounter++;
    for (let i = 0; i < rucksack.length; i++) {
      if (lineCounter === 1) firstRucksackContentsMap[rucksack[i]] = true;
      if (lineCounter === 2) secondRucksackContentsMap[rucksack[i]] = true;
      if (lineCounter === 3) thirdRucksackContentsMap[rucksack[i]] = true;
    }

    if (lineCounter === 3) {
      // Check commonalities in all three rucksacks
      let commonItem, commonItemPriority;
      for (const item in firstRucksackContentsMap) {
        if (secondRucksackContentsMap[item] && thirdRucksackContentsMap[item]) {
          commonItem = item;
          commonItemPriority = priorityMap[commonItem];
          sumPriorities += commonItemPriority;
          break;
        }
      }

      // Reset line counter and rucksack maps
      lineCounter = 0;
      firstRucksackContentsMap = {};
      secondRucksackContentsMap = {};
      thirdRucksackContentsMap = {};
    }
  }

  return sumPriorities;
};

export { day3Part1, day3Part2 };
