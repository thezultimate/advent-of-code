import fs from "fs";
import { day18Part1, day18Part2 } from "./day18.js";

// Node default stack size is not enough for filling cube with water
// Needs to increase the stack size during execution: node --stack-size=15000 main.js

try {
  const input = fs.readFileSync("input.txt", "utf8");
  const inputArr = input.split("\n");
  const resultDay18Part1 = day18Part1(inputArr);
  const resultDay18Part2 = day18Part2(inputArr);
  console.log(resultDay18Part1);
  console.log(resultDay18Part2);
} catch (err) {
  console.error(err);
}
