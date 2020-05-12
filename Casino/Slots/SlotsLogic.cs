using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Casino.Slots
{
    public class SlotsLogic
    {
        Random random = new Random();

        public List<char> RandomlyChosen = new List<char>();

        private char RandomSlot()
        {
            string chars = "CLOPW";
            int num = random.Next(0, chars.Length - 1);
            return chars[num];
        }

        public void RandomChoose()
        {
            RandomlyChosen.Clear();
            RandomlyChosen.Add(RandomSlot());
            RandomlyChosen.Add(RandomSlot());
            RandomlyChosen.Add(RandomSlot());
        }


        /* 
         Obliczenie wysokości wygranej, jeśli wszystkie symbole są takie same, to mnożymy bet * 1000
         PAMIĘTAĆ, ŻE BETSTAKE Z SLOTSVIEWMODEL NIE MOŻE BYĆ < 0
         */
        public decimal ComputeWin(decimal betStake)
        {
            decimal winStake = 0;

            var allAreSame = RandomlyChosen.All(x => x == RandomlyChosen.First());

            if (allAreSame)
            {
                winStake = betStake * 1000;
            }

            //if (TwoAreSame())
            //{
            //    winStake = betStake * 150;
            //}


            return winStake;
        }

        //TODO TU DODAC JAKIES CUSTOMOWE FUNKCJE TYPU BOOL WYGRANYCH JAKO METODY PRYWATNE, WRZUCIC JE DO POWYZSZEJ METODY
        // COS W STYLU LEMONIADA JAK NP WYPADNIE LEMON LEMON ORANGE W DOWOLNEJ KOLEJNOSCI, LOL, OLL ITP JAKO SPECJALNA ODMIANA TWOARESAME

        //private bool TwoAreSame()
        //{
        //}

    }
}
