package main

import (
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestDay17(t *testing.T) {
	xMin := 20
	xMax := 30
	yMin := -10
	yMax := -5
	output := Day17(xMin, xMax, yMin, yMax)
	assert.Equal(t, 45, output, "they should be equal")
}

func TestDay17_Case2(t *testing.T) {
	xMin := 20
	xMax := 30
	yMin := -10
	yMax := -5
	output := Day17_1(xMin, xMax, yMin, yMax)
	assert.Equal(t, 112, output, "they should be equal")
}
