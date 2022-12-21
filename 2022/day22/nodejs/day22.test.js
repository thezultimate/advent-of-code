import fs from "fs";
import assert from "assert";
import { day22Part1, day22Part2 } from "./day22.js";

describe("day 22 part 1", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const inputPath = fs.readFileSync("input-path_test.txt", "utf8");
    const inputPathArr = inputPath.split("\n");
    const result = day22Part1(inputArr, inputPathArr);
    assert.equal(result, 6032);
  });
});

describe("day 22 part 2", () => {
  it("case 1", () => {
    const inputArr = [];
    const result = day22Part2(inputArr);
    assert.equal(result, 0);
  });
});
