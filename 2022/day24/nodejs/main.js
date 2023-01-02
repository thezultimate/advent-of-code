import fs from "fs";
import { day24Part1, day24Part2 } from "./day24.js";

try {
  const input = fs.readFileSync("input_test.txt", "utf8");
  const inputArr = input.split("\n");
  const resultDay24Part1 = day24Part1(inputArr);
  console.log(resultDay24Part1);
  // const resultDay24Part2 = day24Part2(inputArr);
  // console.log(resultDay24Part2);
} catch (err) {
  console.error(err);
}
