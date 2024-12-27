import unittest
from problem import problem_part1, problem_part2, get_input_length, get_input_length2

class TestProblem(unittest.TestCase):
    def test_problem_part1_test1(self):
        input_list = [
            "029A",
            "980A",
            "179A",
            "456A",
            "379A"
        ]
        result = problem_part1(input_list)
        self.assertEqual(result, 126384)

    def test_problem_part1_test2(self):
        input = "029A"
        result = get_input_length(input)
        self.assertEqual(result, 68)

    def test_problem_part1_test3(self):
        input = "980A"
        result = get_input_length(input)
        self.assertEqual(result, 60)

    def test_problem_part1_test4(self):
        input = "179A"
        result = get_input_length(input)
        self.assertEqual(result, 68)

    def test_problem_part1_test5(self):
        input = "456A"
        result = get_input_length(input)
        self.assertEqual(result, 64)

    def test_problem_part1_test6(self):
        input = "379A"
        result = get_input_length(input)
        self.assertEqual(result, 64)

    def test_problem_part2_test1(self):
        input_list = [
            "029A",
            "980A",
            "179A",
            "456A",
            "379A"
        ]
        result = problem_part2(input_list)
        self.assertEqual(result, 126384)

    def test_problem_part2_test2(self):
        input = "029A"
        result = get_input_length2(input, 2)
        self.assertEqual(result, 68)