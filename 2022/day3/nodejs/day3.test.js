import assert from "assert";
import { day3Part1, day3Part2 } from "./day3.js";

describe("day 3 part 1", () => {
  it("case 1", () => {
    const inputArr = [
      "vJrwpWtwJgWrhcsFMMfFFhFp",
      "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
      "PmmdzqPrVvPwwTWBwg",
      "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
      "ttgJtRGJQctTZtZT",
      "CrZsJsPPZsGzwwsLwLmpwMDw",
    ];
    const result = day3Part1(inputArr);
    assert.equal(result, 157);
  });
});

describe("day 3 part 2", () => {
  it("case 1", () => {
    const inputArr = [
      "vJrwpWtwJgWrhcsFMMfFFhFp",
      "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
      "PmmdzqPrVvPwwTWBwg",
      "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
      "ttgJtRGJQctTZtZT",
      "CrZsJsPPZsGzwwsLwLmpwMDw",
    ];
    const result = day3Part2(inputArr);
    assert.equal(result, 70);
  });
});
