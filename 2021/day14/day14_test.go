package main

import (
	"github.com/stretchr/testify/assert"
	"testing"
)

func TestDay14(t *testing.T) {
	input := "NNCB"
	var midCharMap = map[string]string{
		"CH": "B",
		"HH": "N",
		"CB": "H",
		"NH": "C",
		"HB": "C",
		"HC": "B",
		"HN": "C",
		"NN": "C",
		"BH": "H",
		"NC": "B",
		"NB": "B",
		"BN": "B",
		"BB": "N",
		"BC": "B",
		"CC": "N",
		"CN": "C",
	}
	output := Day14(input, midCharMap, 10)
	assert.Equal(t, 1588, output, "they should be equal")
}

func TestDay14_1(t *testing.T) {
	input := "NNCB"
	var midCharMap = map[string]string{
		"CH": "B",
		"HH": "N",
		"CB": "H",
		"NH": "C",
		"HB": "C",
		"HC": "B",
		"HN": "C",
		"NN": "C",
		"BH": "H",
		"NC": "B",
		"NB": "B",
		"BN": "B",
		"BB": "N",
		"BC": "B",
		"CC": "N",
		"CN": "C",
	}
	output := Day14_1(input, midCharMap, 40)
	assert.Equal(t, 2188189693529, output, "they should be equal")
}
