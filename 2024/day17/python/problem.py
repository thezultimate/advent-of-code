from time import sleep


def problem_part1(input_list):
    register_a = -1
    register_b = -1
    register_c = -1
    program = []
    for line in input_list:
        if "Register A" in line:
            register_a = int(line.split(": ")[1])
        if "Register B" in line:
            register_b = int(line.split(": ")[1])
        if "Register C" in line:
            register_c = int(line.split(": ")[1])
        if "Program" in line:
            program = [int(x) for x in line.split(": ")[1].split(",")]

    output_list = []
    i = 0
    while i < len(program)-1:
        opcode = program[i]
        operand = program[i+1]

        if opcode == 0:
            numerator = register_a
            denominator = get_combo_operand_value(operand, register_a, register_b, register_c)
            register_a = int(numerator / (2 ** denominator))
            i += 2

        if opcode == 1:
            register_b = register_b ^ operand
            i += 2

        if opcode == 2:
            combo = get_combo_operand_value(operand, register_a, register_b, register_c)
            register_b = combo % 8
            i += 2

        if opcode == 3:
            if register_a == 0:
                i += 2
            else:
                i = operand

        if opcode == 4:
            register_b = register_b ^ register_c
            i += 2

        if opcode == 5:
            combo = get_combo_operand_value(operand, register_a, register_b, register_c)
            output = combo % 8
            output_list.append(output)
            i += 2

        if opcode == 6:
            numerator = register_a
            denominator = get_combo_operand_value(operand, register_a, register_b, register_c)
            register_b = int(numerator / (2 ** denominator))
            i += 2

        if opcode == 7:
            numerator = register_a
            denominator = get_combo_operand_value(operand, register_a, register_b, register_c)
            register_c = int(numerator / (2 ** denominator))
            i += 2

    result = ",".join([str(x) for x in output_list])
    return result


def get_combo_operand_value(operand, register_a, register_b, register_c):
    if operand == 0:
        return 0
    if operand == 1:
        return 1
    if operand == 2:
        return 2
    if operand == 3:
        return 3
    if operand == 4:
        return register_a
    if operand == 5:
        return register_b
    if operand == 6:
        return register_c


def problem_part2(input_list):
    register_a = -1
    register_b = -1
    register_c = -1
    program = []
    for line in input_list:
        if "Register A" in line:
            register_a = int(line.split(": ")[1])
        if "Register B" in line:
            register_b = int(line.split(": ")[1])
        if "Register C" in line:
            register_c = int(line.split(": ")[1])
        if "Program" in line:
            program = [int(x) for x in line.split(": ")[1].split(",")]

    start_counter = 0
    end_counter = 2000
    column_map = {}
    first_change_length = -1
    prev_output_list_length = 1
    for i in range(start_counter, end_counter):
        output_list = run_program(i, register_b, register_c, program, column_map)
        if len(output_list) != prev_output_list_length:
            prev_output_list_length = len(output_list)
            if first_change_length == -1:
                first_change_length = i
                # print(f"First change length: {i}, {output_list}")

    first_column = column_map[0]
    first_ten_chars = first_column[:10]
    next_occurrence_index = first_column.find(first_ten_chars, 1)

    # start_counter = (6 * first_occurrence_last_digit_index) \
    #     + first_change_length ** (len(program)-2) \
    #     + first_change_length ** (len(program)-3) \
    #     + first_change_length ** (len(program)-4) \
    #     + first_change_length ** (len(program)-5) \
    #     + (2 * first_change_length ** (len(program)-6)) \
    #     + (8 * first_change_length ** (len(program)-7)) - 1
    # ...

    # Get the counter right
    counter_stack = []
    current_digit = len(program)-1
    start_counter = 0
    start_range = 1
    counter_stack.append((start_counter, current_digit, start_range))
    output_list_longer = False
    output_list = []
    final_counter = 0
    while len(counter_stack) > 0:
        current_counter, current_digit, current_start_range = counter_stack.pop()
        # Check from previous run if current_digit of output_list is equal to program
        if len(output_list) == len(program) and output_list[current_digit] == program[current_digit]: # Output index value equals to program index value
            if current_digit == 0:
                final_counter = current_counter
                output_list_longer = True
                break
            counter_stack.append((current_counter, current_digit, current_start_range))
            counter_stack.append((current_counter, current_digit-1, 1))
            # print(f"Equals at index {current_digit} before iterating, push next digit: {current_digit-1}")
            continue
        for i in range(current_start_range, next_occurrence_index):
            addition = first_change_length ** current_digit
            current_counter += addition
            output_list = run_program(current_counter, register_b, register_c, program, column_map)
            if len(output_list) > len(program):
                # print(f"Output list is longer than program: {current_counter}, {output_list}")
                break
            # print(f"{current_counter}, {output_list}")
            # Check all previous digits are equal
            last_index_different = current_digit
            for j in range(current_digit+1, len(program)):
                if output_list[j] != program[j]:
                    last_index_different = j
            if last_index_different != current_digit:
                # Something has changed in previous indices
                pop_times = last_index_different - current_digit - 1
                for j in range(0, pop_times):
                    counter_stack.pop()
                # print(f"Something has changed in previous indices: {last_index_different}, pop {pop_times} times")
                break
            if output_list[current_digit] == program[current_digit]: # Output index value equals to program index value
                counter_stack.append((current_counter, current_digit, i+1))
                counter_stack.append((current_counter, current_digit-1, 1))
                # print(f"Equals at index {current_digit}, push next digit: {current_digit-1}")
                if current_digit == 0:
                    final_counter = current_counter
                    output_list_longer = True
                break

        if output_list_longer:
            break
            
    return final_counter
    # return 117440


def run_program(register_a, register_b, register_c, program, column_map):
    output_list = []
    i = 0
    while i < len(program)-1:
        opcode = program[i]
        operand = program[i+1]

        if opcode == 0:
            numerator = register_a
            denominator = get_combo_operand_value(operand, register_a, register_b, register_c)
            register_a = int(numerator / (2 ** denominator))
            i += 2

        if opcode == 1:
            register_b = register_b ^ operand
            i += 2

        if opcode == 2:
            combo = get_combo_operand_value(operand, register_a, register_b, register_c)
            register_b = combo % 8
            i += 2

        if opcode == 3:
            if register_a == 0:
                i += 2
            else:
                i = operand

        if opcode == 4:
            register_b = register_b ^ register_c
            i += 2

        if opcode == 5:
            combo = get_combo_operand_value(operand, register_a, register_b, register_c)
            output = combo % 8
            output_list.append(output)
            if len(output_list)-1 in column_map:
                column_map[len(output_list)-1] += str(output)
            else:
                column_map[len(output_list)-1] = str(output)
            i += 2

        if opcode == 6:
            numerator = register_a
            denominator = get_combo_operand_value(operand, register_a, register_b, register_c)
            register_b = int(numerator / (2 ** denominator))
            i += 2

        if opcode == 7:
            numerator = register_a
            denominator = get_combo_operand_value(operand, register_a, register_b, register_c)
            register_c = int(numerator / (2 ** denominator))
            i += 2

    # result = ",".join([str(x) for x in output_list])
    # return result
    return output_list


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