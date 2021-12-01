import fs from "fs";
import { day12Part1, day12Part2 } from "./day12.js";

try {
  const input = fs.readFileSync("input.txt", "utf8");
  const inputArr = input.split("\n");
  const resultDay12Part1 = day12Part1(inputArr);
  console.log(resultDay12Part1);
  const resultDay12Part2 = day12Part2(inputArr);
  console.log(resultDay12Part2);
} catch (err) {
  console.error(err);
}
