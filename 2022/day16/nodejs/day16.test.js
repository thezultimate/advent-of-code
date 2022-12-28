import fs from "fs";
import assert from "assert";
import { day16Part1, day16Part2 } from "./day16.js";

describe("day 16 part 1", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const result = day16Part1(inputArr);
    assert.equal(result, 1651);
  });
});

describe("day 16 part 2", () => {
  it("case 1", () => {
    const inputArr = [];
    const result = day16Part2(inputArr);
    assert.equal(result, 0);
  });
});
