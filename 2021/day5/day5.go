package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strconv"
	"strings"
)

func Day5GetMaxXYStraightLine(input [][][]int) (int, int) {
	maxX := 0
	maxY := 0
	// Iterate through each input line
	for _, inputLine := range input {
		// Choose only horizontal or vertical lines
		if inputLine[0][0] == inputLine[1][0] || inputLine[0][1] == inputLine[1][1] {
			if inputLine[0][0] > maxX {
				maxX = inputLine[0][0]
			}
			if inputLine[1][0] > maxX {
				maxX = inputLine[1][0]
			}
			if inputLine[0][1] > maxY {
				maxY = inputLine[0][1]
			}
			if inputLine[1][1] > maxY {
				maxY = inputLine[1][1]
			}
		}
	}
	return maxX, maxY
}

func Day5(input [][][]int) int {
	// Make diagram
	maxX, maxY := Day5GetMaxXYStraightLine(input)
	diagram := make([][]int, maxX+1)
	for i := range diagram {
		diagram[i] = make([]int, maxY+1)
	}

	// Iterate through each input line to populate the diagram
	for _, inputLine := range input {
		// Choose only horizontal or vertical lines
		if inputLine[0][0] == inputLine[1][0] || inputLine[0][1] == inputLine[1][1] {
			if inputLine[0][0] == inputLine[1][0] {
				// Horizontal line
				x := inputLine[0][0]
				var low, high int
				if inputLine[0][1] <= inputLine[1][1] {
					low = inputLine[0][1]
					high = inputLine[1][1]
				} else {
					low = inputLine[1][1]
					high = inputLine[0][1]
				}
				for y := low; y <= high; y++ {
					diagram[y][x]++
				}
			} else {
				// Vertical line
				y := inputLine[0][1]
				var low, high int
				if inputLine[0][0] <= inputLine[1][0] {
					low = inputLine[0][0]
					high = inputLine[1][0]
				} else {
					low = inputLine[1][0]
					high = inputLine[0][0]
				}
				for x := low; x <= high; x++ {
					diagram[y][x]++
				}
			}
		}
	}

	// Count diagram point with value >= 2
	count := 0
	for _, diagramX := range diagram {
		for _, diagramY := range diagramX {
			if diagramY >= 2 {
				count++
			}
		}
	}
	return count
}

func Day5_1(input [][][]int) int {
	// Make diagram
	maxX, maxY := Day5GetMaxXYStraightLine(input)
	diagram := make([][]int, maxX+1)
	for i := range diagram {
		diagram[i] = make([]int, maxY+1)
	}

	// Iterate through each input line to populate the diagram
	for _, inputLine := range input {
		// Choose only horizontal or vertical lines
		if inputLine[0][0] == inputLine[1][0] || inputLine[0][1] == inputLine[1][1] {
			if inputLine[0][0] == inputLine[1][0] {
				// Horizontal line
				x := inputLine[0][0]
				var low, high int
				if inputLine[0][1] <= inputLine[1][1] {
					low = inputLine[0][1]
					high = inputLine[1][1]
				} else {
					low = inputLine[1][1]
					high = inputLine[0][1]
				}
				for y := low; y <= high; y++ {
					diagram[y][x]++
				}
			} else {
				// Vertical line
				y := inputLine[0][1]
				var low, high int
				if inputLine[0][0] <= inputLine[1][0] {
					low = inputLine[0][0]
					high = inputLine[1][0]
				} else {
					low = inputLine[1][0]
					high = inputLine[0][0]
				}
				for x := low; x <= high; x++ {
					diagram[y][x]++
				}
			}
		} else {
			// Diagonal lines 45 degrees
			startPointX := inputLine[0][0]
			startPointY := inputLine[0][1]
			endPointX := inputLine[1][0]
			endPointY := inputLine[1][1]
			var diffX, diffY int
			if startPointX > endPointX {
				diffX = startPointX - endPointX
			}
			if startPointX < endPointX {
				diffX = endPointX - startPointX
			}
			if startPointY > endPointY {
				diffY = startPointY - endPointY
			}
			if startPointY < endPointY {
				diffY = endPointY - startPointY
			}
			if diffX == diffY {
				steps := diffX + 1
				for step := 1; step <= steps; step++ {
					diagram[startPointY][startPointX]++
					if startPointX > endPointX {
						startPointX--
					}
					if startPointX < endPointX {
						startPointX++
					}
					if startPointY > endPointY {
						startPointY--
					}
					if startPointY < endPointY {
						startPointY++
					}
				}
				if inputLine[0][0] > inputLine[1][0] {
					startPointX--
				}
				if inputLine[0][0] < inputLine[1][0] {
					startPointX++
				}
				if inputLine[0][1] > inputLine[1][1] {
					startPointY--
				}
				if inputLine[0][1] < inputLine[1][1] {
					startPointY++
				}
			}
		}
	}

	// Count diagram point with value >= 2
	count := 0
	for _, diagramX := range diagram {
		for _, diagramY := range diagramX {
			if diagramY >= 2 {
				count++
			}
		}
	}
	return count
}

func main() {
	file, err := os.Open("input.txt")
	if err != nil {
		log.Fatalf("failed to open")
	}
	scanner := bufio.NewScanner(file)
	scanner.Split(bufio.ScanLines)
	var input [][][]int
	for scanner.Scan() {
		lineString := scanner.Text()
		pointsStringArr := strings.Split(lineString, "->")
		startPointStringArr := strings.Split(strings.TrimSpace(pointsStringArr[0]), ",")
		startPointX, _ := strconv.Atoi(startPointStringArr[0])
		startPointY, _ := strconv.Atoi(startPointStringArr[1])
		endPointStringArr := strings.Split(strings.TrimSpace(pointsStringArr[1]), ",")
		endPointX, _ := strconv.Atoi(endPointStringArr[0])
		endPointY, _ := strconv.Atoi(endPointStringArr[1])
		startPointIntArr := []int{startPointX, startPointY}
		endPointIntArr := []int{endPointX, endPointY}
		lineIntArr := [][]int{startPointIntArr, endPointIntArr}
		input = append(input, lineIntArr)

	}
	file.Close()

	resultDay5 := Day5(input)
	resultDay5_1 := Day5_1(input)
	fmt.Println(resultDay5)
	fmt.Println(resultDay5_1)
}
