class Tree:
    def __init__(self):
        self.root = None


class TreeNode:
    def __init__(self, data):
        self.data = data
        self.left = None
        self.right = None
        self.parent = None

    def __repr__(self):
        if self is not None:
            return str(self.data)
        else:
            return ''
