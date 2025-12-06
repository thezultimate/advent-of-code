using Test

include("Problem.jl")

@testset "Problem" begin
    input_vector = [
        "123 328  51 64 ",
        " 45 64  387 23 ",
        "  6 98  215 314",
        "*   +   *   +  "
    ]
    @test problem_part1(input_vector) == 4277556

    @test problem_part2(input_vector) == 3263827
end