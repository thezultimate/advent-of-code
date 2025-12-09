using PolygonOps

function problem_part1(input_vector)
    largest_tile = -1

    for i=1:length(input_vector)-1
        current_coordinate = parse.(Int, split(input_vector[i], ","))
        for j=i+1:length(input_vector)
            compare_coordinate = parse.(Int, split(input_vector[j], ","))
            rectangle_area = (abs(current_coordinate[1] - compare_coordinate[1])+1) * (abs(current_coordinate[2] - compare_coordinate[2])+1)
            if rectangle_area > largest_tile
                largest_tile = rectangle_area
            end
        end
    end

    return largest_tile
end

function problem_part2(input_vector)
    poly = []

    for line in input_vector
        coordinate = parse.(Int, split(line, ","))
        push!(poly, (coordinate[1], coordinate[2]))
    end
    first_coordinate = parse.(Int, split(input_vector[1], ","))
    push!(poly, (first_coordinate[1], first_coordinate[2]))

    largest_tile = -1

    for i=1:length(input_vector)-1
        current_coordinate = parse.(Int, split(input_vector[i], ","))
        
        for j=i+1:length(input_vector)
            compare_coordinate = parse.(Int, split(input_vector[j], ","))
            
            # Straight line
            if current_coordinate[1] == compare_coordinate[1] || current_coordinate[2] == compare_coordinate[2]
                rectangle_area = (abs(current_coordinate[1] - compare_coordinate[1])+1) * (abs(current_coordinate[2] - compare_coordinate[2])+1)
                if rectangle_area > largest_tile
                    largest_tile = rectangle_area
                    # println("Largest tile so far: $(largest_tile)")
                end
                continue
            end

            # Check if all points of the rectangle are inside polygon
            third_point = (current_coordinate[1], compare_coordinate[2])
            fourth_point = (compare_coordinate[1], current_coordinate[2])
            if !inpolygon(third_point, poly, in=true, on=true, out=false) || !inpolygon(fourth_point, poly, in=true, on=true, out=false)
                continue
            end

            # Rectangle can be concave, need to check all points along the edges
            # Tiring day, brute force and so not optimizing this further
            is_rectangle_valid = true

            # Check horizontally
            if current_coordinate[1] < compare_coordinate[1]
                start_col = current_coordinate[1]
                end_col = compare_coordinate[1]
            else
                start_col = compare_coordinate[1]
                end_col = current_coordinate[1]
            end
            # Check vertically
            if current_coordinate[2] < compare_coordinate[2]
                start_row = current_coordinate[2]
                end_row = compare_coordinate[2]
            else
                start_row = compare_coordinate[2]
                end_row = current_coordinate[2]
            end
            for red_tile in input_vector
                red_coordinate = parse.(Int, split(red_tile, ","))
                # Check horizontally
                if red_coordinate[1] >= start_col && red_coordinate[1] <= end_col
                    test_coordinate1 = (red_coordinate[1], current_coordinate[2])
                    test_coordinate2 = (red_coordinate[1], compare_coordinate[2])
                    if !inpolygon(test_coordinate1, poly, in=true, on=true, out=false) || !inpolygon(test_coordinate2, poly, in=true, on=true, out=false)
                        is_rectangle_valid = false
                        break
                    end
                end
                # Check vertically
                if red_coordinate[2] >= start_row && red_coordinate[2] <= end_row
                    test_coordinate1 = (current_coordinate[1], red_coordinate[2])
                    test_coordinate2 = (compare_coordinate[1], red_coordinate[2])
                    if !inpolygon(test_coordinate1, poly, in=true, on=true, out=false) || !inpolygon(test_coordinate2, poly, in=true, on=true, out=false)
                        is_rectangle_valid = false
                        break
                    end
                end
            end

            if !is_rectangle_valid
                continue
            end

            # Rectangle is valid inside polygon
            rectangle_area = (abs(current_coordinate[1] - compare_coordinate[1])+1) * (abs(current_coordinate[2] - compare_coordinate[2])+1)
            if rectangle_area > largest_tile
                largest_tile = rectangle_area
                # println("Largest tile so far: $(largest_tile)")
            end

        end
    end

    # println("Largest tile area found: ", largest_tile)

    return largest_tile
end