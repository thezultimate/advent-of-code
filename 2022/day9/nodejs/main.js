import fs from "fs";
import { day9Part1, day9Part2 } from "./day9.js";

try {
  const input = fs.readFileSync("input.txt", "utf8");
  const inputArr = input.split("\n");
  const resultDay9Part1 = day9Part1(inputArr);
  const resultDay9Part2 = day9Part2(inputArr);
  console.log(resultDay9Part1);
  console.log(resultDay9Part2);
} catch (err) {
  console.error(err);
}
