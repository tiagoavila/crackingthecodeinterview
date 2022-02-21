def update_bits(n, m, i, j):
    all_ones = int('1', 2)

    left = all_ones << (j + 1)
    right = ((1 << i) - 1)

    mask = left | right

    n_cleared = n & mask
    m_shifted = m << i

    result = n_cleared | m_shifted
    print(bin(result))


def main():
    n = int('10000000000', 2)
    m = int('10011', 2)
    i = 2
    j = 6

    update_bits(n, m, i, j)


if __name__ == "__main__":
    main()