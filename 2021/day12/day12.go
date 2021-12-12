package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"strings"
)

func Day12(input []string) int {
	// Input set
	pointSet := make(map[string]int)
	connectedTo := make(map[string]map[string]bool)
	for _, connectionString := range input {
		points := strings.Split(connectionString, "-")
		if points[0] != "start" && points[0] != "end" {
			pointSet[points[0]] = 0
		}
		if points[1] != "start" && points[1] != "end" {
			pointSet[points[1]] = 0
		}
		if _, found := connectedTo[points[0]]; found {
			connectedTo[points[0]][points[1]] = true
		} else {
			targetMap := make(map[string]bool)
			connectedTo[points[0]] = targetMap
			connectedTo[points[0]][points[1]] = true
		}
		if _, found := connectedTo[points[1]]; found {
			connectedTo[points[1]][points[0]] = true
		} else {
			targetMap := make(map[string]bool)
			connectedTo[points[1]] = targetMap
			connectedTo[points[1]][points[0]] = true
		}
	}

	for k, _ := range connectedTo["start"] {
		connectedTo[k]["start"] = false
	}
	for k, _ := range connectedTo["end"] {
		connectedTo["end"][k] = false
	}

	counter := 0

	for k, _ := range connectedTo["start"] {
		var traversedPoints []string
		traversedPoints = append(traversedPoints, "start")
		connectedTo["start"][k] = false
		Traverse(k, connectedTo, pointSet, traversedPoints, &counter)
	}

	return counter
}

func Traverse(point string, connectedTo map[string]map[string]bool, pointSet map[string]int, traversedPoints []string, counter *int) {
	// Copy traversedPoints slice
	traversedPointsCopy := make([]string, len(traversedPoints))
	copy(traversedPointsCopy, traversedPoints)
	traversedPointsCopy = append(traversedPointsCopy, point)

	// Copy connectedTo map
	connectedToCopy := make(map[string]map[string]bool)
	for k, v := range connectedTo {
		connectedToValueCopy := make(map[string]bool)
		for k1, v1 := range v {
			connectedToValueCopy[k1] = v1
		}
		connectedToCopy[k] = connectedToValueCopy
	}

	// Copy pointSet map
	pointSetCopy := make(map[string]int)
	for k, v := range pointSet {
		pointSetCopy[k] = v
	}

	// Increase point count
	if point != "start" && point != "end" {
		pointSetCopy[point]++
	}

	// Check if point is lowercased
	if strings.ToLower(point) == point {
		if pointSetCopy[point] == 1 {
			// Remove all connections to this point
			for k, _ := range connectedToCopy[point] {
				connectedToCopy[k][point] = false
			}
		}
	}

	for k, v := range connectedToCopy[point] {
		if v {
			Traverse(k, connectedToCopy, pointSetCopy, traversedPointsCopy, counter)
		}
	}

	if traversedPointsCopy[len(traversedPointsCopy)-1] == "end" {
		*counter++
	}
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

	resultDay12 := Day12(inputArr)
	fmt.Println(resultDay12)
}
