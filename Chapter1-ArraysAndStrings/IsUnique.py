def is_unique(string_to_check):
    """
    Checks if the string only contains unique characters
    :param string_to_check: string to be verified
    :return: true/false
    """
    dictionary_of_characters = {}

    for character in string_to_check:
        if character in dictionary_of_characters:
            return False
        else:
            dictionary_of_characters[character] = True

    return True


def main():
    print("44 has unique characters? ", is_unique("44"))
    print("117 has unique characters? ", is_unique("117"))
    print("132 has unique characters? ", is_unique("132"))


if __name__ == "__main__":
    main()
