package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strconv"
	"strings"
)

func Day4GetUnmarkedSumOfBoard(aBoard [][]int, aMarkerBoard [][]bool) int {
	unmarkedSum := 0
	for i, aBoardX := range aBoard {
		for j, aBoardY := range aBoardX {
			if !aMarkerBoard[i][j] {
				unmarkedSum += aBoardY
			}
		}
	}
	return unmarkedSum
}

func Day4(randomNumbers []int, boards [][][]int) int {
	// Make markerBoards
	markerBoards := make([][][]bool, len(boards))
	for i, aBoard := range boards {
		markerBoards[i] = make([][]bool, len(aBoard))
		for j, aBoardX := range aBoard {
			markerBoards[i][j] = make([]bool, len(aBoardX))
		}
	}

	// Initialize markerBoards with false
	for i, aMarkerBoard := range markerBoards {
		for j, aMarkerBoardX := range aMarkerBoard {
			for k, _ := range aMarkerBoardX {
				markerBoards[i][j][k] = false
			}
		}
	}

	for _, randomNumber := range randomNumbers {
		// Mark all boards that have randomNumber
		for i, aBoard := range boards {
			for j, aBoardX := range aBoard {
				for k, aBoardY := range aBoardX {
					if aBoardY == randomNumber {
						markerBoards[i][j][k] = true

						// Check if horizontal line of point j,k is all true
						allTrueInLine := true
						for checkIndex, _ := range markerBoards[i][j] {
							if !markerBoards[i][j][checkIndex] {
								allTrueInLine = false
								break
							}
						}
						if allTrueInLine {
							// Bingo!
							unmarkedSumOfBoard := Day4GetUnmarkedSumOfBoard(aBoard, markerBoards[i])
							return randomNumber * unmarkedSumOfBoard
						}

						// Check if vertical line of point j,k is all true
						allTrueInLine = true
						for checkIndex, _ := range markerBoards[i] {
							if !markerBoards[i][checkIndex][k] {
								allTrueInLine = false
								break
							}
						}
						if allTrueInLine {
							// Bingo!
							unmarkedSumOfBoard := Day4GetUnmarkedSumOfBoard(aBoard, markerBoards[i])
							return randomNumber * unmarkedSumOfBoard
						}
					}
				}
			}
		}
	}

	return -1
}

func Day4_1(randomNumbers []int, boards [][][]int) int {
	// Make markerBoards
	markerBoards := make([][][]bool, len(boards))
	for i, aBoard := range boards {
		markerBoards[i] = make([][]bool, len(aBoard))
		for j, aBoardX := range aBoard {
			markerBoards[i][j] = make([]bool, len(aBoardX))
		}
	}

	// Initialize markerBoards with false
	for i, aMarkerBoard := range markerBoards {
		for j, aMarkerBoardX := range aMarkerBoard {
			for k, _ := range aMarkerBoardX {
				markerBoards[i][j][k] = false
			}
		}
	}

	numberOfBoardsRemaining := len(boards)

	for _, randomNumber := range randomNumbers {
		// Mark all boards that have randomNumber
		for i, aBoard := range boards {
		BoardsLoop:
			for j, aBoardX := range aBoard {
				for k, aBoardY := range aBoardX {
					if aBoardY == randomNumber {
						markerBoards[i][j][k] = true

						// Check if horizontal line of point j,k is all true
						allTrueInLine := true
						for checkIndex, _ := range markerBoards[i][j] {
							if !markerBoards[i][j][checkIndex] {
								allTrueInLine = false
								break
							}
						}
						if allTrueInLine {
							// Bingo!
							if numberOfBoardsRemaining > 1 {
								numberOfBoardsRemaining--
								boards[i] = nil
								break BoardsLoop
							}
							if numberOfBoardsRemaining == 1 {
								unmarkedSumOfBoard := Day4GetUnmarkedSumOfBoard(aBoard, markerBoards[i])
								return randomNumber * unmarkedSumOfBoard
							}
						}

						// Check if vertical line of point j,k is all true
						allTrueInLine = true
						for checkIndex, _ := range markerBoards[i] {
							if !markerBoards[i][checkIndex][k] {
								allTrueInLine = false
								break
							}
						}
						if allTrueInLine {
							// Bingo!
							if numberOfBoardsRemaining > 1 {
								numberOfBoardsRemaining--
								boards[i] = nil
								break BoardsLoop
							}
							if numberOfBoardsRemaining == 1 {
								unmarkedSumOfBoard := Day4GetUnmarkedSumOfBoard(aBoard, markerBoards[i])
								return randomNumber * unmarkedSumOfBoard
							}
						}
					}
				}
			}
		}
	}

	return -1
}

func main() {
	file, err := os.Open("input.txt")
	if err != nil {
		log.Fatalf("failed to open")
	}
	scanner := bufio.NewScanner(file)
	scanner.Split(bufio.ScanLines)
	var randomNumbers []int
	var boards [][][]int
	var aBoardX [][]int
	for scanner.Scan() {
		lineString := scanner.Text()
		lineStringLength := len(lineString)
		// fmt.Println(lineStringLength)
		if lineStringLength > 100 {
			splitByComma := strings.Split(lineString, ",")
			for _, randomNumberString := range splitByComma {
				randomNumber, _ := strconv.Atoi(randomNumberString)
				randomNumbers = append(randomNumbers, randomNumber)
			}
		}
		if lineStringLength > 0 && lineStringLength < 100 {
			splitByWhiteSpace := strings.Fields(lineString)
			var aBoardY []int
			for _, aNumberString := range splitByWhiteSpace {
				aNumber, _ := strconv.Atoi(aNumberString)
				aBoardY = append(aBoardY, aNumber)
			}
			aBoardX = append(aBoardX, aBoardY)
		}
		if lineStringLength == 0 {
			if aBoardX != nil {
				boards = append(boards, aBoardX)
			}
			aBoardX = nil
		}
	}
	boards = append(boards, aBoardX)
	file.Close()

	// for _, randomNumber := range randomNumbers {
	// 	fmt.Printf("%v ", randomNumber)
	// }

	// firstBoard := boards[0]
	// for _, firstBoardX := range firstBoard {
	// 	for _, firstBoardY := range firstBoardX {
	// 		fmt.Printf("%v ", firstBoardY)
	// 	}
	// 	fmt.Println()
	// }

	// lastBoard := boards[len(boards)-1]
	// for _, lastBoardX := range lastBoard {
	// 	for _, lastBoardY := range lastBoardX {
	// 		fmt.Printf("%v ", lastBoardY)
	// 	}
	// 	fmt.Println()
	// }

	resultDay4 := Day4(randomNumbers, boards)
	resultDay4_1 := Day4_1(randomNumbers, boards)
	fmt.Println(resultDay4)
	fmt.Println(resultDay4_1)
}
