include("Problem.jl")

function read_file_to_vectors(file_path)
    left_vector = Int[]
    right_vector = Int[]
    lines = readlines(file_path)
    for line in lines
        split_line = split(line)
        push!(left_vector, parse(Int, split_line[1]))
        push!(right_vector, parse(Int, split_line[2]))
    end
    return (left_vector, right_vector)

end

function main()
    file_path = "input.txt"
    left_vector, right_vector = read_file_to_vectors(file_path)

    result_part1 = problem_part1(left_vector, right_vector)
    println("Result of problem_part1: $(result_part1)")

    result_part2 = problem_part2(left_vector, right_vector)
    println("Result of problem_part2: $(result_part2)")
end

main()