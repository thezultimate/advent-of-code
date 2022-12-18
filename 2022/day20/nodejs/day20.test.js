import fs from "fs";
import assert from "assert";
import { day20Part1, day20Part2 } from "./day20.js";

describe("day 20 part 1", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const result = day20Part1(inputArr);
    assert.equal(result, 3);
  });
});

describe("day 20 part 2", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const result = day20Part2(inputArr);
    assert.equal(result, 1623178306);
  });
});
