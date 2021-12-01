import fs from "fs";
import assert from "assert";
import { day18Part1, day18Part2 } from "./day18.js";

describe("day 18 part 1", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const result = day18Part1(inputArr);
    assert.equal(result, 64);
  });
});

describe("day 18 part 2", () => {
  it("case 1", () => {
    // Maximum call stack size exceeded. No idea how to increase stack size of Mocha.
    // Works fine directly using node: node --stack-size=15000 main.js
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const result = day18Part2(inputArr);
    assert.equal(result, 58);
  });
});
