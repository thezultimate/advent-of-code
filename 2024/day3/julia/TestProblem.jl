using Test

include("Problem.jl")

@testset "Problem" begin
    input_vector = [
        "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))"
    ]
    @test problem_part1(input_vector) == 161

    input_vector = [
        "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"
    ]
    @test problem_part2(input_vector) == 48
end