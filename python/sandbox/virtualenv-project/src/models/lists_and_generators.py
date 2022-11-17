import array
from collections import abc

if __name__ == '__main__':
    print(issubclass(tuple, abc.Sequence))  # True
    print(issubclass(list, abc.MutableSequence))  # True

    #  simple realisation
    symbols1 = '$¢£¥€¤'
    codes1 = []
    for symbol in symbols1:
        codes1.append(ord(symbol))
    print(codes1)

    #  listcomp(List Comprehension) realisation
    symbols2 = '$¢£¥€¤'
    codes2 = [ord(symbol2) for symbol2 in symbols2]
    print(codes2)

    y = 'ABC'
    codes = [ord(y) for y in y]
    print(y)
    print(codes)
    codes = [last := ord(c) for c in y]
    print(last)  # 67, still can see it, because of ":="
    # print(c) // error, can't see, local variable

    symbols3 = '$¢£¥€¤'
    beyond_ascii = [ord(s) for s in symbols3 if ord(s) > 127]  # listcomp
    print(beyond_ascii)
    beyond_ascii = list(filter(lambda c: c > 127, map(ord, symbols3)))  # filter&map(lambda style)
    print(beyond_ascii)

    colors = ['black', 'white']
    sizes = ['S', 'M', 'L']
    print([(color, size) for color in colors for size in sizes])
    for color in colors:
        for size in sizes:
            print((color, size))

    symbols4 = '$¢£¥€¤'
    tuple(ord(symbol) for symbol in symbols4)  # generation expression(genexp)
    array.array('I', (ord(symbol) for symbol in symbols4))

    colors = ['black', 'white']
    sizes = ['S', 'M', 'L']
    for tshirt in (f'{c} {s}' for c in colors for s in sizes):
        print(tshirt)

    lax_coordinates = (33.9425, -118.408056)  # tuple unpack
    latitude, longitude = lax_coordinates
    print(latitude)
    print(longitude)
    latitude, longitude = longitude, latitude  # swap
    print(latitude)
    print(longitude)
    a, b, *rest = range(5)  # 0, 1, [2, 3, 4]


    def fun(a, b, c, d, *rest):
        return a, b, c, d, rest


    print(fun(*[1, 2], 3, *range(4, 7)))  # (1, 2, 3, 4, (5, 6))
    print(*range(4), 4)  # 0, 1, 2, 3, 4
    print([*range(4), 4])  # [0, 1, 2, 3, 4]
    print({*range(4), 4, *(5, 6, 7)})  # {0, 1, 2, 3, 4, 5, 6, 7}
