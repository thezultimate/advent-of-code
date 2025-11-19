using Test

include("Problem.jl")

@testset "Problem" begin
    input_left_vector = [3, 4, 2, 1, 3, 3]
    input_right_vector = [4, 3, 5, 3, 9, 3]
    @test problem_part1(input_left_vector, input_right_vector) == 11

    @test problem_part2(input_left_vector, input_right_vector) == 31
end