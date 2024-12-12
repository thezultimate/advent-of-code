def problem_part1(input_list):
    visited_nodes = set()
    area_points_list = []
    for i, line in enumerate(input_list):
        for j, char in enumerate(line):
            if (i, j) not in visited_nodes:
                area_points = set()
                get_area_points(i, j, input_list, visited_nodes, area_points)
                area_points_list.append(area_points)

    total_cost = 0
    for area_points in area_points_list:
        total_cost += calculate_cost(area_points)

    return total_cost


def calculate_cost(area_points):
    perimeter_count = 0
    for i, j, char in area_points:
        # Left
        if (i, j - 1, char) not in area_points:
            perimeter_count += 1

        # Down
        if (i + 1, j, char) not in area_points:
            perimeter_count += 1

        # Right
        if (i, j + 1, char) not in area_points:
            perimeter_count += 1

        # Up
        if (i - 1, j, char) not in area_points:
            perimeter_count += 1
    
    cost = len(area_points) * perimeter_count
    return cost


def get_area_points(i, j, input_list, visited_nodes, area_points):
    current_char = input_list[i][j]

    # Terminating case
    if (i, j) in visited_nodes:
        return
    
    visited_nodes.add((i, j))
    area_points.add((i, j, current_char))

    # Recursive case
    # Left
    if j - 1 >= 0 and input_list[i][j - 1] == current_char:
        get_area_points(i, j - 1, input_list, visited_nodes, area_points)

    # Down
    if i + 1 < len(input_list) and input_list[i + 1][j] == current_char:
        get_area_points(i + 1, j, input_list, visited_nodes, area_points)

    # Right
    if j + 1 < len(input_list[i]) and input_list[i][j + 1] == current_char:
        get_area_points(i, j + 1, input_list, visited_nodes, area_points)

    # Up
    if i - 1 >= 0 and input_list[i - 1][j] == current_char:
        get_area_points(i - 1, j, input_list, visited_nodes, area_points)


def problem_part2(input_list):
    visited_nodes = set()
    area_points_list = []
    for i, line in enumerate(input_list):
        for j, char in enumerate(line):
            if (i, j) not in visited_nodes:
                area_points = set()
                get_area_points(i, j, input_list, visited_nodes, area_points)
                area_points_list.append(area_points)

    total_cost = 0
    for area_points in area_points_list:
        total_cost += calculate_bulk_cost(area_points, input_list)

    return total_cost


def calculate_bulk_cost(area_points, input_list):
    # perimeter_points = {}
    perimeter_points = set()
    for i, j, char in area_points:
        # Left
        if (i, j - 1, char) not in area_points:
            perimeter_points.add((i, j - 1, char, "|", i, j))

        # Down
        if (i + 1, j, char) not in area_points:
            perimeter_points.add((i + 1, j, char, "-", i, j))

        # Right
        if (i, j + 1, char) not in area_points:
            perimeter_points.add((i, j + 1, char, "|", i, j))

        # Up
        if (i - 1, j, char) not in area_points:
            perimeter_points.add((i - 1, j, char, "-", i, j))

    side_count = 0
    while len(perimeter_points) > 0:
        i, j, char, side, i_orig, j_orig = perimeter_points.pop()
        side_count += 1

        if side == "-":
            # Check left
            for k in range(j - 1, -2, -1):
                if (i, k, char, side, i_orig, k) in perimeter_points:
                    perimeter_points.remove((i, k, char, side, i_orig, k))
                else:
                    break
            
            # Check right
            for k in range(j + 1, len(input_list[0]) + 1, 1):
                if (i, k, char, side, i_orig, k) in perimeter_points:
                    perimeter_points.remove((i, k, char, side, i_orig, k))
                else:
                    break

        if side == "|":
            # Check up
            for k in range(i - 1, -2, -1):
                if (k, j, char, side, k, j_orig) in perimeter_points:
                    perimeter_points.remove((k, j, char, side, k, j_orig))
                else:
                    break
            
            # Check down
            for k in range(i + 1, len(input_list) + 1, 1):
                if (k, j, char, side, k, j_orig) in perimeter_points:
                    perimeter_points.remove((k, j, char, side, k, j_orig))
                else:
                    break
    
    cost = len(area_points) * side_count
    return cost


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