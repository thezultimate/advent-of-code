def problem_part1(input_list, blink_number):
    line = input_list[0]
    line_list = line.split()
    final_length = 0
    stone_index = 1
    for line in line_list:
        line_list_copy = [line]
        counter = 1
        while counter <= blink_number:
            line_list_new = []
            for i, char in enumerate(line_list_copy):
                if char == "0":
                    line_list_new.append("1")
                elif len(char) % 2 == 0:
                    mid = len(char) // 2
                    left = char[:mid]
                    right = char[mid:]
                    line_list_new.append(str(int(left)))
                    line_list_new.append(str(int(right)))
                else:
                    mul = int(char) * 2024
                    line_list_new.append(str(mul))
            line_list_copy = line_list_new
            counter += 1
        current_length = len(line_list_copy)
        final_length += current_length
        stone_index += 1

    return final_length


def problem_part2(input_list, blink_number):
    line = input_list[0]
    line_list = line.split()
    final_length = 0
    memo = {}
    for stone in line_list:
        current_length = 0
        counter = 1
        top_level_count = count(stone, counter, blink_number, memo)
        current_length += top_level_count
        final_length += current_length
    return final_length


def count(stone, counter, blink_number, memo):
    if (stone, counter) in memo:
        return memo[(stone, counter)]

    stone_list = []
    if stone == "0":
        stone_list.append("1")
    elif len(stone) % 2 == 0:
        mid = len(stone) // 2
        left = stone[:mid]
        right = stone[mid:]
        stone_list.append(str(int(left)))
        stone_list.append(str(int(right)))
    else:
        mul = int(stone) * 2024
        stone_list.append(str(mul))

    # Terminating case
    if counter == blink_number:
        memo[(stone, counter)] = len(stone_list)
        return len(stone_list)
    
    # Recursive case
    current_length = 0
    for next_stone in stone_list:
        next_length = count(next_stone, counter + 1, blink_number, memo)
        current_length += next_length
    memo[(stone, counter)] = current_length
    return current_length


def read_file_to_list(file_path):
    with open(file_path, 'r') as file:
        lines = [line.strip() for line in file]
    return lines


def main():
    file_path = 'input.txt'
    input_list = read_file_to_list(file_path)
    
    result_part1 = problem_part1(input_list, 25)
    print(f"Result of problem_part1: {result_part1}")
    
    result_part2 = problem_part2(input_list, 75)
    print(f"Result of problem_part2: {result_part2}")


if __name__ == "__main__":
    main()