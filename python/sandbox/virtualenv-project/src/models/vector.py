import math


class Vector:
    """
    Simple vector realisation

    Collection(abstract classes(ABC) or interfaces, since P3.6) ->
        Iterable(__iter__),
        Sized(__len__),
        Container(__contains__),
        Reversible(__reversed__),
        Sequence(__getitem__, __contains__, __iter__, __reversed__, index, count),
        Mapping(__getitem__, __contains__, __eq__, __ne__, get, items, keys, values),
        Set(isdisjoint, __le__, __lt__, __gt__, __ge__, __eq__, __ne__, __and__, __or__, __sub__, __xor__)

    See http://docs.python.org/3/reference/datamodel.html
    """

    def __init__(self, x=0, y=0):  # constructor
        self.x = x
        self.y = y

    def __repr__(self):  # toString(), // pretty formatting in print() - __str__
        return f'Vector({self.x!r}, {self.y!r})'

    def __abs__(self):
        return math.hypot(self.x, self.y)

    def __bool__(self):
        """
        Used with if, while, and, or, not
        By default try find __bool__, if missed - __len__, if len() gives 0 - return False!
        """
        return bool(abs(self))

    def __add__(self, other):
        x = self.x + other.x
        y = self.y + other.y
        return Vector(x, y)

    def __mul__(self, scalar):
        return Vector(self.x * scalar, self.y * scalar)


if __name__ == '__main__':
    v1 = Vector(2, 4)
    v2 = Vector(2, 1)
    print(v1 + v2)  # Vector(4, 5)
    print(abs(v1))  # 4.47213595499958
