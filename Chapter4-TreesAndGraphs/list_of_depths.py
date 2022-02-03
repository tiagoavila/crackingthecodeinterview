from Classes.tree import TreeNode
from Classes.linked_list import LinkedList, LinkedListNode


def create_level_linked_list(root_node: TreeNode, list_of_linked_lists: [], level: int):
    if root_node is None:
        return None

    if len(list_of_linked_lists) == level:
        linked_list = LinkedList()
        list_of_linked_lists.append(linked_list)
    else:
        linked_list = list_of_linked_lists[level]

    linked_list.add_last(LinkedListNode(root_node.data))
    create_level_linked_list(root_node.left, list_of_linked_lists, level + 1)
    create_level_linked_list(root_node.right, list_of_linked_lists, level + 1)


def create_list_of_depths(root_node: TreeNode):
    list_of_linked_lists = []
    create_level_linked_list(root_node, list_of_linked_lists, 0)
    return list_of_linked_lists


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

    list_of_linked_lists = create_list_of_depths(root_node)

    print("List of Depths ")

    for index, linked_list in enumerate(list_of_linked_lists):
        print(f"Depth {index}: {linked_list}")


if __name__ == "__main__":
    main()
