import assert from "assert";
import { day8Part1, day8Part2 } from "./day8.js";

describe("day 8 part 1", () => {
  it("case 1", () => {
    const inputArr = [
      "30373", 
      "25512", 
      "65332", 
      "33549", 
      "35390"];
    const result = day8Part1(inputArr);
    assert.equal(result, 21);
  });
});

describe("day 8 part 2", () => {
  it("case 1", () => {
    const inputArr = [
      "30373", 
      "25512", 
      "65332", 
      "33549", 
      "35390"];
    const result = day8Part2(inputArr);
    assert.equal(result, 8);
  });
});
