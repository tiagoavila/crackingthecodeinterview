from Classes.tree import TreeNode


def create_minimal_sub_tree(array, start, end):
    if end < start:
        return None

    mid = int((start + end) / 2)
    n = TreeNode(array[mid])
    n.left = create_minimal_sub_tree(array, start, mid - 1)
    n.right = create_minimal_sub_tree(array, mid + 1, end)
    return n


def create_minimal_tree(array: []):
    return create_minimal_sub_tree(array, 0, len(array) - 1)


def main():
    array = [0, 2, 3, 1, 4, 5, 6]
    tree = create_minimal_tree(array)

    print("Minimal Tree: ", tree)


if __name__ == "__main__":
    main()
