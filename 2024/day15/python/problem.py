def problem_part1(input_list):
    input_map = []
    moves = ""
    for line in input_list:
        if line == "":
            continue
        if "#" in line:
            input_map.append(line)
        else:
            moves += line

    robot_position = (-1, -1)
    positions = {}
    for i, line in enumerate(input_map):
        for j, char in enumerate(line):
            if char == "@":
                robot_position = (i, j)
                positions[(i, j)] = "."
            if char == "#":
                positions[(i, j)] = "#"
            if char == "O":
                positions[(i, j)] = "O"
            if char == ".":
                positions[(i, j)] = "."

    for move in moves:
        i = robot_position[0]
        j = robot_position[1]

        # Left
        if move == "<":
            if positions[(i, j-1)] == ".": # Left is empty
                robot_position = (i, j-1)
                continue
            if positions[(i, j-1)] == "O": # Left is box
                move_box((i, j-1), "<", positions)
                if positions[(i, j-1)] == ".":
                    robot_position = (i, j-1)
                continue
            if positions[(i, j-1)] == "#": # Left is wall
                continue

        # Down
        if move == "v":
            if positions[(i+1, j)] == ".": # Down is empty
                robot_position = (i+1, j)
                continue
            if positions[(i+1, j)] == "O": # Down is box
                move_box((i+1, j), "v", positions)
                if positions[(i+1, j)] == ".":
                    robot_position = (i+1, j)
                continue
            if positions[(i+1, j)] == "#": # Down is wall
                continue

        # Right
        if move == ">":
            if positions[(i, j+1)] == ".": # Right is empty
                robot_position = (i, j+1)
                continue
            if positions[(i, j+1)] == "O": # Right is box
                move_box((i, j+1), ">", positions)
                if positions[(i, j+1)] == ".":
                    robot_position = (i, j+1)
                continue
            if positions[(i, j+1)] == "#": # Right is wall
                continue

        # Up
        if move == "^":
            if positions[(i-1, j)] == ".": # Up is empty
                robot_position = (i-1, j)
                continue
            if positions[(i-1, j)] == "O": # Up is box
                move_box((i-1, j), "^", positions)
                if positions[(i-1, j)] == ".":
                    robot_position = (i-1, j)
                continue
            if positions[(i-1, j)] == "#": # Up is wall
                continue
                
    sum_gps_coordinates = 0
    for key in positions:
        if positions[key] == "O":
            sum_gps_coordinates += key[0] * 100 + key[1]

    return sum_gps_coordinates


def move_box(box_position, direction, positions):
    i = box_position[0]
    j = box_position[1]

    # Left
    if direction == "<":
        # Terminating case
        if positions[(i, j-1)] == "#":
            return

        # Terminating case
        if positions[(i, j-1)] == ".":
            positions[(i, j-1)] = "O"
            positions[(i, j)] = "."
            return
        
        # Recursive case
        if positions[(i, j-1)] == "O":
            move_box((i, j-1), "<", positions)
            if positions[(i, j-1)] == ".":
                positions[(i, j-1)] = "O"
                positions[(i, j)] = "."
                return
        

    # Down
    if direction == "v":
        # Terminating case
        if positions[(i+1, j)] == "#":
            return

        # Terminating case
        if positions[(i+1, j)] == ".":
            positions[(i+1, j)] = "O"
            positions[(i, j)] = "."
            return
        
        # Recursive case
        if positions[(i+1, j)] == "O":
            move_box((i+1, j), "v", positions)
            if positions[(i+1, j)] == ".":
                positions[(i+1, j)] = "O"
                positions[(i, j)] = "."
                return

    # Right
    if direction == ">":
        # Terminating case
        if positions[(i, j+1)] == "#":
            return

        # Terminating case
        if positions[(i, j+1)] == ".":
            positions[(i, j+1)] = "O"
            positions[(i, j)] = "."
            return
        
        # Recursive case
        if positions[(i, j+1)] == "O":
            move_box((i, j+1), ">", positions)
            if positions[(i, j+1)] == ".":
                positions[(i, j+1)] = "O"
                positions[(i, j)] = "."
                return

    # Up
    if direction == "^":
        # Terminating case
        if positions[(i-1, j)] == "#":
            return

        # Terminating case
        if positions[(i-1, j)] == ".":
            positions[(i-1, j)] = "O"
            positions[(i, j)] = "."
            return
        
        # Recursive case
        if positions[(i-1, j)] == "O":
            move_box((i-1, j), "^", positions)
            if positions[(i-1, j)] == ".":
                positions[(i-1, j)] = "O"
                positions[(i, j)] = "."
                return


def problem_part2(input_list):
    input_map = []
    moves = ""
    for line in input_list:
        if line == "":
            continue
        if "#" in line:
            input_map.append(line)
        else:
            moves += line

    robot_position = (-1, -1)
    positions = {}
    for i, line in enumerate(input_map):
        for j, char in enumerate(line):
            if char == "@":
                robot_position = (i, j*2)
                positions[(i, j*2)] = "."
                positions[(i, j*2 + 1)] = "."
            if char == "#":
                positions[(i, j*2)] = "#"
                positions[(i, j*2 + 1)] = "#"
            if char == "O":
                positions[(i, j*2)] = "["
                positions[(i, j*2 + 1)] = "]"
            if char == ".":
                positions[(i, j*2)] = "."
                positions[(i, j*2 + 1)] = "."

    for move in moves:
        i = robot_position[0]
        j = robot_position[1]

        # Left
        if move == "<":
            if positions[(i, j-1)] == ".": # Left is empty
                robot_position = (i, j-1)
                continue
            if positions[(i, j-1)] == "#": # Left is wall
                continue
            if positions[(i, j-1)] == "]": # Left is box
                move_box_left_right((i, j-1), "<", positions)
                if positions[(i, j-1)] == ".":
                    robot_position = (i, j-1)
                continue

        # Right
        if move == ">":
            if positions[(i, j+1)] == ".": # Right is empty
                robot_position = (i, j+1)
                continue
            if positions[(i, j+1)] == "#": # Right is wall
                continue
            if positions[(i, j+1)] == "[":
                move_box_left_right((i, j+1), ">", positions)
                if positions[(i, j+1)] == ".":
                    robot_position = (i, j+1)
                continue

        # Down
        if move == "v":
            if positions[(i+1, j)] == ".": # Down is empty
                robot_position = (i+1, j)
                continue
            if positions[(i+1, j)] == "#": # Down is wall
                continue
            can_box_move_down = can_box_move_down_up((i+1, j), "v", positions)
            if can_box_move_down:
                move_box_down_up((i+1, j), "v", positions)
                robot_position = (i+1, j)

        # Up
        if move == "^":
            if positions[(i-1, j)] == ".": # Up is empty
                robot_position = (i-1, j)
                continue
            if positions[(i-1, j)] == "#": # Up is wall
                continue
            can_box_move_up = can_box_move_down_up((i-1, j), "^", positions)
            if can_box_move_up:
                move_box_down_up((i-1, j), "^", positions)
                robot_position = (i-1, j)

    sum_gps_coordinates = 0
    for key in positions:
        if positions[key] == "[":
            sum_gps_coordinates += key[0] * 100 + key[1]

    return sum_gps_coordinates


def move_box_left_right(box_position, direction, positions):
    i = box_position[0]
    j = box_position[1]

    # Left
    if direction == "<":
        # Terminating case
        if positions[(i, j-2)] == "#":
            return
        
        # Terminating case
        if positions[(i, j-2)] == ".":
            positions[(i, j-2)] = "["
            positions[(i, j-1)] = "]"
            positions[(i, j)] = "."
            return
        
        # Recursive case
        if positions[(i, j-2)] == "]":
            move_box_left_right((i, j-2), "<", positions)
            if positions[(i, j-2)] == ".":
                positions[(i, j-2)] = "["
                positions[(i, j-1)] = "]"
                positions[(i, j)] = "."
                return
    
    # Right
    if direction == ">":
        # Terminating case
        if positions[(i, j+2)] == "#":
            return
        
        # Terminating case
        if positions[(i, j+2)] == ".":
            positions[(i, j+2)] = "]"
            positions[(i, j+1)] = "["
            positions[(i, j)] = "."
            return
        
        # Recursive case
        if positions[(i, j+2)] == "[":
            move_box_left_right((i, j+2), ">", positions)
            if positions[(i, j+2)] == ".":
                positions[(i, j+2)] = "]"
                positions[(i, j+1)] = "["
                positions[(i, j)] = "."
                return
            

def can_box_move_down_up(box_position, direction, positions):
    i = box_position[0]
    j = box_position[1]

    # Down
    if direction == "v":
        current_char = positions[(i, j)]
        can_move_down = True

        # Terminating case
        if current_char == "[":
            if positions[(i+1, j)] == "#" or positions[(i+1, j+1)] == "#":
                return False
            if positions[(i+1, j)] == "." and positions[(i+1, j+1)] == ".":
                return True
            
        if current_char == "]":
            if positions[(i+1, j)] == "#" or positions[(i+1, j-1)] == "#":
                return False
            if positions[(i+1, j)] == "." and positions[(i+1, j-1)] == ".":
                return True
            
        # Recursive case
        if current_char == "[":
            left = can_box_move_down_up((i+1, j), "v", positions)
            right = can_box_move_down_up((i+1, j+1), "v", positions)
            can_move_down = can_move_down and left and right

        if current_char == "]":
            right = can_box_move_down_up((i+1, j), "v", positions)
            left = can_box_move_down_up((i+1, j-1), "v", positions)
            can_move_down = can_move_down and left and right
            
        return can_move_down
    
    # Up
    if direction == "^":
        current_char = positions[(i, j)]
        can_move_up = True

        # Terminating case
        if current_char == "[":
            if positions[(i-1, j)] == "#" or positions[(i-1, j+1)] == "#":
                return False
            if positions[(i-1, j)] == "." and positions[(i-1, j+1)] == ".":
                return True
            
        if current_char == "]":
            if positions[(i-1, j)] == "#" or positions[(i-1, j-1)] == "#":
                return False
            if positions[(i-1, j)] == "." and positions[(i-1, j-1)] == ".":
                return True
            
        # Recursive case
        if current_char == "[":
            left = can_box_move_down_up((i-1, j), "^", positions)
            right = can_box_move_down_up((i-1, j+1), "^", positions)
            can_move_up = can_move_up and left and right

        if current_char == "]":
            right = can_box_move_down_up((i-1, j), "^", positions)
            left = can_box_move_down_up((i-1, j-1), "^", positions)
            can_move_up = can_move_up and left and right
            
        return can_move_up
    

def move_box_down_up(box_position, direction, positions):
    i = box_position[0]
    j = box_position[1]
    current_char = positions[(i, j)]

    # Down
    if direction == "v":
        # Terminating case
        if current_char == "[":
            if positions[(i+1, j)] == "#" or positions[(i+1, j+1)] == "#":
                return
            if positions[(i+1, j)] == "." and positions[(i+1, j+1)] == ".":
                positions[(i+1, j)] = "["
                positions[(i+1, j+1)] = "]"
                positions[(i, j)] = "."
                positions[(i, j+1)] = "."
                return
        
        if current_char == "]":
            if positions[(i+1, j)] == "#" or positions[(i+1, j-1)] == "#":
                return
            if positions[(i+1, j)] == "." and positions[(i+1, j-1)] == ".":
                positions[(i+1, j)] = "]"
                positions[(i+1, j-1)] = "["
                positions[(i, j)] = "."
                positions[(i, j-1)] = "."
                return

        # Recursive case
        if current_char == "[":
            move_box_down_up((i+1, j), "v", positions)
            move_box_down_up((i+1, j+1), "v", positions)
            if positions[(i+1, j)] == "." and positions[(i+1, j+1)] == ".":
                positions[(i+1, j)] = "["
                positions[(i+1, j+1)] = "]"
                positions[(i, j)] = "."
                positions[(i, j+1)] = "."
                return
            
        if current_char == "]":
            move_box_down_up((i+1, j), "v", positions)
            move_box_down_up((i+1, j-1), "v", positions)
            if positions[(i+1, j)] == "." and positions[(i+1, j-1)] == ".":
                positions[(i+1, j)] = "]"
                positions[(i+1, j-1)] = "["
                positions[(i, j)] = "."
                positions[(i, j-1)] = "."
                return
            
    # Up
    if direction == "^":
        # Terminating case
        if current_char == "[":
            if positions[(i-1, j)] == "#" or positions[(i-1, j+1)] == "#":
                return
            if positions[(i-1, j)] == "." and positions[(i-1, j+1)] == ".":
                positions[(i-1, j)] = "["
                positions[(i-1, j+1)] = "]"
                positions[(i, j)] = "."
                positions[(i, j+1)] = "."
                return
        
        if current_char == "]":
            if positions[(i-1, j)] == "#" or positions[(i-1, j-1)] == "#":
                return
            if positions[(i-1, j)] == "." and positions[(i-1, j-1)] == ".":
                positions[(i-1, j)] = "]"
                positions[(i-1, j-1)] = "["
                positions[(i, j)] = "."
                positions[(i, j-1)] = "."
                return

        # Recursive case
        if current_char == "[":
            move_box_down_up((i-1, j), "^", positions)
            move_box_down_up((i-1, j+1), "^", positions)
            if positions[(i-1, j)] == "." and positions[(i-1, j+1)] == ".":
                positions[(i-1, j)] = "["
                positions[(i-1, j+1)] = "]"
                positions[(i, j)] = "."
                positions[(i, j+1)] = "."
                return
            
        if current_char == "]":
            move_box_down_up((i-1, j), "^", positions)
            move_box_down_up((i-1, j-1), "^", positions)
            if positions[(i-1, j)] == "." and positions[(i-1, j-1)] == ".":
                positions[(i-1, j)] = "]"
                positions[(i-1, j-1)] = "["
                positions[(i, j)] = "."
                positions[(i, j-1)] = "."
                return


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