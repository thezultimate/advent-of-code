using Test

include("Problem.jl")

@testset "Problem" begin
    input_vector = [
        "L68",
        "L30",
        "R48",
        "L5",
        "R60",
        "L55",
        "L1",
        "L99",
        "R14",
        "L82"
    ]
    @test problem_part1(input_vector) == 3

    @test problem_part2(input_vector) == 6
end