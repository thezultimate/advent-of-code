import fs from "fs";
import { day4Part1, day4Part2 } from "./day4.js";

try {
  const input = fs.readFileSync("input.txt", "utf8");
  const inputArrString = input.split("\n");
  const resultDay4Part1 = day4Part1(inputArrString);
  const resultDay4Part2 = day4Part2(inputArrString);
  console.log(resultDay4Part1);
  console.log(resultDay4Part2);
} catch (err) {
  console.error(err);
}
