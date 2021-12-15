package main

import (
	"github.com/stretchr/testify/assert"
	"testing"
)

func TestDay15(t *testing.T) {
	input := [][]int{
		[]int{1, 1, 6, 3, 7, 5, 1, 7, 4, 2},
		[]int{1, 3, 8, 1, 3, 7, 3, 6, 7, 2},
		[]int{2, 1, 3, 6, 5, 1, 1, 3, 2, 8},
		[]int{3, 6, 9, 4, 9, 3, 1, 5, 6, 9},
		[]int{7, 4, 6, 3, 4, 1, 7, 1, 1, 1},
		[]int{1, 3, 1, 9, 1, 2, 8, 1, 3, 7},
		[]int{1, 3, 5, 9, 9, 1, 2, 4, 2, 1},
		[]int{3, 1, 2, 5, 4, 2, 1, 6, 3, 9},
		[]int{1, 2, 9, 3, 1, 3, 8, 5, 2, 1},
		[]int{2, 3, 1, 1, 9, 4, 4, 5, 8, 1},
	}
	output := Day15(input)
	assert.Equal(t, 40, output, "they should be equal")
}

func TestDay15_Case2(t *testing.T) {
	input := [][]int{
		[]int{1, 7, 6, 7},
		[]int{1, 6, 8, 8},
		[]int{1, 1, 1, 1},
	}
	output := Day15(input)
	assert.Equal(t, 5, output, "they should be equal")
}

func TestDay15_1(t *testing.T) {
	input := [][]int{
		[]int{1, 1, 6, 3, 7, 5, 1, 7, 4, 2},
		[]int{1, 3, 8, 1, 3, 7, 3, 6, 7, 2},
		[]int{2, 1, 3, 6, 5, 1, 1, 3, 2, 8},
		[]int{3, 6, 9, 4, 9, 3, 1, 5, 6, 9},
		[]int{7, 4, 6, 3, 4, 1, 7, 1, 1, 1},
		[]int{1, 3, 1, 9, 1, 2, 8, 1, 3, 7},
		[]int{1, 3, 5, 9, 9, 1, 2, 4, 2, 1},
		[]int{3, 1, 2, 5, 4, 2, 1, 6, 3, 9},
		[]int{1, 2, 9, 3, 1, 3, 8, 5, 2, 1},
		[]int{2, 3, 1, 1, 9, 4, 4, 5, 8, 1},
	}
	output := Day15_1(input)
	assert.Equal(t, 315, output, "they should be equal")
}

func TestDay15_1_Case2(t *testing.T) {
	input := [][]int{
		[]int{1, 7, 6, 7},
		[]int{1, 6, 8, 8},
		[]int{1, 2, 2, 2},
		[]int{1, 1, 1, 1},
	}
	output := Day15_1(input)
	assert.Equal(t, 132, output, "they should be equal")
}
