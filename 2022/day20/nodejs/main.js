import fs from "fs";
import { day20Part1, day20Part2 } from "./day20.js";

try {
  const input = fs.readFileSync("input.txt", "utf8");
  const inputArr = input.split("\n");
  const resultDay20Part1 = day20Part1(inputArr);
  console.log(resultDay20Part1);
  const resultDay20Part2 = day20Part2(inputArr);
  console.log(resultDay20Part2);
} catch (err) {
  console.error(err);
}
