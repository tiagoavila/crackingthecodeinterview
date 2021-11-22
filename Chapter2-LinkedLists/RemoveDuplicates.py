from Classes.LinkedList import LinkedList, Node


def remove_duplicates(linked_list):
    dictionary_of_tracked_data = {}
    previous_node = linked_list.head

    for node in linked_list:
        if node.data in dictionary_of_tracked_data:
            previous_node.next = node.next
        else:
            dictionary_of_tracked_data[node.data] = True

        previous_node = node

    return linked_list


def main():
    linked_list = LinkedList(["a", "b", "c", "a", "d", "e", "b"])
    print("Original Linked List:           ", linked_list)
    print("Linked List without duplicates: ", remove_duplicates(linked_list))


if __name__ == "__main__":
    main()
