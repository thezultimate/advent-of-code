def problem_part1(input_list):
    visited_nodes = set()
    antinodes_coordinates = set()
    for i, line in enumerate(input_list):
        for j, char in enumerate(line):
            if char == '.':
                continue
            visited_nodes.add((i, j))
            for k, line_pair in enumerate(input_list):
                for l, char_pair in enumerate(line_pair):
                    if char_pair == '.':
                        continue
                    if char == char_pair and (k, l) not in visited_nodes:
                        i_diff = abs(i - k)
                        j_diff = abs(j - l)
                        if i <= k:
                            i_antinode_one = i - i_diff
                            i_antinode_two = k + i_diff
                        else:
                            i_antinode_one = i + i_diff
                            i_antinode_two = k - i_diff
                        if j <= l:
                            j_antinode_one = j - j_diff
                            j_antinode_two = l + j_diff
                        else:
                            j_antinode_one = j + j_diff
                            j_antinode_two = l - j_diff
                        if i_antinode_one >= 0 and i_antinode_one < len(input_list) and j_antinode_one >= 0 and j_antinode_one < len(line):
                            antinodes_coordinates.add((i_antinode_one, j_antinode_one))
                        if i_antinode_two >= 0 and i_antinode_two < len(input_list) and j_antinode_two >= 0 and j_antinode_two < len(line):
                            antinodes_coordinates.add((i_antinode_two, j_antinode_two))
                            
    return len(antinodes_coordinates)


def problem_part2(input_list):
    visited_nodes = set()
    antinodes_coordinates = set()
    for i, line in enumerate(input_list):
        for j, char in enumerate(line):
            if char == '.':
                continue
            visited_nodes.add((i, j))
            for k, line_pair in enumerate(input_list):
                for l, char_pair in enumerate(line_pair):
                    if char_pair == '.':
                        continue
                    if char == char_pair and (k, l) not in visited_nodes:
                        antinodes_coordinates.add((i, j))
                        antinodes_coordinates.add((k, l))
                        i_diff = abs(i - k)
                        j_diff = abs(j - l)
                        if i <= k and j <= l:
                            # First direction
                            i_current = k
                            j_current = l
                            while i_current + i_diff < len(input_list) and j_current + j_diff < len(line):
                                i_current += i_diff
                                j_current += j_diff
                                antinodes_coordinates.add((i_current, j_current))
                            # Second direction
                            i_current = i
                            j_current = j
                            while i_current - i_diff >= 0 and j_current - j_diff >= 0:
                                i_current -= i_diff
                                j_current -= j_diff
                                antinodes_coordinates.add((i_current, j_current))
                        if i <= k and j >= l:
                            # First direction
                            i_current = k
                            j_current = l
                            while i_current + i_diff < len(input_list) and j_current - j_diff >= 0:
                                i_current += i_diff
                                j_current -= j_diff
                                antinodes_coordinates.add((i_current, j_current))
                            # Second direction
                            i_current = i
                            j_current = j
                            while i_current - i_diff >= 0 and j_current + j_diff < len(line):
                                i_current -= i_diff
                                j_current += j_diff
                                antinodes_coordinates.add((i_current, j_current))
                        if i >= k and j <= l:
                            # First direction
                            i_current = k
                            j_current = l
                            while i_current - i_diff >= 0 and j_current + j_diff < len(line):
                                i_current -= i_diff
                                j_current += j_diff
                                antinodes_coordinates.add((i_current, j_current))
                            # Second direction
                            i_current = i
                            j_current = j
                            while i_current + i_diff < len(input_list) and j_current - j_diff >= 0:
                                i_current += i_diff
                                j_current -= j_diff
                                antinodes_coordinates.add((i_current, j_current))
                        if i >= k and j >= l:
                            # First direction
                            i_current = k
                            j_current = l
                            while i_current - i_diff >= 0 and j_current - j_diff >= 0:
                                i_current -= i_diff
                                j_current -= j_diff
                                antinodes_coordinates.add((i_current, j_current))
                            # Second direction
                            i_current = i
                            j_current = j
                            while i_current + i_diff < len(input_list) and j_current + j_diff < len(line):
                                i_current += i_diff
                                j_current += j_diff
                                antinodes_coordinates.add((i_current, j_current))

    return len(antinodes_coordinates)
                            

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