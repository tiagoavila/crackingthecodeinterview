def sort_string(string):
    """
    Sort the provided string in ascending order
    :param string:
    :return:
    """
    sorted_characters = sorted(string)  # Sort string alphabetically and return list

    return "".join(sorted_characters)  # Combine list elements into one string
