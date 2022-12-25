import fs from "fs";
import { day25Part1, day25Part2 } from "./day25.js";

try {
  const input = fs.readFileSync("input.txt", "utf8");
  const inputArr = input.split("\n");
  const resultDay25Part1 = day25Part1(inputArr);
  const resultDay25Part2 = day25Part2(inputArr);
  console.log(resultDay25Part1);
  console.log(resultDay25Part2);
} catch (err) {
  console.error(err);
}
