import fs from "fs";
import { day13Part1, day13Part2 } from "./day13.js";

try {
  const input = fs.readFileSync("input.txt", "utf8");
  const inputArr = input.split("\n");
  const resultDay13Part1 = day13Part1(inputArr);
  const resultDay13Part2 = day13Part2(inputArr);
  console.log(resultDay13Part1);
  console.log(resultDay13Part2);
} catch (err) {
  console.error(err);
}
