using Test

include("Problem.jl")

@testset "Problem" begin
    input_vector = [
        "7 6 4 2 1",
        "1 2 7 8 9",
        "9 7 6 2 1",
        "1 3 2 4 5",
        "8 6 4 4 1",
        "1 3 6 7 9"
    ]
    @test problem_part1(input_vector) == 2

    @test problem_part2(input_vector) == 4
end