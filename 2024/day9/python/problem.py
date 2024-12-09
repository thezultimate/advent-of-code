def problem_part1(input_list):
    input = input_list[0]
    dot_notation_list = []
    final_length = 0
    for i, char in enumerate(input):
        if i % 2 == 0:
            final_length += int(char)
    for i, char in enumerate(input):
        for j in range(int(char)):
            if i % 2 == 0:
                dot_notation_list.append(str(i // 2))
            else:
                dot_notation_list.append(".")

    dot_notation_list_length = len(dot_notation_list)

    right_index = dot_notation_list_length - 1

    final_list = []

    for i, char in enumerate(dot_notation_list):
        if i == final_length:
            break
        if char != ".":
            final_list.append(int(char))
        if char == ".":
            while dot_notation_list[right_index] == ".":
                right_index -= 1
            final_list.append(int(dot_notation_list[right_index]))
            right_index -= 1

    checksum = 0
    for i, char in enumerate(final_list):
        checksum += i * char

    return checksum


def problem_part2(input_list):
    input = input_list[0]
    dot_notation_list = []
    final_length = 0
    for i, char in enumerate(input):
        if i % 2 == 0:
            final_length += int(char)
    for i, char in enumerate(input):
        for j in range(int(char)):
            if i % 2 == 0:
                dot_notation_list.append(str(i // 2))
            else:
                dot_notation_list.append(".")

    dot_notation_list_length = len(dot_notation_list)

    moved_ids = set()

    prev_id = dot_notation_list[-1]
    prev_id_count = 1

    for i in range(dot_notation_list_length - 2, -1, -1):
        current_id = dot_notation_list[i]
        if current_id == prev_id:
            prev_id_count += 1
            continue
        else:
            file = ""
            for j in range(prev_id_count):
                file += prev_id
            if prev_id != ".":
                # print(file)
                if prev_id not in moved_ids:
                    move_to_front(dot_notation_list, i, prev_id_count, prev_id, moved_ids)
            prev_id = current_id
            prev_id_count = 1

    checksum = 0
    for i, char in enumerate(dot_notation_list):
        if char != ".":
            checksum += i * int(char)
            
    return checksum


def move_to_front(dot_notation_list, start_index, prev_id_count, prev_id, moved_ids):
    for i in range(start_index + 1):
        if dot_notation_list[i] == ".":
            dot_count = 1
            j = i + 1
            while j <= start_index and dot_notation_list[j] == ".":
                dot_count += 1
                j += 1
            if dot_count >= prev_id_count:
                for k in range(prev_id_count):
                    dot_notation_list[i + k] = prev_id
                for k in range(prev_id_count):
                    dot_notation_list[start_index + k + 1] = "."
                moved_ids.add(prev_id)
                break


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