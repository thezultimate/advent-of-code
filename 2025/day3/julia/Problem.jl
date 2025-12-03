function problem_part1(input_vector)
    total_sum = 0
    for line in input_vector
        max_first = -1
        max_first_index = 999999
        max_second = -1
        for (i, char) in enumerate(line)
            # println("i: $i, char: $char")
            if i == length(line)
                continue
            end
            joltage = parse(Int, char)
            if joltage > max_first
                max_first = joltage
                max_first_index = i
            end
        end
        for i=max_first_index+1:length(line)
            char = line[i]
            joltage = parse(Int, char)
            if joltage > max_second
                max_second = joltage
            end
        end
        total_sum += parse(Int, string(max_first) * string(max_second))
    end

    return total_sum
end

function problem_part2(input_vector)
    total_sum = 0
    for line in input_vector
        max_joltage_string = ""
        start_index = 1
        for i=1:12
            current_max_joltage = -1
            max_iter_index = length(line) - (12 - i)
            for j=start_index:max_iter_index
                char = line[j]
                joltage = parse(Int, char)
                if joltage > current_max_joltage
                    current_max_joltage = joltage
                    current_max_index = j
                    start_index = current_max_index + 1
                end
            end
            max_joltage_string *= string(current_max_joltage)
        end
        total_sum += parse(Int, max_joltage_string)
    end

    return total_sum
end