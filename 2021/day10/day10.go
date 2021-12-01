package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
	"sort"
)

// Stack implementation
type Stack []string

// IsEmpty: check if stack is empty
func (s *Stack) IsEmpty() bool {
	return len(*s) == 0
}

// Push a new value onto the stack
func (s *Stack) Push(str string) {
	*s = append(*s, str) // Simply append the new value to the end of the stack
}

// Remove and return top element of stack. Return false if stack is empty.
func (s *Stack) Pop() (string, bool) {
	if s.IsEmpty() {
		return "", false
	} else {
		index := len(*s) - 1   // Get the index of the top most element.
		element := (*s)[index] // Index into the slice and obtain the element.
		*s = (*s)[:index]      // Remove it from the stack by slicing it off.
		return element, true
	}
}

// Get the top element of the stack without removing it from the stack
func (s *Stack) Peek() (string, bool) {
	if s.IsEmpty() {
		return "", false
	} else {
		index := len(*s) - 1   // Get the index of the top most element.
		element := (*s)[index] // Index into the slice and obtain the element.
		return element, true
	}
}

func Day10(input []string) int {
	totalPenalties := 0
	closingElementMap := make(map[string]string)
	closingElementMap["("] = ")"
	closingElementMap["["] = "]"
	closingElementMap["{"] = "}"
	closingElementMap["<"] = ">"
	for _, line := range input {
		var stack Stack
		for _, aChar := range line {
			aCharString := string(aChar)
			if lastStackElement, found := stack.Peek(); found {
				if aCharString == ")" || aCharString == "]" || aCharString == "}" || aCharString == ">" {
					if aCharString == closingElementMap[lastStackElement] {
						stack.Pop()
					} else {
						if aCharString == ")" {
							totalPenalties += 3
						}
						if aCharString == "]" {
							totalPenalties += 57
						}
						if aCharString == "}" {
							totalPenalties += 1197
						}
						if aCharString == ">" {
							totalPenalties += 25137
						}
						break
					}
				} else {
					stack.Push(aCharString)
				}
			} else {
				stack.Push(aCharString)
			}
		}
	}
	return totalPenalties
}

func Day10_1(input []string) int {
	closingElementMap := make(map[string]string)
	closingElementMap["("] = ")"
	closingElementMap["["] = "]"
	closingElementMap["{"] = "}"
	closingElementMap["<"] = ">"
	for i, line := range input {
		var stack Stack
		for _, aChar := range line {
			aCharString := string(aChar)
			if lastStackElement, found := stack.Peek(); found {
				if aCharString == ")" || aCharString == "]" || aCharString == "}" || aCharString == ">" {
					if aCharString == closingElementMap[lastStackElement] {
						stack.Pop()
					} else {
						// Discard line
						input[i] = ""
						break
					}
				} else {
					stack.Push(aCharString)
				}
			} else {
				stack.Push(aCharString)
			}
		}
	}

	var scores []int
	for _, line := range input {
		if len(line) == 0 {
			continue
		}
		var stack Stack
		for _, aChar := range line {
			aCharString := string(aChar)
			if lastStackElement, found := stack.Peek(); found {
				if aCharString == ")" || aCharString == "]" || aCharString == "}" || aCharString == ">" {
					if aCharString == closingElementMap[lastStackElement] {
						stack.Pop()
					}
				} else {
					stack.Push(aCharString)
				}
			} else {
				stack.Push(aCharString)
			}
		}

		closingBracketString := ""
		for i := len(stack) - 1; i >= 0; i-- {
			closingBracketString += closingElementMap[stack[i]]
		}

		closingBracketScores := make(map[string]int)
		closingBracketScores[")"] = 1
		closingBracketScores["]"] = 2
		closingBracketScores["}"] = 3
		closingBracketScores[">"] = 4

		score := 0
		for _, aChar := range closingBracketString {
			aCharString := string(aChar)
			score = (score * 5) + closingBracketScores[aCharString]
		}
		scores = append(scores, score)
	}

	sort.Ints(scores)
	mid := len(scores) / 2
	return scores[mid]
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

	resultDay10 := Day10(inputArr)
	resultDay10_1 := Day10_1(inputArr)
	fmt.Println(resultDay10)
	fmt.Println(resultDay10_1)
}
