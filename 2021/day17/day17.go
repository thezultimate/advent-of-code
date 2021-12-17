package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strconv"
	"strings"
)

func Day17(xMin, xMax, yMin, yMax int) int {
	yHighs := make(map[int]bool)
	for xVelocityCandidate := 1; xVelocityCandidate <= 1000; xVelocityCandidate++ {
		for yVelocityCandidate := 1; yVelocityCandidate <= 1000; yVelocityCandidate++ {
			x := 0
			y := 0
			xVelocity := xVelocityCandidate
			yVelocity := yVelocityCandidate
			yHigh := 0
			for {
				x += xVelocity
				y += yVelocity

				if y > yHigh {
					yHigh = y
				}
				if xVelocity > 0 {
					xVelocity--
				}
				yVelocity--
				if x >= xMin && x <= xMax && y >= yMin && y <= yMax {
					// Hit!
					yHighs[yHigh] = true
					break
				}
				if x > xMax || y < yMin {
					// Overshot!
					break
				}
			}
		}
	}

	yHighest := 0
	for k, _ := range yHighs {
		if k > yHighest {
			yHighest = k
		}
	}

	return yHighest
}

func Day17_1(xMin, xMax, yMin, yMax int) int {
	hitCount := 0
	for xVelocityCandidate := 1; xVelocityCandidate <= 1000; xVelocityCandidate++ {
		for yVelocityCandidate := -1000; yVelocityCandidate <= 1000; yVelocityCandidate++ {
			x := 0
			y := 0
			xVelocity := xVelocityCandidate
			yVelocity := yVelocityCandidate
			for {
				x += xVelocity
				y += yVelocity
				if xVelocity > 0 {
					xVelocity--
				}
				yVelocity--
				if x >= xMin && x <= xMax && y >= yMin && y <= yMax {
					// Hit!
					hitCount++
					break
				}
				if x > xMax || y < yMin {
					// Overshot!
					break
				}
			}
		}
	}

	return hitCount
}

func main() {
	file, err := os.Open("input.txt")
	if err != nil {
		log.Fatalf("failed to open")
	}
	scanner := bufio.NewScanner(file)
	scanner.Split(bufio.ScanLines)
	var xMin, xMax, yMin, yMax int
	for scanner.Scan() {
		lineString := scanner.Text()
		splitByColon := strings.Split(lineString, ":")
		splitByComma := strings.Split(splitByColon[1], ",")
		xSection := splitByComma[0]
		ySection := splitByComma[1]
		xSplitByEqual := strings.Split(xSection, "=")
		ySplitByEqual := strings.Split(ySection, "=")
		xValues := strings.Split(xSplitByEqual[1], "..")
		yValues := strings.Split(ySplitByEqual[1], "..")
		xMin, _ = strconv.Atoi(xValues[0])
		xMax, _ = strconv.Atoi(xValues[1])
		yMin, _ = strconv.Atoi(yValues[0])
		yMax, _ = strconv.Atoi(yValues[1])
	}
	file.Close()

	resultDay17 := Day17(xMin, xMax, yMin, yMax)
	fmt.Println(resultDay17)
	resultDay17_1 := Day17_1(xMin, xMax, yMin, yMax)
	fmt.Println(resultDay17_1)
}
