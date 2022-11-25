import assert from "assert";
import { day1Part1, day1Part2 } from "./day1.js";

describe("day 1 part 1", () => {
  it("case 1", () => {
    const inputArr = [199, 200, 208, 210, 200, 207, 240, 269, 260, 263];
    const result = day1Part1(inputArr);
    assert.equal(result, 7);
  });
});

describe("day 1 part 2", () => {
  it("case 1", () => {
    const inputArr = [199, 200, 208, 210, 200, 207, 240, 269, 260, 263];
    const result = day1Part2(inputArr);
    assert.equal(result, 5);
  });
});
