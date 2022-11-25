import fs from "fs";
import { day1Part1, day1Part2 } from "./day1.js";

try {
  const input = fs.readFileSync("input.txt", "utf8");
  const inputArrString = input.split("\n");
  const inputArr = inputArrString.map((x) => parseInt(x));

  const resultDay1Part1 = day1Part1(inputArr);
  const resultDay1Part2 = day1Part2(inputArr);
  console.log(resultDay1Part1);
  console.log(resultDay1Part2);
} catch (err) {
  console.error(err);
}
