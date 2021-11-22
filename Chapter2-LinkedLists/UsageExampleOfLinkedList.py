from Classes.LinkedList import LinkedList, Node


def main():
    llist = LinkedList()
    print(llist)

    first_node = Node("a")
    llist.head = first_node
    print(llist)

    second_node = Node("b")
    third_node = Node("c")
    first_node.next = second_node
    second_node.next = third_node
    print(llist)

    llist2 = LinkedList(["a", "b", "c", "d", "e"])
    print(llist2)


if __name__ == "__main__":
    main()
