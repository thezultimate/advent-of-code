import fs from "fs";
import { day11Part1, day11Part2 } from "./day11.js";

try {
  const input = fs.readFileSync("input.txt", "utf8");
  const inputArr = input.split("\n");
  const resultDay11Part1 = day11Part1(inputArr);
  const resultDay11Part2 = day11Part2(inputArr);
  console.log(resultDay11Part1);
  console.log(resultDay11Part2);
} catch (err) {
  console.error(err);
}
