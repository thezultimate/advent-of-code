package main

import (
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestDay5GetMaxXYStraightLine(t *testing.T) {
	input := [][][]int{
		[][]int{[]int{0, 9}, []int{5, 9}},
		[][]int{[]int{8, 0}, []int{0, 8}},
		[][]int{[]int{9, 4}, []int{3, 4}},
		[][]int{[]int{2, 2}, []int{2, 1}},
		[][]int{[]int{7, 0}, []int{7, 4}},
		[][]int{[]int{6, 4}, []int{2, 0}},
		[][]int{[]int{0, 9}, []int{2, 9}},
		[][]int{[]int{3, 4}, []int{2, 4}},
		[][]int{[]int{0, 0}, []int{8, 8}},
		[][]int{[]int{5, 5}, []int{8, 2}},
	}
	maxX, maxY := Day5GetMaxXYStraightLine(input)
	assert.Equal(t, 9, maxX, "they should be equal")
	assert.Equal(t, 9, maxY, "they should be equal")
}

func TestDay5(t *testing.T) {
	input := [][][]int{
		[][]int{[]int{0, 9}, []int{5, 9}},
		[][]int{[]int{8, 0}, []int{0, 8}},
		[][]int{[]int{9, 4}, []int{3, 4}},
		[][]int{[]int{2, 2}, []int{2, 1}},
		[][]int{[]int{7, 0}, []int{7, 4}},
		[][]int{[]int{6, 4}, []int{2, 0}},
		[][]int{[]int{0, 9}, []int{2, 9}},
		[][]int{[]int{3, 4}, []int{1, 4}},
		[][]int{[]int{0, 0}, []int{8, 8}},
		[][]int{[]int{5, 5}, []int{8, 2}},
	}
	output := Day5(input)
	assert.Equal(t, 5, output, "they should be equal")
}

func TestDay5_1(t *testing.T) {
	input := [][][]int{
		[][]int{[]int{0, 9}, []int{5, 9}},
		[][]int{[]int{8, 0}, []int{0, 8}},
		[][]int{[]int{9, 4}, []int{3, 4}},
		[][]int{[]int{2, 2}, []int{2, 1}},
		[][]int{[]int{7, 0}, []int{7, 4}},
		[][]int{[]int{6, 4}, []int{2, 0}},
		[][]int{[]int{0, 9}, []int{2, 9}},
		[][]int{[]int{3, 4}, []int{1, 4}},
		[][]int{[]int{0, 0}, []int{8, 8}},
		[][]int{[]int{5, 5}, []int{8, 2}},
	}
	output := Day5_1(input)
	assert.Equal(t, 12, output, "they should be equal")
}
