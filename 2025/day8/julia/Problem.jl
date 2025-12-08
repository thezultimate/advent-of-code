function problem_part1(input_vector, num_connections)
    junction_pair_distances = []

    for i = 1:length(input_vector)-1
        for j = i+1:length(input_vector)
            current_junction = input_vector[i]
            neighbor_junction = input_vector[j]
            current_junction_tuple = Tuple(parse.(Int, split(current_junction, ",")))
            neighbor_junction_tuple = Tuple(parse.(Int, split(neighbor_junction, ",")))
            distance = sqrt((neighbor_junction_tuple[1] - current_junction_tuple[1]) ^ 2 + 
                       (neighbor_junction_tuple[2] - current_junction_tuple[2]) ^ 2 + 
                       (neighbor_junction_tuple[3] - current_junction_tuple[3]) ^ 2)
            junction_pair_distance = (current_junction_tuple, neighbor_junction_tuple, distance)
            push!(junction_pair_distances, junction_pair_distance)
        end
    end

    junction_pair_distances_sorted = sort(junction_pair_distances, by = x -> x[3])
    
    circuits = []

    connections_counter = 0

    for i = eachindex(junction_pair_distances_sorted)
        if connections_counter >= num_connections
            break
        end
        
        first_junction = junction_pair_distances_sorted[i][1]
        second_junction = junction_pair_distances_sorted[i][2]
        
        is_new_circuit = true

        for j = eachindex(circuits)
            circuit = circuits[j]
            if first_junction in circuit && second_junction in circuit
                # Both junctions are already in the same circuit
                is_new_circuit = false
                break
            end

            if first_junction in circuit || second_junction in circuit
                # One junction is already in the circuit, add the other junction
                push!(circuit, first_junction)
                push!(circuit, second_junction)
                is_new_circuit = false

                # Check if this circuit can be merged with one other circuit
                for k = j+1:length(circuits)
                    other_circuit = circuits[k]
                    if first_junction in other_circuit || second_junction in other_circuit
                        # Merge circuits
                        union!(circuit, other_circuit)
                        deleteat!(circuits, k)
                        break
                    end
                end

                break
            end
        end

        if is_new_circuit
            # New circuit
            circuit = Set([first_junction, second_junction])
            push!(circuits, circuit)
        end

        connections_counter += 1 # Add a connection
    end

    circuits_length = []
    for circuit in circuits
        push!(circuits_length, length(circuit))
    end

    circuits_length_sorted = sort(circuits_length, rev = true)

    result = 1

    for i = 1:3
        result *= circuits_length_sorted[i]
    end

    return result
end

function problem_part2(input_vector, num_connections)
    junction_pair_distances = []

    for i = 1:length(input_vector)-1
        for j = i+1:length(input_vector)
            current_junction = input_vector[i]
            neighbor_junction = input_vector[j]
            current_junction_tuple = Tuple(parse.(Int, split(current_junction, ",")))
            neighbor_junction_tuple = Tuple(parse.(Int, split(neighbor_junction, ",")))
            distance = sqrt((neighbor_junction_tuple[1] - current_junction_tuple[1]) ^ 2 + 
                       (neighbor_junction_tuple[2] - current_junction_tuple[2]) ^ 2 + 
                       (neighbor_junction_tuple[3] - current_junction_tuple[3]) ^ 2)
            junction_pair_distance = (current_junction_tuple, neighbor_junction_tuple, distance)
            push!(junction_pair_distances, junction_pair_distance)
        end
    end

    junction_pair_distances_sorted = sort(junction_pair_distances, by = x -> x[3])

    circuits = []
    is_converged = false
    iter_counter = 0

    first_converged_junction = ()
    second_converged_junction = ()

    while !is_converged
        for junction_pair_distance in junction_pair_distances_sorted
            iter_counter += 1

            first_junction = junction_pair_distance[1]
            second_junction = junction_pair_distance[2]

            is_new_circuit = true

            for i = eachindex(circuits)
                circuit = circuits[i]
                if first_junction in circuit && second_junction in circuit
                    # Both junctions are already in the same circuit
                    is_new_circuit = false
                    break
                end

                if first_junction in circuit || second_junction in circuit
                    # One junction is already in the circuit, add the other junction
                    push!(circuit, first_junction)
                    push!(circuit, second_junction)
                    is_new_circuit = false

                    # Check if this circuit can be merged with one other circuit
                    for j = i+1:length(circuits)
                        other_circuit = circuits[j]
                        if first_junction in other_circuit || second_junction in other_circuit
                            # Merge circuits
                            union!(circuit, other_circuit)
                            deleteat!(circuits, j)
                            break
                        end
                    end

                    break
                end
            end

            if is_new_circuit
                # New circuit
                circuit = Set([first_junction, second_junction])
                push!(circuits, circuit)
            end

            if length(circuits) == 1 && length(circuits[1]) == length(input_vector)
                is_converged = true
                first_converged_junction = first_junction
                second_converged_junction = second_junction
                # println("Iterations to converge: $(iter_counter)")
                # println("Converged when processing junctions: $(first_junction), $(second_junction)")
                break
            end
        end
    end

    cable_length = first_converged_junction[1] * second_converged_junction[1]

    return cable_length
end