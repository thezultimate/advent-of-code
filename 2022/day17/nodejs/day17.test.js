import fs from "fs";
import assert from "assert";
import { day17Part1, day17Part2 } from "./day17.js";

describe("day 17 part 1", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const result = day17Part1(input, 2022);
    assert.equal(result, 3068);
  });
});

describe("day 17 part 2", () => {
  it("case 1", () => {
    const input = fs.readFileSync("input_test.txt", "utf8");
    const result = day17Part2(input, 1000000000000);
    assert.equal(result, 1514285714288);
  });
});
