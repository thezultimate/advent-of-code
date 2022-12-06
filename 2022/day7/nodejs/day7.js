// Use global list instead of object. Adding global object properties from recursive function is dangerous (sync issue)! Been there, done that, painful, never repeat in the future!
let nodeList = [];

class Node {
  constructor(name, parentNode = null, childNodes = {}, files = {}, size = 0) {
    this.name = name;
    this.parentNode = parentNode;
    this.childNodes = childNodes;
    this.files = files;
    this.size = size;
  }
}

const traverseNode = (currentNode) => {
  let sizeSum = 0;
  for (const file in currentNode.files) {
    sizeSum += currentNode.files[file];
  }
  for (const childNode in currentNode.childNodes) {
    sizeSum += traverseNode(currentNode.childNodes[childNode]);
  }
  currentNode.size = sizeSum;
  nodeList.push(sizeSum);
  return sizeSum;
};

const day7Part1 = (inputArr) => {
  const maxSize = 100000;
  nodeList = [];

  let rootNode = new Node("/");
  let currentDirectory = rootNode;

  for (const line of inputArr) {
    if (line.length === 0) continue;
    const lineSplit = line.split(" ");

    if (lineSplit.length === 3) {
      // This is a command
      const targetDirectoryName = lineSplit[2];
      if (targetDirectoryName === "/") continue;
      if (targetDirectoryName !== "..") {
        // Target directory is not ..
        currentDirectory = currentDirectory.childNodes[targetDirectoryName];
      } else {
        // Target directory is ..
        currentDirectory = currentDirectory.parentNode;
      }
    }
    if (lineSplit.length === 2) {
      // Can be a file line or dir line or ls command
      const firstEntry = parseInt(lineSplit[0]);
      if (!isNaN(firstEntry)) {
        // This is file line
        const fileName = lineSplit[1];
        currentDirectory.files[fileName] = firstEntry;
      }
      if (lineSplit[0] === "dir") {
        // This is dir line
        const dirName = lineSplit[1];
        if (!currentDirectory.childNodes[dirName]) {
          // Child node doesn't exist
          currentDirectory.childNodes[dirName] = new Node(
            dirName,
            currentDirectory
          );
        }
      }
    }
  }

  traverseNode(rootNode);

  let maxHundredThousandSum = 0;
  for (const nodeSize of nodeList) {
    if (nodeSize <= maxSize) {
      maxHundredThousandSum += nodeSize;
    }
  }

  return maxHundredThousandSum;
};

const day7Part2 = (inputArr) => {
  nodeList = [];

  let rootNode = new Node("/");
  let currentDirectory = rootNode;

  let totalSum = 0;

  for (const line of inputArr) {
    if (line.length === 0) continue;
    const lineSplit = line.split(" ");

    const aNumber = parseInt(lineSplit[0]);
    if (!isNaN(aNumber)) {
      totalSum += aNumber;
    }

    if (lineSplit.length === 3) {
      // This is a command
      const targetDirectoryName = lineSplit[2];
      if (targetDirectoryName === "/") continue;
      if (targetDirectoryName !== "..") {
        // Target directory is not ..
        currentDirectory = currentDirectory.childNodes[targetDirectoryName];
      } else {
        // Target directory is ..
        currentDirectory = currentDirectory.parentNode;
      }
    }
    if (lineSplit.length === 2) {
      // Can be a file line or dir line or ls command
      const firstEntry = parseInt(lineSplit[0]);
      if (!isNaN(firstEntry)) {
        // This is file line
        const fileName = lineSplit[1];
        currentDirectory.files[fileName] = firstEntry;
      }
      if (lineSplit[0] === "dir") {
        // This is dir line
        const dirName = lineSplit[1];
        if (!currentDirectory.childNodes[dirName]) {
          // Child node doesn't exist
          currentDirectory.childNodes[dirName] = new Node(
            dirName,
            currentDirectory
          );
        }
      }
    }
  }

  traverseNode(rootNode);

  const remainingSpace = 70000000 - totalSum;
  const requiredDeletion = 30000000 - remainingSpace;
  nodeList.sort((a, b) => a - b);
  let sizeToDelete = 0;
  for (const nodeSize of nodeList) {
    if (nodeSize >= requiredDeletion) {
      sizeToDelete = nodeSize;
      break;
    }
  }

  return sizeToDelete;
};

export { day7Part1, day7Part2 };
