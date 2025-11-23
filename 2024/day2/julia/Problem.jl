function problem_part1(input_vector)
    safe_reports_count = 0
    for report in input_vector
        split_report = split(report)
        level_vector = parse.(Int, split_report)
        if is_safe(level_vector)
            safe_reports_count += 1
        end
    end

    return safe_reports_count
end

function is_safe(report)
    is_increasing = false
    if report[1] < report[2]
        is_increasing = true
    end
    for i in eachindex(report)
        if i+1 <= length(report)
            if report[i] == report[i+1]
                return false
            end
            diff = abs(report[i] - report[i+1])
            if diff < 1 || diff > 3
                return false
            end
            if is_increasing
                if report[i] > report[i+1]
                    return false
                end
            end
            if !is_increasing
                if report[i] < report[i+1]
                    return false
                end
            end
        end
    end
    
    return true
end

function problem_part2(input_vector)
    safe_reports_count = 0
    for report in input_vector
        split_report = split(report)
        level_vector = parse.(Int, split_report)
        if is_safe(level_vector)
            safe_reports_count += 1
        else # Remove one level
            for i in eachindex(level_vector)
                level_vector_copy = copy(level_vector)
                deleteat!(level_vector_copy, i)
                if is_safe(level_vector_copy)
                    safe_reports_count += 1
                    break
                end
            end
        end
    end

    return safe_reports_count
end