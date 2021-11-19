from numpy import *


def rotate_matrix(matrix):
    rows = len(matrix)
    columns = len(matrix[0])

    if rows == 0 or rows != columns:
        return

    layers = int(rows / 2)

    for layer in range(layers):
        first = layer
        last = rows - 1 - layer

        for index in range(first, last):
            offset = index - first

            # Save top
            top = matrix[first][index]

            # left -> top
            matrix[first][index] = matrix[last - offset][first]

            # bottom -> left
            matrix[last - offset][first] = matrix[last][last - offset]

            # right -> bottom
            matrix[last][last - offset] = matrix[index][last]

            # top -> right
            matrix[index][last] = top

    return matrix


def main():
    matrix_list = [
        [1, 2, 3, 4],
        [5, 6, 7, 8],
        [9, 10, 11, 12],
        [13, 14, 15, 16],
    ]

    matrix = reshape(matrix_list, (4, 4))

    print("original matrix: ", matrix)
    print("rotated matrix: ", rotate_matrix(matrix))


if __name__ == "__main__":
    main()
