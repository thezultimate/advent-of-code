def problem_part1(input_list):
    value_sum = 0
    for line in input_list:
        line_split = line.strip().split(": ")
        test_value = int(line_split[0])
        test_numbers = [int(x) for x in line_split[1].split()]
        if can_numbers_yield_value(test_value, test_numbers[1:], test_numbers[0], ["+", "*"]):
            value_sum += test_value

    return value_sum


def can_numbers_yield_value(test_value, test_numbers, temp_result, operators):
    # Terminating case:
    if len(test_numbers) == 0:
        return temp_result == test_value
    
    # Recursive case:
    for operator in operators:
        if operator == "+":
            new_temp_result = temp_result + test_numbers[0]
        elif operator == "*":
            new_temp_result = temp_result * test_numbers[0]
        elif operator == "||":
            new_temp_result = int(str(temp_result) + str(test_numbers[0]))
        if can_numbers_yield_value(test_value, test_numbers[1:], new_temp_result, operators):
            return True


def problem_part2(input_list):
    value_sum = 0
    for line in input_list:
        line_split = line.strip().split(": ")
        test_value = int(line_split[0])
        test_numbers = [int(x) for x in line_split[1].split()]
        if can_numbers_yield_value(test_value, test_numbers[1:], test_numbers[0], ["+", "*", "||"]):
            value_sum += test_value

    return value_sum


def read_file_to_list(file_path):
    with open(file_path, 'r') as file:
        lines = [line.strip() for line in file]
    return lines


def main():
    file_path = 'input.txt'
    input_list = read_file_to_list(file_path)
    
    result_part1 = problem_part1(input_list)
    print(f"Result of problem_part1: {result_part1}")
    
    result_part2 = problem_part2(input_list)
    print(f"Result of problem_part2: {result_part2}")


if __name__ == "__main__":
    main()