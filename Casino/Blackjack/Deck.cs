using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Casino.Blackjack
{
    public class Deck
    {
        public List<Card> cards = new List<Card>();

        public Deck()
            {
                var query =
                    from suit in new[] { "Spades", "Hearts", "Clubs", "Diamonds", }
                    from value in Enumerable.Range(1, 13)
                    select new Card(suit, value);

                cards = query.ToList();

            cards.Shuffle();
            }
    }
}
