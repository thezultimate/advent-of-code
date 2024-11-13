import unittest
from problem import problem_part1, problem_part2

class TestProblem(unittest.TestCase):
    def test_problem_part1_test1(self):
        input_list = [
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet"
        ]
        result = problem_part1(input_list)
        self.assertEqual(result, 142)

    def test_problem_part2_test1(self):
        input_list = [
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen"
        ]
        result = problem_part2(input_list)
        self.assertEqual(result, 281)