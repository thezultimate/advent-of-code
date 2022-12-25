let oreRobotCostOre,
  clayRobotCostOre,
  obsidianRobotCostOre,
  obsidianRobotCostClay,
  geodeRobotCostOre,
  geodeRobotCostObsidian;

let maxGeodeList = [];
let maxGeode = 0;

const day19Part1 = (inputArr) => {
  for (const line of inputArr) {
    if (line.length === 0) continue;

    const lineSplit = line.split(" ");
    const blueprint = parseInt(lineSplit[1].split(":")[0]);
    oreRobotCostOre = parseInt(lineSplit[6]);
    clayRobotCostOre = parseInt(lineSplit[12]);
    obsidianRobotCostOre = parseInt(lineSplit[18]);
    obsidianRobotCostClay = parseInt(lineSplit[21]);
    geodeRobotCostOre = parseInt(lineSplit[27]);
    geodeRobotCostObsidian = parseInt(lineSplit[30]);

    const ore = 0;
    const clay = 0;
    const obsidian = 0;
    const geode = 0;
    const oreRobotOwned = 1;
    const clayRobotOwned = 0;
    const obsidianRobotOwned = 0;
    const geodeRobotOwned = 0;

    const minute = 1;

    processBlueprint(
      blueprint,
      minute,
      ore,
      clay,
      obsidian,
      geode,
      oreRobotOwned,
      clayRobotOwned,
      obsidianRobotOwned,
      geodeRobotOwned
    );

    maxGeodeList.push(blueprint * maxGeode);
    maxGeode = 0;
  }

  let sum = 0;
  for (const x of maxGeodeList) {
    sum += x;
  }

  return sum;
};

const processBlueprint = (
  blueprint,
  minute,
  ore,
  clay,
  obsidian,
  geode,
  oreRobotOwned,
  clayRobotOwned,
  obsidianRobotOwned,
  geodeRobotOwned
) => {
  if (minute >= 25) {
    if (geode > maxGeode) {
      maxGeode = geode;
    }

    return;
  }

  const remainingMinutes = 25 - minute;
  let buildMinutes;

  // Do nothing path
  processBlueprint(
    blueprint,
    minute + remainingMinutes,
    ore + oreRobotOwned * remainingMinutes,
    clay + clayRobotOwned * remainingMinutes,
    obsidian + obsidianRobotOwned * remainingMinutes,
    geode + geodeRobotOwned * remainingMinutes,
    oreRobotOwned,
    clayRobotOwned,
    obsidianRobotOwned,
    geodeRobotOwned
  );

  // Build ore robot path
  if (ore >= oreRobotCostOre) {
    buildMinutes = 1;
  } else {
    buildMinutes = Math.ceil((oreRobotCostOre - ore) / oreRobotOwned);
    buildMinutes++;
  }
  if (buildMinutes <= remainingMinutes) {
    processBlueprint(
      blueprint,
      minute + buildMinutes,
      ore + oreRobotOwned * buildMinutes - oreRobotCostOre,
      clay + clayRobotOwned * buildMinutes,
      obsidian + obsidianRobotOwned * buildMinutes,
      geode + geodeRobotOwned * buildMinutes,
      oreRobotOwned + 1,
      clayRobotOwned,
      obsidianRobotOwned,
      geodeRobotOwned
    );
  }

  // Build clay robot path
  if (ore >= clayRobotCostOre) {
    buildMinutes = 1;
  } else {
    buildMinutes = Math.ceil((clayRobotCostOre - ore) / oreRobotOwned);
    buildMinutes++;
  }

  if (buildMinutes <= remainingMinutes) {
    processBlueprint(
      blueprint,
      minute + buildMinutes,
      ore + oreRobotOwned * buildMinutes - clayRobotCostOre,
      clay + clayRobotOwned * buildMinutes,
      obsidian + obsidianRobotOwned * buildMinutes,
      geode + geodeRobotOwned * buildMinutes,
      oreRobotOwned,
      clayRobotOwned + 1,
      obsidianRobotOwned,
      geodeRobotOwned
    );
  }

  // Build obsidian robot path
  if (clayRobotOwned > 0) {
    if (ore >= obsidianRobotCostOre) {
      buildMinutes = 1;
    } else {
      buildMinutes = Math.ceil((obsidianRobotCostOre - ore) / oreRobotOwned);
      buildMinutes++;
    }
    let clayBuildMinutes;
    if (clay >= obsidianRobotCostClay) {
      clayBuildMinutes = 1;
    } else {
      clayBuildMinutes = Math.ceil(
        (obsidianRobotCostClay - clay) / clayRobotOwned
      );
      clayBuildMinutes++;
    }
    if (clayBuildMinutes > buildMinutes) {
      buildMinutes = clayBuildMinutes;
    }

    if (buildMinutes <= remainingMinutes) {
      processBlueprint(
        blueprint,
        minute + buildMinutes,
        ore + oreRobotOwned * buildMinutes - obsidianRobotCostOre,
        clay + clayRobotOwned * buildMinutes - obsidianRobotCostClay,
        obsidian + obsidianRobotOwned * buildMinutes,
        geode + geodeRobotOwned * buildMinutes,
        oreRobotOwned,
        clayRobotOwned,
        obsidianRobotOwned + 1,
        geodeRobotOwned
      );
    }
  }

  // Build geode robot path
  if (obsidianRobotOwned > 0) {
    if (ore >= geodeRobotCostOre) {
      buildMinutes = 1;
    } else {
      buildMinutes = Math.ceil((geodeRobotCostOre - ore) / oreRobotOwned);
      buildMinutes++;
    }
    let obsidianBuildMinutes;
    if (obsidian >= geodeRobotCostObsidian) {
      obsidianBuildMinutes = 1;
    } else {
      obsidianBuildMinutes = Math.ceil(
        (geodeRobotCostObsidian - obsidian) / obsidianRobotOwned
      );
      obsidianBuildMinutes++;
    }
    if (obsidianBuildMinutes > buildMinutes) {
      buildMinutes = obsidianBuildMinutes;
    }

    if (buildMinutes <= remainingMinutes) {
      processBlueprint(
        blueprint,
        minute + buildMinutes,
        ore + oreRobotOwned * buildMinutes - geodeRobotCostOre,
        clay + clayRobotOwned * buildMinutes,
        obsidian + obsidianRobotOwned * buildMinutes - geodeRobotCostObsidian,
        geode + geodeRobotOwned * buildMinutes,
        oreRobotOwned,
        clayRobotOwned,
        obsidianRobotOwned,
        geodeRobotOwned + 1
      );
    }
  }

  return;
};

const day19Part2 = (inputArr) => {
  return 0;
};

export { day19Part1, day19Part2 };
