import sys
from queue import LifoQueue


class StackWithMinimum:
    def __init__(self):
        self.valuesStack = []
        self.minimumValuesStack = []

    def __repr__(self):
        return " -> ".join([str(value) for value in self.valuesStack])

    def push(self, value: int):
        self.valuesStack.append(value)
        if value < self.peek_minimum_value():
            self.minimumValuesStack.append(value)

    def pop(self):
        value = self.valuesStack.pop()
        if value == self.peek_minimum_value():
            self.minimumValuesStack.pop()

        return value

    def peek_minimum_value(self):
        if len(self.minimumValuesStack) > 0:
            return self.minimumValuesStack[-1]
        else:
            return sys.maxsize
