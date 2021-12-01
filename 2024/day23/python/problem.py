def problem_part1(input_list):
    one_to_many_map = {}
    for line in input_list:
        line_split = line.split("-")
        left_computer = line_split[0]
        right_computer = line_split[1]
        if left_computer not in one_to_many_map:
            one_to_many_map[left_computer] = {right_computer}
        else:
            one_to_many_map[left_computer].add(right_computer)
        if right_computer not in one_to_many_map:
            one_to_many_map[right_computer] = {left_computer}
        else:
            one_to_many_map[right_computer].add(left_computer)

    three_computer_set = set()
    for computer_1, computer_1_links in one_to_many_map.items(): # Iterate through all computers
        for computer_2 in computer_1_links:
            computer_2_links = one_to_many_map[computer_2]
            for computer_3 in computer_2_links:
                computer_3_links = {}
                if computer_3 != computer_1:
                    computer_3_links = one_to_many_map[computer_3]
                for computer_4 in computer_3_links:
                    if computer_4 == computer_1:
                        if (computer_1, computer_2, computer_3) not in three_computer_set \
                        and (computer_1, computer_3, computer_2) not in three_computer_set \
                        and (computer_2, computer_1, computer_3) not in three_computer_set \
                        and (computer_2, computer_3, computer_1) not in three_computer_set \
                        and (computer_3, computer_1, computer_2) not in three_computer_set \
                        and (computer_3, computer_2, computer_1) not in three_computer_set:
                            three_computer_set.add((computer_1, computer_2, computer_3))

    chief_historian_computer_set = set()
    for computer_set in three_computer_set:
        computer_1, computer_2, computer_3 = computer_set
        if computer_1[0] == "t" or computer_2[0] == "t" or computer_3[0] == "t":
            chief_historian_computer_set.add(computer_set)

    return len(chief_historian_computer_set)


def problem_part2(input_list):
    one_to_many_map = {}
    for line in input_list:
        line_split = line.split("-")
        left_computer = line_split[0]
        right_computer = line_split[1]
        if left_computer not in one_to_many_map:
            one_to_many_map[left_computer] = {right_computer}
        else:
            one_to_many_map[left_computer].add(right_computer)
        if right_computer not in one_to_many_map:
            one_to_many_map[right_computer] = {left_computer}
        else:
            one_to_many_map[right_computer].add(left_computer)

    all_overlapping_networks_map = {}

    # Iterate through each computer
    for computer, computer_links in one_to_many_map.items():
        computer_network = {computer}
        for computer_link in computer_links:
            computer_network.add(computer_link)
        computer_links_network_list = []
        for computer_link in computer_links:
            computer_link_links = one_to_many_map[computer_link]
            computer_links_network = {computer_link}
            for computer_link_link in computer_link_links:
                computer_links_network.add(computer_link_link)
            computer_links_network_list.append(computer_links_network)
        
        # Get overlapping networks for this computer and its computer_links
        for computer_link_network in computer_links_network_list:
            overlapping_network = set()
            for a_computer in computer_network:
                if a_computer in computer_link_network:
                    overlapping_network.add(a_computer)
            for a_computer_link in computer_link_network:
                if a_computer_link in computer_network:
                    overlapping_network.add(a_computer_link)
            overlapping_network_frozen = frozenset(overlapping_network)
            if overlapping_network_frozen in all_overlapping_networks_map:
                all_overlapping_networks_map[overlapping_network_frozen] += 1
            else:
                all_overlapping_networks_map[overlapping_network_frozen] = 1

    largest_network_candidates = []
    for overlapping_network, count in all_overlapping_networks_map.items():
        if (int(count / len(overlapping_network))) == (len(overlapping_network) - 1):
            largest_network_candidates.append(overlapping_network)

    largest_network_frozen = None
    largest_network_size = -1
    for candidate in largest_network_candidates:
        if len(candidate) > largest_network_size:
            largest_network_frozen = candidate
            largest_network_size = len(candidate)

    largest_network = list(largest_network_frozen)
    largest_network.sort()
    largest_network_string = ",".join(largest_network)

    return largest_network_string
    # return "co,de,ka,ta"


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