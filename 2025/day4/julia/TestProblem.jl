using Test

include("Problem.jl")

@testset "Problem" begin
    input_vector = [
        "..@@.@@@@.",
        "@@@.@.@.@@",
        "@@@@@.@.@@",
        "@.@@@@..@.",
        "@@.@@@@.@@",
        ".@@@@@@@.@",
        ".@.@.@.@@@",
        "@.@@@.@@@@",
        ".@@@@@@@@.",
        "@.@.@@@.@."
    ]
    @test problem_part1(input_vector) == 13

    @test problem_part2(input_vector) == 43
end