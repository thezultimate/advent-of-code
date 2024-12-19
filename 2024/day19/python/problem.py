def problem_part1(input_list):
    brand_list = []
    stripe_list = []
    for line in input_list:
        if len(line) == 0:
            continue
        if "," not in line:
            brand_list.append(line)
        else:
            stripe_list = line.split(", ")

    can_brand_striped_count = 0
    for brand in brand_list:
        can_brand_striped = is_brand_stripeable(brand, stripe_list)
        if can_brand_striped:
            can_brand_striped_count += 1

    return can_brand_striped_count


def is_brand_stripeable(brand, stripe_list):
    result = False
    for stripe in stripe_list:
        # Terminating case
        if stripe == brand:
            result = True
            break

        if len(stripe) > len(brand):
            continue
        
        is_char_all_same = True
        for i, char in enumerate(stripe):
            if char != brand[i]:
                is_char_all_same = False
                break
        if not is_char_all_same:
            continue
        
        # Recursive case
        can_next_brand_substring_striped = is_brand_stripeable(brand[len(stripe):], stripe_list)
        if can_next_brand_substring_striped:
            result = True
            break
        else:
            continue

    return result


def problem_part2(input_list):
    brand_list = []
    stripe_list = []
    for line in input_list:
        if len(line) == 0:
            continue
        if "," not in line:
            brand_list.append(line)
        else:
            stripe_list = line.split(", ")

    total_ways = 0
    memo = {}
    for brand in brand_list:
    # for brand in ["bbrgwb"]:
        ways = count_stripeable_ways(brand, stripe_list, memo)
        # print(ways)
        total_ways += ways

    return total_ways


def count_stripeable_ways(brand, stripe_list, memo):
    if brand in memo:
        # print("Hit!")
        return memo[brand]

    count = 0
    for stripe in stripe_list:
        # Terminating case
        if stripe == brand:
            count += 1
            # print("Found!")
            continue

        if len(stripe) > len(brand):
            continue
        
        is_char_all_same = True
        for i, char in enumerate(stripe):
            if char != brand[i]:
                is_char_all_same = False
                break
        if not is_char_all_same:
            continue
        
        # Recursive case
        can_next_brand_substring_striped = count_stripeable_ways(brand[len(stripe):], stripe_list, memo)
        count += can_next_brand_substring_striped

    memo[brand] = count
    return count


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