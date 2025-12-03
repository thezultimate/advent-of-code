using Test

include("Problem.jl")

@testset "Problem" begin
    input_vector = [
        "987654321111111",
        "811111111111119",
        "234234234234278",
        "818181911112111"
    ]
    @test problem_part1(input_vector) == 357

    @test problem_part2(input_vector) == 3121910778619
end