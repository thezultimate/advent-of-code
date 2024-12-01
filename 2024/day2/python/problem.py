def problem_part1(input_list):
    safe_reports_count = 0
    for report in input_list:
        level_list = [int(x) for x in report.split()]
        if is_safe(level_list):
            safe_reports_count += 1
    return safe_reports_count


def is_safe(report):
    is_increasing = False
    if report[0] < report[1]:
        is_increasing = True
    for i in range(len(report)):
        if i+1 < len(report):
            if report[i] == report[i+1]:
                return False
            diff = abs(report[i] - report[i+1])
            if diff < 1 or diff > 3:
                return False
            if is_increasing:
                if report[i] > report[i+1]:
                    return False
            if not is_increasing:
                if report[i] < report[i+1]:
                    return False    
        
    return True


def problem_part2(input_list):
    safe_reports_count = 0
    for report in input_list:
        level_list = [int(x) for x in report.split()]
        if is_safe(level_list):
            safe_reports_count += 1
        else: # Remove one level
            for i in range(len(level_list)):
                level_list_copy = level_list.copy()
                level_list_copy.pop(i)
                if is_safe(level_list_copy):
                    safe_reports_count += 1
                    break
    return safe_reports_count


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