import fs from "fs";
import assert from "assert";
import { compare, day13Part1, day13Part2 } from "./day13.js";

describe("test compare", () => {
  it("case 1", () => {
    const left = "[1,1,3,1,1]";
    const right = "[1,1,5,1,1]";
    const result = compare(JSON.parse(left), JSON.parse(right));
    assert.equal(result, true);
  });
  it("case 2", () => {
    const left = "[[1],[2,3,4]]";
    const right = "[[1],4]";
    const result = compare(JSON.parse(left), JSON.parse(right));
    assert.equal(result, true);
  });
  it("case 3", () => {
    const left = "[9]";
    const right = "[[8,7,6]]";
    const result = compare(JSON.parse(left), JSON.parse(right));
    assert.equal(result, false);
  });
  it("case 4", () => {
    const left = "[[4,4],4,4]";
    const right = "[[4,4],4,4,4]";
    const result = compare(JSON.parse(left), JSON.parse(right));
    assert.equal(result, true);
  });
  it("case 5", () => {
    const left = "[7,7,7,7]";
    const right = "[7,7,7]";
    const result = compare(JSON.parse(left), JSON.parse(right));
    assert.equal(result, false);
  });
  it("case 6", () => {
    const left = "[]";
    const right = "[3]";
    const result = compare(JSON.parse(left), JSON.parse(right));
    assert.equal(result, true);
  });
  it("case 7", () => {
    const left = "[[[]]]";
    const right = "[[]]";
    const result = compare(JSON.parse(left), JSON.parse(right));
    assert.equal(result, false);
  });
  it("case 8", () => {
    const left = "[1,[2,[3,[4,[5,6,7]]]],8,9]";
    const right = "[1,[2,[3,[4,[5,6,0]]]],8,9]";
    const result = compare(JSON.parse(left), JSON.parse(right));
    assert.equal(result, false);
  });
  it("case 9", () => {
    const left = "[[0,[3,0]],[0,7,4,10]]";
    const right = "[[[[],[],3,[2]]],[]]";
    const result = compare(JSON.parse(left), JSON.parse(right));
    assert.equal(result, false);
  });
  it("case 10", () => {
    const left = "[[],[10,1,[7,8,[10,7,0,8]],[],[0,[1,5,7,6],8,[5]]],[10]]";
    const right =
      "[[],[],[[[],9,[],9,[2]],[[10,8,1,6],[7,8],[8,2,5,6,9],[]],[],[9,6,2],[[0,4,7],[],3,8,[10,1,0,6,4]]]]";
    const result = compare(JSON.parse(left), JSON.parse(right));
    assert.equal(result, false);
  });
  it("case 11", () => {
    const left =
      "[[2,8,[4,[10],3],[],[2]],[0,[[3,0],[5,10,10]],[[10,1],[10,6,5,9,3]]],[],[],[[]]]";
    const right = "[[[10],[[],6,1,7]],[],[[[7],[3,10,8,7]]]]";
    const result = compare(JSON.parse(left), JSON.parse(right));
    assert.equal(result, true);
  });
  it("case 12", () => {
    const left = "[[],[7],[6,10,[]],[],[[[1,4,7,2],6]]]";
    const right = "[[[],4],[[6,[4,5,4,5,8]],[[3,4],9,7],6,6],[7]]";
    const result = compare(JSON.parse(left), JSON.parse(right));
    assert.equal(result, true);
  });
});

describe("day 13 part 1", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const result = day13Part1(inputArr);
    assert.equal(result, 13);
  });
});

describe("day 13 part 2", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const inputArr = input.split("\n");
    const result = day13Part2(inputArr);
    assert.equal(result, 140);
  });
});
