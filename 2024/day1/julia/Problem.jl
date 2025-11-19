function problem_part1(input_left_vector, input_right_vector)
    total_sum = 0
    left_vector_sorted = sort(input_left_vector)
    right_vector_sorted = sort(input_right_vector)
    for i in eachindex(left_vector_sorted)
        total_sum += abs(left_vector_sorted[i] - right_vector_sorted[i])
    end
    return total_sum
end

function problem_part2(input_left_vector, input_right_vector)
    similarity_score = 0
    similarity_occurrences_map = Dict{Int, Int}()
    for left_number in input_left_vector
        if haskey(similarity_occurrences_map, left_number)
            similarity_score += left_number * similarity_occurrences_map[left_number]
            continue
        end
        right_occurrences = 0
        for right_number in input_right_vector
            if left_number == right_number
                right_occurrences += 1
            end
        end
        similarity_occurrences_map[left_number] = right_occurrences
    end
    for (key, value) in similarity_occurrences_map
        similarity_score += key * value
    end
    return similarity_score
end