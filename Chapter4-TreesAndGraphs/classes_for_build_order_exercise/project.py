class Project:
    def __init__(self):
        pass

    def __init__(self, name):
        self.__children = []
        self.__map = {}
        self.__name = name
        self.__dependencies = 0

    def __repr__(self):
        return f"Project: {self.__name}"

    def get_name(self):
        return self.__name

    def increment_dependencies(self):
        self.__dependencies += 1

    def decrement_dependencies(self):
        self.__dependencies -= 1

    def get_children(self):
        return self.__children

    def get_number_of_dependencies(self):
        return self.__dependencies

    def add_neighbor(self, node):
        if node.get_name() not in self.__map:
            self.__children.append(node)
            self.__map[node.get_name()] = node
            node.increment_dependencies()
