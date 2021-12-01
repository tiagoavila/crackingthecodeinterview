from Classes.QueueWithStacks import QueueWithStacks


def main():
    queue_via_stacks = QueueWithStacks()
    queue_via_stacks.add(1)
    queue_via_stacks.add(2)
    queue_via_stacks.add(3)

    print(queue_via_stacks.pop())

    queue_via_stacks.add(4)

    print(queue_via_stacks.pop())


if __name__ == "__main__":
    main()
