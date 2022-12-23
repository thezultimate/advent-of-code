import fs from "fs";
import { day23Part1, day23Part2 } from "./day23.js";

try {
  const input = fs.readFileSync("input.txt", "utf8");
  const inputArr = input.split("\n");
  const resultDay23Part1 = day23Part1(inputArr);
  console.log(resultDay23Part1);
  const resultDay23Part2 = day23Part2(inputArr);
  console.log(resultDay23Part2);
} catch (err) {
  console.error(err);
}
