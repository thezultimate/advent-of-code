import heapq


def problem_part1(input_list, min_saving=50):
    start_point = (-1, -1)
    end_point = (-1, -1)

    inside_wall_points = set()

    vertices_orig = set()
    prev_orig = {}
    dist_orig = {}
    points_orig = []

    for i, line in enumerate(input_list):
        for j, char in enumerate(line):
            if char == "S":
                start_point = (i, j)
            if char == "E":
                end_point = (i, j)
            if char == "#":
                if i != 0 and j != 0 and i != len(input_list)-1 and j != len(input_list[0])-1:
                    inside_wall_points.add((i, j))
            if char != "#":
                vertices_orig.add((i, j))
                prev_orig[(i, j)] = None
                dist_orig[(i, j)] = float('inf')

    # Run Dijkstra once to get the shortest path without cheating
    vertices = vertices_orig.copy()
    prev = prev_orig.copy()
    dist = dist_orig.copy()
    points = []

    # Dijkstra with priority queue
    dist[start_point] = 0
    heapq.heappush(points, (0, (start_point)))

    while points:
        current_dist, current_point = heapq.heappop(points)
        if current_point == end_point:
            # print(f"End reached in {current_dist} steps without wall removed")
            break

        i = current_point[0]
        j = current_point[1]
        alt = dist[(i, j)] + 1

        # Left
        if (i, j-1) in vertices and alt < dist[(i, j-1)]:
            prev[(i, j-1)] = (i, j)
            dist[(i, j-1)] = alt
            heapq.heappush(points, (alt, (i, j-1)))

        # Right
        if (i, j+1) in vertices and alt < dist[(i, j+1)]:
            prev[(i, j+1)] = (i, j)
            dist[(i, j+1)] = alt
            heapq.heappush(points, (alt, (i, j+1)))

        # Down
        if (i+1, j) in vertices and alt < dist[(i+1, j)]:
            prev[(i+1, j)] = (i, j)
            dist[(i+1, j)] = alt
            heapq.heappush(points, (alt, (i+1, j)))

        # Up
        if (i-1, j) in vertices and alt < dist[(i-1, j)]:
            prev[(i-1, j)] = (i, j)
            dist[(i-1, j)] = alt
            heapq.heappush(points, (alt, (i-1, j)))
    # End of first Dijkstra run

    shortest_steps_orig = dist[end_point]

    min_saving_count = 0

    for wall in inside_wall_points:
        i_wall = wall[0]
        j_wall = wall[1]
        dots_count = 0

        # Check if left of wall is . or S or E
        if input_list[i_wall][j_wall-1] != "#":
            dots_count += 1

        # Check if right of wall is . or S or E
        if input_list[i_wall][j_wall+1] != "#":
            dots_count += 1

        # Check if down of wall is . or S or E
        if input_list[i_wall+1][j_wall] != "#":
            dots_count += 1

        # Check if up of wall is . or S or E
        if input_list[i_wall-1][j_wall] != "#":
            dots_count += 1

        if dots_count >= 2: # If wall has at least 2 empty space, remove this wall and perform Dijkstra
            vertices = vertices_orig.copy()
            prev = prev_orig.copy()
            dist = dist_orig.copy()
            points = []

            vertices.add((i_wall, j_wall)) # Add this wall as a passable vertex
            prev[(i_wall, j_wall)] = None
            dist[(i_wall, j_wall)] = float('inf')
    
            # Dijkstra with priority queue
            dist[start_point] = 0
            heapq.heappush(points, (0, (start_point)))

            while points:
                current_dist, current_point = heapq.heappop(points)
                if current_point == end_point:
                    # print(f"End reached in {current_dist} steps with wall removed at ({i_wall}, {j_wall})")
                    break

                i = current_point[0]
                j = current_point[1]
                alt = dist[(i, j)] + 1

                # Left
                if (i, j-1) in vertices and alt < dist[(i, j-1)]:
                    prev[(i, j-1)] = (i, j)
                    dist[(i, j-1)] = alt
                    heapq.heappush(points, (alt, (i, j-1)))

                # Right
                if (i, j+1) in vertices and alt < dist[(i, j+1)]:
                    prev[(i, j+1)] = (i, j)
                    dist[(i, j+1)] = alt
                    heapq.heappush(points, (alt, (i, j+1)))

                # Down
                if (i+1, j) in vertices and alt < dist[(i+1, j)]:
                    prev[(i+1, j)] = (i, j)
                    dist[(i+1, j)] = alt
                    heapq.heappush(points, (alt, (i+1, j)))

                # Up
                if (i-1, j) in vertices and alt < dist[(i-1, j)]:
                    prev[(i-1, j)] = (i, j)
                    dist[(i-1, j)] = alt
                    heapq.heappush(points, (alt, (i-1, j)))

            current_shortest_steps = dist[end_point]
            current_saving = shortest_steps_orig - current_shortest_steps
            # print(f"Steps: {current_shortest_steps}, saving: {current_saving}")

            if current_saving >= min_saving:
                min_saving_count += 1
                print(f"Passed min saving! Steps: {current_shortest_steps}, saving: {current_saving}. Current saving count: {min_saving_count}")

    return min_saving_count


def problem_part2(input_list, min_saving=70):
    start_point = (-1, -1)
    end_point = (-1, -1)

    inside_wall_points = set()

    vertices_orig = set()
    prev_orig = {}
    dist_orig = {}

    for i, line in enumerate(input_list):
        for j, char in enumerate(line):
            if char == "S":
                start_point = (i, j)
            if char == "E":
                end_point = (i, j)
            if char == "#":
                if i != 0 and j != 0 and i != len(input_list)-1 and j != len(input_list[0])-1:
                    inside_wall_points.add((i, j))
            if char != "#":
                vertices_orig.add((i, j))
                prev_orig[(i, j)] = None
                dist_orig[(i, j)] = float('inf')

    # Run Dijkstra once to get the shortest path without cheating
    vertices = vertices_orig.copy()
    prev = prev_orig.copy()
    dist = dist_orig.copy()
    points = []

    # Dijkstra with priority queue
    dist[start_point] = 0
    path_points = []
    heapq.heappush(points, (0, (start_point, path_points)))

    while points:
        current_dist, current_point = heapq.heappop(points)
        if current_point == end_point:
            print(f"End reached in {current_dist} steps without wall removed")
            break

        i = current_point[0][0]
        j = current_point[0][1]
        current_path = current_point[1]
        alt = dist[(i, j)] + 1

        # Left
        if (i, j-1) in vertices and alt < dist[(i, j-1)]:
            prev[(i, j-1)] = (i, j)
            dist[(i, j-1)] = alt
            current_path.append((i, j))
            heapq.heappush(points, (alt, ((i, j-1), current_path)))

        # Right
        if (i, j+1) in vertices and alt < dist[(i, j+1)]:
            prev[(i, j+1)] = (i, j)
            dist[(i, j+1)] = alt
            current_path.append((i, j))
            heapq.heappush(points, (alt, ((i, j+1), current_path)))

        # Down
        if (i+1, j) in vertices and alt < dist[(i+1, j)]:
            prev[(i+1, j)] = (i, j)
            dist[(i+1, j)] = alt
            current_path.append((i, j))
            heapq.heappush(points, (alt, ((i+1, j), current_path)))

        # Up
        if (i-1, j) in vertices and alt < dist[(i-1, j)]:
            prev[(i-1, j)] = (i, j)
            dist[(i-1, j)] = alt
            current_path.append((i, j))
            heapq.heappush(points, (alt, ((i-1, j), current_path)))
    # End of first Dijkstra run

    shortest_steps_orig = dist[end_point]
    print(f"Shortest path steps: {shortest_steps_orig}")
    print(path_points)

    min_saving_count = 0

    # All points' distances are in dist, no need to run Dijkstra anymore. Brute force for now.
    for i, start_cheat_point in enumerate(path_points):
        i_start_cheat_point = (start_cheat_point[0])
        j_start_cheat_point = (start_cheat_point[1])
        for max_depth in range (2, 21): # Get radius points of start_cheat_point
            end_cheat_point_radius_set = set()
            for left in range(max_depth+1):
                right = max_depth - left
                down_left_point = (left, -right) # 0,-2 = 1,-1 = 2,-0
                down_right_point = (left, right) # 0,2 = 1,1 = 2,0
                up_left_point = (-right, -left) # -2,-0 = -1,-1 = -0,-2
                up_right_point = (-right, left) # -2,0 = -1,1 = -0,2
                end_cheat_point_radius_set.add(down_left_point)
                end_cheat_point_radius_set.add(down_right_point)
                end_cheat_point_radius_set.add(up_left_point)
                end_cheat_point_radius_set.add(up_right_point)

            for end_cheat_point_radius in end_cheat_point_radius_set:
                end_cheat_point = (i_start_cheat_point + end_cheat_point_radius[0], j_start_cheat_point + end_cheat_point_radius[1])
                if end_cheat_point in vertices:
                    end_cheat_point_steps = dist[end_cheat_point]
                    remaining_steps = shortest_steps_orig - end_cheat_point_steps
                    current_shortest_steps = dist[start_cheat_point] + max_depth + remaining_steps
                    current_saving = shortest_steps_orig - current_shortest_steps
                    # print(f"Steps: {current_shortest_steps}, saving: {current_saving}")
                    if current_saving >= min_saving:
                        min_saving_count += 1
                        print(f"Passed min saving! Steps: {current_shortest_steps}, saving: {current_saving}. Current saving count: {min_saving_count}")

    return min_saving_count
    # return 41


def run_dijkstra(start_point, end_point, vertices, prev, dist):
    # Dijkstra with priority queue
    points = []
    dist[start_point] = 0
    heapq.heappush(points, (0, (start_point)))

    while points:
        current_dist, current_point = heapq.heappop(points)
        if current_point == end_point:
            # print(f"End reached in {current_dist} steps")
            break

        i = current_point[0]
        j = current_point[1]
        alt = dist[(i, j)] + 1

        # Left
        if (i, j-1) in vertices and alt < dist[(i, j-1)]:
            prev[(i, j-1)] = (i, j)
            dist[(i, j-1)] = alt
            heapq.heappush(points, (alt, (i, j-1)))

        # Right
        if (i, j+1) in vertices and alt < dist[(i, j+1)]:
            prev[(i, j+1)] = (i, j)
            dist[(i, j+1)] = alt
            heapq.heappush(points, (alt, (i, j+1)))

        # Down
        if (i+1, j) in vertices and alt < dist[(i+1, j)]:
            prev[(i+1, j)] = (i, j)
            dist[(i+1, j)] = alt
            heapq.heappush(points, (alt, (i+1, j)))

        # Up
        if (i-1, j) in vertices and alt < dist[(i-1, j)]:
            prev[(i-1, j)] = (i, j)
            dist[(i-1, j)] = alt
            heapq.heappush(points, (alt, (i-1, j)))

    return dist[end_point]


def read_file_to_list(file_path):
    with open(file_path, 'r') as file:
        lines = [line.strip() for line in file]
    return lines


def main():
    file_path = 'input.txt'
    input_list = read_file_to_list(file_path)
    
    result_part1 = problem_part1(input_list, min_saving=100)
    print(f"Result of problem_part1: {result_part1}")
    result_part2 = problem_part2(input_list, min_saving=100)
    print(f"Result of problem_part2: {result_part2}")


if __name__ == "__main__":
    main()