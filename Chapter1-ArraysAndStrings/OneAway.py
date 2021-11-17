def check_replace(string1, string2):
    found_one_difference = False

    for index, character_string_1 in enumerate(string1):
        if character_string_1 != string2[index]:
            # if the different character was already found it means there are more than 1 replace
            if found_one_difference:
                return False

            found_one_difference = True

    return found_one_difference


def check_insert_delete(string1, string2):
    index_string1 = 0
    index_string2 = 0
    length_string1 = len(string1)
    length_string2 = len(string2)

    while index_string2 < length_string2 and index_string1 < length_string1:
        if string1[index_string1] != string2[index_string2]:
            if index_string1 != index_string2:
                return False

            index_string2 += 1
        else:
            index_string1 += 1
            index_string2 += 1

    return True


def check_if_is_one_edit_away(string1, string2):
    length_string1 = len(string1)
    length_string2 = len(string2)

    if length_string1 == length_string2:
        return check_replace(string1, string2)
    elif (length_string1 + 1) == length_string2:
        return check_insert_delete(string1, string2)
    elif length_string1 == length_string2 + 1:
        return check_insert_delete(string2, string1)

    return False


def main():
    print("pale, ple: ", check_if_is_one_edit_away("pale", "ple"))
    print("pales, pale: ", check_if_is_one_edit_away("pales", "pale"))
    print("pale, bale: ", check_if_is_one_edit_away("pale", "bale"))
    print("pale, bole: ", check_if_is_one_edit_away("pale", "bole"))
    print("pale, bae: ", check_if_is_one_edit_away("pale", "bae"))


if __name__ == "__main__":
    main()
