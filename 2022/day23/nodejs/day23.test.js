import fs from "fs";
import assert from "assert";
import { day23Part1, day23Part2 } from "./day23.js";

describe("day 23 part 1", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const result = day23Part1(inputArr);
    assert.equal(result, 110);
  });
});

describe("day 23 part 2", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const result = day23Part2(inputArr);
    assert.equal(result, 20);
  });
});
