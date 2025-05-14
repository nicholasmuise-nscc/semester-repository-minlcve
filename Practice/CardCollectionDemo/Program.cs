using System;
using System.Collections;
using System.Collections.Generic;

namespace CardCollectionDemo
{
    public class Card
    {
        public string Suit { get; set; }
        public string Value { get; set; }

        public Card(string value, string suit)
        {
            Value = value;
            Suit = suit;
        }

        public string GetCardCode() => Value + Suit;

        public override string ToString()
        {
            return $"{Value} of {Suit}";
        }
    }

    public class Deck
    {
        private string[] suits = { "H", "D", "C", "S" };
        private string[] values = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        private Random random = new Random();

        public Card[] Cards { get; private set; }

        public ArrayList CardInfoList { get; private set; }

        public Dictionary<string, int> CardValueMap { get; private set; }

        public Deck()
        {
            InitializeCards();
            InitializeArrayList();
            InitializeDictionary();
        }

        private void InitializeCards()
        {
            Cards = new Card[52];
            int index = 0;
            foreach (var suit in suits)
            {
                foreach (var value in values)
                {
                    Cards[index++] = new Card(value, suit);
                }
            }
        }

        private void InitializeArrayList()
        {
            CardInfoList = new ArrayList();
            foreach (var suit in suits)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    string cardCode = values[i] + suit;
                    CardInfoList.Add(cardCode);
                    CardInfoList.Add(i + 1);
                }
            }
        }

        private void InitializeDictionary()
        {
            CardValueMap = new Dictionary<string, int>();
            foreach (var suit in suits)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    string cardCode = values[i] + suit;
                    CardValueMap[cardCode] = i + 1;
                }
            }
        }

        public Card Draw()
        {
            int index = random.Next(Cards.Length);
            return Cards[index];
        }

        public List<Card> RandomHand
        {
            get
            {
                List<Card> hand = new List<Card>();
                for (int i = 0; i < 5; i++)
                {
                    hand.Add(Draw());
                }
                return hand;
            }
        }

        public int GetCardValue(Card card)
        {
            string code = card.GetCardCode();
            return CardValueMap.TryGetValue(code, out int value) ? value : -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();

            Console.WriteLine("=== Drawing 5 cards from the deck (Array):");
            Card[] handArray = new Card[5];
            for (int i = 0; i < 5; i++)
            {
                handArray[i] = deck.Draw();
                Console.WriteLine(handArray[i]);
            }

            Console.WriteLine("\n=== Card Info ArrayList (code and value):");
            for (int i = 0; i < deck.CardInfoList.Count; i += 2)
            {
                Console.WriteLine($"{deck.CardInfoList[i]} - {deck.CardInfoList[i + 1]}");
            }

            Console.WriteLine("\n=== RandomHand using List<Card>:");
            List<Card> handList = deck.RandomHand;
            foreach (var card in handList)
            {
                Console.WriteLine(card);
            }

            Console.WriteLine("\n=== Card values using Dictionary:");
            foreach (var card in handList)
            {
                int value = deck.GetCardValue(card);
                Console.WriteLine($"{card.GetCardCode()} = {value}");
            }
        }
    }
}

