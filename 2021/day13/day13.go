package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strconv"
	"strings"
)

func Day13(input [][]int, folds []string) int {
	// Get the first fold
	firstFoldInstruction := strings.Fields(folds[0])
	firstFoldString := strings.Split(firstFoldInstruction[2], "=")
	axis := firstFoldString[0]
	axisIndex, _ := strconv.Atoi(firstFoldString[1])

	// Create initial 2D grid
	yMax := -1
	xMax := -1
	for y, _ := range input {
		if input[y][0] > xMax {
			xMax = input[y][0]
		}
	}
	for y, _ := range input {
		if input[y][1] > yMax {
			yMax = input[y][1]
		}
	}
	grid := make([][]string, yMax+1)
	for i := 0; i <= yMax; i++ {
		grid[i] = make([]string, xMax+1)
	}

	// Put initial dots
	for y := 0; y <= yMax; y++ {
		for x := 0; x <= xMax; x++ {
			grid[y][x] = "."
		}
	}

	// Put initial hashes
	for i, _ := range input {
		y := input[i][1]
		x := input[i][0]
		grid[y][x] = "#"
	}

	// Initialize hashes count to 0
	hashesCount := 0

	// Fold y-axis
	if axis == "y" {
		if yMax-axisIndex <= axisIndex-0 {
			// Easy case
			for y := axisIndex + 1; y <= yMax; y++ {
				for x := 0; x <= xMax; x++ {
					value := grid[y][x]
					yDiff := y - axisIndex
					if grid[axisIndex-yDiff][x] != "#" {
						grid[axisIndex-yDiff][x] = value
					}
				}
			}

			// Count hashes
			for y := 0; y < axisIndex; y++ {
				for x := 0; x <= xMax; x++ {
					if grid[y][x] == "#" {
						hashesCount++
					}
				}
			}
		} else {
			// Tricky case
			// Create a new grid
			newGrid := make([][]string, yMax-axisIndex)
			for i := 0; i < yMax-axisIndex; i++ {
				newGrid[i] = make([]string, xMax+1)
			}

			// Fill from the bottom of the old grid
			yNewGrid := 0
			for y := yMax; y > axisIndex; y-- {
				for x := 0; x <= xMax; x++ {
					value := grid[y][x]
					newGrid[yNewGrid][x] = value
				}
				yNewGrid++
			}

			// Fill from the top of the old grid
			yMaxNew := yMax - axisIndex - 1
			yNew := yMaxNew
			for y := axisIndex - 1; y >= 0; y-- {
				for x := 0; x <= xMax; x++ {
					value := grid[y][x]
					if newGrid[yNew][x] != "#" {
						newGrid[yNew][x] = value
					}
				}
				yNew--
			}

			// Count hashes
			for y := 0; y <= yMaxNew; y++ {
				for x := 0; x <= xMax; x++ {
					if newGrid[y][x] == "#" {
						hashesCount++
					}
				}
			}
		}
	}

	// Fold x-axis
	if axis == "x" {
		if xMax-axisIndex <= axisIndex-0 {
			// Easy case
			for y := 0; y <= yMax; y++ {
				for x := axisIndex + 1; x <= xMax; x++ {
					value := grid[y][x]
					xDiff := x - axisIndex
					if grid[y][axisIndex-xDiff] != "#" {
						grid[y][axisIndex-xDiff] = value
					}
				}
			}

			// Count hashes
			for y := 0; y <= yMax; y++ {
				for x := 0; x < axisIndex; x++ {
					if grid[y][x] == "#" {
						hashesCount++
					}
				}
			}
		} else {
			// Tricky case
			// Create a new grid
			newGrid := make([][]string, yMax+1)
			for i := 0; i < xMax-axisIndex; i++ {
				newGrid[i] = make([]string, xMax-axisIndex)
			}

			// Fill from the right of the old grid
			xNewGrid := 0
			for y := 0; y <= yMax; y++ {
				for x := xMax; x > axisIndex; x-- {
					value := grid[y][x]
					newGrid[y][xNewGrid] = value
				}
				xNewGrid++
			}

			// Fill from the left of the old grid
			xMaxNew := xMax - axisIndex - 1
			xNew := xMaxNew
			for y := 0; y <= yMax; y++ {
				for x := axisIndex - 1; x >= 0; x-- {
					value := grid[y][x]
					if newGrid[y][xNew] != "#" {
						newGrid[y][xNew] = value
					}
				}
				xNew--
			}

			// Count hashes
			for y := 0; y <= yMax; y++ {
				for x := 0; x <= xMaxNew; x++ {
					if newGrid[y][x] == "#" {
						hashesCount++
					}
				}
			}
		}
	}

	return hashesCount
}

func Day13_1(input [][]int, folds []string) {
	// Create initial 2D grid
	yMax := -1
	xMax := -1
	for y, _ := range input {
		if input[y][0] > xMax {
			xMax = input[y][0]
		}
	}
	for y, _ := range input {
		if input[y][1] > yMax {
			yMax = input[y][1]
		}
	}
	grid := make([][]string, yMax+1)
	for i := 0; i <= yMax; i++ {
		grid[i] = make([]string, xMax+1)
	}

	// Put initial dots
	for y := 0; y <= yMax; y++ {
		for x := 0; x <= xMax; x++ {
			grid[y][x] = "."
		}
	}

	// Put initial hashes
	for i, _ := range input {
		y := input[i][1]
		x := input[i][0]
		grid[y][x] = "#"
	}

	// Print out
	fmt.Println("Initial grid:")
	for _, yValue := range grid {
		for _, xValue := range yValue {
			fmt.Printf("%v", xValue)
		}
		fmt.Println()
	}
	fmt.Println()

	for foldIteration, aFold := range folds {
		aFoldInstruction := strings.Fields(aFold)
		aFoldString := strings.Split(aFoldInstruction[2], "=")
		axis := aFoldString[0]
		axisIndex, _ := strconv.Atoi(aFoldString[1])

		// Fold y-axis
		if axis == "y" {
			if yMax-axisIndex <= axisIndex-0 {
				// Easy case
				for y := axisIndex + 1; y <= yMax; y++ {
					for x := 0; x <= xMax; x++ {
						value := grid[y][x]
						yDiff := y - axisIndex
						if grid[axisIndex-yDiff][x] != "#" {
							grid[axisIndex-yDiff][x] = value
						}
					}
				}

				// Create a new grid
				newGrid := make([][]string, axisIndex)
				for i := 0; i < axisIndex; i++ {
					newGrid[i] = make([]string, xMax+1)
				}

				// Copy to new grid
				for y := 0; y < axisIndex; y++ {
					for x := 0; x <= xMax; x++ {
						newGrid[y][x] = grid[y][x]
					}
				}

				// Print out
				fmt.Printf("Fold iteration: %v\n", foldIteration)
				for _, yValue := range newGrid {
					for _, xValue := range yValue {
						fmt.Printf("%v", xValue)
					}
					fmt.Println()
				}
				fmt.Println()

				// Set new xMay, yMax, grid
				yMax = len(newGrid) - 1
				xMax = len(newGrid[0]) - 1
				grid = newGrid
			} else {
				// Tricky case
				// Create a new grid
				newGrid := make([][]string, yMax-axisIndex)
				for i := 0; i < yMax-axisIndex; i++ {
					newGrid[i] = make([]string, xMax+1)
				}

				// Fill from the bottom of the old grid
				yNewGrid := 0
				for y := yMax; y > axisIndex; y-- {
					for x := 0; x <= xMax; x++ {
						value := grid[y][x]
						newGrid[yNewGrid][x] = value
					}
					yNewGrid++
				}

				// Fill from the top of the old grid
				yMaxNew := yMax - axisIndex - 1
				yNew := yMaxNew
				for y := axisIndex - 1; y >= 0; y-- {
					for x := 0; x <= xMax; x++ {
						value := grid[y][x]
						if newGrid[yNew][x] != "#" {
							newGrid[yNew][x] = value
						}
					}
					yNew--
				}

				// Print out
				fmt.Printf("Fold iteration: %v\n", foldIteration)
				for _, yValue := range newGrid {
					for _, xValue := range yValue {
						fmt.Printf("%v", xValue)
					}
					fmt.Println()
				}
				fmt.Println()

				// Set new xMay, yMax, grid
				yMax = len(newGrid) - 1
				xMax = len(newGrid[0]) - 1
				grid = newGrid
			}
		}

		// Fold x-axis
		if axis == "x" {
			if xMax-axisIndex <= axisIndex-0 {
				// Easy case
				for y := 0; y <= yMax; y++ {
					for x := axisIndex + 1; x <= xMax; x++ {
						value := grid[y][x]
						xDiff := x - axisIndex
						if grid[y][axisIndex-xDiff] != "#" {
							grid[y][axisIndex-xDiff] = value
						}
					}
				}

				// Create a new grid
				newGrid := make([][]string, yMax+1)
				for i := 0; i <= yMax; i++ {
					newGrid[i] = make([]string, axisIndex)
				}

				// Copy to new grid
				for y := 0; y <= yMax; y++ {
					for x := 0; x < axisIndex; x++ {
						newGrid[y][x] = grid[y][x]
					}
				}

				// Print out
				fmt.Printf("Fold iteration: %v\n", foldIteration)
				for _, yValue := range newGrid {
					for _, xValue := range yValue {
						fmt.Printf("%v", xValue)
					}
					fmt.Println()
				}
				fmt.Println()

				// Set new xMay, yMax, grid
				yMax = len(newGrid) - 1
				xMax = len(newGrid[0]) - 1
				grid = newGrid
			} else {
				// Tricky case
				// Create a new grid
				newGrid := make([][]string, yMax+1)
				for i := 0; i < xMax-axisIndex; i++ {
					newGrid[i] = make([]string, xMax-axisIndex)
				}

				// Fill from the right of the old grid
				xNewGrid := 0
				for y := 0; y <= yMax; y++ {
					for x := xMax; x > axisIndex; x-- {
						value := grid[y][x]
						newGrid[y][xNewGrid] = value
					}
					xNewGrid++
				}

				// Fill from the left of the old grid
				xMaxNew := xMax - axisIndex - 1
				xNew := xMaxNew
				for y := 0; y <= yMax; y++ {
					for x := axisIndex - 1; x >= 0; x-- {
						value := grid[y][x]
						if newGrid[y][xNew] != "#" {
							newGrid[y][xNew] = value
						}
					}
					xNew--
				}

				// Print out
				fmt.Printf("Fold iteration: %v\n", foldIteration)
				for _, yValue := range newGrid {
					for _, xValue := range yValue {
						fmt.Printf("%v", xValue)
					}
					fmt.Println()
				}
				fmt.Println()

				// Set new xMay, yMax, grid
				yMax = len(newGrid) - 1
				xMax = len(newGrid[0]) - 1
				grid = newGrid
			}
		}
	}
}

func main() {
	file, err := os.Open("input.txt")
	if err != nil {
		log.Fatalf("failed to open")
	}
	scanner := bufio.NewScanner(file)
	scanner.Split(bufio.ScanLines)
	var inputArr [][]int
	var folds []string
	for scanner.Scan() {
		lineString := scanner.Text()
		if len(lineString) > 0 {
			if strings.Contains(lineString, "=") {
				folds = append(folds, lineString)
			} else {
				lineStringSplitted := strings.Split(lineString, ",")
				x, _ := strconv.Atoi(lineStringSplitted[0])
				y, _ := strconv.Atoi(lineStringSplitted[1])
				coordinate := []int{x, y}
				inputArr = append(inputArr, coordinate)
			}
		}
	}
	file.Close()

	resultDay13 := Day13(inputArr, folds)
	fmt.Println(resultDay13)
	Day13_1(inputArr, folds)
}
