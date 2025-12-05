using Test

include("Problem.jl")

@testset "Problem" begin
    input_vector = [
        "3-5",
        "10-14",
        "16-20",
        "12-18",
        "",
        "1",
        "5",
        "8",
        "11",
        "17",
        "32"
    ]
    @test problem_part1(input_vector) == 3

    @test problem_part2(input_vector) == 14

    input_vector2 = [
        "2-21",
        "3-5",
        "10-14",
        "16-20",
        "12-18",
    ]
    @test problem_part2(input_vector2) == 20

end