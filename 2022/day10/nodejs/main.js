import fs from "fs";
import { day10Part1, day10Part2 } from "./day10.js";

try {
  const input = fs.readFileSync("input.txt", "utf8");
  const inputArr = input.split("\n");
  const resultDay10Part1 = day10Part1(inputArr);
  console.log(resultDay10Part1);
  const resultDay10Part2 = day10Part2(inputArr);
} catch (err) {
  console.error(err);
}
