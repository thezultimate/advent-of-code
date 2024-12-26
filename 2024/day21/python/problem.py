import heapq


def problem_part1(input_list):
    sum = 0
    for line in input_list:
        min_press_length = get_input_length(line)
        number = int(line.split("A")[0])
        sum += number * min_press_length

    return sum


def get_numeric_keypad_layout():
    numeric_keypad_layout = {}
    numeric_keypad_layout["7"] = (0, 0)
    numeric_keypad_layout["8"] = (0, 1)
    numeric_keypad_layout["9"] = (0, 2)
    numeric_keypad_layout["4"] = (1, 0)
    numeric_keypad_layout["5"] = (1, 1)
    numeric_keypad_layout["6"] = (1, 2)
    numeric_keypad_layout["1"] = (2, 0)
    numeric_keypad_layout["2"] = (2, 1)
    numeric_keypad_layout["3"] = (2, 2)
    numeric_keypad_layout["0"] = (3, 1)
    numeric_keypad_layout["A"] = (3, 2)
    return numeric_keypad_layout


def get_directional_keypad_layout():
    directional_keypad_layout = {}
    directional_keypad_layout["^"] = (0, 1)
    directional_keypad_layout["A"] = (0, 2)
    directional_keypad_layout["<"] = (1, 0)
    directional_keypad_layout["v"] = (1, 1)
    directional_keypad_layout[">"] = (1, 2)
    return directional_keypad_layout


def get_input_length(input):
    # First level
    numeric_keypad_layout = get_numeric_keypad_layout()
    initial_point = numeric_keypad_layout["A"]
    complete_path_list_level_1 = []
    for char in input:
        target_point = numeric_keypad_layout[char]
        shortest_path_list = get_shortest_path(initial_point, target_point, numeric_keypad_layout)
        if len(complete_path_list_level_1) == 0:
            for shortest_path in shortest_path_list:
                shortest_path_temp = "".join(shortest_path) + "A"
                complete_path_list_level_1.append(shortest_path_temp)
        else:
            complete_path_list_temp = []
            for complete_path in complete_path_list_level_1:
                for shortest_path in shortest_path_list:
                    complete_path_combined = complete_path + "".join(shortest_path) + "A"
                    complete_path_list_temp.append(complete_path_combined)
            complete_path_list_level_1 = complete_path_list_temp
        initial_point = target_point
    # print(complete_path_list_level_1)

    complete_path_list_level_prev = complete_path_list_level_1
    for i in range(2):
        directional_keypad_layout = get_directional_keypad_layout()
        initial_point = directional_keypad_layout["A"]
        complete_path_list_level_n = []
        for complete_path_level_n in complete_path_list_level_prev:
            complete_shortest_path = ""
            for char in complete_path_level_n:
                target_point = directional_keypad_layout[char]
                shortest_path = get_shortest_path_directional(initial_point, target_point)
                complete_shortest_path += shortest_path
                initial_point = target_point
            complete_path_list_level_n.append(complete_shortest_path)
        complete_path_list_level_prev = complete_path_list_level_n
        # print(complete_path_list_level_prev)

    min_length = 999999999999
    for x in complete_path_list_level_prev:
        if len(x) < min_length:
            min_length = len(x)
        
    return min_length


def get_shortest_path(start_point, end_point, map):
    vertices = set()
    prev = {}
    dist = {}
    points = []
    path = []
    direction = "."
    heapq.heappush(points, (0, ((start_point, path, direction))))

    for key, value in map.items():
        vertices.add(value)
        prev[value] = None
        dist[value] = float('inf')

    dist[start_point] = 0

    path_list = []

    while points:
        current_dist, current_point_path = heapq.heappop(points)
        current_point = current_point_path[0]
        current_path = current_point_path[1]
        current_direction = current_point_path[2]
        if current_point == end_point:
            # print(f"End reached in {current_dist} steps")
            # print(current_path)
            path_list.append(current_path)
            # break

        i = current_point[0]
        j = current_point[1]
        # alt = dist[(i, j)] + 1

        # Left
        left_alt = dist[(i, j)] + 1
        if current_direction != "<":
            left_alt += 1
        if (i, j-1) in vertices and left_alt <= dist[(i, j-1)]:
            prev[(i, j-1)] = (i, j)
            dist[(i, j-1)] = left_alt
            current_path_copy = current_path.copy()
            current_path_copy.append("<")
            heapq.heappush(points, (left_alt, ((i, j-1), current_path_copy, "<")))

        # Right
        right_alt = dist[(i, j)] + 1
        if current_direction != ">":
            right_alt += 1
        if (i, j+1) in vertices and right_alt <= dist[(i, j+1)]:
            prev[(i, j+1)] = (i, j)
            dist[(i, j+1)] = right_alt
            current_path_copy = current_path.copy()
            current_path_copy.append(">")
            heapq.heappush(points, (right_alt, ((i, j+1), current_path_copy, ">")))

        # Down
        down_alt = dist[(i, j)] + 1
        if current_direction != "v":
            down_alt += 1
        if (i+1, j) in vertices and down_alt <= dist[(i+1, j)]:
            prev[(i+1, j)] = (i, j)
            dist[(i+1, j)] = down_alt
            current_path_copy = current_path.copy()
            current_path_copy.append("v")
            heapq.heappush(points, (down_alt, ((i+1, j), current_path_copy, "v")))

        # Up
        up_alt = dist[(i, j)] + 1
        if current_direction != "^":
            up_alt += 1
        if (i-1, j) in vertices and up_alt <= dist[(i-1, j)]:
            prev[(i-1, j)] = (i, j)
            dist[(i-1, j)] = up_alt
            current_path_copy = current_path.copy()
            current_path_copy.append("^")
            heapq.heappush(points, (up_alt, ((i-1, j), current_path_copy, "^")))

    # return dist[end_point]
    return path_list


def get_shortest_path_directional(start_point, end_point):
    if start_point == (0, 2): # Start from A
        if end_point == (0, 2): # End at A
            return "A"
        if end_point == (0, 1): # End at ^
            return "<A"
        if end_point == (1, 2): # End at >
            return "vA"
        if end_point == (1, 1): # End at v
            return "v<A"
        if end_point == (1, 0): # End at <
            return "v<<A"
    if start_point == (0, 1): # Start from ^
        if end_point == (0, 1): # End at ^
            return "A"
        if end_point == (0, 2): # End at A
            return ">A"
        if end_point == (1, 1): # End at v
            return "vA"
        if end_point == (1, 0): # End at <
            return "v<A"
        if end_point == (1, 2): # End at >
            return "v>A"
    if start_point == (1, 2): # Start from >
        if end_point == (1, 2): # End at >
            return "A"
        if end_point == (0, 2): # End at A
            return "^A"
        if end_point == (1, 1): # End at v
            return "<A"
        if end_point == (0, 1): # End at ^
            return "<^A"
        if end_point == (1, 0): # End at <
            return "<<A"
    if start_point == (1, 1): # Start from v
        if end_point == (1, 1): # End at v
            return "A"
        if end_point == (0, 1): # End at ^
            return "^A"
        if end_point == (1, 2): # End at >
            return ">A"
        if end_point == (1, 0): # End at <
            return "<A"
        if end_point == (0, 2): # End at A
            return ">^A"
    if start_point == (1, 0): # Start from <
        if end_point == (1, 0): # End at <
            return "A"
        if end_point == (1, 1): # End at v
            return ">A"
        if end_point == (0, 1): # End at ^
            return ">^A"
        if end_point == (1, 2): # End at >
            return ">>A"
        if end_point == (0, 2): # End at A
            return ">>^A"


# TODO
def problem_part2(input_list, depth=2):
    sum = 0
    for line in input_list:
        min_press_length = get_input_length2(line, depth)
        number = int(line.split("A")[0])
        sum += number * min_press_length

    return sum


# TODO
def get_input_length2(input, depth=2):
    # First level
    numeric_keypad_layout = get_numeric_keypad_layout()
    initial_point = numeric_keypad_layout["A"]
    complete_path_list_level_1 = []
    for char in input:
        target_point = numeric_keypad_layout[char]
        shortest_path_list = get_shortest_path(initial_point, target_point, numeric_keypad_layout)
        if len(complete_path_list_level_1) == 0:
            for shortest_path in shortest_path_list:
                shortest_path_temp = "".join(shortest_path) + "A"
                complete_path_list_level_1.append(shortest_path_temp)
        else:
            complete_path_list_temp = []
            for complete_path in complete_path_list_level_1:
                for shortest_path in shortest_path_list:
                    complete_path_combined = complete_path + "".join(shortest_path) + "A"
                    complete_path_list_temp.append(complete_path_combined)
            complete_path_list_level_1 = complete_path_list_temp
        initial_point = target_point
    # print(complete_path_list_level_1)

    complete_path_level_n_length_list = []
    for complete_path_level_1 in complete_path_list_level_1:
        memo = {}
        complete_path_level_n_length = get_length_dfs(complete_path_level_1, depth, memo)
        complete_path_level_n_length_list.append(complete_path_level_n_length)

    min_length = 999999999999
    for x in complete_path_level_n_length_list:
        if x < min_length:
            min_length = x

    return min_length


def get_length_dfs(path, depth, memo):
    # Check memo if this call has been cached
    if (path, depth) in memo:
        return memo[(path, depth)]

    # Terminating case
    if depth == 0:
        return len(path)

    # Recursive case
    sum = 0
    start_path = 0
    for i in range(len(path)):
        if path[i] == "A": # One block is reached
            left_path = path[start_path:i+1]
            directional_keypad_layout = get_directional_keypad_layout()
            initial_point = directional_keypad_layout["A"]
            block_min_length_sum = 0
            for char in left_path:
                target_point = directional_keypad_layout[char]
                shortest_path_list = get_shortest_path(initial_point, target_point, directional_keypad_layout)
                shortest_path_string_list = []
                for shortest_path in shortest_path_list:
                    shortest_path_string = "".join(shortest_path) + "A"
                    shortest_path_string_list.append(shortest_path_string)
                min_length = 999999999999999
                # Get min length of the shortest paths
                for shortest_path_string in shortest_path_string_list:
                    result = get_length_dfs(shortest_path_string, depth-1, memo)
                    if result < min_length:
                        min_length = result
                block_min_length_sum += min_length
                initial_point = target_point
            start_path = i+1
            sum += block_min_length_sum

    # Cache the result
    memo[(path, depth)] = sum

    return sum


def read_file_to_list(file_path):
    with open(file_path, 'r') as file:
        lines = [line.strip() for line in file]
    return lines


def main():
    file_path = 'input.txt'
    input_list = read_file_to_list(file_path)
    
    result_part1 = problem_part1(input_list)
    print(f"Result of problem_part1: {result_part1}")
    
    result_part2 = problem_part2(input_list, 25)
    print(f"Result of problem_part2: {result_part2}")


if __name__ == "__main__":
    main()