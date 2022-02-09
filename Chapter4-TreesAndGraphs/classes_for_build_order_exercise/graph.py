from .project import Project


class Graph:
    def __init__(self):
        self.__nodes = []
        self.__map = {}

    def get_or_create_node(self, name):
        if name not in self.__map:
            node = Project(name)
            self.__nodes.append(node)
            self.__map[name] = node

        return map[name]

    def add_edge(self, start_name, end_name):
        start = self.get_or_create_node(start_name)
        end = self.get_or_create_node(end_name)
        start.add_neighbor(end)

    def get_nodes(self):
        return self.__nodes