def problem_part1(input_list):
    xmas_count = 0
    for i, line in enumerate(input_list):
        for j, char in enumerate(line):
            if char == "X":
                if is_west(i, j, input_list):
                    xmas_count += 1
                if is_south(i, j, input_list):
                    xmas_count += 1
                if is_east(i, j, input_list):
                    xmas_count += 1
                if is_north(i, j, input_list):
                    xmas_count += 1
                if is_north_west(i, j, input_list):
                    xmas_count += 1
                if is_south_west(i, j, input_list):
                    xmas_count += 1
                if is_south_east(i, j, input_list):
                    xmas_count += 1
                if is_north_east(i, j, input_list):
                    xmas_count += 1

    return xmas_count


def is_west(i, j, input_list):
    try:
        if (input_list[i][j-1] == "M" and 
            input_list[i][j-2] == "A" and 
            input_list[i][j-3] == "S" and
            j-1 >= 0 and
            j-2 >= 0 and
            j-3 >= 0):
            return True
    except IndexError:
        return False
    return False


def is_south(i, j, input_list):
    try:
        if (input_list[i+1][j] == "M" and 
            input_list[i+2][j] == "A" and 
            input_list[i+3][j] == "S"):
            return True
    except IndexError:
        return False
    return False


def is_east(i, j, input_list):
    try:
        if (input_list[i][j+1] == "M" and 
            input_list[i][j+2] == "A" and 
            input_list[i][j+3] == "S"):
            return True
    except IndexError:
        return False
    return False


def is_north(i, j, input_list):
    try:
        if (input_list[i-1][j] == "M" and 
            input_list[i-2][j] == "A" and 
            input_list[i-3][j] == "S" and
            i-1 >= 0 and
            i-2 >= 0 and
            i-3 >= 0):
            return True
    except IndexError:
        return False
    return False


def is_north_west(i, j, input_list):
    try:
        if (input_list[i-1][j-1] == "M" and 
            input_list[i-2][j-2] == "A" and 
            input_list[i-3][j-3] == "S" and
            i-1 >= 0 and
            i-2 >= 0 and
            i-3 >= 0 and
            j-1 >= 0 and
            j-2 >= 0 and
            j-3 >= 0):
            return True
    except IndexError:
        return False
    return False


def is_south_west(i, j, input_list):
    try:
        if (input_list[i+1][j-1] == "M" and 
            input_list[i+2][j-2] == "A" and 
            input_list[i+3][j-3] == "S" and
            j-1 >= 0 and
            j-2 >= 0 and
            j-3 >= 0):
            return True
    except IndexError:
        return False
    return False


def is_south_east(i, j, input_list):
    try:
        if (input_list[i+1][j+1] == "M" and 
            input_list[i+2][j+2] == "A" and 
            input_list[i+3][j+3] == "S"):
            return True
    except IndexError:
        return False
    return False


def is_north_east(i, j, input_list):
    try:
        if (input_list[i-1][j+1] == "M" and 
            input_list[i-2][j+2] == "A" and 
            input_list[i-3][j+3] == "S" and
            i-1 >= 0 and
            i-2 >= 0 and
            i-3 >= 0
            ):
            return True
    except IndexError:
        return False
    return False


def problem_part2(input_list):
    xmas_count = 0
    for i, line in enumerate(input_list):
        for j, char in enumerate(line):
            if char == "A":
                if (
                    (
                        i-1 >= 0 and
                        j-1 >= 0 and
                        i+1 < len(input_list) and
                        j+1 < len(input_list[0]) and
                        input_list[i-1][j-1] == "M" and
                        input_list[i+1][j+1] == "S"
                    ) or 
                    (
                        i-1 >= 0 and
                        j-1 >= 0 and
                        i+1 < len(input_list) and
                        j+1 < len(input_list[0]) and
                        input_list[i-1][j-1] == "S" and
                        input_list[i+1][j+1] == "M"
                    )
                ) and (
                    (
                        i-1 >= 0 and
                        j-1 >= 0 and
                        i+1 < len(input_list) and
                        j+1 < len(input_list[0]) and
                        input_list[i+1][j-1] == "M" and
                        input_list[i-1][j+1] == "S"
                    ) or 
                    (
                        i-1 >= 0 and
                        j-1 >= 0 and
                        i+1 < len(input_list) and
                        j+1 < len(input_list[0]) and
                        input_list[i+1][j-1] == "S" and
                        input_list[i-1][j+1] == "M"
                    )
                ):
                    xmas_count += 1
    return xmas_count


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