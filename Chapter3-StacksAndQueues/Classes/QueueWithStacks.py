class QueueWithStacks:
    def __init__(self):
        self.__stackNewest = []
        self.__stackOldest = []

    def size(self):
        return len(self.__stackNewest) + len(self.__stackOldest)

    def add(self, value):
        # Push onto stackNewest, which always has the newest elements on top
        self.__stackNewest.append(value)

    def __shift_stacks(self):
        # Move elements from stackNewest into stackOldest.
        # This is usually done so that we can do operations on stackOldest
        if len(self.__stackOldest) == 0:
            while len(self.__stackNewest) > 0:
                self.__stackOldest.append(self.__stackNewest.pop())

    def pop(self):
        self.__shift_stacks()
        return self.__stackOldest.pop()
