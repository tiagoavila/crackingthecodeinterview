import sys

from Classes.tree import TreeNode

INT_MIN_VALUE = -sys.maxsize - 1


def check_tree_height(root_node: TreeNode):
    if root_node is None:
        return -1

    left_height = check_tree_height(root_node.left)
    if left_height == INT_MIN_VALUE:
        return INT_MIN_VALUE  # Pass Error up

    right_height = check_tree_height(root_node.right)
    if right_height == INT_MIN_VALUE:
        return INT_MIN_VALUE  # Pass Error up

    height_diff = left_height - right_height
    if abs(height_diff) > 1:
        return INT_MIN_VALUE  # Found error -> pass it back
    else:
        return max(left_height, right_height) + 1


def check_if_tree_is_balanced(root_node: TreeNode):
    return check_tree_height(root_node) != INT_MIN_VALUE


def main():
    root_node = TreeNode(1)
    node_2 = TreeNode(2)
    node_3 = TreeNode(3)
    node_4 = TreeNode(4)
    node_5 = TreeNode(5)
    node_6 = TreeNode(6)

    node_2.left = node_4
    node_2.right = node_5

    node_3.left = node_6

    root_node.left = node_2
    root_node.right = node_3

    root_node1 = TreeNode(1)
    root_node1.left = node_2

    print(f"is this tree balanced? {check_if_tree_is_balanced(root_node)}")
    print(f"is this tree balanced? {check_if_tree_is_balanced(root_node1)}")


if __name__ == "__main__":
    main()

# Balanced binary tree
#        1
#     2     3
#   4   5 6

# Not Balanced binary tree
#        1
#     2
#   4   5