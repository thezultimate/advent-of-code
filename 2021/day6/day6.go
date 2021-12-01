package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strconv"
	"strings"
)

func Day6(inputArr []int, observationDays int) int {
	fishContainer := inputArr
	numberOfNewFishes := 0
	// Repeat for the number of observation days
	for i := observationDays; i > 0; i-- {
		for j, remainingDay := range fishContainer {
			if remainingDay == 0 {
				// Times up!
				fishContainer[j] = 6
				numberOfNewFishes++
			} else {
				fishContainer[j]--
			}
		}
		// Spawn new fishes
		for k := 0; k < numberOfNewFishes; k++ {
			fishContainer = append(fishContainer, 8)
		}
		numberOfNewFishes = 0
	}
	return len(fishContainer)
}

func Day6Alternative(inputArr []int, observationDays int) int {
	key := 0
	fishMap := make(map[int]int)
	for _, inputInt := range inputArr {
		fishMap[key] = inputInt
		key++
	}
	numberOfNewFishes := 0
	// Repeat for the number of observation days
	for i := observationDays; i > 0; i-- {
		for j, remainingDay := range fishMap {
			if remainingDay == 0 {
				// Times up!
				fishMap[j] = 6
				numberOfNewFishes++
			} else {
				fishMap[j] = remainingDay - 1
			}
		}
		// Spawn new fishes
		for k := 0; k < numberOfNewFishes; k++ {
			// fishContainer = append(fishContainer, 8)
			fishMap[key] = 8
			key++
		}
		numberOfNewFishes = 0
	}
	return len(fishMap)
}

func Day6_1(inputArr []int, observationDays int) int {
	fishMap := make(map[int]int)
	for _, intputInt := range inputArr {
		if _, found := fishMap[intputInt]; !found {
			fishMap[intputInt] = CountFish(intputInt, observationDays)
		}
	}
	totalFish := 0
	for _, inputInt := range inputArr {
		totalFish += fishMap[inputInt]
	}
	return totalFish
}

func CountFish(remainingFishDays, remainingObservationDays int) int {
	count := 1
	diff := remainingObservationDays - (remainingFishDays + 1)
	if diff >= 0 {
		count += CountFish(8, diff)
	}
	diff -= 7
	for i := diff; i >= 0; i -= 7 {
		count += CountFish(8, i)
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
	var inputArr []int
	for scanner.Scan() {
		lineString := scanner.Text()
		inputStringArr := strings.Split(lineString, ",")
		for _, inputString := range inputStringArr {
			inputInt, _ := strconv.Atoi(inputString)
			inputArr = append(inputArr, inputInt)
		}
	}
	file.Close()

	resultDay6 := Day6(inputArr, 80)
	resultDay6_1 := Day6_1(inputArr, 256)
	fmt.Println(resultDay6)
	fmt.Println(resultDay6_1)
}
