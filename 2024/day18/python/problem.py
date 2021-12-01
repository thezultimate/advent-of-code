import heapq

def problem_part1(input_list, grid_length=7, bytes_falling=12):
    incoming_byte_positions = []
    for line in input_list:
        line_split = line.split(',')
        i = int(line_split[1])
        j = int(line_split[0])
        incoming_byte_positions.append((i, j))

    corrupted_points = set()
    for i in range(bytes_falling):
        current_byte_position = incoming_byte_positions[i]
        corrupted_points.add(current_byte_position)

    start_point = (0, 0)
    end_point = (grid_length - 1, grid_length - 1)

    vertices = set()
    prev = {}
    dist = {}
    points = []
    heapq.heappush(points, (0, ((start_point[0], start_point[1]))))

    for i in range(grid_length):
        for j in range(grid_length):
            if (i, j) not in corrupted_points:
                vertices.add((i, j))
                prev[(i, j)] = None
                dist[(i, j)] = float('inf')
        
    dist[(start_point[0], start_point[1])] = 0

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

        # Up
        if (i-1, j) in vertices and alt < dist[(i-1, j)]:
            prev[(i-1, j)] = (i, j)
            dist[(i-1, j)] = alt
            heapq.heappush(points, (alt, (i-1, j)))

        # Down
        if (i+1, j) in vertices and alt < dist[(i+1, j)]:
            prev[(i+1, j)] = (i, j)
            dist[(i+1, j)] = alt
            heapq.heappush(points, (alt, (i+1, j)))

    return dist[end_point]


def problem_part2(input_list, grid_length=7):
    incoming_byte_positions = []
    for line in input_list:
        line_split = line.split(',')
        i = int(line_split[1])
        j = int(line_split[0])
        incoming_byte_positions.append((i, j))

    index_blocking_stone = -1

    for bytes_falling in range(len(incoming_byte_positions)):
        corrupted_points = set()
        for i in range(bytes_falling):
            current_byte_position = incoming_byte_positions[i]
            corrupted_points.add(current_byte_position)

        start_point = (0, 0)
        end_point = (grid_length - 1, grid_length - 1)

        vertices = set()
        prev = {}
        dist = {}
        points = []
        heapq.heappush(points, (0, ((start_point[0], start_point[1]))))

        for i in range(grid_length):
            for j in range(grid_length):
                if (i, j) not in corrupted_points:
                    vertices.add((i, j))
                    prev[(i, j)] = None
                    dist[(i, j)] = float('inf')
            
        dist[(start_point[0], start_point[1])] = 0

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

            # Up
            if (i-1, j) in vertices and alt < dist[(i-1, j)]:
                prev[(i-1, j)] = (i, j)
                dist[(i-1, j)] = alt
                heapq.heappush(points, (alt, (i-1, j)))

            # Down
            if (i+1, j) in vertices and alt < dist[(i+1, j)]:
                prev[(i+1, j)] = (i, j)
                dist[(i+1, j)] = alt
                heapq.heappush(points, (alt, (i+1, j)))

        # print(f"Bytes falling: {bytes_falling}, distance: {dist[end_point]}")
        if dist[end_point] == float('inf'):
            index_blocking_stone = bytes_falling
            break

    result = "" + str(incoming_byte_positions[index_blocking_stone-1][1]) + "," + str(incoming_byte_positions[index_blocking_stone-1][0])
    return result

    # return "6,1"


def read_file_to_list(file_path):
    with open(file_path, 'r') as file:
        lines = [line.strip() for line in file]
    return lines


def main():
    file_path = 'input.txt'
    input_list = read_file_to_list(file_path)
    
    result_part1 = problem_part1(input_list, grid_length=71, bytes_falling=1024)
    print(f"Result of problem_part1: {result_part1}")
    
    result_part2 = problem_part2(input_list, grid_length=71)
    print(f"Result of problem_part2: {result_part2}")


if __name__ == "__main__":
    main()