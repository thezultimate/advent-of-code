package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strconv"
	"strings"
)

func Day8(inputArr []string) int {
	uniqueNumberCount := 0
	for _, inputString := range inputArr {
		inputStringSplitted := strings.Split(inputString, "|")
		outputString := inputStringSplitted[1]
		outputStringSplitted := strings.Fields(strings.TrimSpace(outputString))
		for _, segmentNumberString := range outputStringSplitted {
			segmentLength := len(segmentNumberString)
			if segmentLength == 2 || segmentLength == 3 || segmentLength == 4 || segmentLength == 7 {
				uniqueNumberCount++
			}
		}
	}
	return uniqueNumberCount
}

func Day8_1(inputArr []string) int {
	rightNumberSum := 0
	for _, inputString := range inputArr {
		var one, four, seven, eight string
		inputStringSplitted := strings.Split(inputString, "|")
		leftString := inputStringSplitted[0]
		leftStringSplitted := strings.Fields(strings.TrimSpace(leftString))
		rightString := inputStringSplitted[1]
		rightStringSplitted := strings.Fields(strings.TrimSpace(rightString))

		// Get one, four, seven, eight characters
		for _, segmentNumberString := range leftStringSplitted {
			segmentLength := len(segmentNumberString)
			if segmentLength == 2 {
				one = segmentNumberString
			}
			if segmentLength == 3 {
				seven = segmentNumberString
			}
			if segmentLength == 4 {
				four = segmentNumberString
			}
			if segmentLength == 7 {
				eight = segmentNumberString
			}
		}
		for _, segmentNumberString := range rightStringSplitted {
			segmentLength := len(segmentNumberString)
			if segmentLength == 2 {
				one = segmentNumberString
			}
			if segmentLength == 3 {
				seven = segmentNumberString
			}
			if segmentLength == 4 {
				four = segmentNumberString
			}
			if segmentLength == 7 {
				eight = segmentNumberString
			}
		}

		// Save known numbers' characters in a map
		oneMap := make(map[string]bool)
		fourMap := make(map[string]bool)
		sevenMap := make(map[string]bool)
		eightMap := make(map[string]bool)
		for _, aChar := range one {
			oneMap[string(aChar)] = true
		}
		for _, aChar := range four {
			fourMap[string(aChar)] = true
		}
		for _, aChar := range seven {
			sevenMap[string(aChar)] = true
		}
		for _, aChar := range eight {
			eightMap[string(aChar)] = true
		}

		// Get right number
		rightNumber := ""
		for _, segmentNumberString := range rightStringSplitted {
			segmentLength := len(segmentNumberString)

			// Obvious numbers
			if segmentLength == 2 {
				rightNumber += "1"
				continue
			}
			if segmentLength == 3 {
				rightNumber += "7"
				continue
			}
			if segmentLength == 4 {
				rightNumber += "4"
				continue
			}
			if segmentLength == 7 {
				rightNumber += "8"
				continue
			}

			// Tricky numbers
			if segmentLength == 5 {
				// Length 5
				containsOneSegmentCount := 0
				containsFourSegmentCount := 0
				for _, aChar := range segmentNumberString {
					if _, found := oneMap[string(aChar)]; found {
						containsOneSegmentCount++
					}
					if _, found := fourMap[string(aChar)]; found {
						containsFourSegmentCount++
					}
				}
				if containsOneSegmentCount == 2 {
					rightNumber += "3"
					continue
				}
				if containsFourSegmentCount == 2 {
					rightNumber += "2"
					continue
				}
				if containsFourSegmentCount == 3 {
					rightNumber += "5"
					continue
				}
			}

			if segmentLength == 6 {
				// Length 6
				containsOneSegmentCount := 0
				containsFourSegmentCount := 0
				for _, aChar := range segmentNumberString {
					if _, found := oneMap[string(aChar)]; found {
						containsOneSegmentCount++
					}
					if _, found := fourMap[string(aChar)]; found {
						containsFourSegmentCount++
					}
				}
				if containsOneSegmentCount != 2 {
					rightNumber += "6"
					continue
				}
				if containsFourSegmentCount == 4 {
					rightNumber += "9"
					continue
				}
				if containsFourSegmentCount == 3 {
					rightNumber += "0"
					continue
				}
			}
		}
		rightNumberInt, _ := strconv.Atoi(rightNumber)
		rightNumberSum += rightNumberInt
	}
	return rightNumberSum
}

func main() {
	file, err := os.Open("input.txt")
	if err != nil {
		log.Fatalf("failed to open")
	}
	scanner := bufio.NewScanner(file)
	scanner.Split(bufio.ScanLines)
	var inputArr []string
	for scanner.Scan() {
		lineString := scanner.Text()
		inputArr = append(inputArr, lineString)
	}
	file.Close()

	resultDay8 := Day8(inputArr)
	resultDay8_1 := Day8_1(inputArr)
	fmt.Println(resultDay8)
	fmt.Println(resultDay8_1)
}
