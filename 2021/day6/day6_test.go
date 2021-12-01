package main

import (
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestDay6(t *testing.T) {
	input := []int{3, 4, 3, 1, 2}
	output := Day6(input, 80)
	assert.Equal(t, 5934, output, "they should be equal")
}

func TestDay6_Case2(t *testing.T) {
	input := []int{3, 4, 3, 1, 2}
	output := Day6(input, 18)
	assert.Equal(t, 26, output, "they should be equal")
}

func TestDay6_Case3(t *testing.T) {
	input := []int{3}
	output := Day6(input, 18)
	assert.Equal(t, 5, output, "they should be equal")
}

func TestDay6_Case4(t *testing.T) {
	input := []int{3}
	output := Day6(input, 80)
	assert.Equal(t, 1154, output, "they should be equal")
}

func TestDay6_Case5(t *testing.T) {
	input := []int{3}
	output := Day6(input, 256)
	assert.Equal(t, 39025282, output, "they should be equal")
}

func TestDay6_1(t *testing.T) {
	input := []int{3}
	output := Day6_1(input, 18)
	assert.Equal(t, 5, output, "they should be equal")
}

func TestDay6_1_Case2(t *testing.T) {
	input := []int{3}
	output := Day6_1(input, 256)
	assert.Equal(t, 5217223242, output, "they should be equal")
}

func TestDay6_1_Case3(t *testing.T) {
	input := []int{3, 4, 3, 1, 2}
	output := Day6_1(input, 80)
	assert.Equal(t, 5934, output, "they should be equal")
}

func TestDay6_1_Case4(t *testing.T) {
	input := []int{3, 4, 3, 1, 2}
	output := Day6_1(input, 256)
	assert.Equal(t, 26984457539, output, "they should be equal")
}

func TestDay6_1_Case5(t *testing.T) {
	input := []int{1, 2, 1, 1, 1, 1, 1, 1, 2, 1, 3, 1, 1, 1, 1, 3, 1, 1, 1, 5, 1, 1, 1, 4, 5, 1, 1, 1, 3, 4, 1, 1, 1, 1, 1, 1, 1, 5, 1, 4, 1, 1, 1, 1, 1, 1, 1, 5, 1, 3, 1, 3, 1, 1, 1, 5, 1, 1, 1, 1, 1, 5, 4, 1, 2, 4, 4, 1, 1, 1, 1, 1, 5, 1, 1, 1, 1, 1, 5, 4, 3, 1, 1, 1, 1, 1, 1, 1, 5, 1, 3, 1, 4, 1, 1, 3, 1, 1, 1, 1, 1, 1, 2, 1, 4, 1, 3, 1, 1, 1, 1, 1, 5, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 4, 1, 3, 1, 1, 1, 1, 1, 1, 1, 1, 5, 1, 1, 4, 1, 1, 1, 1, 1, 3, 1, 3, 3, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 1, 1, 1, 1, 5, 1, 1, 1, 1, 2, 1, 1, 1, 4, 1, 1, 1, 2, 3, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 2, 3, 1, 2, 1, 1, 5, 4, 1, 1, 2, 1, 1, 1, 3, 1, 4, 1, 1, 1, 1, 3, 1, 2, 5, 1, 1, 1, 5, 1, 1, 1, 1, 1, 4, 1, 1, 4, 1, 1, 1, 2, 2, 2, 2, 4, 3, 1, 1, 3, 1, 1, 1, 1, 1, 1, 2, 2, 1, 1, 4, 2, 1, 4, 1, 1, 1, 1, 1, 5, 1, 1, 4, 2, 1, 1, 2, 5, 4, 2, 1, 1, 1, 1, 4, 2, 3, 5, 2, 1, 5, 1, 3, 1, 1, 5, 1, 1, 4, 5, 1, 1, 1, 1, 4}
	output := Day6_1(input, 80)
	assert.Equal(t, 390923, output, "they should be equal")
}

func TestDay6_1_Case6(t *testing.T) {
	input := []int{1, 2, 1, 1, 1, 1, 1, 1, 2, 1, 3, 1, 1, 1, 1, 3, 1, 1, 1, 5, 1, 1, 1, 4, 5, 1, 1, 1, 3, 4, 1, 1, 1, 1, 1, 1, 1, 5, 1, 4, 1, 1, 1, 1, 1, 1, 1, 5, 1, 3, 1, 3, 1, 1, 1, 5, 1, 1, 1, 1, 1, 5, 4, 1, 2, 4, 4, 1, 1, 1, 1, 1, 5, 1, 1, 1, 1, 1, 5, 4, 3, 1, 1, 1, 1, 1, 1, 1, 5, 1, 3, 1, 4, 1, 1, 3, 1, 1, 1, 1, 1, 1, 2, 1, 4, 1, 3, 1, 1, 1, 1, 1, 5, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 4, 1, 3, 1, 1, 1, 1, 1, 1, 1, 1, 5, 1, 1, 4, 1, 1, 1, 1, 1, 3, 1, 3, 3, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 1, 1, 1, 1, 5, 1, 1, 1, 1, 2, 1, 1, 1, 4, 1, 1, 1, 2, 3, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 2, 3, 1, 2, 1, 1, 5, 4, 1, 1, 2, 1, 1, 1, 3, 1, 4, 1, 1, 1, 1, 3, 1, 2, 5, 1, 1, 1, 5, 1, 1, 1, 1, 1, 4, 1, 1, 4, 1, 1, 1, 2, 2, 2, 2, 4, 3, 1, 1, 3, 1, 1, 1, 1, 1, 1, 2, 2, 1, 1, 4, 2, 1, 4, 1, 1, 1, 1, 1, 5, 1, 1, 4, 2, 1, 1, 2, 5, 4, 2, 1, 1, 1, 1, 4, 2, 3, 5, 2, 1, 5, 1, 3, 1, 1, 5, 1, 1, 4, 5, 1, 1, 1, 1, 4}
	output := Day6_1(input, 256)
	assert.Equal(t, 1749945484935, output, "they should be equal")
}
