using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Player
    {
        public List<Card> Hand;
        public Card? LastDrawnCard;
        public int LowValue { get; private set; }
        int HighValue;
        //dot yet know what to do with best value
        int BestValue;
        public Player()
        {
            Hand = new List<Card>();
            LastDrawnCard = null;
        }
        void Reset()
        {

        }
        //prints the players hand and the value of the hand
        public override string ToString()
        {
            string hand = string.Empty;
            LowValue = 0;
            HighValue = 0;
            foreach (Card card in Hand)
            {
                hand += $"{card.ToString()}, ";
                //adds 10 more to highvalue if the hand contains an ace wich can be counted as 1 or 11
                if (card.Value == 1)
                {
                    HighValue += 10;
                }
                LowValue += card.BlackJackValue;
                HighValue += card.BlackJackValue;
                
            }
            return $"{hand} ({LowValue}/{HighValue})";
        }
    }
}
