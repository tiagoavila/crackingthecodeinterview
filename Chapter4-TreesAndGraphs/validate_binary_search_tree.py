from Classes.tree import TreeNode


def check_if_tree_is_a_binary_search_tree(node: TreeNode, min_value: int, max_value: int):
    if node is None:
        return True

    if (min_value is not None and node.data <= min_value) or (max_value is not None and node.data > max_value):
        return False

    if not check_if_tree_is_a_binary_search_tree(node.left, min_value, node.data) \
            or not check_if_tree_is_a_binary_search_tree(node.right, node.data, max_value):
        return False

    return True


def is_a_binary_search_tree(root_node: TreeNode):
    return check_if_tree_is_a_binary_search_tree(root_node, None, None)


def main():
    # node_1 = TreeNode(1)
    # node_2 = TreeNode(2)
    # node_3 = TreeNode(3)
    # node_4 = TreeNode(4)
    # node_5 = TreeNode(5)
    # node_6 = TreeNode(6)
    #
    # node_2.left = node_4
    # node_2.right = node_5
    #
    # node_3.left = node_6
    #
    # node_1.left = node_2
    # node_1.right = node_3
    #
    # print(f"is this tree a BST? {is_a_binary_search_tree(node_1)}")

    node_1 = TreeNode(1)
    node_2 = TreeNode(2)
    node_3 = TreeNode(3)
    node_4 = TreeNode(4)
    node_5 = TreeNode(5)
    node_6 = TreeNode(6)
    node_7 = TreeNode(7)

    node_2.left = node_1
    node_2.right = node_3

    node_6.left = node_5
    node_6.right = node_7

    node_4.left = node_2
    node_4.right = node_6

    print(f"is this tree a BST? {is_a_binary_search_tree(node_4)}")


if __name__ == "__main__":
    main()
