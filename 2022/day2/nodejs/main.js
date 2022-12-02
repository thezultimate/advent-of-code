import fs from "fs";
import { day2Part1, day2Part2 } from "./day2.js";

try {
  const input = fs.readFileSync("input.txt", "utf8");
  const inputArrString = input.split("\n");

  let inputArr = [];
  for (const i of inputArrString) {
    if (i.length > 0) {
      const roundArr = i.split(" ");
      inputArr.push(roundArr);
    }
  }

  const resultDay2Part1 = day2Part1(inputArr);
  const resultDay2Part2 = day2Part2(inputArr);
  console.log(resultDay2Part1);
  console.log(resultDay2Part2);
} catch (err) {
  console.error(err);
}
