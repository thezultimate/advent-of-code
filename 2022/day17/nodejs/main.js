import fs from "fs";
import { day17Part1, day17Part2 } from "./day17.js";

try {
  const input = fs.readFileSync("input.txt", "utf8");
  const resultDay17Part1 = day17Part1(input, 2022);
  console.log(resultDay17Part1);
  const resultDay17Part2 = day17Part2(input, 1000000000000);
  console.log(resultDay17Part2);
} catch (err) {
  console.error(err);
}
