import assert from "assert";
import { day5Part1, day5Part2 } from "./day5.js";

describe("day 5 part 1", () => {
  it("case 1", () => {
    const initialStack = {
      1: ["Z", "N"],
      2: ["M", "C", "D"],
      3: ["P"],
    };
    const inputArr = [
      "move 1 from 2 to 1",
      "move 3 from 1 to 3",
      "move 2 from 2 to 1",
      "move 1 from 1 to 2",
    ];
    const result = day5Part1(initialStack, inputArr);
    assert.equal(result, "CMZ");
  });
});

describe("day 5 part 2", () => {
  it("case 1", () => {
    const initialStack = {
      1: ["Z", "N"],
      2: ["M", "C", "D"],
      3: ["P"],
    };
    const inputArr = [
      "move 1 from 2 to 1",
      "move 3 from 1 to 3",
      "move 2 from 2 to 1",
      "move 1 from 1 to 2",
    ];
    const result = day5Part2(initialStack, inputArr);
    assert.equal(result, "MCD");
  });
});
