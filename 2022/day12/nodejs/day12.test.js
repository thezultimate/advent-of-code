import assert from "assert";
import { day12Part1, day12Part2 } from "./day12.js";
import fs from "fs";

describe("day 12 part 1", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const result = day12Part1(inputArr);
    assert.equal(result, 31);
  });
});

describe("day 12 part 2", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const result = day12Part2(inputArr);
    assert.equal(result, 29);
  });
});
