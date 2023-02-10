using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Card
    {
        public int Value;
        SuitType Suit;
        public int BlackJackValue;

        public Card(int value, SuitType suit)
        {
            Value = value;
            Suit = suit;
            //keeps face cards value at 10
            if (Value > 10)
            {
                BlackJackValue = 10;
            }
            else
            {
                BlackJackValue = Value;
            }
        }
        public override string ToString()
        {
            //prints out the card with its value for face cards it shows the letter
            switch (Value)
            {
                case 13:
                    return $"K of {Suit}";
                case 12:
                    return $"Q of {Suit}";
                case 11:
                    return $"J of {Suit}";
                case 1:
                    return $"A of {Suit}";
                default:
                    return $"{Value} of {Suit}";

            }   
        }
    }
    internal enum SuitType
    {
        Club,
        Diamond,
        Heart,
        Spade
    }
}
