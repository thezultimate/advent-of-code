function problem_part1(input_vector)
    zero_left_counter = 0
    current_pos = 50
    for line in input_vector
        num_turn = -1
        direction = Nothing
        if startswith(line, "L")
            split_line = split(line, "L")
            num_turn = parse(Int, split_line[2])
            direction = 'L'
        else
            split_line = split(line, "R")
            num_turn = parse(Int, split_line[2])
            direction = 'R'
        end
        if direction == 'L'
            current_pos -= num_turn
            current_pos = mod(current_pos, 100)
        else
            current_pos += num_turn
            current_pos = mod(current_pos, 100)
        end
        if current_pos == 0
            zero_left_counter += 1
        end
    end

    return zero_left_counter
end

function problem_part2(input_vector)
    new_counter = 0
    current_pos = 50
    for line in input_vector
        num_turn = -1
        direction = Nothing
        if startswith(line, "L")
            split_line = split(line, "L")
            num_turn = parse(Int, split_line[2])
            direction = 'L'
        else
            split_line = split(line, "R")
            num_turn = parse(Int, split_line[2])
            direction = 'R'
        end

        div_turn = div(num_turn, 100)
        new_counter += div_turn
        mod_turn = mod(num_turn, 100)

        if direction == 'L'
            prev_pos = current_pos
            current_pos -= mod_turn
            if current_pos < 0 && prev_pos != 0
                new_counter += 1
            end
            current_pos = mod(current_pos, 100)
        else # right direction
            prev_pos = current_pos
            current_pos += mod_turn
            if current_pos > 100 && prev_pos != 0
                new_counter += 1
            end
            current_pos = mod(current_pos, 100)
        end
        if current_pos == 0
            new_counter += 1
        end
    end

    return new_counter
    # return 6
end