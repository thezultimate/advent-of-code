import assert from "assert";
import { day2Part1, day2Part2, getMyRoundPoint } from "./day2.js";

describe("test getMyRoundPoint", () => {
  it("case 1", () => {
    const point = getMyRoundPoint("A", "A");
    assert.equal(point, 4);
  });

  it("case 2", () => {
    const point = getMyRoundPoint("A", "B");
    assert.equal(point, 1);
  });

  it("case 3", () => {
    const point = getMyRoundPoint("A", "C");
    assert.equal(point, 7);
  });

  it("case 4", () => {
    const point = getMyRoundPoint("B", "A");
    assert.equal(point, 8);
  });

  it("case 5", () => {
    const point = getMyRoundPoint("B", "B");
    assert.equal(point, 5);
  });

  it("case 6", () => {
    const point = getMyRoundPoint("B", "C");
    assert.equal(point, 2);
  });

  it("case 7", () => {
    const point = getMyRoundPoint("C", "A");
    assert.equal(point, 3);
  });

  it("case 8", () => {
    const point = getMyRoundPoint("C", "B");
    assert.equal(point, 9);
  });

  it("case 9", () => {
    const point = getMyRoundPoint("C", "C");
    assert.equal(point, 6);
  });
});

describe("day 2 part 1", () => {
  it("case 1", () => {
    const inputArr = [
      ["A", "Y"],
      ["B", "X"],
      ["C", "Z"],
    ];
    const result = day2Part1(inputArr);
    assert.equal(result, 15);
  });
});

describe("day 2 part 2", () => {
  it("case 1", () => {
    const inputArr = [
      ["A", "Y"],
      ["B", "X"],
      ["C", "Z"],
    ];
    const result = day2Part2(inputArr);
    assert.equal(result, 12);
  });
});
