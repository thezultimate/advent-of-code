package main

import (
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestDay21(t *testing.T) {
	input := []string{
		"Player 1 starting position: 4",
		"Player 2 starting position: 8",
	}
	output := Day21(input)
	assert.Equal(t, 739785, output, "they should be equal")
}
