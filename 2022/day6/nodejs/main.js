import fs from "fs";
import { day6Part1, day6Part2 } from "./day6.js";

try {
  const input = fs.readFileSync("input.txt", "utf8");
  const resultDay6Part1 = day6Part1(input);
  const resultDay6Part2 = day6Part2(input);
  console.log(resultDay6Part1);
  console.log(resultDay6Part2);
} catch (err) {
  console.error(err);
}
