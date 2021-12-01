package main

import (
	"github.com/stretchr/testify/assert"
	"testing"
)

func TestDay9(t *testing.T) {
	input := [][]int{
		{2, 1, 9, 9, 9, 4, 3, 2, 1, 0},
		{3, 9, 8, 7, 8, 9, 4, 9, 2, 1},
		{9, 8, 5, 6, 7, 8, 9, 8, 9, 2},
		{8, 7, 6, 7, 8, 9, 6, 7, 8, 9},
		{9, 8, 9, 9, 9, 6, 5, 6, 7, 8},
	}
	output := Day9(input)
	assert.Equal(t, 15, output, "they should be equal")
}

func TestDay9_Case2(t *testing.T) {
	input := [][]int{
		{1, 0, 1, 0, 1},
		{0, 1, 0, 1, 0},
		{1, 0, 1, 0, 1},
	}
	output := Day9(input)
	assert.Equal(t, 7, output, "they should be equal")
}

func TestDay9_1(t *testing.T) {
	input := [][]int{
		{2, 1, 9, 9, 9, 4, 3, 2, 1, 0},
		{3, 9, 8, 7, 8, 9, 4, 9, 2, 1},
		{9, 8, 5, 6, 7, 8, 9, 8, 9, 2},
		{8, 7, 6, 7, 8, 9, 6, 7, 8, 9},
		{9, 8, 9, 9, 9, 6, 5, 6, 7, 8},
	}
	output := Day9_1(input)
	assert.Equal(t, 1134, output, "they should be equal")
}

func TestDay9_1_Case2(t *testing.T) {
	input := [][]int{
		{1, 0, 1, 0, 1},
		{0, 1, 0, 1, 0},
		{1, 0, 1, 0, 1},
	}
	output := Day9_1(input)
	assert.Equal(t, 15, output, "they should be equal")
}
