package main

import "fmt"

func getSubsets(set []int, index int) [][]int {
	var allSubsets [][]int

	if len(set) == index {
		allSubsets = append(allSubsets, make([]int, 0))
	} else {
		allSubsets = getSubsets(set, index+1)
		var item int = set[index]
		var moresubsets [][]int
		for i := 0; i < len(allSubsets); i++ { // Clone the subsets and add the current element from the original set to the existing subsets
			var newSubset []int
			newSubset = append(newSubset, allSubsets[i]...)
			newSubset = append(newSubset, item)
			moresubsets = append(moresubsets, newSubset)
		}
		allSubsets = append(allSubsets, moresubsets...)
	}

	return allSubsets
}

func main() {
	fmt.Println("subsets of set {1, 2, 3}: ", getSubsets([]int{1, 2, 3}, 0))
}
