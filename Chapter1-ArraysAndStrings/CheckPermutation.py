from Util.StringUtil import sort_string


def check_permutation(string1, string2):
    """
    Check if two strings are permutation of each other.
    :param string2:
    :param string1: string to be verified
    :return: true/false
    """
    if len(string1) != len(string2):
        return False

    string1 = sort_string(string1)
    string2 = sort_string(string2)

    return string1 == string2


def main():
    print("god Is permutation of dog?", check_permutation("god", "dog"))
    print("gody Is permutation dog?", check_permutation("gody", "dog"))


if __name__ == "__main__":
    main()
