using Test

include("Problem.jl")

@testset "Problem" begin
    input_vector = [
        "7,1",
        "11,1",
        "11,7",
        "9,7",
        "9,5",
        "2,5",
        "2,3",
        "7,3"
    ]
    @test problem_part1(input_vector) == 50

    @test problem_part2(input_vector) == 24
end