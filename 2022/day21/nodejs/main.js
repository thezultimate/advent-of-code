import fs from "fs";
import { day21Part1, day21Part2 } from "./day21.js";

try {
  const input = fs.readFileSync("input.txt", "utf8");
  const inputArr = input.split("\n");
  const resultDay21Part1 = day21Part1(inputArr);
  console.log(resultDay21Part1);
  const resultDay21Part2 = day21Part2(inputArr, 3916491093500); // Manually picked starting number after brute-force debugging
  console.log(resultDay21Part2);
} catch (err) {
  console.error(err);
}
