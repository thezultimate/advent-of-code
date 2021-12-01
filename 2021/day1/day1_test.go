package main

import (
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestDay1(t *testing.T) {
	inputArr := []int{199, 200, 208, 210, 200, 207, 240, 269, 260, 263}
	result := Day1(inputArr)
	assert.Equal(t, 7, result, "they should be equal")
}

func TestDay1_2(t *testing.T) {
	inputArr := []int{199, 200, 208, 210, 200, 207, 240, 269, 260, 263}
	result := Day1_2(inputArr)
	assert.Equal(t, 5, result, "they should be equal")
}
