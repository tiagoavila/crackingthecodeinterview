from numpy import *

def rotate_matrix(matrix):
    rows = len(matrix)
    columns = len(matrix[0])

    print(rows)
    print(columns)

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
