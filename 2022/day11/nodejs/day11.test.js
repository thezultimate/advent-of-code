import assert from "assert";
import { day11Part1, day11Part2 } from "./day11.js";
import fs from "fs";

describe("day 11 part 1", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const result = day11Part1(inputArr);
    assert.equal(result, 10605);
  });
});

describe("day 11 part 2", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const result = day11Part2(inputArr);
    assert.equal(result, 2713310158);
  });
});
