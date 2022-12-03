import fs from "fs";
import { day3Part1, day3Part2 } from "./day3.js";

try {
  const input = fs.readFileSync("input.txt", "utf8");
  const inputArrString = input.split("\n");

  const resultDay3Part1 = day3Part1(inputArrString);
  const resultDay3Part2 = day3Part2(inputArrString);
  console.log(resultDay3Part1);
  console.log(resultDay3Part2);
} catch (err) {
  console.error(err);
}
