package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strings"
)

func Day14(input string, midCharMap map[string]string, steps int) int {
	// Create a map of position index -> character
	inputIndexMap := make(map[int]string)

	// Create character occurrences map
	charOccurrencesMap := make(map[string]int)

	// Initialize both maps
	for i, v := range input {
		inputIndexMap[i] = string(v)
		if _, found := charOccurrencesMap[string(v)]; found {
			charOccurrencesMap[string(v)]++
		} else {
			charOccurrencesMap[string(v)] = 1
		}
	}

	// Iterate through steps
	for step := 1; step <= steps; step++ {
		ExecuteStep(0, inputIndexMap, midCharMap, charOccurrencesMap)
	}

	// Get min and max from charOccurrencesMap
	min := 999999
	max := -1
	for _, v := range charOccurrencesMap {
		if v < min {
			min = v
		}
		if v > max {
			max = v
		}
	}

	return max - min
}

func ExecuteStep(startIndex int, inputIndexMap map[int]string, midCharMap map[string]string, charOccurrencesMap map[string]int) {
	endIndex := startIndex + 1
	pair := inputIndexMap[startIndex] + inputIndexMap[endIndex]
	if midChar, found := midCharMap[pair]; found {
		// Shift inputIndexMap index to the right
		for i := len(inputIndexMap) - 1; i >= endIndex; i-- {
			inputIndexMap[i+1] = inputIndexMap[i]
		}
		inputIndexMap[endIndex] = midChar
		if _, found := charOccurrencesMap[midChar]; found {
			charOccurrencesMap[midChar]++
		} else {
			charOccurrencesMap[midChar] = 1
		}
	}
	if endIndex+1 < len(inputIndexMap)-1 {
		ExecuteStep(endIndex+1, inputIndexMap, midCharMap, charOccurrencesMap)
	}
}

// Only count the pairs, no recursion!
func Day14_1(input string, midCharMap map[string]string, steps int) int {
	// Create character occurrences map
	charOccurrencesMap := make(map[string]int)

	// Initialize character occurrences maps
	for _, v := range input {
		if _, found := charOccurrencesMap[string(v)]; found {
			charOccurrencesMap[string(v)]++
		} else {
			charOccurrencesMap[string(v)] = 1
		}
	}

	// Create pair counter map
	pairCounterMap := make(map[string]int)

	// Initialize pair counter maps
	for i := 0; i < len(input)-1; i++ {
		pair := string(input[i]) + string(input[i+1])
		if _, found := pairCounterMap[pair]; found {
			pairCounterMap[pair]++
		} else {
			pairCounterMap[pair] = 1
		}
	}

	// Iterate through steps
	for step := 1; step <= steps; step++ {
		// Copy pairCounterMap
		pairCounterMapCopy := make(map[string]int)
		for k, v := range pairCounterMap {
			pairCounterMapCopy[k] = v
		}

		for k, v := range midCharMap {
			if counter, found := pairCounterMap[k]; found {
				if counter > 0 {
					// "Insert" v to mid
					leftChar := string(k[0])
					rightChar := string(k[1])
					pairCounterMapCopy[k] -= counter
					if _, found2 := pairCounterMapCopy[leftChar+v]; found2 {
						pairCounterMapCopy[leftChar+v] += counter
					} else {
						pairCounterMapCopy[leftChar+v] = counter
					}
					if _, found2 := pairCounterMapCopy[v+rightChar]; found2 {
						pairCounterMapCopy[v+rightChar] += counter
					} else {
						pairCounterMapCopy[v+rightChar] = counter
					}

					// Increase occurrence of v
					if _, found := charOccurrencesMap[v]; found {
						charOccurrencesMap[v] += counter
					} else {
						charOccurrencesMap[v] = counter
					}
				}
			}
		}

		pairCounterMap = pairCounterMapCopy
	}

	// Get min and max from charOccurrencesMap
	min := charOccurrencesMap["N"]
	max := charOccurrencesMap["N"]
	for _, v := range charOccurrencesMap {
		if v < min {
			min = v
		}
		if v > max {
			max = v
		}
	}

	return max - min
}

func main() {
	file, err := os.Open("input.txt")
	if err != nil {
		log.Fatalf("failed to open")
	}
	scanner := bufio.NewScanner(file)
	scanner.Split(bufio.ScanLines)
	var input string
	midCharMap := make(map[string]string)
	for scanner.Scan() {
		lineString := scanner.Text()
		if len(lineString) > 0 {
			if strings.Contains(lineString, "->") {
				midCharSplitted := strings.Split(lineString, "->")
				midCharMap[strings.TrimSpace(midCharSplitted[0])] = strings.TrimSpace(midCharSplitted[1])
			} else {
				input = lineString
			}
		}
	}
	file.Close()

	resultDay14 := Day14(input, midCharMap, 10)
	resultDay14_1 := Day14_1(input, midCharMap, 40)
	fmt.Println(resultDay14)
	fmt.Println(resultDay14_1)
}
