package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strconv"
	"strings"
)

func Day2(inputArr []string) int {
	horizontalPosition := 0
	depth := 0
	for _, command := range inputArr {
		commandSplitted := strings.Split(command, " ")
		currentCommand := commandSplitted[0]
		currentValue, _ := strconv.Atoi(commandSplitted[1])
		if currentCommand == "forward" {
			horizontalPosition += currentValue
		}
		if currentCommand == "up" {
			depth -= currentValue
		}
		if currentCommand == "down" {
			depth += currentValue
		}
	}
	return horizontalPosition * depth
}

func Day2_1(inputArr []string) int {
	horizontalPosition := 0
	depth := 0
	aim := 0
	for _, command := range inputArr {
		commandSplitted := strings.Split(command, " ")
		currentCommand := commandSplitted[0]
		currentValue, _ := strconv.Atoi(commandSplitted[1])
		if currentCommand == "forward" {
			horizontalPosition += currentValue
			depth += currentValue * aim
		}
		if currentCommand == "up" {
			aim -= currentValue
		}
		if currentCommand == "down" {
			aim += currentValue
		}
	}
	return horizontalPosition * depth
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

	resultDay2 := Day2(inputArr)
	resultDay2_1 := Day2_1(inputArr)
	fmt.Println(resultDay2)
	fmt.Println(resultDay2_1)
}
