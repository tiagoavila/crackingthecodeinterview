def sort_stack(stack: []):
    r = []
    while len(stack) > 0:
        # Insert each element in stack in sorted order into r
        temp = stack.pop()
        while len(r) > 0 and r[-1] > temp:
            stack.append(r.pop())

        r.append(temp)

    # Copy the elements from r back into stack
    while len(r) > 0:
        stack.append(r.pop())


def main():
    stack = [3, 1, 5, 4]

    sort_stack(stack)

    while len(stack) > 0:
        print(stack.pop())


if __name__ == "__main__":
    main()
