import unittest
from problem import problem_part1, problem_part2

class TestProblem(unittest.TestCase):
    def test_problem_part1_test1(self):
        input_list = [
            "Register A: 729",
            "Register B: 0",
            "Register C: 0",
            "",
            "Program: 0,1,5,4,3,0"
        ]
        result = problem_part1(input_list)
        self.assertEqual(result, "4,6,3,5,6,3,5,2,1,0")


    def test_problem_part2_test1(self):
        input_list = [
            "Register A: 2024",
            "Register B: 0",
            "Register C: 0",
            "",
            "Program: 0,3,5,4,3,0"
        ]
        result = problem_part2(input_list)
        self.assertEqual(result, 117440)