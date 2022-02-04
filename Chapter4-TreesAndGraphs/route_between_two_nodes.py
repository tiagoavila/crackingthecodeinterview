from Classes.graph import Graph, GraphNode
from Enums.state_enum import StateEnum


def check_route_between_two_nodes(graph: Graph, start: GraphNode, end: GraphNode):
    if start == end:
        return True

    queue = []

    for node in graph.children:
        node.state = StateEnum.UnVisited

    start.state = StateEnum.Visiting
    queue.append(start)
    currentNode: GraphNode

    while len(queue) > 0:
        u = queue.pop()

        if u is not None:
            for v in u.children:
                if v.state == StateEnum.UnVisited:
                    if v == end:
                        return True
                    else:
                        v.state = StateEnum.Visiting
                        queue.append(v)

            u.state = StateEnum.Visited

    return False


def main():
    node_a = GraphNode("a")
    node_b = GraphNode("b")
    node_c = GraphNode("c")
    node_d = GraphNode("d")
    node_e = GraphNode("e")
    node_f = GraphNode("f")

    node_a.children.append(node_b)
    node_a.children.append(node_d)
    node_a.children.append(node_c)

    node_c.children.append(node_e)
    node_c.children.append(node_f)

    graph = Graph()
    graph.children.append(node_a)
    graph.children.append(node_b)
    graph.children.append(node_c)
    graph.children.append(node_d)
    graph.children.append(node_e)
    graph.children.append(node_f)

    print("Is the a route between NodeA and NodeB?", check_route_between_two_nodes(graph, node_a, node_b))
    print("Is the a route between NodeA and NodeE?", check_route_between_two_nodes(graph, node_a, node_e))
    print("Is the a route between NodeC and NodeF?", check_route_between_two_nodes(graph, node_c, node_f))
    print("Is the a route between NodeB and NodeF?", check_route_between_two_nodes(graph, node_b, node_f)) 


if __name__ == "__main__":
    main()
