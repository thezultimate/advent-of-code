function problem_part1(input_vector)
    grid = [collect(line) for line in input_vector]
    rows_length = length(grid)
    cols_length = length(grid[1])

    for row in 1:rows_length
        for col in 1:cols_length
            if grid[row][col] == 'S' || grid[row][col] == '|'
                next_row_index = row + 1
                if next_row_index <= rows_length
                    if grid[next_row_index][col] == '.'
                        grid[next_row_index][col] = '|'
                    end
                    if grid[next_row_index][col] == '^'
                        left_index = col - 1
                        right_index = col + 1
                        if left_index >= 1
                            if grid[next_row_index][left_index] == '.'
                                grid[next_row_index][left_index] = '|'
                            end
                        end
                        if right_index <= cols_length
                            if grid[next_row_index][right_index] == '.'
                                grid[next_row_index][right_index] = '|'
                            end
                        end
                    end
                end
            end
        end
    end

    split_count = 0

    for row in 1:rows_length
        for col in 1:cols_length
            if grid[row][col] == '^'
                if grid[row-1][col] == '|'
                    split_count += 1
                end
            end
        end
    end

    return split_count
end

function problem_part2(input_vector)
    grid = [collect(line) for line in input_vector]

    start_col = findfirst(isequal('S'), grid[1])
    start_coordinate = (1, start_col)

    memo = Dict{Tuple{Int,Int}, Int}()

    count = traverse_tachyon_manifold(start_coordinate, grid, memo)
    # println("Total paths: $(count)")

    return count
end

function traverse_tachyon_manifold(coordinate, grid, memo)
    if haskey(memo, coordinate)
        return memo[coordinate]
    end

    row, col = coordinate
    rows_length = length(grid)
    count = 0

    # Terminating condition
    if row == rows_length # Bottom of tachyon manifold
        # println("Reached bottom at coordinate: $(coordinate)")
        return 1
    end

    # Recursive conditions
    if grid[row+1][col] == '.' # Below is empty space
        count += traverse_tachyon_manifold((row+1, col), grid, memo)
    end
    
    if grid[row+1][col] == '^' # Below is a splitter
        if grid[row+1][col-1] == '.'
            count += traverse_tachyon_manifold((row+1, col-1), grid, memo) # Left branch
        end
        if grid[row+1][col+1] == '.'
            count += traverse_tachyon_manifold((row+1, col+1), grid, memo) # Right branch
        end
    end

    memo[coordinate] = count

    return count
end