import sys


class StackWithMinimum:
    def __init__(self):
        self.__valuesStack = []
        self.__minimumValuesStack = []

    def __repr__(self):
        return " - ".join([str(value) for value in self.__valuesStack])

    def push(self, value: int):
        self.__valuesStack.append(value)
        if value < self.peek_minimum_value():
            self.__minimumValuesStack.append(value)

    def pop(self):
        value = self.__valuesStack.pop()
        if value == self.peek_minimum_value():
            self.__minimumValuesStack.pop()

        return value

    def peek_minimum_value(self):
        if len(self.__minimumValuesStack) > 0:
            return self.__minimumValuesStack[-1]
        else:
            return sys.maxsize
