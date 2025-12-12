function problem_part1(input_vector)
    # Shapes
    shapes = Dict{Int, Vector{String}}()
    shapes_start_index = 1
    for i = 0:5
        shape_lines = String[]
        for j = 1:3
            shape_line = input_vector[shapes_start_index + j]
            push!(shape_lines, shape_line)
        end
        shapes[i] = shape_lines
        shapes_start_index += 5
    end

    # Regions and requirements
    regions_requirements_start_index = shapes_start_index
    regions_requirements = Vector{Tuple{Tuple{Int, Int}, Vector{Int}}}()

    for i = regions_requirements_start_index:length(input_vector)
        line = input_vector[i]
        region_requirement_split = split(line, ": ")
        region = region_requirement_split[1]
        dimensions = split(region, "x")
        width = parse(Int, dimensions[1])
        height = parse(Int, dimensions[2])
        region_tuple = (width, height)
        requirement = parse.(Int, split(region_requirement_split[2], " "))
        push!(regions_requirements, (region_tuple, requirement))
    end

    shapes_sizes = Dict{Int, Int}()
    for (key, shape) in shapes
        shape_size = 0
        for line in shape
            for char in line
                if char == '#'
                    shape_size += 1
                end
            end
        end
        shapes_sizes[key] = shape_size
    end

    fit_regions = 0

    for (region, requirement) in regions_requirements # Each region line
        region_size = region[1] * region[2]
        total_required_size = 0
        is_region_fit = true
        for req_index = eachindex(requirement)
            shape_index = req_index - 1
            num_shapes_needed = requirement[req_index]
            total_required_size += num_shapes_needed * shapes_sizes[shape_index]
            if total_required_size > region_size
                # println("Region $region cannot fit the required shapes.")
                is_region_fit = false
                break
            end
        end
        if is_region_fit
            fit_regions += 1
            # println("Region $region can fit the required shapes.")
        end
    end

    # println("Total fit regions: $fit_regions")

    return fit_regions
end
