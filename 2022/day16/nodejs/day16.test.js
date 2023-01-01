import fs from "fs";
import assert from "assert";
import { day16Part1, day16Part2, getPermuteTwo } from "./day16.js";

describe("day 16 part 1", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const result = day16Part1(inputArr);
    assert.equal(result, 1651);
  });
});

describe("test getPermuteTwo", () => {
  it("case 1", () => {
    let valvesMap = { A: true, B: true };
    const result = getPermuteTwo(valvesMap);
    assert.equal(result.length, 2);
  });
  it("case 2", () => {
    let valvesMap = { A: true, B: true, C: true };
    const result = getPermuteTwo(valvesMap);
    assert.equal(result.length, 6);
  });
  it("case 3", () => {
    let valvesMap = { A: true, B: true, C: true, D: true };
    const result = getPermuteTwo(valvesMap);
    assert.equal(result.length, 12);
  });
});

describe("day 16 part 2", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const result = day16Part2(inputArr);
    assert.equal(result, 1707);
  });
});
