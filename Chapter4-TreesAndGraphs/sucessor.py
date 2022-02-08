from Classes.tree import TreeNode


def find_in_order_successor(node: TreeNode):
    if node is None:
        return None

    # Found right children -> return leftmost node of right subtree
    if node.right is not None:
        return find_left_most_child(node.right)
    else:
        auxiliary_node = node
        auxiliary_parent = auxiliary_node.parent

        # Go up until we're on left instead of right
        while auxiliary_parent is not None and auxiliary_parent.left != auxiliary_node:
            auxiliary_node = auxiliary_parent
            auxiliary_parent = auxiliary_parent.parent

        return auxiliary_parent

    # if successor_node is not None:
    #     return successor_node.data
    # else:
    #     return None


def find_left_most_child(node: TreeNode):
    if node is None:
        return None

    while node.left is not None:
        node = node.left

    return node


def main():
    node_1 = TreeNode(1)
    node_2 = TreeNode(2)
    node_3 = TreeNode(3)
    node_4 = TreeNode(4)
    node_5 = TreeNode(5)
    node_6 = TreeNode(6)

    node_2.left = node_4
    node_2.right = node_5
    node_4.parent = node_2
    node_5.parent = node_2

    node_3.left = node_6
    node_6.parent = node_3

    node_1.left = node_2
    node_1.right = node_3
    node_2.parent = node_1
    node_3.parent = node_1

    # Representation of the tree
    #         1
    #       2    3
    #     4   5 6

    print(f"What is the successor of node_2? {find_in_order_successor(node_2)}")
    print(f"What is the successor of node_5? {find_in_order_successor(node_5)}")
    print(f"What is the successor of node_1? {find_in_order_successor(node_1)}")
    print(f"What is the successor of node_3? {find_in_order_successor(node_3)}")
    print(f"What is the successor of node_6? {find_in_order_successor(node_6)}")


if __name__ == "__main__":
    main()
