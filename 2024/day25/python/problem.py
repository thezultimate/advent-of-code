def problem_part1(input_list):
    lock_list = []
    key_list = []
    current_schema = []
    for line in input_list:
        if len(line) > 0:
            current_schema.append(line)
        if len(line) == 0:
            if current_schema[0][0] == "#":
                lock_list.append(current_schema)
            else:
                key_list.append(current_schema)
            current_schema = []

    match_count = 0

    for lock in lock_list:
        # print(lock)
        schema_column_length = len(lock)
        
        lock_column_length = {}
        for i, line in enumerate(lock):
            for j, char in enumerate(line):
                if char == "#":
                    if j in lock_column_length:
                        lock_column_length[j] += 1
                    else:
                        lock_column_length[j] = 0
        # print()

        for key in key_list:
            key_column_length = {}
            for i, line in enumerate(key):
                for j, char in enumerate(line):
                    if char == "#":
                        if j in key_column_length:
                            key_column_length[j] += 1
                        else:
                            key_column_length[j] = 0

            is_match = True

            for lock_column_index, lock_column_count in lock_column_length.items():
                if lock_column_count + 1 + key_column_length[lock_column_index] + 1 > schema_column_length:
                    is_match = False
                    break

            if is_match:
                match_count += 1

    return match_count


def problem_part2(input_list):
    pass


def read_file_to_list(file_path):
    with open(file_path, 'r') as file:
        lines = [line.strip() for line in file]
    return lines


def main():
    file_path = 'input.txt'
    input_list = read_file_to_list(file_path)
    
    result_part1 = problem_part1(input_list)
    print(f"Result of problem_part1: {result_part1}")

    
if __name__ == "__main__":
    main()