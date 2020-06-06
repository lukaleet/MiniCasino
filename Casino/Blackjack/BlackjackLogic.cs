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

        public BlackjackLogic()
        {
            Deal();
        }

        //rozdanie kart, moze dziala xd
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

        //Hit dobierz karte, troche to opakowalem z dupy, ale nie mam chwilowo innego pomyslu
        public bool Hit()
        {
            if (HandValue(playerHand) < 21)
            {
                playerHand.Add(deck.cards.ElementAt(0));

                deck.cards.RemoveAt(0);

                return true;
            }

            else
            {
                ShouldEnemyDrawCard(enemyHand);
                ComputePlayerWin(playerHand, enemyHand);

                return false;
            }         
        }

        // Stay przestan dobierac
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

        // obliczanie wartosci reki
        private int HandValue(List<Card> cards)
        {
            int sum = 0;
            foreach(var card in cards)
            {
                sum += card.GameValue;
            }

            return sum;
        }

        // enemy dobiera karte gry jego hand value < 17
        private bool ShouldEnemyDrawCard(List<Card> enemyCards)
        {
            if (HandValue(enemyCards) >= 17)
                return false;
            else
                return true;
        }

        // obliczenie wygranej
        public bool ComputePlayerWin(List<Card> playerCards, List<Card> enemyCards)
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
