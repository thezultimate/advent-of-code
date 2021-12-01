import unittest
from problem import problem_part1, problem_part2, get_nth_secret_number, get_nth_secret_number2

class TestProblem(unittest.TestCase):
    def test_problem_part1_test1(self):
        input_list = [
            "1",
            "10",
            "100",
            "2024"
        ]
        result = problem_part1(input_list)
        self.assertEqual(result, 37327623)

    def test_problem_part1_test2(self):
        input = 123
        result = get_nth_secret_number(input, 10)
        self.assertEqual(result, 5908254)

    def test_problem_part1_test3(self):
        input = 1
        result = get_nth_secret_number(input, 2000)
        self.assertEqual(result, 8685429)

    def test_problem_part1_test4(self):
        input = 10
        result = get_nth_secret_number(input, 2000)
        self.assertEqual(result, 4700978)

    def test_problem_part1_test5(self):
        input = 100
        result = get_nth_secret_number(input, 2000)
        self.assertEqual(result, 15273692)

    def test_problem_part1_test6(self):
        input = 2024
        result = get_nth_secret_number(input, 2000)
        self.assertEqual(result, 8667524)

    def test_problem_part2_test1(self):
        input_list = [
            "1",
            "2",
            "3",
            "2024"
        ]
        result = problem_part2(input_list)
        self.assertEqual(result, 23)

    def test_problem_part2_test2(self):
        input = 123
        result = get_nth_secret_number2(input, 10)
        self.assertEqual(result[1], 6)