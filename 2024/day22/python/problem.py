def problem_part1(input_list):
    sum = 0
    for line in input_list:
        initial_secret_number = int(line)
        secret_number = get_nth_secret_number(initial_secret_number, 2000)
        sum += secret_number

    return sum
    # return 37327623


def get_nth_secret_number(secret_number, n):
    for i in range(n):
        mul = secret_number * 64
        mul_mix = mul ^ secret_number
        mul_prune = mul_mix % 16777216
        div = mul_prune // 32
        div_mix = div ^ mul_prune
        div_prune = div_mix % 16777216
        mul2 = div_prune * 2048
        mul2_mix = mul2 ^ div_prune
        mul2_prune = mul2_mix % 16777216
        secret_number = mul2_prune
    # print(secret_number)

    return secret_number
    # return 5908254


def problem_part2(input_list):
    unique_sequence_highest_price_set = set()
    all_price_diff_list = []

    for line in input_list:
        initial_secret_number = int(line)
        price_diff_list, highest_price = get_nth_secret_number2(initial_secret_number, 2000)
        all_price_diff_list.append(price_diff_list)
        # print(highest_price)
        for i, price_diff in enumerate(price_diff_list):
            # print(price_diff)
            current_price, current_price_diff = price_diff
            if current_price == highest_price:
                if i + 1 - 4 >= 0:
                    unique_sequence_highest_price_set.add((price_diff_list[i-3][1], price_diff_list[i-2][1], price_diff_list[i-1][1], price_diff_list[i][1]))
            
    max_sum = 0
    for unique_sequence_highest_price in unique_sequence_highest_price_set: # When in vacation, brute force while dining out :)
        # if (unique_sequence_highest_price == (-2, 1, -1, 3)):
        #     print("Start")
        sum = 0
        for price_diff_list in all_price_diff_list:
            for i in range (3, len(price_diff_list)-1):
                if ((price_diff_list[i-3][1], price_diff_list[i-2][1], price_diff_list[i-1][1], price_diff_list[i][1]) == unique_sequence_highest_price):
                    current_price = price_diff_list[i][0]
                    sum += current_price
                    break
        if max_sum < sum:
            max_sum = sum
            print(max_sum)

    return max_sum 
    # return 23


def get_nth_secret_number2(secret_number, n):
    secret_number_string = str(secret_number)
    prev_last_digit = int(secret_number_string[len(secret_number_string)-1])
    highest_price = -1
    # price_diff_map = {}
    price_diff_list = []
    for i in range(n):
        mul = secret_number * 64
        mul_mix = mul ^ secret_number
        mul_prune = mul_mix % 16777216
        div = mul_prune // 32
        div_mix = div ^ mul_prune
        div_prune = div_mix % 16777216
        mul2 = div_prune * 2048
        mul2_mix = mul2 ^ div_prune
        mul2_prune = mul2_mix % 16777216
        secret_number = mul2_prune
        secret_number_string = str(secret_number)
        last_digit = int(secret_number_string[len(secret_number_string)-1])
        last_digit_diff = last_digit - prev_last_digit
        prev_last_digit = last_digit
        # price_diff_map[secret_number] = (last_digit, last_digit_diff)
        price_diff_list.append((last_digit, last_digit_diff))
        if last_digit > highest_price:
            highest_price = last_digit
        # print(secret_number)
        # print(f"{last_digit}, {last_digit_diff}")
    
    # print(f"Highest price: {highest_price}")

    # return (price_diff_map, highest_price)
    return (price_diff_list, highest_price)
    # return 5908254


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