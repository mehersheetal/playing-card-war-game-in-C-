using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    public static class GameUtil
    { 
        public static Queue<Card> CreateCards()
        {
            Queue<Card> cards = new Queue<Card>();
            for(int i = 2; i <= 14; i++)
            {
                foreach(Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    cards.Enqueue(new Card()
                    {
                        Suit = suit,
                        Value = i,
                        DisplayName = GetShortName(i, suit)
                    });
                }
            }
            cards = Shuffle(cards);
            cards = Shuffle(cards);
            cards = Shuffle(cards);
            return Shuffle(cards);
        }

        public static Queue<Card> Shuffle(Queue<Card> cards)
        {
            List<Card> transformedCards = cards.ToList();
            Random r = new Random(DateTime.Now.Second);
            for (int n = transformedCards.Count - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                Card temp = transformedCards[n];
                transformedCards[n] = transformedCards[k];
                transformedCards[k] = temp;
            }

            Queue<Card> shuffledCards = new Queue<Card>();
            foreach(var card in transformedCards)
            {
                shuffledCards.Enqueue(card);
            }

            return shuffledCards;
        }

        private static string GetShortName(int value, Suit suit)
        {
            string valueDisplay = "";
            if (value >= 2 && value <= 10)
            {
                valueDisplay = value.ToString();
            }
            else if (value == 11)
            {
                valueDisplay = "J";
            }
            else if (value == 12)
            {
                valueDisplay = "Q";
            }
            else if (value == 13)
            {
                valueDisplay = "K";
            }
            else if (value == 14)
            {
                valueDisplay = "A";
            }

            return valueDisplay + Enum.GetName(typeof(Suit), suit)[0];
        }
    }
}
