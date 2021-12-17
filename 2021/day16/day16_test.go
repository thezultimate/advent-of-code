package main

import (
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestDay16_HexStringToBinaryString(t *testing.T) {
	input := "D2FE28"
	output := Day16_1_HexStringToBinaryString(input)
	assert.Equal(t, 24, len(output), "they should be equal")
	assert.Equal(t, "110100101111111000101000", output, "they should be equal")

	input = "38006F45291200"
	output = Day16_1_HexStringToBinaryString(input)
	assert.Equal(t, 56, len(output), "they should be equal")
	assert.Equal(t, "00111000000000000110111101000101001010010001001000000000", output, "they should be equal")

	input = "EE00D40C823060"
	output = Day16_1_HexStringToBinaryString(input)
	assert.Equal(t, 56, len(output), "they should be equal")
	assert.Equal(t, "11101110000000001101010000001100100000100011000001100000", output, "they should be equal")

	input = "0"
	output = Day16_1_HexStringToBinaryString(input)
	assert.Equal(t, 4, len(output), "they should be equal")
	assert.Equal(t, "0000", output, "they should be equal")

	input = "7"
	output = Day16_1_HexStringToBinaryString(input)
	assert.Equal(t, 4, len(output), "they should be equal")
	assert.Equal(t, "0111", output, "they should be equal")

	input = "F"
	output = Day16_1_HexStringToBinaryString(input)
	assert.Equal(t, 4, len(output), "they should be equal")
	assert.Equal(t, "1111", output, "they should be equal")

	input = "8A004A801A8002F478"
	output = Day16_1_HexStringToBinaryString(input)
	assert.Equal(t, 72, len(output), "they should be equal")
	assert.Equal(t, "100010100000000001001010100000000001101010000000000000101111010001111000", output, "they should be equal")

	input = "620080001611562C8802118E34"
	output = Day16_1_HexStringToBinaryString(input)
	assert.Equal(t, 104, len(output), "they should be equal")
	assert.Equal(t, "01100010000000001000000000000000000101100001000101010110001011001000100000000010000100011000111000110100", output, "they should be equal")
}

func TestDay16_BinaryStringToInt(t *testing.T) {
	input := "110"
	output := Day16BinaryStringToInt(input)
	assert.Equal(t, 6, output, "they should be equal")

	input = "011111100101"
	output = Day16BinaryStringToInt(input)
	assert.Equal(t, 2021, output, "they should be equal")

	input = "000000000011011"
	output = Day16BinaryStringToInt(input)
	assert.Equal(t, 27, output, "they should be equal")

	input = "00010100"
	output = Day16BinaryStringToInt(input)
	assert.Equal(t, 20, output, "they should be equal")

	input = "000000000011011"
	output = Day16BinaryStringToInt(input)
	assert.Equal(t, 27, output, "they should be equal")

	input = "011111111111111"
	output = Day16BinaryStringToInt(input)
	assert.Equal(t, 16383, output, "they should be equal")

	input = "000000000010110"
	output = Day16BinaryStringToInt(input)
	assert.Equal(t, 22, output, "they should be equal")
}

func TestDay16(t *testing.T) {
	input := "8A004A801A8002F478"
	output := Day16(input)
	assert.Equal(t, 16, output, "they should be equal")
}

func TestDay16_Case2(t *testing.T) {
	input := "620080001611562C8802118E34"
	output := Day16(input)
	assert.Equal(t, 12, output, "they should be equal")
}

func TestDay16_Case3(t *testing.T) {
	input := "C0015000016115A2E0802F182340"
	output := Day16(input)
	assert.Equal(t, 23, output, "they should be equal")
}

func TestDay16_Case4(t *testing.T) {
	input := "A0016C880162017C3686B18A3D4780"
	output := Day16(input)
	assert.Equal(t, 31, output, "they should be equal")
}
