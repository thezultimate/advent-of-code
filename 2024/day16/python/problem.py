import heapq
from copy import deepcopy


def problem_part1(input_list):
    start_point = (len(input_list[1])-2, 1)
    end_point = (1, len(input_list[1])-2)

    vertices = set()
    prev = {}
    dist = {}

    points = []
    heapq.heappush(points, (0, ((start_point[0], start_point[1], ">"))))

    for i, line in enumerate(input_list):
        for j, char in enumerate(line):
            if char != "#":
                vertices.add((i, j, "<"))
                vertices.add((i, j, "v"))
                vertices.add((i, j, ">"))
                vertices.add((i, j, "^"))
                prev[(i, j, "<")] = None
                prev[(i, j, "v")] = None
                prev[(i, j, ">")] = None
                prev[(i, j, "^")] = None
                dist[(i, j, "<")] = float("inf")
                dist[(i, j, "v")] = float("inf")
                dist[(i, j, ">")] = float("inf")
                dist[(i, j, "^")] = float("inf")
    
    dist[(start_point[0], start_point[1], "<")] = 0
    dist[(start_point[0], start_point[1], "v")] = 0
    dist[(start_point[0], start_point[1], ">")] = 0
    dist[(start_point[0], start_point[1], "^")] = 0

    while points:
        current_dist, current_point_direction = heapq.heappop(points)
        if (current_point_direction[0], current_point_direction[1]) == end_point:
            # print(f"E reached in {current_dist} steps")
            break

        i = current_point_direction[0]
        j = current_point_direction[1]
        current_direction = current_point_direction[2]

        # Left
        if current_direction != ">":
            alt = dist[current_point_direction] + 1
            if current_direction == "v":
                alt += 1000
            if current_direction == "^":
                alt += 1000
            if (i, j-1, "<") in vertices and alt < dist[(i, j-1, "<")]:
                prev[(i, j-1, "<")] = current_point_direction
                dist[(i, j-1, "<")] = alt
                heapq.heappush(points, (alt, ((i, j-1, "<"))))

        # Right
        if current_direction != "<":
            alt = dist[current_point_direction] + 1
            if current_direction == "v":
                alt += 1000
            if current_direction == "^":
                alt += 1000
            if (i, j+1, ">") in vertices and alt < dist[(i, j+1, ">")]:
                prev[(i, j+1, ">")] = current_point_direction
                dist[(i, j+1, ">")] = alt
                heapq.heappush(points, (alt, ((i, j+1, ">"))))

        # Up
        if current_direction != "v":
            alt = dist[current_point_direction] + 1
            if current_direction == ">":
                alt += 1000
            if current_direction == "<":
                alt += 1000
            if (i-1, j, "^") in vertices and alt < dist[(i-1, j, "^")]:
                prev[(i-1, j, "^")] = current_point_direction
                dist[(i-1, j, "^")] = alt
                heapq.heappush(points, (alt, ((i-1, j, "^"))))

        # Down
        if current_direction != "^":
            alt = dist[current_point_direction] + 1
            if current_direction == ">":
                alt += 1000
            if current_direction == "<":
                alt += 1000
            if (i+1, j, "v") in vertices and alt < dist[(i+1, j, "v")]:
                prev[(i+1, j, "v")] = current_point_direction
                dist[(i+1, j, "v")] = alt
                heapq.heappush(points, (alt, ((i+1, j, "v"))))

    min_end_distance = dist[end_point[0], end_point[1], "<"]
    if dist[end_point[0], end_point[1], "v"] < min_end_distance:
        min_end_distance = dist[end_point[0], end_point[1], "v"]
    if dist[end_point[0], end_point[1], ">"] < min_end_distance:
        min_end_distance = dist[end_point[0], end_point[1], ">"]
    if dist[end_point[0], end_point[1], "^"] < min_end_distance:
        min_end_distance = dist[end_point[0], end_point[1], "^"]
    
    return min_end_distance
    

def problem_part2(input_list):
    min_end_distance = problem_part1(input_list)
    # print(f"Min end distance: {min_end_distance}")

    start_point = (len(input_list[1])-2, 1)
    end_point = (1, len(input_list[1])-2)

    vertices = set()
    prev = {}
    dist = {}

    points = []
    path = [(start_point[0], start_point[1], ">")]
    heapq.heappush(points, (0, ((start_point[0], start_point[1], ">", path))))

    for i, line in enumerate(input_list):
        for j, char in enumerate(line):
            if char != "#":
                vertices.add((i, j, "<"))
                vertices.add((i, j, "v"))
                vertices.add((i, j, ">"))
                vertices.add((i, j, "^"))
                dist[(i, j, "<")] = float("inf")
                dist[(i, j, "v")] = float("inf")
                dist[(i, j, ">")] = float("inf")
                dist[(i, j, "^")] = float("inf")
    
    dist[(start_point[0], start_point[1], "<")] = 0
    dist[(start_point[0], start_point[1], "v")] = 0
    dist[(start_point[0], start_point[1], ">")] = 0
    dist[(start_point[0], start_point[1], "^")] = 0

    path_list = []

    while points:
        current_dist, current_point_direction = heapq.heappop(points)
        if (current_point_direction[0], current_point_direction[1]) == end_point:
            if current_dist <= min_end_distance:
                # print(f"E reached in {current_dist} steps")
                # print(f"Current point direction: {current_point_direction}")
                # print(f"Path: {current_point_direction[3]}")
                # print()
                min_path = []
                for point in current_point_direction[3]:
                    min_path.append(point)
                path_list.append(min_path)

        i = current_point_direction[0]
        j = current_point_direction[1]
        current_direction = current_point_direction[2]
        current_path = current_point_direction[3]

        # Left
        if current_direction != ">":
            alt = dist[(current_point_direction[0], current_point_direction[1], current_point_direction[2])] + 1
            if current_direction == "v":
                alt += 1000
            if current_direction == "^":
                alt += 1000
            if (i, j-1, "<") in vertices and alt <= dist[(i, j-1, "<")]:
                prev[(i, j-1, "<")] = current_point_direction
                dist[(i, j-1, "<")] = alt
                current_path_copy = current_path.copy()
                current_path_copy.append((i, j-1, "<"))
                heapq.heappush(points, (alt, ((i, j-1, "<", current_path_copy))))

        # Right
        if current_direction != "<":
            alt = dist[(current_point_direction[0], current_point_direction[1], current_point_direction[2])] + 1
            if current_direction == "v":
                alt += 1000
            if current_direction == "^":
                alt += 1000
            if (i, j+1, ">") in vertices and alt <= dist[(i, j+1, ">")]:
                prev[(i, j+1, ">")] = current_point_direction
                dist[(i, j+1, ">")] = alt
                current_path_copy = current_path.copy()
                current_path_copy.append((i, j+1, ">"))
                heapq.heappush(points, (alt, ((i, j+1, ">", current_path_copy))))

        # Down
        if current_direction != "^":
            alt = dist[(current_point_direction[0], current_point_direction[1], current_point_direction[2])] + 1
            if current_direction == ">":
                alt += 1000
            if current_direction == "<":
                alt += 1000
            if (i+1, j, "v") in vertices and alt <= dist[(i+1, j, "v")]:
                prev[(i+1, j, "v")] = current_point_direction
                dist[(i+1, j, "v")] = alt
                current_path_copy = current_path.copy()
                current_path_copy.append((i+1, j, "v"))
                heapq.heappush(points, (alt, ((i+1, j, "v", current_path_copy))))

        # Up
        if current_direction != "v":
            alt = dist[(current_point_direction[0], current_point_direction[1], current_point_direction[2])] + 1
            if current_direction == ">":
                alt += 1000
            if current_direction == "<":
                alt += 1000
            if (i-1, j, "^") in vertices and alt <= dist[(i-1, j, "^")]:
                prev[(i-1, j, "^")] = current_point_direction
                dist[(i-1, j, "^")] = alt
                current_path_copy = current_path.copy()
                current_path_copy.append((i-1, j, "^"))
                heapq.heappush(points, (alt, ((i-1, j, "^", current_path_copy))))


    # print(f"Min paths count: {len(path_list)}")

    unique_points = set()

    # Verify paths in path_list
    for path in path_list:
        score = 0
        start_direction = path[0][2]
        for i in range(1, len(path)):
            current_direction = path[i][2]
            score += 1
            if current_direction != start_direction:
                score += 1000
            start_direction = current_direction
        # print(f"Score: {score}")
        if score <= min_end_distance:
            for point in path:
                unique_points.add((point[0], point[1]))

    return len(unique_points)


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
