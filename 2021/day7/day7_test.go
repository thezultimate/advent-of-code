package main

import (
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestDay7GetDistanceSumFromPivot(t *testing.T) {
	input := []int{1, 2, 3}
	output := Day7GetDistanceSumFromPivot(input, 2)
	assert.Equal(t, 2, output, "they should be equal")
}

func TestDay7(t *testing.T) {
	input := []int{16, 1, 2, 0, 4, 2, 7, 1, 2, 14}
	output := Day7(input)
	assert.Equal(t, 37, output, "they should be equal")
}

func TestDay7_1GetDistanceCostMap(t *testing.T) {
	input := []int{1, 2, 3, 4, 5}
	output := Day7_1GetDistanceCostMap(input)
	assert.Equal(t, 4, len(output), "they should be equal")
	assert.Equal(t, 1, output[1], "they should be equal")
	assert.Equal(t, 3, output[2], "they should be equal")
	assert.Equal(t, 6, output[3], "they should be equal")
	assert.Equal(t, 10, output[4], "they should be equal")
}

func TestDay7_1GetDistanceCostMap_Case2(t *testing.T) {
	input := []int{13, 1, 2, 10, 7, 9}
	output := Day7_1GetDistanceCostMap(input)
	assert.Equal(t, 12, len(output), "they should be equal")
	assert.Equal(t, 1, output[1], "they should be equal")
	assert.Equal(t, 3, output[2], "they should be equal")
	assert.Equal(t, 6, output[3], "they should be equal")
	assert.Equal(t, 10, output[4], "they should be equal")
	assert.Equal(t, 15, output[5], "they should be equal")
	assert.Equal(t, 21, output[6], "they should be equal")
	assert.Equal(t, 28, output[7], "they should be equal")
	assert.Equal(t, 36, output[8], "they should be equal")
	assert.Equal(t, 45, output[9], "they should be equal")
	assert.Equal(t, 55, output[10], "they should be equal")
	assert.Equal(t, 66, output[11], "they should be equal")
	assert.Equal(t, 78, output[12], "they should be equal")
}

func TestDay7_1(t *testing.T) {
	input := []int{16, 1, 2, 0, 4, 2, 7, 1, 2, 14}
	output := Day7_1(input)
	assert.Equal(t, 168, output, "they should be equal")
}
