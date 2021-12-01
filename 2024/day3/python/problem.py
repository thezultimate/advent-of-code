def problem_part1(input_list):
    total_sum = 0
    mul_string = ""
    left_number = ""
    right_number = ""
    comma_exists = False
    for line in input_list:
        mul_string = ""
        left_number = ""
        right_number = ""
        comma_exists = False
        for char in line:
            if not char.isdigit() and char not in ("m", "u", "l", "(", ")", ","):
                mul_string = ""
                left_number = ""
                right_number = ""
                comma_exists = False
                continue

            if char == "m":
                if mul_string == "":
                    mul_string += char
                else:
                    mul_string = ""
                continue
            if char == "u":
                if mul_string == "m":
                    mul_string += char
                else:
                    mul_string = ""
                continue
            if char == "l":
                if mul_string == "mu":
                    mul_string += char
                else:
                    mul_string = ""
                continue
            if char == "(":
                if mul_string == "mul":
                    mul_string += char
                else:
                    mul_string = ""
                continue
            
            if mul_string == "mul(":
                if char == ")":
                    if left_number.isdigit() and right_number.isdigit():
                        total_sum += int(left_number) * int(right_number)
                    mul_string = ""
                    left_number = ""
                    right_number = ""
                    comma_exists = False
                    continue
                
                if char == ",":
                    if left_number.isdigit():
                        comma_exists = True
                    else:
                        mul_string = ""
                        left_number = ""
                        right_number = ""
                        comma_exists = False
                    continue
                    
                if char.isdigit():
                    if comma_exists:
                        # right number
                        if len(right_number) < 3:
                            right_number += char
                    else:
                        # left number
                        if len(left_number) < 3:
                            left_number += char
                else:
                    mul_string = ""
                    left_number = ""
                    right_number = ""
                    comma_exists = False
                continue
    return total_sum


def problem_part2(input_list):
    total_sum = 0
    mul_string = ""
    left_number = ""
    right_number = ""
    comma_exists = False
    do_or_dont_string = ""
    do = True
    prev_char = ""
    for line in input_list:
        mul_string = ""
        left_number = ""
        right_number = ""
        comma_exists = False
        for char in line:
            if char == "d":
                if do_or_dont_string == "" and prev_char == "":
                    do_or_dont_string += char
                    prev_char = char
                else:
                    do_or_dont_string = ""
                    prev_char = ""
            elif char == "o":
                if do_or_dont_string == "d" and prev_char == "d":
                    do_or_dont_string += char
                    prev_char = char
                else:
                    do_or_dont_string = ""
                    prev_char = ""
            elif char == "n":
                if do_or_dont_string == "do" and prev_char == "o":
                    do_or_dont_string += char
                    prev_char = char
                else:
                    do_or_dont_string = ""
                    prev_char = ""
            elif char == "'":
                if do_or_dont_string == "don" and prev_char == "n":
                    do_or_dont_string += char
                    prev_char = char
                else:
                    do_or_dont_string = ""
                    prev_char = ""
            elif char == "t":
                if do_or_dont_string == "don'" and prev_char == "'":
                    do_or_dont_string += char
                    prev_char = char
                else:
                    do_or_dont_string = ""
                    prev_char = ""
            elif char == "(":
                if do_or_dont_string == "don't" and prev_char == "t":
                    do_or_dont_string += char
                    prev_char = char
                elif do_or_dont_string == "do" and prev_char == "o":
                    do_or_dont_string += char
                    prev_char = char
                else:
                    do_or_dont_string = ""
                    prev_char = ""
            elif char == ")":
                if do_or_dont_string == "don't(" and prev_char == "(":
                    do_or_dont_string += char
                    prev_char = char
                elif do_or_dont_string == "do(" and prev_char == "(":
                    do_or_dont_string += char
                    prev_char = char
                else:
                    do_or_dont_string = ""
                    prev_char = ""
            else:
                do_or_dont_string = ""
                prev_char = ""

            if do_or_dont_string == "don't()":
                do = False
                do_or_dont_string = ""
                prev_char = ""

            if do_or_dont_string == "do()":
                do = True
                do_or_dont_string = ""
                prev_char = ""

            if not do:
                continue

            if do:
                if not char.isdigit() and char not in ("m", "u", "l", "(", ")", ","):
                    mul_string = ""
                    left_number = ""
                    right_number = ""
                    comma_exists = False
                    continue

                if char == "m":
                    if mul_string == "":
                        mul_string += char
                    else:
                        mul_string = ""
                    continue
                if char == "u":
                    if mul_string == "m":
                        mul_string += char
                    else:
                        mul_string = ""
                    continue
                if char == "l":
                    if mul_string == "mu":
                        mul_string += char
                    else:
                        mul_string = ""
                    continue
                if char == "(":
                    if mul_string == "mul":
                        mul_string += char
                    else:
                        mul_string = ""
                    continue
                
                if mul_string == "mul(":
                    if char == ")":
                        if left_number.isdigit() and right_number.isdigit():
                            total_sum += int(left_number) * int(right_number)
                        mul_string = ""
                        left_number = ""
                        right_number = ""
                        comma_exists = False
                        continue
                    
                    if char == ",":
                        if left_number.isdigit():
                            comma_exists = True
                        else:
                            mul_string = ""
                            left_number = ""
                            right_number = ""
                            comma_exists = False
                        continue
                        
                    if char.isdigit():
                        if comma_exists:
                            # right number
                            if len(right_number) < 3:
                                right_number += char
                        else:
                            # left number
                            if len(left_number) < 3:
                                left_number += char
                    else:
                        mul_string = ""
                        left_number = ""
                        right_number = ""
                        comma_exists = False
                    continue
    return total_sum


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