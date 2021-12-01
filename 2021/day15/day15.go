package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strconv"
)

type Coordinate struct {
	y, x int
}

// DFS, doesn't scale
func Day15_DFS(input [][]int) int {
	startCoordinate := Coordinate{0, 0}

	// Create already traversed coordinate map
	traversedCoordinates := make(map[Coordinate]bool)

	totalSums := make(map[int]bool)
	aPathSum := 0
	var coordinateArr []Coordinate

	Traverse(startCoordinate, input, aPathSum, totalSums, traversedCoordinates, coordinateArr)

	min := 999999999999
	for k, _ := range totalSums {
		if k < min {
			min = k
		}
	}

	return min
}

func Traverse(coordinate Coordinate, input [][]int, aPathSum int, totalSums map[int]bool, traversedCoordinates map[Coordinate]bool, coordinateArr []Coordinate) {
	// Copy coordinateArr
	var coordinateArrCopy []Coordinate
	for _, v := range coordinateArr {
		coordinateArrCopy = append(coordinateArrCopy, v)
	}

	// Copy traversedCoordinates map
	traversedCoordinatesCopy := make(map[Coordinate]bool)
	for k, v := range traversedCoordinates {
		traversedCoordinatesCopy[k] = v
	}

	// Add current coordinate to coordinateArrCopy
	coordinateArrCopy = append(coordinateArrCopy, coordinate)

	if _, found := traversedCoordinatesCopy[coordinate]; !found {
		// This coordinate has not been traversed
		// Add this coordinate to traversed coordinate
		traversedCoordinatesCopy[coordinate] = true

		// Add current coordinate risk level
		aPathSum += input[coordinate.y][coordinate.x]
		if coordinate.y == len(input)-1 && coordinate.x == len(input[0])-1 {
			// Destination reached
			// Append current path's risk level
			totalSums[aPathSum] = true
		} else {
			// All other coordinate except destination
			if coordinate.x+1 < len(input[0]) {
				// Traverse right
				Traverse(Coordinate{coordinate.y, coordinate.x + 1}, input, aPathSum, totalSums, traversedCoordinatesCopy, coordinateArrCopy)
			}
			if coordinate.x-1 >= 0 {
				// Traverse left
				Traverse(Coordinate{coordinate.y, coordinate.x - 1}, input, aPathSum, totalSums, traversedCoordinatesCopy, coordinateArrCopy)
			}
			if coordinate.y+1 < len(input) {
				// Traverse below
				Traverse(Coordinate{coordinate.y + 1, coordinate.x}, input, aPathSum, totalSums, traversedCoordinatesCopy, coordinateArrCopy)
			}
			if coordinate.y-1 >= 0 {
				// Traverse above
				Traverse(Coordinate{coordinate.y - 1, coordinate.x}, input, aPathSum, totalSums, traversedCoordinatesCopy, coordinateArrCopy)
			}
		}
	}
}

// Use Djikstra instead of DFS (took hours for part 2, probably should have used priority queue)
func Day15(input [][]int) int {
	// Create visited coordinate set
	coordinatesSet := make(map[Coordinate]bool)

	// Create and initialize distance map coordinate -> value
	distancesMap := make(map[Coordinate]int)
	for y, yValue := range input {
		for x, _ := range yValue {
			aCoordinate := Coordinate{y, x}
			if y == 0 && x == 0 {
				// Start coordinate
				distancesMap[aCoordinate] = 0
			} else {
				// All other coordinates
				distancesMap[aCoordinate] = 999999999999
			}

			// Add to coordinates set
			coordinatesSet[aCoordinate] = true
		}
	}

	// While coordinate set is not empty
	for len(coordinatesSet) > 0 {
		// Get coordinate with min distance
		var coordinateWithMinDistance Coordinate
		minDistance := 999999999999
		for k, v := range distancesMap {
			if _, found := coordinatesSet[k]; found {
				if v < minDistance {
					minDistance = v
					coordinateWithMinDistance = k
				}
			}
		}

		// Remove min distance coordinate from coordinate set
		delete(coordinatesSet, coordinateWithMinDistance)

		// Terminate if target is reached
		if coordinateWithMinDistance.y == len(input)-1 && coordinateWithMinDistance.x == len(input[0])-1 {
			break
		}

		// For each neighbour
		if coordinateWithMinDistance.x+1 < len(input[0]) {
			// Right neighbour
			altDistance := distancesMap[coordinateWithMinDistance] + input[coordinateWithMinDistance.y][coordinateWithMinDistance.x+1]
			rightCoordinate := Coordinate{coordinateWithMinDistance.y, coordinateWithMinDistance.x + 1}
			if altDistance < distancesMap[rightCoordinate] {
				distancesMap[rightCoordinate] = altDistance
			}
		}
		if coordinateWithMinDistance.x-1 >= 0 {
			// Left neighbour
			altDistance := distancesMap[coordinateWithMinDistance] + input[coordinateWithMinDistance.y][coordinateWithMinDistance.x-1]
			leftCoordinate := Coordinate{coordinateWithMinDistance.y, coordinateWithMinDistance.x - 1}
			if altDistance < distancesMap[leftCoordinate] {
				distancesMap[leftCoordinate] = altDistance
			}
		}
		if coordinateWithMinDistance.y+1 < len(input) {
			// Below neighbour
			altDistance := distancesMap[coordinateWithMinDistance] + input[coordinateWithMinDistance.y+1][coordinateWithMinDistance.x]
			belowCoordinate := Coordinate{coordinateWithMinDistance.y + 1, coordinateWithMinDistance.x}
			if altDistance < distancesMap[belowCoordinate] {
				distancesMap[belowCoordinate] = altDistance
			}
		}
		if coordinateWithMinDistance.y-1 >= 0 {
			// Above neighbour
			altDistance := distancesMap[coordinateWithMinDistance] + input[coordinateWithMinDistance.y-1][coordinateWithMinDistance.x]
			aboveCoordinate := Coordinate{coordinateWithMinDistance.y - 1, coordinateWithMinDistance.x}
			if altDistance < distancesMap[aboveCoordinate] {
				distancesMap[aboveCoordinate] = altDistance
			}
		}
	}

	targetCoordinate := Coordinate{len(input) - 1, len(input[0]) - 1}
	return distancesMap[targetCoordinate]
}

func Day15_1(input [][]int) int {
	inputFiveTimes := make([][]int, len(input)*5)
	for i := 0; i < len(input)*5; i++ {
		inputFiveTimes[i] = make([]int, len(input[0])*5)
	}

	for j := 0; j < 5; j++ {
		xBig := 0
		for y := 0; y < len(input); y++ {
			for i := 0; i < 5; i++ {
				for x := 0; x < len(input[0]); x++ {
					value := input[y][x]
					if xBig >= len(input[0]) {
						value = inputFiveTimes[y][xBig-len(input[0])] + 1
						if value > 9 {
							value = 1
						}
					}
					inputFiveTimes[y][xBig] = value
					xBig++
				}
			}
			xBig = 0
		}
	}

	for y := 0; y < len(inputFiveTimes); y++ {
		for x := 0; x < len(inputFiveTimes[0]); x++ {
			value := inputFiveTimes[y][x]
			if y >= len(input) {
				value = inputFiveTimes[y-len(input)][x] + 1
				if value > 9 {
					value = 1
				}
			}
			inputFiveTimes[y][x] = value
		}
	}

	return Day15(inputFiveTimes)
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

	resultDay15 := Day15(inputArr)
	resultDay15_1 := Day15_1(inputArr)
	fmt.Println(resultDay15)
	fmt.Println(resultDay15_1)
}
