import fs from "fs";
import assert from "assert";
import { day25Part1, day25Part2, decToSnafu } from "./day25.js";

describe("day 25 part 1", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const result = day25Part1(inputArr);
    assert.equal(result, "2=-1=0");
  });
});

describe("decToSnafu", () => {
  it("case 1", () => {
    const result = decToSnafu(4890);
    assert.equal(result, "2=-1=0");
  });

  it("case 2", () => {
    const result = decToSnafu(2022);
    assert.equal(result, "1=11-2");
  });

  it("case 3", () => {
    const result = decToSnafu(12345);
    assert.equal(result, "1-0---0");
  });

  it("case 4", () => {
    const result = decToSnafu(314159265);
    assert.equal(result, "1121-1110-1=0");
  });
});

describe("day 25 part 2", () => {
  it("case 1", () => {
    const inputArr = [];
    const result = day25Part2(inputArr);
    assert.equal(result, 0);
  });
});
