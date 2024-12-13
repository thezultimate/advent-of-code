import time

def problem_part1(input_list, grid_width=11, grid_height=7, max_counter=100):
    robot_velocities = {} # key: robot_id, value: (vx, vy)
    robot_positions = {} # key: robot_id, value: (x, y)
    for index, line in enumerate(input_list):
        line_split = line.split()
        p = line_split[0].strip().split('=')
        x, y = p[1].strip().split(',')
        v = line_split[1].strip().split('=')
        vx, vy = v[1].strip().split(',')
        # print(f"x: {x}, y: {y}, vx: {vx}, vy: {vy}")
        robot_velocities[index] = (int(vx), int(vy))
        robot_positions[index] = (int(x), int(y))

    safety_factor = 0
    counter = 1
    while counter <= max_counter:
        # print(f"counter: {counter}")
        current_robot_positions = {}
        positions_count = {} # key: (x, y), value: count
        for robot_id, position in robot_positions.items():
            x, y = position
            vx, vy = robot_velocities[robot_id]
            new_x = x + vx
            new_y = y + vy
            if new_x < 0:
                new_x = grid_width + new_x # Wrap to the right
            if new_y < 0:
                new_y = grid_height + new_y # Wrap to the bottom
            if new_x >= grid_width:
                new_x = new_x - grid_width # Wrap to the left
            if new_y >= grid_height:
                new_y = new_y - grid_height # Wrap to the top
            current_robot_positions[robot_id] = (new_x, new_y)
            if (new_x, new_y) in positions_count:
                positions_count[(new_x, new_y)] += 1
            else:
                positions_count[(new_x, new_y)] = 1
        
        safety_factor = calculate_safety_factor(positions_count, grid_width, grid_height)
        # print(f"counter: {counter}, safety_factor: {safety_factor}")
        robot_positions = current_robot_positions
        counter += 1

    return safety_factor


def calculate_safety_factor(positions_count, grid_width, grid_height):
    mid_width_index = grid_width // 2
    mid_height_index = grid_height // 2

    # First quadrant
    first_quadrant_count = 0
    for i in range(mid_height_index):
        for j in range(mid_width_index):
            if (j, i) in positions_count:
                first_quadrant_count += positions_count[(j, i)]

    # Second quadrant
    second_quadrant_count = 0
    for i in range(mid_height_index):
        for j in range(mid_width_index + 1, grid_width):
            if (j, i) in positions_count:
                second_quadrant_count += positions_count[(j, i)]

    # Third quadrant
    third_quadrant_count = 0
    for i in range(mid_height_index + 1, grid_height):
        for j in range(mid_width_index):
            if (j, i) in positions_count:
                third_quadrant_count += positions_count[(j, i)]

    # Fourth quadrant
    fourth_quadrant_count = 0
    for i in range(mid_height_index + 1, grid_height):
        for j in range(mid_width_index + 1, grid_width):
            if (j, i) in positions_count:
                fourth_quadrant_count += positions_count[(j, i)]

    safety_factor = first_quadrant_count * second_quadrant_count * third_quadrant_count * fourth_quadrant_count
    return safety_factor


def problem_part2(input_list, grid_width=11, grid_height=7, max_counter=100):
    robot_velocities = {} # key: robot_id, value: (vx, vy)
    robot_positions = {} # key: robot_id, value: (x, y)
    for index, line in enumerate(input_list):
        line_split = line.split()
        p = line_split[0].strip().split('=')
        x, y = p[1].strip().split(',')
        v = line_split[1].strip().split('=')
        vx, vy = v[1].strip().split(',')
        # print(f"x: {x}, y: {y}, vx: {vx}, vy: {vy}")
        robot_velocities[index] = (int(vx), int(vy))
        robot_positions[index] = (int(x), int(y))

    safety_factors = set()
    safety_factor = 0
    counter = 1
    while counter <= max_counter:
        current_robot_positions = {}
        positions_count = {} # key: (x, y), value: count
        for robot_id, position in robot_positions.items():
            x, y = position
            vx, vy = robot_velocities[robot_id]
            new_x = x + vx
            new_y = y + vy
            if new_x < 0:
                new_x = grid_width + new_x # Wrap to the right
            if new_y < 0:
                new_y = grid_height + new_y # Wrap to the bottom
            if new_x >= grid_width:
                new_x = new_x - grid_width # Wrap to the left
            if new_y >= grid_height:
                new_y = new_y - grid_height # Wrap to the top
            current_robot_positions[robot_id] = (new_x, new_y)
            if (new_x, new_y) in positions_count:
                positions_count[(new_x, new_y)] += 1
            else:
                positions_count[(new_x, new_y)] = 1
        
        safety_factor = calculate_safety_factor(positions_count, grid_width, grid_height)
        print(f"counter: {counter}")
        # Draw and see if my eyes work as expected
        draw_robot_positions(current_robot_positions, grid_width, grid_height)
        robot_positions = current_robot_positions
        counter += 1

    return safety_factor


def draw_robot_positions(robot_positions, grid_width, grid_height):
    grid = [[' ' for _ in range(grid_width)] for _ in range(grid_height)]
    for robot_id, position in robot_positions.items():
        x, y = position
        grid[y][x] = '#'
    for row in grid:
        print(' '.join(row))
    print()


def read_file_to_list(file_path):
    with open(file_path, 'r') as file:
        lines = [line.strip() for line in file]
    return lines


def main():
    file_path = 'input.txt'
    input_list = read_file_to_list(file_path)
    
    result_part1 = problem_part1(input_list, grid_width=101, grid_height=103, max_counter=100)
    print(f"Result of problem_part1: {result_part1}")
    
    result_part2 = problem_part2(input_list, grid_width=101, grid_height=103, max_counter=10000)
    print(f"Result of problem_part2: {result_part2}")


if __name__ == "__main__":
    main()