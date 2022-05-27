package main

import "fmt"

func findMagicIndex(slyceOfValues []int) int {
	return findMagicIndexRecursive(slyceOfValues, 0, len(slyceOfValues)-1)
}

func findMagicIndexRecursive(slyceOfValues []int, start int, end int) int {
	if end < start {
		return -1
	}

	var mid int = (start + end) / 2
	if slyceOfValues[mid] == mid {
		return mid
	} else if slyceOfValues[mid] > mid {
		return findMagicIndexRecursive(slyceOfValues, start, mid-1)
	} else {
		return findMagicIndexRecursive(slyceOfValues, mid+1, end)
	}
}

func incrementor() func(increment int) int {
	i := 0

	return func(increment int) int {
		i += increment
		return i
	}
}

func main() {
	incrementValue := incrementor()

	fmt.Println(incrementValue(5))
	fmt.Println(incrementValue(2))
	fmt.Println(incrementValue(10))

	mySlyce := []int{-40, -20, -1, 1, 2, 3, 5, 7, 9, 12, 13}

	fmt.Println(fmt.Sprintf("Magic index is of the array %d is %d", mySlyce, findMagicIndex(mySlyce)))
}
