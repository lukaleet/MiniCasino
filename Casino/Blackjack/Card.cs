using System;
using System.Collections.Generic;
using System.Text;

namespace Casino.Blackjack
{
    public class Card
    {
        public int LocalValue { get; set; }
        public int GameValue { get; set; }
        public string Suit { get; set; }

        public Card(string suit, int value)
        {
            Suit = suit;
            LocalValue = value;
            GameValue = SetGameValue(LocalValue);
        }

        private int SetGameValue(int localValue)
        {
            int value = 0;

            if (localValue <= 10) 
            {
                value = localValue;
            }

            else if (localValue == 11)
            {
                value = 10;
            }

            else if (localValue == 12)
            {
                value = 10;
            }

            else if (localValue == 13)
            {
                value = 11;
            }

            return value;
        }
    }
}
