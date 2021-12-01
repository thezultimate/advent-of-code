package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strconv"
)

func Day1(inputArr []int) int {
	increaseCount := 0
	for i, depth := range inputArr {
		if i > 0 {
			if depth > inputArr[i-1] {
				increaseCount++
			}
		}
	}
	return increaseCount
}

func Day1_2(inputArr []int) int {
	increaseCount := 0
	var threeSumArr []int
	for i, depth := range inputArr {
		if i < len(inputArr)-2 {
			threeSumArr = append(threeSumArr, depth+inputArr[i+1]+inputArr[i+2])
		}
	}
	for i, depth := range threeSumArr {
		if i > 0 {
			if depth > threeSumArr[i-1] {
				increaseCount++
			}
		}
	}
	return increaseCount
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
		intValue, _ := strconv.Atoi(scanner.Text())
		inputArr = append(inputArr, intValue)
	}
	file.Close()

	// for _, each_ln := range inputArr {
	// 	fmt.Println(each_ln)
	// }

	resultDay1 := Day1(inputArr)
	resultDay1_2 := Day1_2(inputArr)
	fmt.Println(resultDay1)
	fmt.Println(resultDay1_2)
}
