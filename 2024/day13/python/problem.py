def problem_part1(input_list):
    claw_machines = []
    claw_machine_info = {}
    x_a = 0
    y_a = 0
    x_b = 0
    y_b = 0
    prize_x = 0
    prize_y = 0
    for line in input_list:
        if line != "":
            if "Button A" in line:
                button = line.split(":")[0].split(" ")[1]
                x_a = int(line.split("X+")[1].split(",")[0])
                y_a = int(line.split("Y+")[1])
                # print(f"{button} {x} {y}")
                

            if "Button B" in line:
                button = line.split(":")[0].split(" ")[1]
                x_b = int(line.split("X+")[1].split(",")[0])
                y_b = int(line.split("Y+")[1])
                # print(f"{button} {x} {y}")
                
            if "Prize" in line:
                prize_x = int(line.split("X=")[1].split(",")[0])
                prize_y = int(line.split("Y=")[1])
                # print(f"Prize {prize_x} {prize_y}")
        else:
            claw_machine_info = {
                "x_a": x_a,
                "y_a": y_a,
                "x_b": x_b,
                "y_b": y_b,
                "prize_x": prize_x,
                "prize_y": prize_y
            }
            claw_machines.append(claw_machine_info)
            x_a = 0
            y_a = 0
            x_b = 0
            y_b = 0
            prize_x = 0
            prize_y = 0
            continue

    total_cheapset_cost = 0
    for claw_machine in claw_machines:
        current_cheapest_cost = count_cheapest_cost(claw_machine)
        total_cheapset_cost += current_cheapest_cost

    return total_cheapset_cost


def count_cheapest_cost(claw_machine):
    x_a = claw_machine["x_a"]
    y_a = claw_machine["y_a"]
    x_b = claw_machine["x_b"]
    y_b = claw_machine["y_b"]
    prize_x = claw_machine["prize_x"]
    prize_y = claw_machine["prize_y"]

    max_iterations = 100
    min_cost = 999999999
    for i in range(1, max_iterations + 1):
        for j in range(1, max_iterations + 1):
            if (x_a * i) + (x_b * j) == prize_x and (y_a * i) + (y_b * j) == prize_y:
                current_cost = i * 3 + j * 1
                if current_cost < min_cost:
                    min_cost = current_cost
    
    if min_cost == 999999999:
        return 0
    
    return min_cost


def problem_part2(input_list):
    claw_machines = []
    claw_machine_info = {}
    x_a = 0
    y_a = 0
    x_b = 0
    y_b = 0
    prize_x = 0
    prize_y = 0
    for line in input_list:
        if line != "":
            if "Button A" in line:
                button = line.split(":")[0].split(" ")[1]
                x_a = int(line.split("X+")[1].split(",")[0])
                y_a = int(line.split("Y+")[1])
                # print(f"{button} {x} {y}")
                

            if "Button B" in line:
                button = line.split(":")[0].split(" ")[1]
                x_b = int(line.split("X+")[1].split(",")[0])
                y_b = int(line.split("Y+")[1])
                # print(f"{button} {x} {y}")
                
            if "Prize" in line:
                prize_x = int(line.split("X=")[1].split(",")[0])
                prize_y = int(line.split("Y=")[1])
                # print(f"Prize {prize_x} {prize_y}")
        else:
            claw_machine_info = {
                "x_a": x_a,
                "y_a": y_a,
                "x_b": x_b,
                "y_b": y_b,
                "prize_x": prize_x,
                "prize_y": prize_y
            }
            claw_machines.append(claw_machine_info)
            x_a = 0
            y_a = 0
            x_b = 0
            y_b = 0
            prize_x = 0
            prize_y = 0
            continue

    total_cheapset_cost = 0
    for claw_machine in claw_machines:
        current_cheapest_cost = count_cheapest_cost2(claw_machine)
        total_cheapset_cost += current_cheapest_cost

    return total_cheapset_cost


def count_cheapest_cost2(claw_machine):
    x_a = claw_machine["x_a"]
    y_a = claw_machine["y_a"]
    x_b = claw_machine["x_b"]
    y_b = claw_machine["y_b"]
    prize_x = claw_machine["prize_x"] + 10000000000000
    prize_y = claw_machine["prize_y"] + 10000000000000

    j = round(((prize_y / y_a) - (prize_x / x_a)) / ((y_b / y_a) - (x_b / x_a)))
    i = round((prize_x - (x_b * j)) / x_a)
    if (x_a * i) + (x_b * j) != prize_x or (y_a * i) + (y_b * j) != prize_y:
        return 0
    
    min_cost = i * 3 + j * 1
    return min_cost


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