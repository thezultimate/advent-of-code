package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strconv"
	"strings"
)

type RebootStep struct {
	action                             string
	xMin, xMax, yMin, yMax, zMin, zMax int
}

func Day22(input []string) int {
	cubeStateMap := make(map[string]bool)
	var rebootSteps []RebootStep

	// Handle input
	for _, v := range input {
		inputSplitted := strings.Split(v, " ")
		// on or off
		action := inputSplitted[0]
		coordinatesSplitted := strings.Split(inputSplitted[1], ",")
		xSection := coordinatesSplitted[0]
		ySection := coordinatesSplitted[1]
		zSection := coordinatesSplitted[2]
		xSectionSplitted := strings.Split(xSection, "=")
		ySectionSplitted := strings.Split(ySection, "=")
		zSectionSplitted := strings.Split(zSection, "=")
		xRange := xSectionSplitted[1]
		yRange := ySectionSplitted[1]
		zRange := zSectionSplitted[1]
		xPair := strings.Split(xRange, "..")
		yPair := strings.Split(yRange, "..")
		zPair := strings.Split(zRange, "..")
		xMin, _ := strconv.Atoi(xPair[0])
		xMax, _ := strconv.Atoi(xPair[1])
		yMin, _ := strconv.Atoi(yPair[0])
		yMax, _ := strconv.Atoi(yPair[1])
		zMin, _ := strconv.Atoi(zPair[0])
		zMax, _ := strconv.Atoi(zPair[1])
		// fmt.Printf("%v %v %v %v %v %v\n", xMin, xMax, yMin, yMax, zMin, zMax)

		rebootStep := RebootStep{action: action, xMin: xMin, xMax: xMax, yMin: yMin, yMax: yMax, zMin: zMin, zMax: zMax}
		rebootSteps = append(rebootSteps, rebootStep)
	}

	// Iterate through steps
	for _, v := range rebootSteps {
		xMin := v.xMin
		xMax := v.xMax
		yMin := v.yMin
		yMax := v.yMax
		zMin := v.zMin
		zMax := v.zMax

		if xMin < -50 || xMax > 50 || yMin < -50 || yMax > 50 || zMin < -50 || zMax > 50 {
			continue
		}

		// Iterate through cubes
		for i := xMin; i <= xMax; i++ {
			for j := yMin; j <= yMax; j++ {
				for k := zMin; k <= zMax; k++ {
					cubeKey := strconv.Itoa(i) + "," + strconv.Itoa(j) + "," + strconv.Itoa(k)
					if v.action == "on" {
						cubeStateMap[cubeKey] = true
					} else {
						cubeStateMap[cubeKey] = false
					}
				}
			}
		}
	}

	onCounter := 0
	for _, v := range cubeStateMap {
		if v {
			onCounter++
		}
	}

	return onCounter
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

	resultDay22 := Day22(input)
	fmt.Println(resultDay22)
}
