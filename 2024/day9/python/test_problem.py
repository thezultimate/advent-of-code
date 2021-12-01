import unittest
from problem import problem_part1, problem_part2

class TestProblem(unittest.TestCase):
    def test_problem_part1_test1(self):
        input_list = [
            "12345"
        ]
        result = problem_part1(input_list)
        self.assertEqual(result, 60)


    def test_problem_part1_test2(self):
        input_list = [
            "2333133121414131402"
        ]
        result = problem_part1(input_list)
        self.assertEqual(result, 1928)


    def test_problem_part2_test1(self):
        input_list = [
            "2333133121414131402"
        ]
        result = problem_part2(input_list)
        self.assertEqual(result, 2858)