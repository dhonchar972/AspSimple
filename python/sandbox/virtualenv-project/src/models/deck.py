import collections
from random import choice

Card = collections.namedtuple('Card', ['rank', 'suit'])  # records equivalent(class with fields only - perfect DTO)


class FrenchDeck:
    ranks = [str(n) for n in range(2, 11)] + list('JQKA')
    suits = 'spades diamonds clubs hearts'.split()

    def __init__(self):
        self._cards = [Card(rank, suit) for suit in self.suits
                       for rank in self.ranks]

    def __len__(self):
        return len(self._cards)

    def __getitem__(self, position):
        return self._cards[position]


if __name__ == '__main__':
    card = Card('7', 'diamonds')
    print(card)  # Card(rank='7', suit='diamonds')

    deck = FrenchDeck()
    print(len(deck))  # 52 // __len__ at work
    print(deck[0])  # Card(rank='2', suit='spades') // __getitem__ at work
    choice(deck)  # Card(rank='2', suit='spades') // get random card from deck
    print(deck[:3])  # [Card(rank='2', suit='spades'), Card(rank='3', suit='spades'), Card(rank='4', suit='spades')]
    print(deck[
          12::13])  # [Card(rank='A', suit='spades'), Card(rank='A', suit='diamonds'), Card(rank='A', suit='clubs'), Card(rank='A', suit='hearts')]
    for card in deck:  # for right work need __getitem__
        print(card)
    for card in reversed(deck):
        print(card)
    print(Card('Q', 'hearts') in deck)  # True
    print(Card('7', 'beasts') in deck)  # False

    suit_values = dict(spades=3, hearts=2, diamonds=1, clubs=0)


    def spades_high(cd):  # sorting
        rank_value = FrenchDeck.ranks.index(cd.rank)
        return rank_value * len(suit_values) + suit_values[cd.suit]


    for card in sorted(deck, key=spades_high):
        print(card)
