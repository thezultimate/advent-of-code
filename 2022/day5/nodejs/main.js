import fs from "fs";
import { day5Part1, day5Part2 } from "./day5.js";

// Cheat a bit since parsing the input file is tedious
const getInitialStack = () => {
  return {
    1: ["D", "H", "N", "Q", "T", "W", "V", "B"],
    2: ["D", "W", "B"],
    3: ["T", "S", "Q", "W", "J", "C"],
    4: ["F", "J", "R", "N", "Z", "T", "P"],
    5: ["G", "P", "V", "J", "M", "S", "T"],
    6: ["B", "W", "F", "T", "N"],
    7: ["B", "L", "D", "Q", "F", "H", "V", "N"],
    8: ["H", "P", "F", "R"],
    9: ["Z", "S", "M", "B", "L", "N", "P", "H"],
  };
};

try {
  const input = fs.readFileSync("input.txt", "utf8");
  const inputArrString = input.split("\n");
  let initialStack = getInitialStack();
  const resultDay5Part1 = day5Part1(initialStack, inputArrString);
  initialStack = getInitialStack();
  const resultDay5Part2 = day5Part2(initialStack, inputArrString);
  console.log(resultDay5Part1);
  console.log(resultDay5Part2);
} catch (err) {
  console.error(err);
}
