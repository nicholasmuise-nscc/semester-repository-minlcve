using System;
using System.Collections.Generic;

namespace BlackJackGame
{
    public class Card
    {
        public string Suit { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{Value} of {Suit}";
        }
    }

    public class Deck
    {
        private List<Card> cards;
        private Random rand = new Random();

        public Deck()
        {
            Reset();
        }

        public void Reset()
        {
            cards = new List<Card>();
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            foreach (string suit in suits)
            {
                foreach (string value in values)
                {
                    cards.Add(new Card { Suit = suit, Value = value });
                }
            }
        }

        public Card DrawCard()
        {
            if (cards.Count == 0)
                return null;

            int index = rand.Next(cards.Count);
            Card drawn = cards[index];
            cards.RemoveAt(index);
            return drawn;
        }
    }
}
