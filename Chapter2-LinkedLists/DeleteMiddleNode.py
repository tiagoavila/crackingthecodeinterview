from Classes.LinkedList import LinkedList, Node


def delete_middle_node(node_to_remove: Node):
    if node_to_remove is None or node_to_remove.next is None:
        return False
    
    next_node: Node = node_to_remove.next
    node_to_remove.data = next_node.data
    node_to_remove.next = next_node.next
    return True


def main():
    linked_list = LinkedList()
    first_node = Node("a")
    linked_list.head = first_node

    second_node = Node("b")
    third_node = Node("c")
    fourth_node = Node("d")
    fifth_node = Node("e")
    first_node.next = second_node
    second_node.next = third_node
    third_node.next = fourth_node
    fourth_node.next = fifth_node
    print(linked_list)

    delete_middle_node(third_node)
    print(linked_list)


if __name__ == "__main__":
    main()
