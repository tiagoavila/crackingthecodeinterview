package main

import "fmt"

func countWays(n int) int {
	var memo = make([]int, n+1)
	for i := 0; i < n+1; i++ {
		memo[i] = -1
	}

	return countWaysRecursive(n, memo)
}

func countWaysRecursive(n int, memo []int) int {
	if n < 0 {
		return 0
	} else if n == 0 {
		return 1
	} else if memo[n] > -1 {
		return memo[n]
	} else {
		memo[n] = countWaysRecursive(n-1, memo) + countWaysRecursive(n-2, memo) + countWaysRecursive(n-3, memo)
		return memo[n]
	}
}

func main() {
	var stairsSize int = 3
	fmt.Println(fmt.Sprintf("Number of ways a child can run up staircase of %d steps is: %d", stairsSize, countWays(stairsSize)))
}
