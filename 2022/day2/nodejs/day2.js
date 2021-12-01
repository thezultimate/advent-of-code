const day2Part1 = (inputArr) => {
  const myMap = { X: "", Y: "", Z: "" };

  const enemyFirstChoice = inputArr[0][0];
  const myFirstChoiceUnknown = inputArr[0][1];

  let myFirstChoice;
  if (enemyFirstChoice === "A") myFirstChoice = "B";
  else if (enemyFirstChoice === "B") myFirstChoice = "C";
  else myFirstChoice = "A";
  myMap[myFirstChoiceUnknown] = myFirstChoice;

  let mySecondChoiceUnknown;
  let mySecondChoice;
  for (let i = 1; i < inputArr.length; i++) {
    mySecondChoiceUnknown = inputArr[i][1];
    if (myMap[mySecondChoiceUnknown] === "") {
      const enemySecondChoice = inputArr[i][0];
      if (enemySecondChoice === "A") mySecondChoice = "C";
      else if (enemySecondChoice === "B") mySecondChoice = "A";
      else mySecondChoice = "B";
      myMap[mySecondChoiceUnknown] = mySecondChoice;
      break;
    }
  }

  let myThirdChoice;
  if (myFirstChoice === "A" && mySecondChoice === "B") myThirdChoice = "C";
  if (myFirstChoice === "A" && mySecondChoice === "C") myThirdChoice = "B";
  if (myFirstChoice === "B" && mySecondChoice === "C") myThirdChoice = "A";
  if (myFirstChoice === "B" && mySecondChoice === "A") myThirdChoice = "C";
  if (myFirstChoice === "C" && mySecondChoice === "A") myThirdChoice = "B";
  if (myFirstChoice === "C" && mySecondChoice === "B") myThirdChoice = "A";

  if (myMap["X"] === "") myMap["X"] = myThirdChoice;
  if (myMap["Y"] === "") myMap["Y"] = myThirdChoice;
  if (myMap["Z"] === "") myMap["Z"] = myThirdChoice;

  let myTotalPoints = 0;
  for (const round of inputArr) {
    const enemyCurrentChoice = round[0];
    const myCurrentChoice = myMap[round[1]];
    const myRoundPoint = getMyRoundPoint(myCurrentChoice, enemyCurrentChoice);
    myTotalPoints += myRoundPoint;
  }

  return myTotalPoints;
};

const getMyRoundPoint = (myChoice, enemyChoice) => {
  if (myChoice === "A") {
    if (enemyChoice === "A") return 1 + 3;
    if (enemyChoice === "B") return 1 + 0;
    if (enemyChoice === "C") return 1 + 6;
  }
  if (myChoice === "B") {
    if (enemyChoice === "A") return 2 + 6;
    if (enemyChoice === "B") return 2 + 3;
    if (enemyChoice === "C") return 2 + 0;
  }
  if (myChoice === "C") {
    if (enemyChoice === "A") return 3 + 0;
    if (enemyChoice === "B") return 3 + 6;
    if (enemyChoice === "C") return 3 + 3;
  }
};

const day2Part2 = (inputArr) => {
  let myTotalPoints = 0;
  for (const round of inputArr) {
    const enemyChoice = round[0];
    const target = round[1];
    let myChoice;
    if (target === "X") {
      if (enemyChoice === "A") myChoice = "C";
      if (enemyChoice === "B") myChoice = "A";
      if (enemyChoice === "C") myChoice = "B";
    }
    if (target === "Y") {
      if (enemyChoice === "A") myChoice = "A";
      if (enemyChoice === "B") myChoice = "B";
      if (enemyChoice === "C") myChoice = "C";
    }
    if (target === "Z") {
      if (enemyChoice === "A") myChoice = "B";
      if (enemyChoice === "B") myChoice = "C";
      if (enemyChoice === "C") myChoice = "A";
    }
    const myRoundPoint = getMyRoundPoint(myChoice, enemyChoice);
    myTotalPoints += myRoundPoint;
  }

  return myTotalPoints;
};

export { day2Part1, day2Part2, getMyRoundPoint };
