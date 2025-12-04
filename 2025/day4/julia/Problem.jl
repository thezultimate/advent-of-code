function problem_part1(input_vector)
    grid = []
    total_rolls = 0
    for line in input_vector
        row = []
        for char in collect(line)
            push!(row, char)
        end
        push!(grid, row)
    end

    for row in eachindex(grid)
        for col in eachindex(grid[1])
            cell = grid[row][col]
            if cell == '@'
                neighbor_count = 0

                # Left Up
                if row > 1 && col > 1
                    neighbor = grid[row - 1][col - 1]
                    if neighbor == '@'
                        neighbor_count += 1
                    end
                end

                # Left
                if col > 1
                    neighbor = grid[row][col - 1]
                    if neighbor == '@'
                        neighbor_count += 1
                    end
                end

                # Left Down
                if row < length(grid) && col > 1
                    neighbor = grid[row + 1][col - 1]
                    if neighbor == '@'
                        neighbor_count += 1
                    end
                end

                # Down
                if row < length(grid)
                    neighbor = grid[row + 1][col]
                    if neighbor == '@'
                        neighbor_count += 1
                    end
                end

                # Right Down
                if row < length(grid) && col < length(grid[1])
                    neighbor = grid[row + 1][col + 1]
                    if neighbor == '@'
                        neighbor_count += 1
                    end
                end

                # Right
                if col < length(grid[1])
                    neighbor = grid[row][col + 1]
                    if neighbor == '@'
                        neighbor_count += 1
                    end
                end

                # Right Up
                if row > 1 && col < length(grid[1])
                    neighbor = grid[row - 1][col + 1]
                    if neighbor == '@'
                        neighbor_count += 1
                    end
                end

                # Up
                if row > 1
                    neighbor = grid[row - 1][col]
                    if neighbor == '@'
                        neighbor_count += 1
                    end
                end

                if neighbor_count < 4
                    total_rolls += 1
                end
            end
        end
    end

    return total_rolls
end

function problem_part2(input_vector)
    grid = []
    total_rolls = 0
    for line in input_vector
        row = []
        for char in collect(line)
            push!(row, char)
        end
        push!(grid, row)
    end

    done = false

    while !done
        current_rolls = 0
        for row in eachindex(grid)
            for col in eachindex(grid[1])
                cell = grid[row][col]
                if cell == '@'
                    neighbor_count = 0

                    # Left Up
                    if row > 1 && col > 1
                        neighbor = grid[row - 1][col - 1]
                        if neighbor == '@'
                            neighbor_count += 1
                        end
                    end

                    # Left
                    if col > 1
                        neighbor = grid[row][col - 1]
                        if neighbor == '@'
                            neighbor_count += 1
                        end
                    end

                    # Left Down
                    if row < length(grid) && col > 1
                        neighbor = grid[row + 1][col - 1]
                        if neighbor == '@'
                            neighbor_count += 1
                        end
                    end

                    # Down
                    if row < length(grid)
                        neighbor = grid[row + 1][col]
                        if neighbor == '@'
                            neighbor_count += 1
                        end
                    end

                    # Right Down
                    if row < length(grid) && col < length(grid[1])
                        neighbor = grid[row + 1][col + 1]
                        if neighbor == '@'
                            neighbor_count += 1
                        end
                    end

                    # Right
                    if col < length(grid[1])
                        neighbor = grid[row][col + 1]
                        if neighbor == '@'
                            neighbor_count += 1
                        end
                    end

                    # Right Up
                    if row > 1 && col < length(grid[1])
                        neighbor = grid[row - 1][col + 1]
                        if neighbor == '@'
                            neighbor_count += 1
                        end
                    end

                    # Up
                    if row > 1
                        neighbor = grid[row - 1][col]
                        if neighbor == '@'
                            neighbor_count += 1
                        end
                    end

                    if neighbor_count < 4
                        current_rolls += 1
                        grid[row][col] = '.'
                    end
                end
            end
        end

        if current_rolls == 0
            done = true
        else
            total_rolls += current_rolls
        end
    end

    return total_rolls
end