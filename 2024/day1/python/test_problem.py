import unittest
from problem import problem_part1, problem_part2

class TestProblem(unittest.TestCase):
    def test_problem_part1_test1(self):
        input_left_list = [3, 4, 2, 1, 3, 3]
        input_right_list = [4, 3, 5, 3, 9, 3]
            
        result = problem_part1(input_left_list, input_right_list)
        self.assertEqual(result, 11)

    def test_problem_part2_test1(self):
        input_left_list = [3, 4, 2, 1, 3, 3]
        input_right_list = [4, 3, 5, 3, 9, 3]
        result = problem_part2(input_left_list, input_right_list)
        self.assertEqual(result, 31)