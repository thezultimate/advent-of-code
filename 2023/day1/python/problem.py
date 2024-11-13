def problem_part1(input_list):
    total_sum = 0
    for string in input_list:
        num_list = []
        for char in string:
            if char.isdigit():
                num_list.append(char)
        a_number_string = num_list[0] + num_list[-1]
        a_number = int(a_number_string)
        total_sum += a_number
    return total_sum


def problem_part2(input_list):
    digit_map = {
        "one": 1,
        "two": 2,
        "three": 3,
        "four": 4,
        "five": 5,
        "six": 6,
        "seven": 7,
        "eight": 8,
        "nine": 9
    }
    digit_string_list = [
        "one",
        "two",
        "three",
        "four",
        "five",
        "six",
        "seven",
        "eight",
        "nine"
    ]
    total_sum = 0
    for string in input_list:
        first_num_string = get_first_num_string(string, digit_map, digit_string_list)
        second_num_string = get_last_num_string(string, digit_map, digit_string_list)
        a_number_string = first_num_string + second_num_string
        a_number = int(a_number_string)
        total_sum += a_number

    return total_sum


def get_first_num_string(string, digit_map, digit_string_list):
    possible_number = ""
    for char in string:
        if char.isdigit():
            return char
        else:
            possible_number += char
            for digit_string in digit_string_list:
                if digit_string in possible_number:
                    return str(digit_map[digit_string])


def get_last_num_string(string, digit_map, digit_string_list):
    possible_number = ""
    for char in reversed(string):
        if char.isdigit():
            return char
        else:
            possible_number = char + possible_number
            for digit_string in digit_string_list:
                if digit_string in possible_number:
                    return str(digit_map[digit_string])
                

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