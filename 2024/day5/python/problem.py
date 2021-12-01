def problem_part1(input_list):
    left_to_right_map = {}
    right_to_left_map = {}
    updates_list = []
    for line in input_list:
        if "|" in line:
            line_split = line.split("|")
            left = line_split[0]
            right = line_split[1]
            if left not in left_to_right_map:
                left_to_right_map[left] = {right}
            else:
                left_to_right_map[left].add(right)
            if right not in right_to_left_map:
                right_to_left_map[right] = {left}
            else:
                right_to_left_map[right].add(left)
        if "," in line:
            current_update = line.split(",")
            updates_list.append(current_update)

    correct_updates_list = []

    for update in updates_list:
        is_page_in_order = True
        for i in range(len(update) - 1):
            for j in range(i + 1, len(update)):
                if update[j] in left_to_right_map and update[i] in left_to_right_map[update[j]]:
                    is_page_in_order = False
                    break
                if update[i] in right_to_left_map and update[j] in right_to_left_map[update[i]]:
                    is_page_in_order = False
                    break
            if not is_page_in_order:
                break
        if is_page_in_order:
            correct_updates_list.append(update)

    total_mid_sum = 0

    for correct_update in correct_updates_list:
        current_mid_index = len(correct_update) // 2
        total_mid_sum += int(correct_update[current_mid_index])
    
    return total_mid_sum


def problem_part2(input_list):
    left_to_right_map = {}
    right_to_left_map = {}
    updates_list = []
    for line in input_list:
        if "|" in line:
            line_split = line.split("|")
            left = line_split[0]
            right = line_split[1]
            if left not in left_to_right_map:
                left_to_right_map[left] = {right}
            else:
                left_to_right_map[left].add(right)
            if right not in right_to_left_map:
                right_to_left_map[right] = {left}
            else:
                right_to_left_map[right].add(left)
        if "," in line:
            current_update = line.split(",")
            updates_list.append(current_update)

    incorrect_updates_list = []

    for update in updates_list:
        is_page_in_order = True
        for i in range(len(update) - 1):
            for j in range(i + 1, len(update)):
                if update[j] in left_to_right_map and update[i] in left_to_right_map[update[j]]:
                    is_page_in_order = False
                    break
                if update[i] in right_to_left_map and update[j] in right_to_left_map[update[i]]:
                    is_page_in_order = False
                    break
            if not is_page_in_order:
                break
        if not is_page_in_order:
            incorrect_updates_list.append(update)

    corrected_updates_list = []

    for incorrect_update in incorrect_updates_list:
        for i in range(len(incorrect_update) - 1):
            for j in range(i + 1, len(incorrect_update)):
                if incorrect_update[j] in left_to_right_map and incorrect_update[i] in left_to_right_map[incorrect_update[j]]:
                    # swap element at indices i and j
                    incorrect_update[i], incorrect_update[j] = incorrect_update[j], incorrect_update[i]
        corrected_updates_list.append(incorrect_update)

    total_mid_sum = 0

    for correct_update in corrected_updates_list:
        current_mid_index = len(correct_update) // 2
        total_mid_sum += int(correct_update[current_mid_index])

    return total_mid_sum


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