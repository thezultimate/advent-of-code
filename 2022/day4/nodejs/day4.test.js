import assert from "assert";
import { day4Part1, day4Part2 } from "./day4.js";

describe("day 4 part 1", () => {
  it("case 1", () => {
    const inputArr = [
      "2-4,6-8",
      "2-3,4-5",
      "5-7,7-9",
      "2-8,3-7",
      "6-6,4-6",
      "2-6,4-8",
    ];
    const result = day4Part1(inputArr);
    assert.equal(result, 2);
  });
});

describe("day 4 part 2", () => {
  it("case 1", () => {
    const inputArr = [
      "2-4,6-8",
      "2-3,4-5",
      "5-7,7-9",
      "2-8,3-7",
      "6-6,4-6",
      "2-6,4-8",
    ];
    const result = day4Part2(inputArr);
    assert.equal(result, 4);
  });
});
