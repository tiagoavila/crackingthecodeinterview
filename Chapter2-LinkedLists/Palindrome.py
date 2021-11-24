from Classes.LinkedList import LinkedList, Node


def is_palindrome(head: Node):
    head_reversed_linked_list = reverse_and_clone(head)
    return is_equal(head, head_reversed_linked_list)


def reverse_and_clone(node: Node):
    head_of_reversed_linked_list: Node = None

    while node is not None:
        new_node: None = Node(node.data)
        new_node.next = head_of_reversed_linked_list
        head_of_reversed_linked_list = new_node

        # moves to the next node of the linked list
        node = node.next

    return head_of_reversed_linked_list


def is_equal(node1: Node, node2: Node):
    while node1 is not None and node2 is not None:
        if node1.data != node2.data:
            return False

        node1 = node1.next
        node2 = node2.next

    return node1 is None and node2 is None


def is_palindrome_using_stack(head: Node):
    """
    It checks if the front half of the linked list is the reverse of the second half, to accomplish this we use a stack
    to append the elements of the first half
    :param head:
    :return:
    """
    fast: Node = head
    slow: Node = head

    stack = []

    # Push elements of the first half of the linked list onto stack. When fast runner (which is moving at 2x speed)
    # reaches the end of the linked list, then we know we're at the middle of the linked list
    while fast is not None and fast.next is not None:
        stack.append(slow.data)
        slow = slow.next
        fast = fast.next.next

    # linked list has odd number of elements, so skip the middle element
    if fast is not None:
        slow = slow.next

    while slow is not None:
        top = stack.pop()

        # if the values are different is not a palindrome
        if top != slow.data:
            return False

        slow = slow.next

    return True


def main():
    linked_list = LinkedList()
    first_node = Node("a")
    linked_list.head = first_node

    second_node = Node("b")
    third_node = Node("c")
    fourth_node = Node("b")
    fifth_node = Node("a")
    first_node.next = second_node
    second_node.next = third_node
    third_node.next = fourth_node
    fourth_node.next = fifth_node
    print(linked_list)
    print(is_palindrome(first_node))
    print("using stack: ", is_palindrome_using_stack(first_node))

    linked_list1 = LinkedList()
    first_node1 = Node("a")
    linked_list1.head = first_node1

    second_node1 = Node("b")
    third_node1 = Node("c")
    fourth_node1 = Node("d")
    fifth_node1 = Node("e")
    first_node1.next = second_node1
    second_node1.next = third_node1
    third_node1.next = fourth_node1
    fourth_node1.next = fifth_node1
    print(linked_list1)

    print(is_palindrome(first_node1))
    print("using stack: ", is_palindrome_using_stack(first_node1))


if __name__ == "__main__":
    main()
