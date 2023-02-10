using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Deck
    {
        int _nrOfDecks;
        List<Card> _cards;

        public Deck(int nrOfDecks)
        {
            _nrOfDecks = nrOfDecks;
            _cards = new List<Card>();
            for (int i = 0; i < _nrOfDecks; i++)
            {
                for (int s = 0; s < 4; s++)
                {
                    for (int v = 1; v < 14; v++)
                    {
                        _cards.Add(new Card(v, (SuitType)s));
                    }
                }
            }
            Shuffle();
        }
        void ResetAndShuffle()
        {
            Shuffle();

        }
        //shuffles the deck
        void Shuffle()
        {
            Random rng = new Random();
            _cards = _cards.OrderBy(a => rng.Next()).ToList();
        }
        //gets the top card from the deck and removes it from the deck
        public Card Draw()
        {
            Card card = _cards.First();
            _cards.Remove(card);
            return card;
        }
    }
}
