function problem_part1(input_vector)
    device_connections = Dict{String, Vector{String}}()

    for line in input_vector
        input_output = split(line, ": ")
        input_device = input_output[1]
        output_devices = split(input_output[2], " ")
        device_connections[input_device] = output_devices
    end

    start_device = "you"
    end_device = "out"

    path_count = traverse_device_connections(start_device, end_device, device_connections)

    return path_count
end

function traverse_device_connections(current_device, end_device, device_connections)
    path_count = 0

    # Terminating condition
    if current_device == end_device
        # println("Reached end device: $end_device")
        return 1
    end

    # Recursive condition
    for next_device in device_connections[current_device]
        path_count += traverse_device_connections(next_device, end_device, device_connections)
    end
    
    return path_count
end

function problem_part2(input_vector)
    device_connections = Dict{String, Vector{String}}()

    for line in input_vector
        input_output = split(line, ": ")
        input_device = input_output[1]
        output_devices = split(input_output[2], " ")
        device_connections[input_device] = output_devices
    end

    start_device = "svr"
    end_device = "out"
    traversed_devices = Set{String}()
    memo = Dict{Tuple{String, String}, Int}()

    path_count = traverse_device_connections2(start_device, end_device, device_connections, traversed_devices, memo)
    # println("Total paths from $start_device to $end_device: $path_count")

    fft_dac_path_count = traverse_device_connections2("fft", "dac", device_connections, traversed_devices, memo)
    # println("Total paths from fft to dac: $fft_dac_path_count")

    dac_fft_path_count = traverse_device_connections2("dac", "fft", device_connections, traversed_devices, memo)
    # println("Total paths from dac to fft: $dac_fft_path_count")

    svr_fft_path_count = traverse_device_connections2("svr", "fft", device_connections, traversed_devices, memo)
    # println("Total paths from svr to fft: $svr_fft_path_count")

    svr_dac_path_count = traverse_device_connections2("svr", "dac", device_connections, traversed_devices, memo)
    # println("Total paths from svr to dac: $svr_dac_path_count")

    fft_out_path_count = traverse_device_connections2("fft", "out", device_connections, traversed_devices, memo)
    # println("Total paths from fft to out: $fft_out_path_count")

    dac_out_path_count = traverse_device_connections2("dac", "out", device_connections, traversed_devices, memo)
    # println("Total paths from dac to out: $dac_out_path_count")

    final_path_count = svr_fft_path_count * fft_dac_path_count * dac_out_path_count +
                       svr_dac_path_count * dac_fft_path_count * fft_out_path_count

    # println("Final computed path count: $final_path_count")

    return final_path_count
end

function traverse_device_connections2(current_device, end_device, device_connections, traversed_devices, memo)
    # Check memoization
    if haskey(memo, (current_device, end_device))
        # println("Using memoized result for ($current_device, $end_device): $(memo[(current_device, end_device)])")
        return memo[(current_device, end_device)]
    end

    traversed_devices_copy = copy(traversed_devices)

    # Terminating condition
    # Check if current_device has already been traversed to avoid loops
    if current_device in traversed_devices_copy
        # println("Already traversed device: $current_device, skipping to avoid loop.")
        return 0
    end

    push!(traversed_devices_copy, current_device)

    path_count = 0

    # Terminating condition
    if current_device == end_device
        return 1
    end

    # Terminating condition
    if current_device == "out"
        return 0
    end

    # Recursive condition
    for next_device in device_connections[current_device]
        path_count += traverse_device_connections2(next_device, end_device, device_connections, traversed_devices_copy, memo)
    end
    
    # Store in memo
    memo[(current_device, end_device)] = path_count

    return path_count
end