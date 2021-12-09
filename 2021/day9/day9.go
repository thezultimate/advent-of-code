package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"sort"
	"strconv"
	"strings"
)

func Day9(input [][]int) int {
	sum := 0
	for y, yArr := range input {
		yLength := len(input)
		for x, aNumber := range yArr {
			if aNumber == 9 {
				continue
			}
			xLength := len(yArr)
			currentIsMin := true
			if x+1 < xLength {
				if input[y][x+1] < aNumber {
					currentIsMin = false
				}
			}
			if x-1 >= 0 {
				if input[y][x-1] < aNumber {
					currentIsMin = false
				}
			}
			if y+1 < yLength {
				if input[y+1][x] < aNumber {
					currentIsMin = false
				}
			}
			if y-1 >= 0 {
				if input[y-1][x] < aNumber {
					currentIsMin = false
				}
			}
			if currentIsMin {
				sum += aNumber + 1
			}
		}
	}
	return sum
}

func Day9_1(input [][]int) int {
	// Get low point coordinates
	var lowPointCoordinates []string
	for y, yArr := range input {
		yLength := len(input)
		for x, aNumber := range yArr {
			if aNumber == 9 {
				continue
			}
			xLength := len(yArr)
			currentIsMin := true
			if x+1 < xLength {
				if input[y][x+1] < aNumber {
					currentIsMin = false
				}
			}
			if x-1 >= 0 {
				if input[y][x-1] < aNumber {
					currentIsMin = false
				}
			}
			if y+1 < yLength {
				if input[y+1][x] < aNumber {
					currentIsMin = false
				}
			}
			if y-1 >= 0 {
				if input[y-1][x] < aNumber {
					currentIsMin = false
				}
			}
			if currentIsMin {
				currentCoordinate := strconv.Itoa(y) + "," + strconv.Itoa(x)
				lowPointCoordinates = append(lowPointCoordinates, currentCoordinate)
			}
		}
	}

	visitedCoordinates := make(map[string]bool)
	var basinSizes []int

	// For each low point coordinates
	for _, lowPointCoordinate := range lowPointCoordinates {
		visitedCoordinates[lowPointCoordinate] = true
		lowPointCoordinateSplitted := strings.Split(lowPointCoordinate, ",")
		y, _ := strconv.Atoi(string(lowPointCoordinateSplitted[0]))
		x, _ := strconv.Atoi(string(lowPointCoordinateSplitted[1]))
		pointsSum := CountPoint(input, y, x, visitedCoordinates)
		basinSizes = append(basinSizes, pointsSum)
	}

	sort.Ints(basinSizes)
	basinSizesLength := len(basinSizes)
	return basinSizes[basinSizesLength-1] * basinSizes[basinSizesLength-2] * basinSizes[basinSizesLength-3]
}

func CountPoint(input [][]int, y, x int, visitedCoordinates map[string]bool) int {
	yLength := len(input)
	xLength := len(input[0])
	sum := 1
	// Recursively call CountPoint for each neighbouring point
	if x+1 < xLength {
		if _, found := visitedCoordinates[strconv.Itoa(y)+","+strconv.Itoa(x+1)]; !found {
			if input[y][x+1] != 9 {
				visitedCoordinates[strconv.Itoa(y)+","+strconv.Itoa(x+1)] = true
				sum += CountPoint(input, y, x+1, visitedCoordinates)
			}
		}
	}
	if x-1 >= 0 {
		if _, found := visitedCoordinates[strconv.Itoa(y)+","+strconv.Itoa(x-1)]; !found {
			if input[y][x-1] != 9 {
				visitedCoordinates[strconv.Itoa(y)+","+strconv.Itoa(x-1)] = true
				sum += CountPoint(input, y, x-1, visitedCoordinates)
			}
		}
	}
	if y+1 < yLength {
		if _, found := visitedCoordinates[strconv.Itoa(y+1)+","+strconv.Itoa(x)]; !found {
			if input[y+1][x] != 9 {
				visitedCoordinates[strconv.Itoa(y+1)+","+strconv.Itoa(x)] = true
				sum += CountPoint(input, y+1, x, visitedCoordinates)
			}
		}
	}
	if y-1 >= 0 {
		if _, found := visitedCoordinates[strconv.Itoa(y-1)+","+strconv.Itoa(x)]; !found {
			if input[y-1][x] != 9 {
				visitedCoordinates[strconv.Itoa(y-1)+","+strconv.Itoa(x)] = true
				sum += CountPoint(input, y-1, x, visitedCoordinates)
			}
		}
	}
	return sum
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
		lineString := scanner.Text()
		var lineArr []int
		for _, aChar := range lineString {
			anInt, _ := strconv.Atoi(string(aChar))
			lineArr = append(lineArr, anInt)
		}
		inputArr = append(inputArr, lineArr)
	}
	file.Close()

	resultDay9 := Day9(inputArr)
	resultDay9_1 := Day9_1(inputArr)
	fmt.Println(resultDay9)
	fmt.Println(resultDay9_1)
}
