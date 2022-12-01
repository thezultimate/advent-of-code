import assert from "assert";
import { day1Part1, day1Part2 } from "./day1.js";

describe("day 1 part 1", () => {
  it("case 1", () => {
    const inputArr = [
      1000, 2000, 3000, -1, 4000, -1, 5000, 6000, -1, 7000, 8000, 9000, -1,
      10000,
    ];
    const result = day1Part1(inputArr);
    assert.equal(result, 24000);
  });
});

describe("day 1 part 2", () => {
  it("case 1", () => {
    const inputArr = [
      1000, 2000, 3000, -1, 4000, -1, 5000, 6000, -1, 7000, 8000, 9000, -1,
      10000,
    ];
    const result = day1Part2(inputArr);
    assert.equal(result, 45000);
  });
});
