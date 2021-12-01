package main

import (
	"github.com/stretchr/testify/assert"
	"testing"
)

func TestDay13(t *testing.T) {
	input := [][]int{
		[]int{6, 10},
		[]int{0, 14},
		[]int{9, 10},
		[]int{0, 3},
		[]int{10, 4},
		[]int{4, 11},
		[]int{6, 0},
		[]int{6, 12},
		[]int{4, 1},
		[]int{0, 13},
		[]int{10, 12},
		[]int{3, 4},
		[]int{3, 0},
		[]int{8, 4},
		[]int{1, 10},
		[]int{2, 14},
		[]int{8, 10},
		[]int{9, 0},
	}
	folds := []string{
		"fold along y=7",
		"fold along x=5",
	}
	output := Day13(input, folds)
	assert.Equal(t, 17, output, "they should be equal")
}

func TestDay13_1(t *testing.T) {
	input := [][]int{
		[]int{6, 10},
		[]int{0, 14},
		[]int{9, 10},
		[]int{0, 3},
		[]int{10, 4},
		[]int{4, 11},
		[]int{6, 0},
		[]int{6, 12},
		[]int{4, 1},
		[]int{0, 13},
		[]int{10, 12},
		[]int{3, 4},
		[]int{3, 0},
		[]int{8, 4},
		[]int{1, 10},
		[]int{2, 14},
		[]int{8, 10},
		[]int{9, 0},
	}
	folds := []string{
		"fold along y=7",
		"fold along x=5",
	}
	Day13_1(input, folds)
}
