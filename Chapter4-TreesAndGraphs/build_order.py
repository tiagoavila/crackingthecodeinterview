from classes_for_build_order_exercise.project import Project
from classes_for_build_order_exercise.graph import Graph


def add_non_dependent(order_array, projects, offset):
    for project in projects:
        if project.get_number_of_dependencies() == 0:
            order_array[offset] = project
            offset = offset + 1

    return offset


def order_projects(projects):
    """
    Return a list of the projects a correct build order
    :param projects:
    :return:
    """
    order_array = [Project] * len(projects)

    # Add "roosts" to the build order first
    end_of_list = add_non_dependent(order_array, projects, 0)

    to_be_processed = 0
    while to_be_processed < len(order_array):
        current = order_array[to_be_processed]

        # we have a circular dependency since there are no remaining projects with zero dependencies
        if current is None:
            return None

        # remove myself as a dependency
        children_array = current.get_children()
        for child in children_array:
            child.decrement_dependencies()

        # Add children that have no one depending on them
        end_of_list = add_non_dependent(order_array, children_array, end_of_list)
        to_be_processed += 1

    return order_array


def build_graph(projects, dependencies):
    """
    Build the graph, adding the edge (a, b) if b is dependent on a. Assumes a pair is listed in "build order".
    The Pair (a, b) in dependencies indicates that b depends on a and a bust be built before b
    :param projects:
    :param dependencies:
    :return:
    """
    graph = Graph()

    for project in projects:
        graph.get_or_create_node(project)

    for dependency in dependencies:
        first = dependency[0]
        second = dependency[1]
        graph.add_edge(first, second)

    return graph


def find_build_order(projects, dependencies):
    graph = build_graph(projects, dependencies)
    return order_projects(graph.get_nodes())


def main():
    projects = ["a", "b", "c", "d", "e", "f"]
    dependencies = [["a", "d"], ["f", "b"], ["b", "d"], ["f", "a"], ["d", "c"]]

    print('Build order: ', find_build_order(projects, dependencies))


if __name__ == "__main__":
    main()
