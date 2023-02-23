using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
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
            //updates player
            Player.ToString();
            //checks for blackjack
            if (Player.HighValue == 21)
                Status = GameStatus.BlackJack;
            else
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
                    //status check after drawing a card
                    StatusUpdate();
                }
                else if (input.ToLower() == "s" || input.ToLower() == "stay")
                {
                    DealerDraw(1);
                    //status check after drawing a card
                    StatusUpdate();
                }
            }
            //writes game status after finished game
            switch (Status)
            {
                case GameStatus.Won:
                    Console.WriteLine("You Won!");
                    break;
                case GameStatus.Lost:
                    Console.WriteLine("You Lost");
                    break;
                case GameStatus.Tie:
                    Console.WriteLine("Game Tied");
                    break;
                case GameStatus.BlackJack:
                    Console.WriteLine("BlackJack" + Environment.NewLine + "You Won");
                    break;
                default:
                    Console.WriteLine("an error occured");
                    break;
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
            //player.ToString() also updates the player
            Player.ToString();
            Debug.WriteLine("Player: " + Player.LowValue + "/" + Player.HighValue); 
        }
        public void DealerDraw(int nrOfCards)
        {
            //if dealers hand is < 17 draw otherwise stay
            //dealer always counts ace as 11 (HighValue)
            if (Dealer.HighValue < 17)
            {
                //adds new card to dealers hand;
                for (int i = 0; i < nrOfCards; i++)
                {
                    Card card = Deck.Draw();
                    Dealer.Hand.Add(card);
                    Dealer.LastDrawnCard = card;
                }
            }
            
            //player.ToString() also updates the player
            Dealer.ToString();
            Debug.WriteLine("Dealer: " + Dealer.LowValue + "/" + Dealer.HighValue);
        }
        void StatusUpdate(){
            //player == 21 => won
            if (Player.LowValue == 21 || Player.HighValue == 21)
            {
                Status = GameStatus.Won;
            }
            //dealer > 21 => won
            else if (Dealer.HighValue > 21)
            {
                Status = GameStatus.Won;
            }
            //player > 21 => lost
            else if (Player.LowValue > 21)
            {
                Status = GameStatus.Lost;
            }
            //player && dealer == 20 => tie
            else if (Dealer.HighValue == 20 && Player.LowValue == 20)
            {
                Status = GameStatus.Tie;
            }
            //player && dealer == 17 || 18 || 19 => lost
            else if (Dealer.HighValue == 17 || Dealer.HighValue == 18 || Dealer.HighValue == 19)
            {
                if (Player.LowValue == Dealer.HighValue)
                {
                    Status = GameStatus.Lost;
                }
                //player is higher than dealer
                else if (Player.LowValue > Dealer.HighValue)
                {
                    Status = GameStatus.Won;
                }
            }
            //default playing
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
