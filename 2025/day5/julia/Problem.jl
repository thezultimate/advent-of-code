function problem_part1(input_vector)
    fresh_id_count = 0
    fresh_id_ranges = []

    for line in input_vector
        if isempty(strip(line))
            continue
        end

        if contains(line, "-")
            parts = split(line, "-")
            start_id = parse(Int, parts[1])
            end_id = parse(Int, parts[2])
            push!(fresh_id_ranges, (start_id, end_id))
        else
            # Process each single ID
            id = parse(Int, strip(line))
            for (start_id, end_id) in fresh_id_ranges
                if id >= start_id && id <= end_id
                    fresh_id_count += 1
                    break
                end
            end
        end
    end

    return fresh_id_count
end

function problem_part2(input_vector)
    fresh_id_ranges = []

    for line in input_vector
        if contains(line, "-")
            parts = split(line, "-")
            start_id = parse(Int, parts[1])
            end_id = parse(Int, parts[2])
            push!(fresh_id_ranges, (start_id, end_id))
        end
    end

    total_fresh_ids = 0

    for i in 1:length(fresh_id_ranges)-1
        (start_id1, end_id1) = fresh_id_ranges[i]
        current_id_range_vector = []
        push!(current_id_range_vector, (start_id1, end_id1))
        
        for j in i+1:length(fresh_id_ranges)
            new_current_id_range = get_new_ranges(current_id_range_vector, fresh_id_ranges[j])
            current_id_range_vector = new_current_id_range
        end

        for (s_id, e_id) in current_id_range_vector
            total_fresh_ids += e_id - s_id + 1
        end
    end

    # Last line range addition
    (start_id_last, end_id_last) = fresh_id_ranges[end]
    total_fresh_ids += end_id_last - start_id_last + 1

    return total_fresh_ids
end

function get_new_ranges(current_ranges, compare_range)
    new_ranges = []
    (comp_start, comp_end) = compare_range

    for (curr_start, curr_end) in current_ranges
        # No overlap check
        if curr_end < comp_start || curr_start > comp_end
            push!(new_ranges, (curr_start, curr_end))
            continue
        end

        # In-between check
        if curr_start >= comp_start && curr_end <= comp_end
            continue
        end

        # Lower overlap check
        if curr_start <= comp_start && curr_end >= comp_start && curr_end <= comp_end
            new_curr_start = curr_start
            new_curr_end = comp_start - 1
            push!(new_ranges, (new_curr_start, new_curr_end))
            continue
        end

        # Upper overlap check
        if curr_start >= comp_start && curr_start <= comp_end && curr_end >= comp_end
            new_curr_start = comp_end + 1
            new_curr_end = curr_end
            push!(new_ranges, (new_curr_start, new_curr_end))
            continue
        end

        # Split range check
        if curr_start < comp_start && curr_end > comp_end
            new_curr_start1 = curr_start
            new_curr_end1 = comp_start - 1
            push!(new_ranges, (new_curr_start1, new_curr_end1))
            new_curr_start2 = comp_end + 1
            new_curr_end2 = curr_end
            push!(new_ranges, (new_curr_start2, new_curr_end2))
            continue
        end
    end

    return new_ranges
end