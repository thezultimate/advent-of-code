def problem_part1(input_list):
    trailheads = []
    for i, list in enumerate(input_list):
        for j, char in enumerate(list):
            if char == '0':
                trailheads.append((i, j))

    total_score = 0
    for trailhead in trailheads:
        end_of_trail = set()
        traverse(trailhead, input_list, -1, end_of_trail)
        # print("Trailhead done")
        total_score += len(end_of_trail)

    return total_score


def traverse(trailhead, input_list, prev_height, end_of_trail):
    i = trailhead[0]
    j = trailhead[1]
    current_height = int(input_list[i][j])

    # Terminating case
    if current_height != prev_height + 1:
        return
    
    # Terminating case
    if current_height == 9:
        if (i, j) not in end_of_trail:
            end_of_trail.add((i, j))
            # print("Reached the end of the trail")
        return

    # Recursive case
    # Left
    if j - 1 >= 0:
        traverse((i, j - 1), input_list, current_height, end_of_trail)

    # Down
    if i + 1 < len(input_list):
        traverse((i + 1, j), input_list, current_height, end_of_trail)

    # Right
    if j + 1 < len(input_list[i]):
        traverse((i, j + 1), input_list, current_height, end_of_trail)

    # Up
    if i - 1 >= 0:
        traverse((i - 1, j), input_list, current_height, end_of_trail)
        

def problem_part2(input_list):
    trailheads = []
    for i, list in enumerate(input_list):
        for j, char in enumerate(list):
            if char == '0':
                trailheads.append((i, j))

    total_score = 0
    for trailhead in trailheads:
        end_of_trail = []
        traverse2(trailhead, input_list, -1, end_of_trail)
        # print("Trailhead done")
        total_score += len(end_of_trail)

    return total_score


def traverse2(trailhead, input_list, prev_height, end_of_trail):
    i = trailhead[0]
    j = trailhead[1]
    current_height = int(input_list[i][j])

    # Terminating case
    if current_height != prev_height + 1:
        return
    
    # Terminating case
    if current_height == 9:
        end_of_trail.append((i, j))
        # print("Reached the end of the trail")
        return

    # Recursive case
    # Left
    if j - 1 >= 0:
        traverse2((i, j - 1), input_list, current_height, end_of_trail)

    # Down
    if i + 1 < len(input_list):
        traverse2((i + 1, j), input_list, current_height, end_of_trail)

    # Right
    if j + 1 < len(input_list[i]):
        traverse2((i, j + 1), input_list, current_height, end_of_trail)

    # Up
    if i - 1 >= 0:
        traverse2((i - 1, j), input_list, current_height, end_of_trail)


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