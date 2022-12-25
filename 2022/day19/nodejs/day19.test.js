import fs from "fs";
import assert from "assert";
import { day19Part1, day19Part2 } from "./day19.js";

describe("day 19 part 1", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const result = day19Part1(inputArr);
    assert.equal(result, 33);
  });
});

describe("day 19 part 2", () => {
  it("case 1", () => {
    const inputArr = [];
    const result = day19Part2(inputArr);
    assert.equal(result, 0);
  });
});
