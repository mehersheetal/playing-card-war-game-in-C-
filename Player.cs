using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    public class Player
    {
        public string Name { get; set; }
        public Queue<Card> Deck { get; set; }

        public Player() { }

        public Player(string name)
        {
            Name = name;
        }

        public List<Queue<Card>> Deal(Queue<Card> cards)
        {
            Queue<Card> player1cards = new Queue<Card>();
            Queue<Card> player2cards = new Queue<Card>();
            Queue<Card> player3cards = new Queue<Card>();
            List<Queue<Card>> distributedCardsListbyPlayer = new List<Queue<Card>>();

            int counter = 2;
            while(cards.Any())
            {
                if (counter % 3 == 0)
                {
                    player3cards.Enqueue(cards.Dequeue());

                } else if(counter % 2 == 0) 
                {
                    player2cards.Enqueue(cards.Dequeue());
                }
                else
                {
                    player1cards.Enqueue(cards.Dequeue());

                }
                counter++;
            }

            Deck = player1cards;
            distributedCardsListbyPlayer.Add(player2cards);
            distributedCardsListbyPlayer.Add(player3cards);

            return distributedCardsListbyPlayer;
        }
    }
}
