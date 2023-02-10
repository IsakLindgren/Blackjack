using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Game
    {
        Player Player;
        Player Dealer;
        Deck Deck;
        GameStatus Status;
        public Game()
        {
            //Game initialization
            Player = new Player();
            Dealer = new Player();
            //4 is how many decks it shuffles together (might add a prompt to choose how many decks)
            Deck = new Deck(4);
            Status = GameStatus.Playing;

            //draws 2 cards for each to start the game
            PlayerDraw(2);
            DealerDraw(2);

            //Gameloop
            while (Status == GameStatus.Playing)
            {
                Console.Clear();
                Console.WriteLine("Dealer: " + Dealer.LastDrawnCard.ToString());
                Console.WriteLine("Player: " + Player.ToString());
                Console.WriteLine(Environment.NewLine + "(S)tay (D)raw");

                string input = Console.ReadLine();
                if (input.ToLower() == "d" || input.ToLower() == "draw")
                {
                    PlayerDraw(1);
                }
                else if (input.ToLower() == "s" || input.ToLower() == "stay")
                {
                    DealerDraw(1);
                }
            }
        }
        public void reset()
        {

        }
        public void PlayerDraw(int nrOfCards)
        {
            //adds new card to player hand
            for (int i = 0; i < nrOfCards; i++)
            {
                Card card = Deck.Draw();
                Player.Hand.Add(card);
                Player.LastDrawnCard = card;
            }
            Player.ToString();

            //status check after drawing a card
            StatusUpdate();
                
        }
        public void DealerDraw(int nrOfCards)
        {
            //adds new card to dealers hand;
            for (int i = 0; i < nrOfCards; i++)
            {
                Card card = Deck.Draw();
                Dealer.Hand.Add(card);
                Dealer.LastDrawnCard = card;
            }
        }
        void StatusUpdate(){
            
        }
    }
    internal enum GameStatus
    {
        Won,
        Lost,
        Playing,
        Tie,
        BlackJack
    }
}
