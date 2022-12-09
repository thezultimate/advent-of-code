import assert from "assert";
import { day9Part1, day9Part2 } from "./day9.js";

describe("day 9 part 1", () => {
  it("case 1", () => {
    const inputArr = [
      "R 4", 
      "U 4", 
      "L 3", 
      "D 1", 
      "R 4", 
      "D 1", 
      "L 5", 
      "R 2"
    ];
    const result = day9Part1(inputArr);
    assert.equal(result, 13);
  });
});

describe("day 9 part 2", () => {
  it("case 1", () => {
    const inputArr = [
      "R 4", 
      "U 4", 
      "L 3", 
      "D 1", 
      "R 4", 
      "D 1", 
      "L 5", 
      "R 2"
    ];
    const result = day9Part2(inputArr);
    assert.equal(result, 1);
  });

  it("case 2", () => {
    const inputArr = [
      "R 5",
      "U 8",
      "L 8",
      "D 3",
      "R 17",
      "D 10",
      "L 25",
      "U 20"
    ];
    const result = day9Part2(inputArr);
    assert.equal(result, 36);
  });
});
