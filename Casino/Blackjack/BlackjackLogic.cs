using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Casino.Blackjack
{
    public class BlackjackLogic
    {
        private Deck deck = new Deck();

        public List<Card> playerHand { get; set; } = new List<Card>();

        public List<Card> enemyHand { get; set; } = new List<Card>();

        public void Deal()
        {
            playerHand.Add(deck.cards.ElementAt(0));

            deck.cards.RemoveAt(0);

            enemyHand.Add(deck.cards.ElementAt(0));

            deck.cards.RemoveAt(0);

            playerHand.Add(deck.cards.ElementAt(0));

            deck.cards.RemoveAt(0);

            enemyHand.Add(deck.cards.ElementAt(0));

            deck.cards.RemoveAt(0);
        }

        public void Hit()
        {
            playerHand.Add(deck.cards.ElementAt(0));

            deck.cards.RemoveAt(0);
        }

        public bool Stay()
        {
            if (ShouldEnemyDrawCard(enemyHand))
            {
                enemyHand.Add(deck.cards.ElementAt(0));
                deck.cards.RemoveAt(0);
            }

            bool win = ComputePlayerWin(playerHand, enemyHand);

            return win;
        }

        public int HandValue(List<Card> cards)
        {
            int sum = 0;
            foreach(var card in cards)
            {
                sum += card.GameValue;
            }

            return sum;
        }

        public bool ShouldEnemyDrawCard(List<Card> enemyCards)
        {
            if (HandValue(enemyCards) >= 17)
                return false;
            else
                return true;
        }

        bool ComputePlayerWin(List<Card> playerCards, List<Card> enemyCards)
        {
            if ((HandValue(playerCards) > HandValue(enemyCards)) && (HandValue(playerCards) < 22))
                return true;

            else if ((HandValue(playerCards) == HandValue(enemyCards) && HandValue(playerCards) < 21))
                return false;

            else if ((HandValue(playerCards) < HandValue(enemyCards)) && HandValue(enemyCards) < 22)
                return false;

            else
                return false;
        }

    }
}
