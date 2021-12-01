package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strconv"
	"strings"
)

func Day21(input []string) int {
	// Get start positions of players
	var startPositions []int
	for _, v := range input {
		playerStringSplitted := strings.Split(v, ":")
		startPositionString := playerStringSplitted[1]
		startPosition, _ := strconv.Atoi(strings.TrimSpace(startPositionString))
		startPositions = append(startPositions, startPosition)
	}

	// Points for each player
	points := make([]int, len(input))

	// Total number of rolls
	totalDiceRollCounter := 0

	// Number of rolls per player (don't really need this, apparently)
	diceRollCounter := make([]int, len(input))

	// 100 dice counter
	diceCounter := 0

RoundIteration:
	// Iterate each round until someone gets 1000 points
	for {
		// Iterate on each player
		for i, _ := range input {
			roundDiceSum := 0
			// roundDiceCounter := diceCounter + 1
			for j := 1; j <= 3; j++ {
				diceCounter++
				if diceCounter > 100 {
					diceCounter = 1
				}
				roundDiceSum += diceCounter
				totalDiceRollCounter++
			}
			diceRollCounter[i] = totalDiceRollCounter
			if roundDiceSum > 10 {
				roundDiceSum %= 10
			}
			roundPosition := startPositions[i] + roundDiceSum
			if roundPosition > 10 {
				roundPosition %= 10
			}
			points[i] += roundPosition
			startPositions[i] = roundPosition
			if points[i] >= 1000 {
				break RoundIteration
			}
		}
	}

	minIndex := 0
	minPoints := 999999999999
	for i, v := range points {
		if v < minPoints {
			minPoints = v
			minIndex = i
		}
	}

	return points[minIndex] * totalDiceRollCounter
}

func main() {
	file, err := os.Open("input.txt")
	if err != nil {
		log.Fatalf("failed to open")
	}
	scanner := bufio.NewScanner(file)
	scanner.Split(bufio.ScanLines)
	var input []string
	for scanner.Scan() {
		lineString := scanner.Text()
		input = append(input, lineString)
	}
	file.Close()

	resultDay21 := Day21(input)
	fmt.Println(resultDay21)
}
