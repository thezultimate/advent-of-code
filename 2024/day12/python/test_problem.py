import unittest
from problem import problem_part1, problem_part2

class TestProblem(unittest.TestCase):
    def test_problem_part1_test1(self):
        input_list = [
            "AAAA",
            "BBCD",
            "BBCC",
            "EEEC"
        ]
        result = problem_part1(input_list)
        self.assertEqual(result, 140)

    def test_problem_part1_test2(self):
        input_list = [
            "OOOOO",
            "OXOXO",
            "OOOOO",
            "OXOXO",
            "OOOOO"
        ]
        result = problem_part1(input_list)
        self.assertEqual(result, 772)

    def test_problem_part1_test3(self):
        input_list = [
            "RRRRIICCFF",
            "RRRRIICCCF",
            "VVRRRCCFFF",
            "VVRCCCJFFF",
            "VVVVCJJCFE",
            "VVIVCCJJEE",
            "VVIIICJJEE",
            "MIIIIIJJEE",
            "MIIISIJEEE",
            "MMMISSJEEE"
        ]
        result = problem_part1(input_list)
        self.assertEqual(result, 1930)

    def test_problem_part2_test1(self):
        input_list = [
            "AAAA",
            "BBCD",
            "BBCC",
            "EEEC"
        ]
        result = problem_part2(input_list)
        self.assertEqual(result, 80)

    def test_problem_part2_test2(self):
        input_list = [
            "OOOOO",
            "OXOXO",
            "OOOOO",
            "OXOXO",
            "OOOOO"
        ]
        result = problem_part2(input_list)
        self.assertEqual(result, 436)

    def test_problem_part2_test3(self):
        input_list = [
            "EEEEE",
            "EXXXX",
            "EEEEE",
            "EXXXX",
            "EEEEE"
        ]
        result = problem_part2(input_list)
        self.assertEqual(result, 236)

    def test_problem_part2_test4(self):
        input_list = [
            "AAAAAA",
            "AAABBA",
            "AAABBA",
            "ABBAAA",
            "ABBAAA",
            "AAAAAA"
        ]
        result = problem_part2(input_list)
        self.assertEqual(result, 368)

    def test_problem_part2_test5(self):
        input_list = [
            "RRRRIICCFF",
            "RRRRIICCCF",
            "VVRRRCCFFF",
            "VVRCCCJFFF",
            "VVVVCJJCFE",
            "VVIVCCJJEE",
            "VVIIICJJEE",
            "MIIIIIJJEE",
            "MIIISIJEEE",
            "MMMISSJEEE"
        ]
        result = problem_part2(input_list)
        self.assertEqual(result, 1206)