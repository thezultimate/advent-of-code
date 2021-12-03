package main

import (
	"bufio"
	"fmt"
	"log"
	"math"
	"os"
	"strconv"
)

func Day3BinaryToInt(input string) int {
	inputLength := len(input)
	result := float64(0)
	for i, char := range input {
		currentBit, _ := strconv.Atoi(string(char))
		result += math.Pow(2, float64(inputLength-i-1)) * float64(currentBit)
	}
	return int(result)
}

func Day3GetGammaAndEpsilonRates(inputArr []string) (int, int) {
	inputLength := len(inputArr)
	oneCounter := make(map[int]int)
	for _, binaryString := range inputArr {
		for i, char := range binaryString {
			currentBit, _ := strconv.Atoi(string(char))
			if _, found := oneCounter[i]; !found {
				oneCounter[i] = 0
			}
			if currentBit == 1 {
				oneCounter[i]++
			}
		}
	}
	gammaRateBinaryString := ""
	epsilonRateBinaryString := ""
	for _, oneCount := range oneCounter {
		if oneCount >= inputLength-oneCount {
			gammaRateBinaryString += "1"
			epsilonRateBinaryString += "0"
		} else {
			gammaRateBinaryString += "0"
			epsilonRateBinaryString += "1"
		}
	}
	return Day3BinaryToInt(gammaRateBinaryString), Day3BinaryToInt(epsilonRateBinaryString)
}

func Day3(inputArr []string) int {
	gamma, epsilon := Day3GetGammaAndEpsilonRates(inputArr)
	return gamma * epsilon
}

func Day3_1GetOxygenRating(inputArr []string) int {
	oxygenRatingBinary := Day3_1GetOxygenRatingBinary(inputArr, 0)
	return Day3BinaryToInt(oxygenRatingBinary)
}

func Day3_1GetOxygenRatingBinary(inputArr []string, currentIndex int) string {
	if len(inputArr) == 1 {
		return inputArr[0]
	}

	var oneArr []string
	var zeroArr []string
	for _, binaryString := range inputArr {
		if string(binaryString[currentIndex]) == "1" {
			oneArr = append(oneArr, binaryString)
		} else {
			zeroArr = append(zeroArr, binaryString)
		}
	}
	if len(oneArr) >= len(zeroArr) {
		return Day3_1GetOxygenRatingBinary(oneArr, currentIndex+1)
	} else {
		return Day3_1GetOxygenRatingBinary(zeroArr, currentIndex+1)
	}
}

func Day3_1GetCO2Rating(inputArr []string) int {
	co2RatingBinary := Day3_1GetCO2RatingBinary(inputArr, 0)
	return Day3BinaryToInt(co2RatingBinary)
}

func Day3_1GetCO2RatingBinary(inputArr []string, currentIndex int) string {
	if len(inputArr) == 1 {
		return inputArr[0]
	}

	var oneArr []string
	var zeroArr []string
	for _, binaryString := range inputArr {
		if string(binaryString[currentIndex]) == "1" {
			oneArr = append(oneArr, binaryString)
		} else {
			zeroArr = append(zeroArr, binaryString)
		}
	}
	if len(oneArr) < len(zeroArr) {
		return Day3_1GetCO2RatingBinary(oneArr, currentIndex+1)
	} else {
		return Day3_1GetCO2RatingBinary(zeroArr, currentIndex+1)
	}
}

func Day3_1(inputArr []string) int {
	return Day3_1GetOxygenRating(inputArr) * Day3_1GetCO2Rating(inputArr)
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

	resultDay3 := Day3(inputArr)
	resultDay3_1 := Day3_1(inputArr)
	fmt.Println(resultDay3)
	fmt.Println(resultDay3_1)
}
