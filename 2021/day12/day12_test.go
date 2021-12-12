package main

import (
	"github.com/stretchr/testify/assert"
	"testing"
)

func TestDay12(t *testing.T) {
	input := []string{
		"start-A",
		"start-b",
		"A-c",
		"A-b",
		"b-d",
		"A-end",
		"b-end",
	}
	output := Day12(input)
	assert.Equal(t, 10, output, "they should be equal")
}

func TestDay12_Case2(t *testing.T) {
	input := []string{
		"dc-end",
		"HN-start",
		"start-kj",
		"dc-start",
		"dc-HN",
		"LN-dc",
		"HN-end",
		"kj-sa",
		"kj-HN",
		"kj-dc",
	}
	output := Day12(input)
	assert.Equal(t, 19, output, "they should be equal")
}

func TestDay12_Case3(t *testing.T) {
	input := []string{
		"fs-end",
		"he-DX",
		"fs-he",
		"start-DX",
		"pj-DX",
		"end-zg",
		"zg-sl",
		"zg-pj",
		"pj-he",
		"RW-he",
		"fs-DX",
		"pj-RW",
		"zg-RW",
		"start-pj",
		"he-WI",
		"zg-he",
		"pj-fs",
		"start-RW",
	}
	output := Day12(input)
	assert.Equal(t, 226, output, "they should be equal")
}

func TestDay12_Case4(t *testing.T) {
	input := []string{
		"xq-XZ",
		"zo-yr",
		"CT-zo",
		"yr-xq",
		"yr-LD",
		"xq-ra",
		"np-zo",
		"end-LD",
		"np-LD",
		"xq-kq",
		"start-ra",
		"np-kq",
		"LO-end",
		"start-xq",
		"zo-ra",
		"LO-np",
		"XZ-start",
		"zo-kq",
		"LO-yr",
		"kq-XZ",
		"zo-LD",
		"kq-ra",
		"XZ-yr",
		"LD-ws",
		"np-end",
		"kq-yr",
	}
	output := Day12(input)
	assert.Equal(t, 5457, output, "they should be equal")
}
