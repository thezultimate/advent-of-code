package main

import (
	"bufio"
	"fmt"
	"log"
	"math"
	"os"
	"strconv"
)

const Padding = 100

func GetPaddedInput(input [][]string) [][]string {
	yInputLength := len(input)
	xInputLength := len(input[0])
	paddedInput := make([][]string, yInputLength+(Padding*2))
	for i, _ := range paddedInput {
		paddedInput[i] = make([]string, xInputLength+(Padding*2))
	}

	// Fill paddedInput with dots
	for i, y := range paddedInput {
		for j, _ := range y {
			paddedInput[i][j] = "."
		}
	}

	// Fill input to paddedInput
	for i, y := range input {
		for j, _ := range y {
			paddedInput[i+Padding][j+Padding] = input[i][j]
		}
	}

	return paddedInput
}

func Day20BinaryStringToInt(input string) int {
	inputLength := len(input)
	result := float64(0)
	for i, char := range input {
		currentBit, _ := strconv.Atoi(string(char))
		result += math.Pow(2, float64(inputLength-i-1)) * float64(currentBit)
	}
	return int(result)
}

func Day20(input [][]string, enhancementAlgorithm string, steps int) int {
	paddedInput := GetPaddedInput(input)
	var paddedOutput [][]string
	litPixels := 0

	// Iterate number of steps
	for step := 1; step <= steps; step++ {
		// Create initial output grid
		paddedOutput = make([][]string, len(paddedInput))
		for i, _ := range paddedOutput {
			paddedOutput[i] = make([]string, len(paddedInput[0]))
		}
		for i, y := range paddedOutput {
			for j, _ := range y {
				paddedOutput[i][j] = "."
			}
		}

		for i := 0; i <= len(paddedInput)-3; i++ {
			for j := 0; j < len(paddedInput[0])-3; j++ {
				// 3x3 grid
				binaryString := ""
				for k := 0; k < 3; k++ {
					for l := 0; l < 3; l++ {
						if paddedInput[i+k][j+l] == "#" {
							binaryString += "1"
						} else {
							binaryString += "0"
						}
					}
				}
				indexLookup := Day20BinaryStringToInt(binaryString)
				toBeInserted := string(enhancementAlgorithm[indexLookup])
				paddedOutput[i+1][j+1] = toBeInserted
			}
		}

		paddedInput = paddedOutput
	}

	for i, y := range paddedOutput {
		for j, v := range y {
			if i >= Padding-steps && i <= len(paddedOutput)-steps && j >= Padding-steps && j <= len(paddedOutput[0]) {
				if v == "#" {
					litPixels++
				}
			}
		}
	}

	return litPixels
}

func main() {
	file, err := os.Open("input.txt")
	if err != nil {
		log.Fatalf("failed to open")
	}
	scanner := bufio.NewScanner(file)
	scanner.Split(bufio.ScanLines)
	var enhancementAlgorithm string
	var inputArr [][]string
	for scanner.Scan() {
		var lineArr []string
		lineString := scanner.Text()
		if len(lineString) > 0 {
			if len(lineString) > 100 {
				enhancementAlgorithm = lineString
			} else {
				for _, aChar := range lineString {
					lineArr = append(lineArr, string(aChar))
				}
				inputArr = append(inputArr, lineArr)
			}
		}
	}
	file.Close()

	resultDay20 := Day20(inputArr, enhancementAlgorithm, 2)
	resultDay20_1 := Day20(inputArr, enhancementAlgorithm, 50)
	fmt.Println(resultDay20)
	fmt.Println(resultDay20_1)
}
