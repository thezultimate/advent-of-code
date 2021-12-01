import unittest
from problem import problem_part1, problem_part2

class TestProblem(unittest.TestCase):
    def test_problem_part1_test1(self):
        input_list = [
            "0 1 10 99 999"
        ]
        result = problem_part1(input_list, 1)
        self.assertEqual(result, 7)

    def test_problem_part1_test2(self):
        input_list = [
            "125 17"
        ]
        result = problem_part1(input_list, 6)
        self.assertEqual(result, 22)

    def test_problem_part1_test3(self):
        input_list = [
            "125 17"
        ]
        result = problem_part1(input_list, 25)
        self.assertEqual(result, 55312)

    def test_problem_part2_test1(self):
        input_list = [
            "0 1 10 99 999"
        ]
        result = problem_part2(input_list, 1)
        self.assertEqual(result, 7)

    def test_problem_part2_test2(self):
        input_list = [
            "125 17"
        ]
        result = problem_part2(input_list, 6)
        self.assertEqual(result, 22)

    def test_problem_part2_test3(self):
        input_list = [
            "125 17"
        ]
        result = problem_part2(input_list, 25)
        self.assertEqual(result, 55312)