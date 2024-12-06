def problem_part1(input_list):
    i_start = 0
    j_start = 0
    for i in range(len(input_list)):
        if '^' in input_list[i]:
            i_start = i
            j_start = input_list[i].index('^')
            break

    is_guard_inside_map = True
    visited_coordinates = {(i_start, j_start)}
    i = i_start
    j = j_start
    guard_direction = "^"
    
    while is_guard_inside_map:
        # left
        if guard_direction == "<":
            if j-1 < 0:
                is_guard_inside_map = False
                break
            if input_list[i][j-1] == "#":
                guard_direction = "^"
                continue
            else:
                j -= 1
                visited_coordinates.add((i, j))

        # down
        if guard_direction == "v":
            if i+1 >= len(input_list):
                is_guard_inside_map = False
                break
            if input_list[i+1][j] == "#":
                guard_direction = "<"
                continue
            else:
                i += 1
                visited_coordinates.add((i, j))

        # right
        if guard_direction == ">":
            if j+1 >= len(input_list[0]):
                is_guard_inside_map = False
                break
            if input_list[i][j+1] == "#":
                guard_direction = "v"
                continue
            else:
                j += 1
                visited_coordinates.add((i, j))

        # up
        if guard_direction == "^":
            if i-1 < 0:
                is_guard_inside_map = False
                break
            if input_list[i-1][j] == "#":
                guard_direction = ">"
                continue
            else:
                i -= 1
                visited_coordinates.add((i, j))

    num_visited_coordinates = len(visited_coordinates)
        
    return (num_visited_coordinates, visited_coordinates)


def problem_part2(input_list):
    first_visited_coordinates = problem_part1(input_list)[1]

    i_start = 0
    j_start = 0
    for i in range(len(input_list)):
        if '^' in input_list[i]:
            i_start = i
            j_start = input_list[i].index('^')
            break

    obstacle_coordinates = set()
    input_list_copy = input_list.copy()

    # Iterate through visited nodes from part 1
    for previous_coordinate in first_visited_coordinates:
        i_obstacle = previous_coordinate[0]
        j_obstacle = previous_coordinate[1]
        is_loop_found = False

        is_guard_inside_map = True
        guard_direction = "^"
        visited_coordinates = {(i_start, j_start, guard_direction)}
        i_current = i_start
        j_current = j_start
        
        while is_guard_inside_map:
            # left
            if guard_direction == "<":
                if j_current-1 < 0:
                    is_guard_inside_map = False
                    break
                if input_list_copy[i_current][j_current-1] == "#" or (i_current == i_obstacle and j_current-1 == j_obstacle):
                    guard_direction = "^"
                    continue
                else:
                    j_current -= 1
                    next_coordinate = (i_current, j_current, "<")
                    if next_coordinate in visited_coordinates:
                        is_loop_found = True
                        break
                    visited_coordinates.add(next_coordinate)

            # down
            if guard_direction == "v":
                if i_current+1 >= len(input_list_copy):
                    is_guard_inside_map = False
                    break
                if input_list_copy[i_current+1][j_current] == "#" or (i_current+1 == i_obstacle and j_current == j_obstacle):
                    guard_direction = "<"
                    continue
                else:
                    i_current += 1
                    next_coordinate = (i_current, j_current, "v")
                    if next_coordinate in visited_coordinates:
                        is_loop_found = True
                        break
                    visited_coordinates.add(next_coordinate)

            # right
            if guard_direction == ">":
                if j_current+1 >= len(input_list_copy[0]):
                    is_guard_inside_map = False
                    break
                if input_list_copy[i_current][j_current+1] == "#" or (i_current == i_obstacle and j_current+1 == j_obstacle):
                    guard_direction = "v"
                    continue
                else:
                    j_current += 1
                    next_coordinate = (i_current, j_current, ">")
                    if next_coordinate in visited_coordinates:
                        is_loop_found = True
                        break
                    visited_coordinates.add(next_coordinate)

            # up
            if guard_direction == "^":
                if i_current-1 < 0:
                    is_guard_inside_map = False
                    break
                if input_list_copy[i_current-1][j_current] == "#" or (i_current-1 == i_obstacle and j_current == j_obstacle):
                    guard_direction = ">"
                    continue
                else:
                    i_current -= 1
                    next_coordinate = (i_current, j_current, "^")
                    if next_coordinate in visited_coordinates:
                        is_loop_found = True
                        break
                    visited_coordinates.add(next_coordinate)

        if is_loop_found:
            obstacle_coordinates.add((previous_coordinate[0], previous_coordinate[1]))
    
    return len(obstacle_coordinates)


def read_file_to_list(file_path):
    with open(file_path, 'r') as file:
        lines = [line.strip() for line in file]
    return lines


def main():
    file_path = 'input.txt'
    input_list = read_file_to_list(file_path)
    
    result_part1 = problem_part1(input_list)
    print(f"Result of problem_part1: {result_part1[0]}")
    
    result_part2 = problem_part2(input_list)
    print(f"Result of problem_part2: {result_part2}")


if __name__ == "__main__":
    main()