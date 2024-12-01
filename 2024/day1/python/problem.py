def problem_part1(input_left_list, input_right_list):
    total_sum = 0
    left_list_sorted = sorted(input_left_list)
    right_list_sorted = sorted(input_right_list)
    for i in range(len(left_list_sorted)):
        total_sum += abs(left_list_sorted[i] - right_list_sorted[i])
    return total_sum


def problem_part2(input_left_list, input_right_list):
    similarity_score = 0
    similarity_occurrences_map = {}
    for left_number in input_left_list:
        if left_number in similarity_occurrences_map:
            similarity_score += left_number * similarity_occurrences_map[left_number]
        right_occurrences = 0
        for right_number in input_right_list:
            if left_number == right_number:
                right_occurrences += 1
        similarity_occurrences_map[left_number] = right_occurrences
    for key, value in similarity_occurrences_map.items():
        similarity_score += key * value
    return similarity_score


def read_file_to_list(file_path):
    with open(file_path, 'r') as file:
        lines = [line.strip() for line in file]
    left_list = []
    right_list = []
    for line in lines:
        split_line = line.split()
        left_list.append(int(split_line[0]))
        right_list.append(int(split_line[1]))
    return (left_list, right_list)


def main():
    file_path = 'input.txt'
    left_list, right_list = read_file_to_list(file_path)
    
    result_part1 = problem_part1(left_list, right_list)
    print(f"Result of problem_part1: {result_part1}")
    
    result_part2 = problem_part2(left_list, right_list)
    print(f"Result of problem_part2: {result_part2}")


if __name__ == "__main__":
    main()