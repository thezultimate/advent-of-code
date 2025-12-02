include("Problem.jl")

function read_file_to_string(file_path)
    lines = readlines(file_path)
    stripped_lines = strip.(lines)
    return stripped_lines[1]

end

function main()
    file_path = "input.txt"
    input_string = read_file_to_string(file_path)

    result_part1 = problem_part1(input_string)
    println("Result of problem_part1: $(result_part1)")

    result_part2 = problem_part2(input_string)
    println("Result of problem_part2: $(result_part2)")
end

main()