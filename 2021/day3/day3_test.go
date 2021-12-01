package main

import (
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestDay3_BinaryStringToInt(t *testing.T) {
	input := "10110"
	output := Day3BinaryToInt(input)
	assert.Equal(t, 22, output, "they should be equal")

	input = "01001"
	output = Day3BinaryToInt(input)
	assert.Equal(t, 9, output, "they should be equal")
}

func TestDay3_GetGammaAndEpsilonRates(t *testing.T) {
	input := []string{"00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010"}
	gamma, epsilon := Day3GetGammaAndEpsilonRates(input)
	assert.Equal(t, 22, gamma, "they should be equal")
	assert.Equal(t, 9, epsilon, "they should be equal")
}

func TestDay3(t *testing.T) {
	inputArr := []string{"00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010"}
	result := Day3(inputArr)
	assert.Equal(t, 198, result, "they should be equal")
}

func TestDay3_1_GetOxygenRating(t *testing.T) {
	input := []string{"00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010"}
	output := Day3_1GetOxygenRating(input)
	assert.Equal(t, 23, output, "they should be equal")
}

func TestDay3_1_GetCO2Rating(t *testing.T) {
	input := []string{"00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010"}
	output := Day3_1GetCO2Rating(input)
	assert.Equal(t, 10, output, "they should be equal")
}

func TestDay3_1(t *testing.T) {
	inputArr := []string{"00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010"}
	result := Day3_1(inputArr)
	assert.Equal(t, 230, result, "they should be equal")
}
