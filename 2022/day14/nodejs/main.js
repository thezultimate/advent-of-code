import fs from "fs";
import { day14Part1, day14Part2 } from "./day14.js";

try {
  const input = fs.readFileSync("input.txt", "utf8");
  const inputArr = input.split("\n");
  const resultDay14Part1 = day14Part1(inputArr);
  const resultDay14Part2 = day14Part2(inputArr);
  console.log(resultDay14Part1);
  console.log(resultDay14Part2);
} catch (err) {
  console.error(err);
}
