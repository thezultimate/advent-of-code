import fs from "fs";
import { day22Part1, day22Part2 } from "./day22.js";

try {
  const input = fs.readFileSync("input.txt", "utf8");
  const inputArr = input.split("\n");
  const inputPath = fs.readFileSync("input-path.txt", "utf8");
  const inputPathArr = inputPath.split("\n");
  const resultDay22Part1 = day22Part1(inputArr, inputPathArr);
  const resultDay22Part2 = day22Part2(inputArr);
  console.log(resultDay22Part1);
  console.log(resultDay22Part2);
} catch (err) {
  console.error(err);
}
