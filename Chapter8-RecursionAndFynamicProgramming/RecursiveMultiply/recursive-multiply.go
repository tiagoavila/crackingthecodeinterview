package main

import "fmt"

func minProduct(a int, b int) int {
	var bigger int
	if a < b {
		bigger = b
	} else {
		bigger = a
	}

	var smaller int
	if a < b {
		smaller = a
	} else {
		smaller = b
	}

	return minProductHelper(smaller, bigger)
}

func minProductHelper(smaller, bigger int) int {
	if smaller == 0 { // 0 x bigger = 0
		return 0
	} else if smaller == 1 { // 1 x bigger = bigger
		return bigger
	}

	var halfOfSmaller int = smaller >> 1 // divide by 2
	var halfProd int = minProductHelper(halfOfSmaller, bigger)

	if smaller%2 == 0 {
		return halfProd + halfProd
	} else {
		return halfProd + halfProd + bigger
	}
}

func main() {
	fmt.Println("Multiplication without using * operator")
	fmt.Println("3 * 5 is: ", minProduct(3, 5))
}
