import fs from "fs";
import assert from "assert";
import { day24Part1, day24Part2 } from "./day24.js";

describe("day 24 part 1", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const result = day24Part1(inputArr);
    assert.equal(result, 18);
  });
});

describe("day 24 part 2", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const result = day24Part2(inputArr);
    assert.equal(result, 54);
  });
});
