package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strconv"
)

func Day11(input [][]int, steps int) ([][]int, int) {
	totalFlashes := 0

	// For each step
	for step := 1; step <= steps; step++ {
		// Initialize 2D slice for tracking which point has flashed during this step
		hasFlashed := make([][]bool, len(input))
		for i := range hasFlashed {
			hasFlashed[i] = make([]bool, len(input[0]))
		}

		// Traverse each point
		for y, yValue := range input {
			for x, _ := range yValue {
				// Increase and flash
				totalFlashes += IncreaseAndFlash(input, hasFlashed, y, x)
			}
		}
	}

	return input, totalFlashes
}

func IncreaseAndFlash(inputArr [][]int, hasFlashed [][]bool, y, x int) int {
	flashes := 0
	yLength := len(inputArr)
	xLength := len(inputArr[0])
	if !hasFlashed[y][x] {
		// Increase if current point is not marked as has been flashed during this step
		inputArr[y][x]++
	}
	if inputArr[y][x] > 9 {
		flashes++
		inputArr[y][x] = 0
		hasFlashed[y][x] = true
		// If flashing, call itself in adjacent neighbours
		if x+1 < xLength {
			flashes += IncreaseAndFlash(inputArr, hasFlashed, y, x+1)
		}
		if x-1 >= 0 {
			flashes += IncreaseAndFlash(inputArr, hasFlashed, y, x-1)
		}
		if y+1 < yLength {
			flashes += IncreaseAndFlash(inputArr, hasFlashed, y+1, x)
		}
		if y-1 >= 0 {
			flashes += IncreaseAndFlash(inputArr, hasFlashed, y-1, x)
		}
		if x+1 < xLength && y+1 < yLength {
			flashes += IncreaseAndFlash(inputArr, hasFlashed, y+1, x+1)
		}
		if x+1 < xLength && y-1 >= 0 {
			flashes += IncreaseAndFlash(inputArr, hasFlashed, y-1, x+1)
		}
		if x-1 >= 0 && y+1 < yLength {
			flashes += IncreaseAndFlash(inputArr, hasFlashed, y+1, x-1)
		}
		if x-1 >= 0 && y-1 >= 0 {
			flashes += IncreaseAndFlash(inputArr, hasFlashed, y-1, x-1)
		}
	}
	return flashes
}

func Day11_1(input [][]int) int {
	step := 1

	// While all-flashing step not found
	for {
		// Initialize 2D slice for tracking which point has flashed during this step
		hasFlashed := make([][]bool, len(input))
		for i := range hasFlashed {
			hasFlashed[i] = make([]bool, len(input[0]))
		}

		currentStepFlashes := 0

		// Traverse each point
		for y, yValue := range input {
			for x, _ := range yValue {
				// Increase and flash
				currentStepFlashes += IncreaseAndFlash(input, hasFlashed, y, x)
			}
		}

		// Check if hasFlashed contains all true
		lengthHasFlashed := len(hasFlashed) * len(hasFlashed[0])
		if currentStepFlashes == lengthHasFlashed {
			// Bingo!
			break
		}

		// Increase step
		step++
	}

	return step
}

func main() {
	file, err := os.Open("input.txt")
	if err != nil {
		log.Fatalf("failed to open")
	}
	scanner := bufio.NewScanner(file)
	scanner.Split(bufio.ScanLines)
	var inputArr [][]int
	for scanner.Scan() {
		var lineArr []int
		lineString := scanner.Text()
		for _, aChar := range lineString {
			anInt, _ := strconv.Atoi(string(aChar))
			lineArr = append(lineArr, anInt)
		}
		inputArr = append(inputArr, lineArr)
	}
	file.Close()

	_, resultDay11 := Day11(inputArr, 100)
	resultDay11_1 := Day11_1(inputArr)
	fmt.Println(resultDay11)
	fmt.Println(resultDay11_1)
}
