import unittest
from problem import problem_part1, problem_part2, binary_to_decimal, decimal_to_binary

class TestProblem(unittest.TestCase):
    def test_problem_part1_test1(self):
        input_list = [
            "x00: 1",
            "x01: 1",
            "x02: 1",
            "y00: 0",
            "y01: 1",
            "y02: 0",
            "",
            "x00 AND y00 -> z00",
            "x01 XOR y01 -> z01",
            "x02 OR y02 -> z02"
        ]
        result = problem_part1(input_list)
        self.assertEqual(result, 4)
    

    def test_problem_part1_test2(self):
        input_list = [
            "x00: 1",
            "x01: 0",
            "x02: 1",
            "x03: 1",
            "x04: 0",
            "y00: 1",
            "y01: 1",
            "y02: 1",
            "y03: 1",
            "y04: 1",
            "",
            "ntg XOR fgs -> mjb",
            "y02 OR x01 -> tnw",
            "kwq OR kpj -> z05",
            "x00 OR x03 -> fst",
            "tgd XOR rvg -> z01",
            "vdt OR tnw -> bfw",
            "bfw AND frj -> z10",
            "ffh OR nrd -> bqk",
            "y00 AND y03 -> djm",
            "y03 OR y00 -> psh",
            "bqk OR frj -> z08",
            "tnw OR fst -> frj",
            "gnj AND tgd -> z11",
            "bfw XOR mjb -> z00",
            "x03 OR x00 -> vdt",
            "gnj AND wpb -> z02",
            "x04 AND y00 -> kjc",
            "djm OR pbm -> qhw",
            "nrd AND vdt -> hwm",
            "kjc AND fst -> rvg",
            "y04 OR y02 -> fgs",
            "y01 AND x02 -> pbm",
            "ntg OR kjc -> kwq",
            "psh XOR fgs -> tgd",
            "qhw XOR tgd -> z09",
            "pbm OR djm -> kpj",
            "x03 XOR y03 -> ffh",
            "x00 XOR y04 -> ntg",
            "bfw OR bqk -> z06",
            "nrd XOR fgs -> wpb",
            "frj XOR qhw -> z04",
            "bqk OR frj -> z07",
            "y03 OR x01 -> nrd",
            "hwm AND bqk -> z03",
            "tgd XOR rvg -> z12",
            "tnw OR pbm -> gnj"
        ]
        result = problem_part1(input_list)
        self.assertEqual(result, 2024)

    def test_problem_part1_test3(self):
        input = "100"
        result = binary_to_decimal(input)
        self.assertEqual(result, 4)

    def test_problem_part1_test4(self):
        input = "0011111101000"
        result = binary_to_decimal(input)
        self.assertEqual(result, 2024)

    def test_problem_part1_test5(self):
        input = 13
        result = decimal_to_binary(input)
        self.assertEqual(result, "1101")

    def test_problem_part1_test6(self):
        input = 31
        result = decimal_to_binary(input)
        self.assertEqual(result, "11111")
