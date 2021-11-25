from Classes.StackWithMinimum import StackWithMinimum


def main():
    stack_with_minimum = StackWithMinimum()

    stack_with_minimum.push(5)
    stack_with_minimum.push(3)
    stack_with_minimum.push(6)
    stack_with_minimum.push(1)
    stack_with_minimum.push(4)

    print(stack_with_minimum)
    print("Minimum from stack: ", stack_with_minimum.peek_minimum_value())

    stack_with_minimum.pop()
    stack_with_minimum.pop()

    print(stack_with_minimum)
    print("Minimum from stack: ", stack_with_minimum.peek_minimum_value())


if __name__ == "__main__":
    main()
