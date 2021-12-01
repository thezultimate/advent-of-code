package main

import (
	"github.com/stretchr/testify/assert"
	"testing"
)

func TestDay10(t *testing.T) {
	input := []string{
		"[({(<(())[]>[[{[]{<()<>>",
		"[(()[<>])]({[<{<<[]>>(",
		"{([(<{}[<>[]}>{[]{[(<()>",
		"(((({<>}<{<{<>}{[]{[]{}",
		"[[<[([]))<([[{}[[()]]]",
		"[{[{({}]{}}([{[{{{}}([]",
		"{<[[]]>}<{[{[{[]{()[[[]",
		"[<(<(<(<{}))><([]([]()",
		"<{([([[(<>()){}]>(<<{{",
		"<{([{{}}[<[[[<>{}]]]>[]]",
	}
	output := Day10(input)
	assert.Equal(t, 26397, output, "they should be equal")
}

func TestDay10_Case2(t *testing.T) {
	input := []string{
		"[({(<(())[]>[[{[]{<()<>>",
	}
	output := Day10(input)
	assert.Equal(t, 0, output, "they should be equal")
}

func TestDay10_Case3(t *testing.T) {
	input := []string{
		"{([(<{}[<>[]}>{[]{[(<()>",
	}
	output := Day10(input)
	assert.Equal(t, 1197, output, "they should be equal")
}

func TestDay10_Case4(t *testing.T) {
	input := []string{
		"[[<[([]))<([[{}[[()]]]",
	}
	output := Day10(input)
	assert.Equal(t, 3, output, "they should be equal")
}

func TestDay10_Case5(t *testing.T) {
	input := []string{
		"[{[{({}]{}}([{[{{{}}([]",
	}
	output := Day10(input)
	assert.Equal(t, 57, output, "they should be equal")
}

func TestDay10_Case6(t *testing.T) {
	input := []string{
		"<{([([[(<>()){}]>(<<{{",
	}
	output := Day10(input)
	assert.Equal(t, 25137, output, "they should be equal")
}

func TestDay10_1(t *testing.T) {
	input := []string{
		"[({(<(())[]>[[{[]{<()<>>",
		"[(()[<>])]({[<{<<[]>>(",
		"{([(<{}[<>[]}>{[]{[(<()>",
		"(((({<>}<{<{<>}{[]{[]{}",
		"[[<[([]))<([[{}[[()]]]",
		"[{[{({}]{}}([{[{{{}}([]",
		"{<[[]]>}<{[{[{[]{()[[[]",
		"[<(<(<(<{}))><([]([]()",
		"<{([([[(<>()){}]>(<<{{",
		"<{([{{}}[<[[[<>{}]]]>[]]",
	}
	output := Day10_1(input)
	assert.Equal(t, 288957, output, "they should be equal")
}
