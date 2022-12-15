import fs from "fs";
import assert from "assert";
import { day15Part1, day15Part2 } from "./day15.js";

describe("day 15 part 1", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const result = day15Part1(inputArr, 10);
    assert.equal(result, 26);
  });
});

describe("day 15 part 2", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const result = day15Part2(inputArr, 20);
    assert.equal(result, 56000011);
  });
});
