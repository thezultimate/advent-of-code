import unittest
from problem import problem_part1, problem_part2

class TestProblem(unittest.TestCase):
    def test_problem_part1_test1(self):
        input_list = [
            "............",
            "........0...",
            ".....0......",
            ".......0....",
            "....0.......",
            "......A.....",
            "............",
            "............",
            "........A...",
            ".........A..",
            "............",
            "............"
        ]
        result = problem_part1(input_list)
        self.assertEqual(result, 14)


    def test_problem_part2_test1(self):
        input_list = [
            "T.........",
            "...T......",
            ".T........",
            "..........",
            "..........",
            "..........",
            "..........",
            "..........",
            "..........",
            ".........."
        ]
        result = problem_part2(input_list)
        self.assertEqual(result, 9)


    def test_problem_part2_test2(self):
        input_list = [
            "............",
            "........0...",
            ".....0......",
            ".......0....",
            "....0.......",
            "......A.....",
            "............",
            "............",
            "........A...",
            ".........A..",
            "............",
            "............"
        ]
        result = problem_part2(input_list)
        self.assertEqual(result, 34)