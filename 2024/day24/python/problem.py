def problem_part1(input_list):
    wires_map = {}
    rule_list = []
    z_set = set()
    z_list = []

    for line in input_list:
        if len(line) == 0:
            continue
        if ":" in line:
            line_split = line.split(": ")
            wires_map[line_split[0]] = int(line_split[1])
        if "->" in line:
            line_split = line.split(" -> ")
            output = line_split[1]
            input = line_split[0]
            gate = ""
            if "AND" in input:
                gate = "AND"
            if " XOR " in input:
                gate = "XOR"
            if " OR " in input:
                gate = "OR"
            input_split = input.split(" " + gate + " ")
            input_left = input_split[0]
            input_right = input_split[1]
            rule = (input_left, gate, input_right, output)
            rule_list.append(rule)
            if output[0] == "z":
                z_set.add(output)
                z_list.append(output)
            
    # Iterate until z_set is empty
    while len(z_set) > 0:
        for rule in rule_list:
            input_left, gate, input_right, output = rule
            if input_left in wires_map and input_right in wires_map and output not in wires_map:
                # Only proceeds if both inputs exist in wires_map and output doesn't exist in wires_map
                input_left_value = wires_map[input_left]
                input_right_value = wires_map[input_right]
                result = -1
                if gate == "AND":
                    result = input_left_value and input_right_value
                if gate == "XOR":
                    result = input_left_value ^ input_right_value
                if gate == "OR":
                    result = input_left_value or input_right_value
                wires_map[output] = result
                if output[0] == "z":
                    z_set.remove(output)

    z_list.sort(reverse=True)

    binary_string = ""
    for z in z_list:
        binary_string += str(wires_map[z])

    decimal = binary_to_decimal(binary_string)

    return decimal


def binary_to_decimal(binary_string):
    decimal = 0
    for i in range(len(binary_string)-1, -1, -1):
        j = len(binary_string)-1 - i
        char = binary_string[i]
        char_decimal = int(char) * (2 ** j)
        decimal += char_decimal

    return decimal


def decimal_to_binary(decimal):
    div = 999999999999
    binary_string = ""
    while div >= 1:
        div = decimal // 2
        mod = decimal % 2
        binary_string = str(mod) + binary_string
        decimal = div

    # print(binary_string)
    return binary_string


# TODO
def problem_part2(input_list):
    wires_map_orig = {}
    rule_set_orig = set()
    z_set_orig = set()
    z_list = []
    x_binary_string = ""
    y_binary_string = ""
    rule_backtrack_map_orig = {}
    z_not_xor_list = []
    rule_xor_not_z_list = []

    for line in input_list:
        if len(line) == 0:
            continue
        if ":" in line:
            line_split = line.split(": ")
            wires_map_orig[line_split[0]] = int(line_split[1])
            if "x" in line_split[0]:
                x_binary_string = line_split[1] + x_binary_string
            if "y" in line_split[0]:
                y_binary_string = line_split[1] + y_binary_string
        if "->" in line:
            line_split = line.split(" -> ")
            output = line_split[1]
            input = line_split[0]
            gate = ""
            if "AND" in input:
                gate = "AND"
            if " XOR " in input:
                gate = "XOR"
            if " OR " in input:
                gate = "OR"
            input_split = input.split(" " + gate + " ")
            input_left = input_split[0]
            input_right = input_split[1]
            rule = (input_left, gate, input_right, output)
            rule_set_orig.add(rule)
            rule_backtrack_map_orig[output] = (input_left, gate, input_right)
            if gate == "XOR" and output[0] != "z":
                rule_xor_not_z_list.append(rule)
            if output[0] == "z":
                z_set_orig.add(output)
                z_list.append(output)
                if gate != "XOR":
                    z_not_xor_list.append(output)

    target_sum_decimal = binary_to_decimal(x_binary_string) + binary_to_decimal(y_binary_string)
    target_sum_binary_string = decimal_to_binary(target_sum_decimal)
    # print(f"Correct result: {target_sum_decimal} or {target_sum_binary_string}")

    wires_map = wires_map_orig.copy()
    z_set = z_set_orig.copy()
    rule_set = rule_set_orig.copy()
    decimal, binary_string = get_process_result(wires_map, rule_set, z_set, z_list)
    # print(f"Process result: {decimal} or {binary_string}")

    swap_pair_list = get_swap_pair_list(target_sum_binary_string, binary_string, rule_backtrack_map_orig)
    # print(swap_pair_list)

    swap_pair_flattened = []
    for swap_pair in swap_pair_list:
        swap_pair_flattened.append(swap_pair[0])
        swap_pair_flattened.append(swap_pair[1])

    swap_pair_flattened.sort()
    result = ",".join(swap_pair_flattened)

    return result

def get_swap_pair_list(target_sum_binary_string, binary_string, rule_backtrack_map_orig):
    z_correct_map = {}
    z_incorrect_map = {}

    # Make both binary strings the same length
    if len(target_sum_binary_string) > len(binary_string):
        target_sum_binary_string = target_sum_binary_string[len(target_sum_binary_string) - len(binary_string):]
    elif len(target_sum_binary_string) < len(binary_string):
        binary_string = binary_string[len(binary_string) - len(target_sum_binary_string):]

    # Fill z_correct_map
    for i in range(len(target_sum_binary_string) - 1, -1, -1):
        char_correct = target_sum_binary_string[len(target_sum_binary_string) - 1 - i]
        number_suffix = str(i).zfill(2)
        z_correct_map["z" + number_suffix] = int(char_correct)

    # Fill z_incorrect_map
    for i in range(len(binary_string) - 1, -1, -1):
        char_incorrect = binary_string[len(binary_string) - 1 - i]
        number_suffix = str(i).zfill(2)
        z_incorrect_map["z" + number_suffix] = int(char_incorrect)

    # General rule after backtracking: zn = (xn XOR yn) XOR (a OR b)
    swap_pair_list = []
    rule_backtrack_map = rule_backtrack_map_orig.copy()
    for i in range(len(z_correct_map)):
        key = "z" + str(i).zfill(2)
        # Check if z_correct_map and z_incorrect_map elements are not the same
        if z_correct_map[key] != z_incorrect_map[key]:
            # print()
            # print(f"{key} => Correct: {z_correct_map[key]}, Incorrect: {z_incorrect_map[key]}")
            # print()

            # backtrack_result = backtrack_output(key, rule_backtrack_map)
            # print("Backtrack result:")
            # print(backtrack_result)
            # print()

            x_key = "x" + str(i).zfill(2)
            y_key = "y" + str(i).zfill(2)
            first_wire_of_main_xor = None
            for output, rule_backtrack in rule_backtrack_map.items():
                if rule_backtrack == (x_key, "XOR", y_key) or rule_backtrack == (y_key, "XOR", x_key):
                    first_wire_of_main_xor = output
                    break
            for output, rule_backtrack in rule_backtrack_map.items():
                if rule_backtrack[1] == "XOR" and (rule_backtrack[0] == first_wire_of_main_xor or rule_backtrack[2] == first_wire_of_main_xor):
                    z_should_be = output
                    if z_should_be != key:
                        swap_pair = (key, z_should_be)
                        swap_pair_list.append(swap_pair)
                        break
            
            z_rule = rule_backtrack_map[key]
            if z_rule[1] == "XOR":
                left_xor_wire = z_rule[0]
                right_xor_wire = z_rule[2]
                left_xor_wire_rule = rule_backtrack_map[left_xor_wire]
                right_xor_wire_rule = rule_backtrack_map[right_xor_wire]
                if left_xor_wire_rule[1] == "OR" and right_xor_wire_rule[1] != "XOR":
                    swap_pair_list.append((first_wire_of_main_xor, right_xor_wire))
                if right_xor_wire_rule[1] == "OR" and left_xor_wire_rule[1] != "XOR":
                    swap_pair_list.append((first_wire_of_main_xor, left_xor_wire))

    return swap_pair_list


def backtrack_output(output, rule_backtrack_map):
    # Terminating case
    if rule_backtrack_map.get(output) is None:
        return output

    input_left, gate, input_right = rule_backtrack_map[output]
    print(f"Backtrack: {input_left} {gate} {input_right} -> {output}")

    # Recursive case
    result_left = backtrack_output(input_left, rule_backtrack_map)
    result_right = backtrack_output(input_right, rule_backtrack_map)
    # result = (result_left, gate, result_right)
    result = [result_left, gate, result_right]
    # print(result)

    return result


def get_process_result(wires_map, rule_set, z_set, z_list):
    # Iterate until z_set is empty
    while len(z_set) > 0:
        for rule in rule_set:
            input_left, gate, input_right, output = rule
            if input_left in wires_map and input_right in wires_map and output not in wires_map:
                # Only proceeds if both inputs exist in wires_map and output doesn't exist in wires_map
                input_left_value = wires_map[input_left]
                input_right_value = wires_map[input_right]
                result = -1
                if gate == "AND":
                    result = input_left_value and input_right_value
                if gate == "XOR":
                    result = input_left_value ^ input_right_value
                if gate == "OR":
                    result = input_left_value or input_right_value
                wires_map[output] = result
                if output[0] == "z":
                    z_set.remove(output)

    z_list.sort(reverse=True)

    binary_string = ""
    for z in z_list:
        binary_string += str(wires_map[z])

    decimal = binary_to_decimal(binary_string)

    return (decimal, binary_string)


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