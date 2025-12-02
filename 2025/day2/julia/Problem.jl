function problem_part1(input_string)
    range_string = split(input_string, ",")
    sum = 0
    for range in range_string
        bounds = split(range, "-")
        lower_string = bounds[1]
        upper_string = bounds[2]
        
        # Both bounds have the same length and that length is odd
        if length(lower_string) == length(upper_string) && isodd(length(lower_string))
            continue
        end

        lower_int = parse(Int, lower_string)
        upper_int = parse(Int, upper_string)
        for num in lower_int:upper_int
            if isodd(ndigits(num)) # Skip odd digit numbers
                continue
            end

            # Even digit numbers
            num_string = string(num)
            half_length = div(length(num_string), 2)
            first_half = num_string[1:half_length]
            second_half = num_string[half_length+1:end]
            if first_half == second_half
                sum += num
            end
        end
    end

    return sum
end

function problem_part2(input_string)
    range_string = split(input_string, ",")
    sum = 0
    invalid_numbers = Set{Int64}()
    
    for range in range_string
        bounds = split(range, "-")
        lower_int = parse(Int, bounds[1])
        upper_int = parse(Int, bounds[2])
        for num in lower_int:upper_int
            num_string = string(num)

            if length(num_string) == 1 # Omit single digit numbers
                continue
            end

            # Odd digit numbers
            if isodd(ndigits(num))
                char_array = collect(num_string)
                if all(isequal(char_array[1]), char_array)
                    push!(invalid_numbers, num)
                end
            end

            # Even digit numbers
            for n in 1:(div(length(num_string), 2))
                chunks = [num_string[i:min(i + n - 1, end)] for i in 1:n:length(num_string)]
                if all(isequal(chunks[1]), chunks)
                    push!(invalid_numbers, num)
                end
            end
        end
    end

    for num in invalid_numbers
        sum += num
    end

    return sum
end