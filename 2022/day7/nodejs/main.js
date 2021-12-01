import fs from "fs";
import { day7Part1, day7Part2 } from "./day7.js";

try {
  const input = fs.readFileSync("input.txt", "utf8");
  const inputArrString = input.split("\n");
  const resultDay7Part1 = day7Part1(inputArrString);
  const resultDay7Part2 = day7Part2(inputArrString);
  console.log(resultDay7Part1);
  console.log(resultDay7Part2);
} catch (err) {
  console.error(err);
}
