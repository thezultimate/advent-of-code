import assert from "assert";
import { day6Part1, day6Part2 } from "./day6.js";

describe("day 6 part 1", () => {
  it("case 1", () => {
    const input = "mjqjpqmgbljsphdztnvjfqwrcgsmlb";
    const result = day6Part1(input);
    assert.equal(result, 7);
  });

  it("case 2", () => {
    const input = "bvwbjplbgvbhsrlpgdmjqwftvncz";
    const result = day6Part1(input);
    assert.equal(result, 5);
  });

  it("case 3", () => {
    const input = "nppdvjthqldpwncqszvftbrmjlhg";
    const result = day6Part1(input);
    assert.equal(result, 6);
  });

  it("case 4", () => {
    const input = "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg";
    const result = day6Part1(input);
    assert.equal(result, 10);
  });

  it("case 5", () => {
    const input = "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw";
    const result = day6Part1(input);
    assert.equal(result, 11);
  });
});

describe("day 6 part 2", () => {
  it("case 1", () => {
    const input = "mjqjpqmgbljsphdztnvjfqwrcgsmlb";
    const result = day6Part2(input);
    assert.equal(result, 19);
  });

  it("case 2", () => {
    const input = "bvwbjplbgvbhsrlpgdmjqwftvncz";
    const result = day6Part2(input);
    assert.equal(result, 23);
  });

  it("case 3", () => {
    const input = "nppdvjthqldpwncqszvftbrmjlhg";
    const result = day6Part2(input);
    assert.equal(result, 23);
  });

  it("case 4", () => {
    const input = "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg";
    const result = day6Part2(input);
    assert.equal(result, 29);
  });

  it("case 5", () => {
    const input = "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw";
    const result = day6Part2(input);
    assert.equal(result, 26);
  });
});
