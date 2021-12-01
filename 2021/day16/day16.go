package main

import (
	"bufio"
	"fmt"
	"log"
	"math"
	"os"
	"strconv"
)

func Day16HexStringToBinaryString(hex string) string {
	ui, _ := strconv.ParseUint(hex, 16, 64)
	format := fmt.Sprintf("%%0%db", len(hex)*4)
	return fmt.Sprintf(format, ui)
}

func Day16_1_HexStringToBinaryString(hex string) string {
	binaryString := ""
	var hexMap = map[string]string{
		"0": "0000",
		"1": "0001",
		"2": "0010",
		"3": "0011",
		"4": "0100",
		"5": "0101",
		"6": "0110",
		"7": "0111",
		"8": "1000",
		"9": "1001",
		"A": "1010",
		"B": "1011",
		"C": "1100",
		"D": "1101",
		"E": "1110",
		"F": "1111",
	}
	for _, aChar := range hex {
		binaryString += hexMap[string(aChar)]
	}
	return binaryString
}

func Day16BinaryStringToInt(input string) int {
	inputLength := len(input)
	result := float64(0)
	for i, char := range input {
		currentBit, _ := strconv.Atoi(string(char))
		result += math.Pow(2, float64(inputLength-i-1)) * float64(currentBit)
	}
	return int(result)
}

func Day16(hex string) int {
	binaryString := Day16_1_HexStringToBinaryString(hex)
	// fmt.Println(binaryString)

	versionSum := 0
	startIndex := 0

	if binaryString[3:6] == "100" {
		// Literal value
		LiteralValue(binaryString, startIndex, &versionSum)
	} else {
		// Operator
		Operator(binaryString, startIndex, &versionSum)
	}

	return versionSum
}

func LiteralValue(binaryString string, startIndex int, versionSum *int) int {
	// Get version and add to versionSum
	versionBinaryString := binaryString[startIndex : startIndex+3]
	versionInt := Day16BinaryStringToInt(versionBinaryString)
	*versionSum += versionInt

	dataIndex := startIndex + 6
	for {
		if string(binaryString[dataIndex]) == "0" {
			// Last data
			break
		} else {
			dataIndex += 5
		}
	}

	// Return end index of this literal value
	return dataIndex + 4
}

func Operator(binaryString string, startIndex int, versionSum *int) int {
	// Get version and add to versionSum
	versionBinaryString := binaryString[startIndex : startIndex+3]
	versionInt := Day16BinaryStringToInt(versionBinaryString)
	*versionSum += versionInt

	typeID := string(binaryString[startIndex+6])
	if typeID == "0" {
		// Type ID 0
		// Sub-packet length
		subPacketLengthBinaryString := binaryString[startIndex+7 : startIndex+22]
		subpacketLengthInt := Day16BinaryStringToInt(subPacketLengthBinaryString)
		subpacketEndIndex := startIndex + 21 + subpacketLengthInt

		subPacketTrackerIndex := startIndex + 22
		typeID := binaryString[subPacketTrackerIndex+3 : subPacketTrackerIndex+6]

		// Iterate until sub-packet end index is reached
		for subPacketTrackerIndex < subpacketEndIndex {
			typeID = binaryString[subPacketTrackerIndex+3 : subPacketTrackerIndex+6]
			if typeID == "100" {
				// Sub-packet is literal value
				subPacketTrackerIndex = LiteralValue(binaryString, subPacketTrackerIndex, versionSum) + 1
			} else {
				// Sub-packet is operator
				subPacketTrackerIndex = Operator(binaryString, subPacketTrackerIndex, versionSum) + 1
			}
		}

		// Return subPacketTrackerIndex - 1 (last index)
		return subPacketTrackerIndex - 1
	} else {
		// Type ID 1
		subPacketOccurrencesBinaryString := binaryString[startIndex+7 : startIndex+18]
		subPacketOccurrencesInt := Day16BinaryStringToInt(subPacketOccurrencesBinaryString)

		subPacketTrackerIndex := startIndex + 18
		typeID := binaryString[subPacketTrackerIndex+3 : subPacketTrackerIndex+6]

		// Iterate for the number of sub-packet occurrences
		for i := 0; i < subPacketOccurrencesInt; i++ {
			typeID = binaryString[subPacketTrackerIndex+3 : subPacketTrackerIndex+6]
			if typeID == "100" {
				// Sub-packet is literal value
				subPacketTrackerIndex = LiteralValue(binaryString, subPacketTrackerIndex, versionSum) + 1
			} else {
				// Sub-packet is operator
				subPacketTrackerIndex = Operator(binaryString, subPacketTrackerIndex, versionSum) + 1
			}
		}

		// Return subPacketTrackerIndex - 1 (last index)
		return subPacketTrackerIndex - 1
	}
}

func main() {
	file, err := os.Open("input.txt")
	if err != nil {
		log.Fatalf("failed to open")
	}
	scanner := bufio.NewScanner(file)
	scanner.Split(bufio.ScanLines)
	var input string
	for scanner.Scan() {
		lineString := scanner.Text()
		input = lineString
	}
	file.Close()

	resultDay16 := Day16(input)
	fmt.Println(resultDay16)
}
