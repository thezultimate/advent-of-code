package main

import (
	"github.com/stretchr/testify/assert"
	"testing"
)

func TestDay11(t *testing.T) {
	inputArr := [][]int{
		[]int{1, 1, 1, 1, 1},
		[]int{1, 9, 9, 9, 1},
		[]int{1, 9, 1, 9, 1},
		[]int{1, 9, 9, 9, 1},
		[]int{1, 1, 1, 1, 1},
	}
	outputArr, flashes := Day11(inputArr, 1)
	assert.Equal(t, 9, flashes, "they should be equal")

	assert.Equal(t, 3, outputArr[0][0], "they should be equal")
	assert.Equal(t, 4, outputArr[0][1], "they should be equal")
	assert.Equal(t, 5, outputArr[0][2], "they should be equal")
	assert.Equal(t, 4, outputArr[0][3], "they should be equal")
	assert.Equal(t, 3, outputArr[0][4], "they should be equal")

	assert.Equal(t, 4, outputArr[1][0], "they should be equal")
	assert.Equal(t, 0, outputArr[1][1], "they should be equal")
	assert.Equal(t, 0, outputArr[1][2], "they should be equal")
	assert.Equal(t, 0, outputArr[1][3], "they should be equal")
	assert.Equal(t, 4, outputArr[1][4], "they should be equal")

	assert.Equal(t, 5, outputArr[2][0], "they should be equal")
	assert.Equal(t, 0, outputArr[2][1], "they should be equal")
	assert.Equal(t, 0, outputArr[2][2], "they should be equal")
	assert.Equal(t, 0, outputArr[2][3], "they should be equal")
	assert.Equal(t, 5, outputArr[2][4], "they should be equal")

	assert.Equal(t, 4, outputArr[3][0], "they should be equal")
	assert.Equal(t, 0, outputArr[3][1], "they should be equal")
	assert.Equal(t, 0, outputArr[3][2], "they should be equal")
	assert.Equal(t, 0, outputArr[3][3], "they should be equal")
	assert.Equal(t, 4, outputArr[3][4], "they should be equal")

	assert.Equal(t, 3, outputArr[4][0], "they should be equal")
	assert.Equal(t, 4, outputArr[4][1], "they should be equal")
	assert.Equal(t, 5, outputArr[4][2], "they should be equal")
	assert.Equal(t, 4, outputArr[4][3], "they should be equal")
	assert.Equal(t, 3, outputArr[4][4], "they should be equal")
}

func TestDay11_Case3(t *testing.T) {
	inputArr := [][]int{
		[]int{1, 1, 1, 1, 1},
		[]int{1, 9, 9, 9, 1},
		[]int{1, 9, 1, 9, 1},
		[]int{1, 9, 9, 9, 1},
		[]int{1, 1, 1, 1, 1},
	}
	outputArr, flashes := Day11(inputArr, 2)
	assert.Equal(t, 9, flashes, "they should be equal")

	assert.Equal(t, 4, outputArr[0][0], "they should be equal")
	assert.Equal(t, 5, outputArr[0][1], "they should be equal")
	assert.Equal(t, 6, outputArr[0][2], "they should be equal")
	assert.Equal(t, 5, outputArr[0][3], "they should be equal")
	assert.Equal(t, 4, outputArr[0][4], "they should be equal")

	assert.Equal(t, 5, outputArr[1][0], "they should be equal")
	assert.Equal(t, 1, outputArr[1][1], "they should be equal")
	assert.Equal(t, 1, outputArr[1][2], "they should be equal")
	assert.Equal(t, 1, outputArr[1][3], "they should be equal")
	assert.Equal(t, 5, outputArr[1][4], "they should be equal")

	assert.Equal(t, 6, outputArr[2][0], "they should be equal")
	assert.Equal(t, 1, outputArr[2][1], "they should be equal")
	assert.Equal(t, 1, outputArr[2][2], "they should be equal")
	assert.Equal(t, 1, outputArr[2][3], "they should be equal")
	assert.Equal(t, 6, outputArr[2][4], "they should be equal")

	assert.Equal(t, 5, outputArr[3][0], "they should be equal")
	assert.Equal(t, 1, outputArr[3][1], "they should be equal")
	assert.Equal(t, 1, outputArr[3][2], "they should be equal")
	assert.Equal(t, 1, outputArr[3][3], "they should be equal")
	assert.Equal(t, 5, outputArr[3][4], "they should be equal")

	assert.Equal(t, 4, outputArr[4][0], "they should be equal")
	assert.Equal(t, 5, outputArr[4][1], "they should be equal")
	assert.Equal(t, 6, outputArr[4][2], "they should be equal")
	assert.Equal(t, 5, outputArr[4][3], "they should be equal")
	assert.Equal(t, 4, outputArr[4][4], "they should be equal")
}

func TestDay11_Case2(t *testing.T) {
	inputArr := [][]int{
		[]int{5, 4, 8, 3, 1, 4, 3, 2, 2, 3},
		[]int{2, 7, 4, 5, 8, 5, 4, 7, 1, 1},
		[]int{5, 2, 6, 4, 5, 5, 6, 1, 7, 3},
		[]int{6, 1, 4, 1, 3, 3, 6, 1, 4, 6},
		[]int{6, 3, 5, 7, 3, 8, 5, 4, 7, 8},
		[]int{4, 1, 6, 7, 5, 2, 4, 6, 4, 5},
		[]int{2, 1, 7, 6, 8, 4, 1, 7, 2, 1},
		[]int{6, 8, 8, 2, 8, 8, 1, 1, 3, 4},
		[]int{4, 8, 4, 6, 8, 4, 8, 5, 5, 4},
		[]int{5, 2, 8, 3, 7, 5, 1, 5, 2, 6},
	}
	_, flashes := Day11(inputArr, 100)
	assert.Equal(t, 1656, flashes, "they should be equal")
}

func TestDay11_1(t *testing.T) {
	inputArr := [][]int{
		[]int{5, 4, 8, 3, 1, 4, 3, 2, 2, 3},
		[]int{2, 7, 4, 5, 8, 5, 4, 7, 1, 1},
		[]int{5, 2, 6, 4, 5, 5, 6, 1, 7, 3},
		[]int{6, 1, 4, 1, 3, 3, 6, 1, 4, 6},
		[]int{6, 3, 5, 7, 3, 8, 5, 4, 7, 8},
		[]int{4, 1, 6, 7, 5, 2, 4, 6, 4, 5},
		[]int{2, 1, 7, 6, 8, 4, 1, 7, 2, 1},
		[]int{6, 8, 8, 2, 8, 8, 1, 1, 3, 4},
		[]int{4, 8, 4, 6, 8, 4, 8, 5, 5, 4},
		[]int{5, 2, 8, 3, 7, 5, 1, 5, 2, 6},
	}
	stepAllFlash := Day11_1(inputArr)
	assert.Equal(t, 195, stepAllFlash, "they should be equal")
}
