function problem_part1(input_vector)
    number_grid = []
    operators = Nothing
    grand_total = 0
    result_vector = []

    for line in input_vector
        if !occursin("*", line) && !occursin("+", line)
            numbers = parse.(Int, split(strip(line)))
            push!(number_grid, numbers)
        else
            operators = split(strip(line))
            for op in operators
                if op == "+"
                    push!(result_vector, 0) # Addition
                else
                    push!(result_vector, 1) # Multiplication
                end
            end
        end
    end

    for number_line in number_grid
        for (i, number) in enumerate(number_line)
            if operators[i] == "+"
                result_vector[i] += number
            else
                result_vector[i] *= number
            end
        end
    end

    grand_total = sum(result_vector)
    return grand_total
end

function problem_part2(input_vector)
    number_grid = []
    operators = Nothing
    grand_total = 0
    result_vector = []

    for line in input_vector
        if !occursin("*", line) && !occursin("+", line)
            numbers = split(strip(line))
            push!(number_grid, numbers)
        else
            operators = split(strip(line))
            for op in operators
                if op == "+"
                    push!(result_vector, 0) # Addition
                else
                    push!(result_vector, 1) # Multiplication
                end
            end
        end
    end

    trans_number_grid = reduce(hcat, number_grid)

    max_num_length_per_column = []

    for row in eachrow(trans_number_grid)
        row_max_length = maximum(length.(row))
        push!(max_num_length_per_column, row_max_length)
    end

    number_grid_padded = []

    for line in input_vector
        if !occursin("*", line) && !occursin("+", line)
            max_num_length_per_column_index = 1
            row_num_padded = []
            current_num_padded = ""
            i = 1
            while i <= length(line)
                char = line[i]
                current_num_padded *= char
                if length(current_num_padded) == max_num_length_per_column[max_num_length_per_column_index]
                    push!(row_num_padded, current_num_padded)
                    current_num_padded = ""
                    max_num_length_per_column_index += 1
                    i += 1
                end
                i += 1
            end
            push!(number_grid_padded, row_num_padded)
        end
    end

    trans_number_grid_padded = reduce(hcat, number_grid_padded)

    for (i, row) in enumerate(eachrow(trans_number_grid_padded))
        col_numbers = fill("", max_num_length_per_column[i])
        for num_str in row
            for (i, char) in enumerate(num_str)
                col_numbers[i] *= char
            end
        end

        col_numbers_int = parse.(Int, col_numbers)

        for num in col_numbers_int
            if operators[i] == "+"
                result_vector[i] += num
            else
                result_vector[i] *= num
            end
        end
    end

    grand_total = sum(result_vector)
    return grand_total
end