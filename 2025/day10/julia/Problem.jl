using DataStructures

function problem_part1(input_vector)
    total_min_presses = 0

    for line in input_vector
        lights_split_line = split(line, ']')
        lights = lights_split_line[1][2:end]
        lights_vector = collect(lights)
        buttons_split_line = split(lights_split_line[2], '{')
        buttons = buttons_split_line[1][2:end-1]
        buttons_vector = split(buttons, ' ')
        buttons_vector = replace.(buttons_vector, '(' => "")
        buttons_vector = replace.(buttons_vector, ')' => "")
        buttons_vector = split.(buttons_vector, ',')
        buttons_vector = [parse.(Int, btn) for btn in buttons_vector]

        min_press = 999999999999
        max_digit = 1
        buttons_length = length(buttons_vector)
        buttons_press_combinations = zeros(Int, buttons_length)

        # Generate button push combinations BFS
        queue = Queue{Tuple{Vector{Int}, Int}}()
        enqueue!(queue, (buttons_press_combinations, max_digit))
        while !isempty(queue)
            current = dequeue!(queue)
            current_combinations = current[1]
            # println("Current: ", current)

            # Process push button combination
            lights_vector_copy = fill('.', length(lights_vector))
            for i in eachindex(current_combinations)
                current_push_count = current_combinations[i]
                if current_push_count > 0
                    # Push 1X
                    current_buttons_to_push = buttons_vector[i]
                    for button_push in current_buttons_to_push
                        if lights_vector_copy[button_push + 1] == '#'
                            lights_vector_copy[button_push + 1] = '.'
                        else
                            lights_vector_copy[button_push + 1] = '#'
                        end
                    end
                end
            end
            if join(lights_vector_copy, "") == lights
                sum_button_presses = sum(current_combinations)
                # println("Found matching combination: ", current_combinations, " with total presses: ", sum_button_presses)
                if sum_button_presses < min_press
                    min_press = sum_button_presses
                end
            end

            # Enqueue new combinations
            for i in eachindex(current_combinations)
                current_combinations_copy = copy(current_combinations)
                current_combinations_copy[i] += 1
                if current_combinations_copy[i] <= max_digit && !((current_combinations_copy, max_digit) in queue)
                    enqueue!(queue, (current_combinations_copy, max_digit))
                end
            end
        end

        # println("Minimum presses for line '", line, "': ", min_press)
        total_min_presses += min_press
    end

    # println("Total minimum presses: ", total_min_presses)
    return total_min_presses
end

# Part 2 works for test input but is too slow for real input
function problem_part2(input_vector)
    total_min_presses = 0

    for line in input_vector
        lights_split_line = split(line, ']')
        buttons_split_line = split(lights_split_line[2], '{')
        buttons = buttons_split_line[1][2:end-1]
        buttons_vector = split(buttons, ' ')
        buttons_vector = replace.(buttons_vector, '(' => "")
        buttons_vector = replace.(buttons_vector, ')' => "")
        buttons_vector = split.(buttons_vector, ',')
        buttons_vector = [parse.(Int, btn) for btn in buttons_vector]
        joltage_vector = buttons_split_line[2]
        joltage_vector = replace(joltage_vector, '}' => "")
        joltage_vector = split(joltage_vector, ',')
        joltage_vector = parse.(Int, joltage_vector)
        # println("------")
        # println("Button vector: ", buttons_vector)
        # println("Joltage vector: ", joltage_vector)

        # Build equations
        equations = []
        for i in eachindex(joltage_vector)
            sum_indices = []
            for j in eachindex(buttons_vector)
                if i-1 in buttons_vector[j]
                    push!(sum_indices, j)
                end
            end
            push!(equations, sum_indices)
        end
        # println("Equations: ", equations)

        min_press = 999999999999
        max_digit = maximum(joltage_vector)
        buttons_length = length(buttons_vector)
        buttons_press_combinations = zeros(Int, buttons_length)

        # Generate button push combinations BFS
        queue = Queue{Tuple{Vector{Int}, Int}}()
        enqueue!(queue, (buttons_press_combinations, max_digit))
        while !isempty(queue)
            current = dequeue!(queue)
            current_combinations = current[1]
            # println("Current combination: ", current_combinations)

            # Process push button combination
            is_equations_satisfied = true
            for i in eachindex(equations)
                sum_value = 0
                for btn_index in equations[i]
                    sum_value += current_combinations[btn_index]
                end
                if sum_value != joltage_vector[i]
                    # One of the equations is not satisfied
                    is_equations_satisfied = false
                    break
                end
            end
            if is_equations_satisfied
                sum_button_presses = sum(current_combinations)
                # println("Found matching combination: ", current_combinations, " with total presses: ", sum_button_presses)
                if sum_button_presses < min_press
                    min_press = sum_button_presses
                    break
                end
            end

            # joltage_vector_copy = fill(0, length(joltage_vector))
            # for i in eachindex(current_combinations)
            #     current_push_count = current_combinations[i]
            #     if current_push_count > 0
            #         # Push current_push_count times
            #         current_buttons_to_push = buttons_vector[i]
            #         for button_push in current_buttons_to_push
            #             joltage_vector_copy[button_push + 1] += current_push_count
            #         end
            #     end
            # end
            # # println("Joltage vector copy: ", joltage_vector_copy)
            # if joltage_vector_copy == joltage_vector
            #     sum_button_presses = sum(current_combinations)
            #     # println("Found matching combination: ", current_combinations, " with total presses: ", sum_button_presses)
            #     if sum_button_presses < min_press
            #         min_press = sum_button_presses
            #         break
            #     end
            # end
            
            # Enqueue new combinations
            for i in eachindex(current_combinations)
                current_combinations_copy = copy(current_combinations)
                current_combinations_copy[i] += 1
                if current_combinations_copy[i] <= max_digit && !((current_combinations_copy, max_digit) in queue)
                    enqueue!(queue, (current_combinations_copy, max_digit))
                end
            end
        end

        # println("Minimum presses for line '", line, "': ", min_press)
        total_min_presses += min_press
    end

    # println("Total minimum presses: ", total_min_presses)
    return total_min_presses
end