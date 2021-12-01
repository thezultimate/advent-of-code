package main

import (
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestDay2(t *testing.T) {
	inputArr := []string{"forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2"}
	result := Day2(inputArr)
	assert.Equal(t, 150, result, "they should be equal")
}

func TestDay2_1(t *testing.T) {
	inputArr := []string{"forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2"}
	result := Day2_1(inputArr)
	assert.Equal(t, 900, result, "they should be equal")
}
