import fs from "fs";
import { day19Part1, day19Part2 } from "./day19.js";

try {
  const input = fs.readFileSync("input.txt", "utf8");
  const inputArr = input.split("\n");
  const resultDay19Part1 = day19Part1(inputArr);
  console.log(resultDay19Part1);
  const resultDay19Part2 = day19Part2(inputArr);
  console.log(resultDay19Part2);
} catch (err) {
  console.error(err);
}
