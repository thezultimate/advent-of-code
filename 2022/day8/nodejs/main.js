import fs from "fs";
import { day8Part1, day8Part2 } from "./day8.js";

try {
  const input = fs.readFileSync("input.txt", "utf8");
  const inputArrString = input.split("\n");
  const resultDay8Part1 = day8Part1(inputArrString);
  const resultDay8Part2 = day8Part2(inputArrString);
  console.log(resultDay8Part1);
  console.log(resultDay8Part2);
} catch (err) {
  console.error(err);
}
