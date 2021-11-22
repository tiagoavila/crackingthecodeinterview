from Classes.LinkedList import LinkedList, Node


def print_kth_to_last(current_node, k):
    if current_node is None:
        return 0

    index = print_kth_to_last(current_node.next, k) + 1
    if index == k:
        print(k, "th to last node is: ", current_node.data)

    return index


def main():
    linked_list = LinkedList(["a", "b", "c", "d", "e", "f"])
    print_kth_to_last(linked_list.head, 1)
    print_kth_to_last(linked_list.head, 3)


if __name__ == "__main__":
    main()
