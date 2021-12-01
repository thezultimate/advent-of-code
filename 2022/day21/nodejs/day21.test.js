import fs from "fs";
import assert from "assert";
import { day21Part1, day21Part2 } from "./day21.js";

describe("day 21 part 1", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const result = day21Part1(inputArr);
    assert.equal(result, 152);
  });
});

describe("day 21 part 2", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const result = day21Part2(inputArr, 0);
    assert.equal(result, 301);
  });
});
