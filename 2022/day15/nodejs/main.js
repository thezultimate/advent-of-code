import fs from "fs";
import { day15Part1, day15Part2 } from "./day15.js";

try {
  const input = fs.readFileSync("input.txt", "utf8");
  const inputArr = input.split("\n");
  const resultDay15Part1 = day15Part1(inputArr, 2000000);
  console.log(resultDay15Part1);
  const resultDay15Part2 = day15Part2(inputArr, 4000000);
  console.log(resultDay15Part2);
} catch (err) {
  console.error(err);
}
