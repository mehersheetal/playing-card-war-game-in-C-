using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CardGame
{
    public class Game
    {
        private Player Player1;
        private Player Player2;
        private Player Player3;

        public int TurnCount = 1;
        public Game(string player1, string player2, string player3)
        {
            Player1 = new Player(player1);
            Player2 = new Player(player2);
            Player3 = new Player(player3);


            var cards = GameUtil.CreateCards();

            List<Queue<Card>> decks = Player1.Deal(cards); 
            Player2.Deck = decks[0];
            Player3.Deck = decks[1];
        }

        public bool IsEndOfGame()
        {
            Boolean player1OutOfCard = false;
            Boolean player2OutOfCard = false;
            Boolean player3OutOfCard = false;
            if (!Player1.Deck.Any())
            {
                Console.WriteLine(Player1.Name + " is out of cards!  ");
                player1OutOfCard = true;
            }
            if(!Player2.Deck.Any())
            {
                Console.WriteLine(Player2.Name + " is out of cards!  ");
                player2OutOfCard = true;
            }
             if (!Player3.Deck.Any())
            {
                Console.WriteLine(Player3.Name + " is out of cards!  ");
                player3OutOfCard = true;
            }

             if ((player1OutOfCard && player2OutOfCard))
            {
                Console.WriteLine(Player1.Name + " and " + Player2.Name + " are out of cards!  " + Player3.Name + " WINS!");
                Console.WriteLine("TURNS: " + TurnCount.ToString());
                return true;
            } else if ((player2OutOfCard && player3OutOfCard))
            {
                Console.WriteLine(Player2.Name + " and " + Player3.Name + " are out of cards!  " + Player1.Name + " WINS!");
                Console.WriteLine("TURNS: " + TurnCount.ToString());
                return true;
            }
            else if ((player1OutOfCard && player3OutOfCard))
            {
                Console.WriteLine(Player1.Name + " and " + Player3.Name + " are out of cards!  " + Player2.Name + " WINS!");
                Console.WriteLine("TURNS: " + TurnCount.ToString());
                return true;
            }
            TurnCount++;
            return false;
        }
        public void PlayTurn()
        {
            Queue<Card> pool = new Queue<Card>();
            Card emptyCard = new Card()
            {
                Suit = Suit.Clubs,
                Value = 0,
                DisplayName = "No Card"
            };
            var player1card = emptyCard;
            var player2card = emptyCard;
            var player3card = emptyCard;
            if (Player1.Deck.Any())
            {
                player1card = Player1.Deck.Dequeue();
            }
            if (Player2.Deck.Any())
            {
                player2card = Player2.Deck.Dequeue();
            }
            if (Player3.Deck.Any())
            {
                player3card = Player3.Deck.Dequeue();
            }

            if (player1card.Value != 0)
            {
                pool.Enqueue(player1card);
            }
            if (player2card.Value != 0)
            {
                pool.Enqueue(player2card);
            }
            if (player3card.Value != 0)
            {
                pool.Enqueue(player3card);
            }

            pool = GameUtil.Shuffle(pool);

            Console.WriteLine(Player1.Name + " plays " + player1card.DisplayName + ", " + Player2.Name + " plays " + player2card.DisplayName + ", " + Player3.Name + " plays " + player3card.DisplayName);

            while (player1card.Value == player2card.Value && player2card.Value == player3card.Value)
            {
                Console.WriteLine("WAR!");
                if (Player1.Deck.Count < 4)
                {
                    Player1.Deck.Clear();
                    return;
                }
                if(Player2.Deck.Count < 4)
                {
                    Player2.Deck.Clear();
                    return;
                }

                if (Player3.Deck.Count < 4)
                {
                    Player3.Deck.Clear();
                    return;
                }

                pool.Enqueue(Player1.Deck.Dequeue());
                pool.Enqueue(Player1.Deck.Dequeue());
                pool.Enqueue(Player1.Deck.Dequeue());
                pool.Enqueue(Player2.Deck.Dequeue());
                pool.Enqueue(Player2.Deck.Dequeue());
                pool.Enqueue(Player2.Deck.Dequeue());
                pool.Enqueue(Player3.Deck.Dequeue());
                pool.Enqueue(Player3.Deck.Dequeue());
                pool.Enqueue(Player3.Deck.Dequeue());

                player1card = Player1.Deck.Dequeue();
                player2card = Player2.Deck.Dequeue();
                player3card = Player3.Deck.Dequeue();

                pool.Enqueue(player1card);
                pool.Enqueue(player2card);
                pool.Enqueue(player3card);

                Console.WriteLine(Player1.Name + " plays " + player1card.DisplayName + ", " + Player2.Name + " plays " + player2card.DisplayName + ", " + Player3.Name + " plays " + player3card.DisplayName);
            }

            if (player1card.Value < player2card.Value)
            {
                if (player2card.Value < player3card.Value)
                {
                    foreach (var card in pool)
                    {
                        Player3.Deck.Enqueue(card);
                    }
                    Console.WriteLine(Player3.Name + " takes the hand!");
                } 
                else 
                {
                    foreach (var card in pool)
                    {
                        Player2.Deck.Enqueue(card);
                    }
                    Console.WriteLine(Player2.Name + " takes the hand!");
                }

            }
            else if (player1card.Value < player3card.Value)
            {
                if (player3card.Value < player2card.Value)
                {
                    foreach (var card in pool)
                    {
                        Player2.Deck.Enqueue(card);
                    }
                    Console.WriteLine(Player2.Name + " takes the hand!");
                }
                else
                {
                    foreach (var card in pool)
                    {
                        Player3.Deck.Enqueue(card);
                    }
                    Console.WriteLine(Player3.Name + " takes the hand!");
                }

            } else
            {
                foreach (var card in pool)
                {
                    Player1.Deck.Enqueue(card);
                }
                Console.WriteLine(Player1.Name + " takes the hand!");
            }
            TurnCount++;
        }
    }
}
