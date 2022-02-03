class Graph:
    def __init__(self):
        self.children = []


class GraphNode:
    def __init__(self, data):
        self.data = data
        self.children = []