const day8Part1 = (inputArr) => {
  let originalGrid = [];
  for (const line of inputArr) {
    if (line.length === 0) continue;
    let lineArr = [];
    for (const char of line) lineArr.push(parseInt(char));
    originalGrid.push(lineArr);
  }

  const rowLength = originalGrid.length;
  const colLength = originalGrid[0].length;

  let visibleTrees = 2 * rowLength + (2 * colLength - 4);

  for (let i = 1; i < rowLength - 1; i++) {
    for (let j = 1; j < colLength - 1; j++) {
      let currentTree = originalGrid[i][j];

      // Check left
      let leftVisible = true;
      for (let k = j - 1; k >= 0; k--) {
        if (originalGrid[i][k] >= currentTree) {
          leftVisible = false;
          break;
        }
      }

      // Check right
      let rightVisible = true;
      for (let k = j + 1; k < rowLength; k++) {
        if (originalGrid[i][k] >= currentTree) {
          rightVisible = false;
          break;
        }
      }

      // Check down
      let downVisible = true;
      for (let k = i + 1; k < colLength; k++) {
        if (originalGrid[k][j] >= currentTree) {
          downVisible = false;
          break;
        }
      }

      // Check up
      let upVisible = true;
      for (let k = i - 1; k >= 0; k--) {
        if (originalGrid[k][j] >= currentTree) {
          upVisible = false;
          break;
        }
      }

      let currentVisibility =
        leftVisible || rightVisible || downVisible || upVisible;

      if (currentVisibility) visibleTrees++;
    }
  }

  return visibleTrees;
};

const day8Part2 = (inputArr) => {
  let originalGrid = [];
  for (const line of inputArr) {
    if (line.length === 0) continue;
    let lineArr = [];
    for (const char of line) lineArr.push(parseInt(char));
    originalGrid.push(lineArr);
  }

  const rowLength = originalGrid.length;
  const colLength = originalGrid[0].length;

  let finalScenicScore = 1;

  for (let i = 1; i < rowLength - 1; i++) {
    for (let j = 1; j < colLength - 1; j++) {
      let currentTree = originalGrid[i][j];

      // Check left
      let leftCount = 0;
      for (let k = j - 1; k >= 0; k--) {
        leftCount++;
        if (originalGrid[i][k] >= currentTree) break;
      }

      // Check right
      let rightCount = 0;
      for (let k = j + 1; k < rowLength; k++) {
        rightCount++;
        if (originalGrid[i][k] >= currentTree) break;
      }

      // Check down
      let downCount = 0;
      for (let k = i + 1; k < colLength; k++) {
        downCount++;
        if (originalGrid[k][j] >= currentTree) break;
      }

      // Check up
      let upCount = 0;
      for (let k = i - 1; k >= 0; k--) {
        upCount++;
        if (originalGrid[k][j] >= currentTree) break;
      }

      const currentScenicScore = leftCount * rightCount * downCount * upCount;
      if (finalScenicScore < currentScenicScore)
        finalScenicScore = currentScenicScore;
    }
  }

  return finalScenicScore;
};

export { day8Part1, day8Part2 };
