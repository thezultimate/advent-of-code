package main

import (
	"bufio"
	"fmt"
	"log"
	"math"
	"os"
	"sort"
	"strconv"
	"strings"
)

func Day7GetDistanceSumFromPivot(inputArr []int, pivot int) int {
	sum := 0
	for _, inputInt := range inputArr {
		sum += int(math.Abs(float64(inputInt - pivot)))
	}
	return sum
}

func Day7(inputArr []int) int {
	sort.Ints(inputArr)
	inputLength := len(inputArr)
	if inputLength%2 != 0 {
		// Odd length
		midIndex := inputLength / 2
		return Day7GetDistanceSumFromPivot(inputArr, inputArr[midIndex])
	} else {
		// Even length
		mid2Index := inputLength / 2
		mid1Index := mid2Index - 1
		if inputArr[mid1Index] == inputArr[mid2Index] {
			// Both mid candidates have same values
			return Day7GetDistanceSumFromPivot(inputArr, inputArr[mid1Index])
		} else {
			// Both mid candidates have different values
			sum1 := Day7GetDistanceSumFromPivot(inputArr, inputArr[mid1Index])
			sum2 := Day7GetDistanceSumFromPivot(inputArr, inputArr[mid2Index])
			if sum1 <= sum2 {
				return sum1
			} else {
				return sum2
			}
		}
	}
}

func Day7_1GetDistanceCostMap(inputArr []int) map[int]int {
	distanceCostMap := make(map[int]int)
	min := 99999
	max := -99999
	for _, inputInt := range inputArr {
		if inputInt < min {
			min = inputInt
		}
		if inputInt > max {
			max = inputInt
		}
	}
	maxDistance := max - min
	distanceSum := 0
	for i := 1; i <= maxDistance; i++ {
		distanceSum += i
		distanceCostMap[i] = distanceSum
	}
	return distanceCostMap
}

func Day7_1(inputArr []int) int {
	sort.Ints(inputArr)
	inputLength := len(inputArr)
	minInput := inputArr[0]
	maxInput := inputArr[inputLength-1]
	distanceCostMap := Day7_1GetDistanceCostMap(inputArr)
	minDistanceCostSum := 999999999
	for pivot := minInput; pivot <= maxInput; pivot++ {
		currentDistanceCostSum := 0
		for _, inputInt := range inputArr {
			distance := int(math.Abs(float64(inputInt - pivot)))
			currentDistanceCostSum += distanceCostMap[distance]
		}
		if currentDistanceCostSum < minDistanceCostSum {
			minDistanceCostSum = currentDistanceCostSum
		}
	}
	return minDistanceCostSum
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

	resultDay7 := Day7(inputArr)
	resultDay7_1 := Day7_1(inputArr)
	fmt.Println(resultDay7)
	fmt.Println(resultDay7_1)
}
