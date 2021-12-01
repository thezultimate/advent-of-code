import fs from "fs";
import { day16Part1, day16Part2 } from "./day16.js";

try {
  const input = fs.readFileSync("input.txt", "utf8");
  const inputArr = input.split("\n");
  const resultDay16Part1 = day16Part1(inputArr);
  console.log(resultDay16Part1);
  const resultDay16Part2 = day16Part2(inputArr);
  console.log(resultDay16Part2);
} catch (err) {
  console.error(err);
}
