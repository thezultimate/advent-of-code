import unittest
from problem import problem_part1, is_safe, problem_part2

class TestProblem(unittest.TestCase):
    def test_problem_part1_test1(self):
        input_list = [
            "7 6 4 2 1",
            "1 2 7 8 9",
            "9 7 6 2 1",
            "1 3 2 4 5",
            "8 6 4 4 1",
            "1 3 6 7 9"
        ]
        result = problem_part1(input_list)
        self.assertEqual(result, 2)


    def test_problem_part2_test1(self):
        input_list = [
            "7 6 4 2 1",
            "1 2 7 8 9",
            "9 7 6 2 1",
            "1 3 2 4 5",
            "8 6 4 4 1",
            "1 3 6 7 9"
        ]
        result = problem_part2(input_list)
        self.assertEqual(result, 4)