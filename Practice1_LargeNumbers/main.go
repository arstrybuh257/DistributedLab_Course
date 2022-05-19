package main

import (
	"fmt"
	"math/big"
	"math/rand"
	"time"
)

func main() {
	fmt.Print("Task_1\n\n")
	bigNumber := new(big.Int)
	for i := 8; i <= 4096; i *= 2 {
		numberOfKeys := bigNumber.Exp(big.NewInt(2), big.NewInt(int64(i)), nil)
		fmt.Printf("Bits: %d\nNumber of possible keys: %d\n\n", i, numberOfKeys)
	}

	fmt.Println("__________________________________________________________________")
	fmt.Print("\nTasks_2-3\n\n")
	s1 := rand.NewSource(time.Now().UnixNano())
	rnd := rand.New(s1)
	for i := 8; i <= 4069; i *= 2 {
		randomNumber := bigNumber.Rand(rnd, bigNumber.Exp(big.NewInt(2), big.NewInt(int64(i)), nil))
		fmt.Printf("Random generated key for %d bits in heximal form:%X\n", i, randomNumber)
		bruteForce(randomNumber)
	}
}

func bruteForce(key *big.Int) {
	counter := big.NewInt(0)

	start := time.Now()
	for {
		if counter.Cmp(key) == 0 {
			fmt.Printf("Time to bruteforce key: %d miliseconds\n", time.Since(start).Milliseconds())
			break
		}

		counter = counter.Add(counter, big.NewInt(1))
	}

	fmt.Println()
}
