import unittest
from problem import problem_part1, problem_part2

class TestProblem(unittest.TestCase):
    def test_problem_part1_test1(self):
        input_list = [
            "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))"
        ]
        result = problem_part1(input_list)
        self.assertEqual(result, 161)


    def test_problem_part2_test1(self):
        input_list = [
            "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"
        ]
        result = problem_part2(input_list)
        self.assertEqual(result, 48)