import fs from "fs";
import assert from "assert";
import { day14Part1, day14Part2 } from "./day14.js";

describe("day 14 part 1", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const result = day14Part1(inputArr);
    assert.equal(result, 24);
  });
});

describe("day 14 part 2", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const result = day14Part2(inputArr);
    assert.equal(result, 93);
  });
});
