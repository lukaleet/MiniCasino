using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Casino.Roulette
{
    public class RouletteLogic
    {
        Random rand = new Random();
        public int RandomlyChosen = 0;

        // Losuje liczbę, która wygrywa - zakres 0-37
        public void RandomNumber()
        {
            RandomlyChosen = 0;
            RandomlyChosen = rand.Next(37);
        }

        // Oblicza wygraną na podstawie wyboru konkretnej liczby
        public decimal ComputeNumber(decimal betStake, int playerBet)
        {
            if (RandomlyChosen == playerBet) return betStake * 36;
            else return 0;
        }

        // Oblicza wygraną na podstawie wyboru parzystości/nieparzystości liczby
        public decimal ComputeOdd(decimal betStake, string playerBet)
        {
            if (playerBet == "nieparzyste" && RandomlyChosen % 2 == 1) return betStake * 2;
            else if (playerBet == "parzyste" && RandomlyChosen % 2 == 0) return betStake * 2;
            else return 0;
        }

        // Oblicza wygraną na podstawie wyboru koloru liczby
        public decimal ComputeColor(decimal betStake, string playerBet)
        {
            int[] red = new int[] { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
            if (playerBet == "czerwone" && red.Contains(RandomlyChosen)) return betStake * 2;
            else if (playerBet == "czarne" && !red.Contains(RandomlyChosen)) return betStake * 2;
            else return 0;
        }

        // Oblicza wygraną na podstawie połówki puli liczb
        public decimal ComputeHalf(decimal betStake, string playerBet)
        {
            if (playerBet == "1" && RandomlyChosen <= 18) return betStake * 2;
            else if (playerBet == "2" && RandomlyChosen > 18) return betStake * 2;
            else return 0;
        }

        // Oblicza wygraną na podstawie 1/3 puli liczb
        public decimal ComputeThird(decimal betStake, string playerBet)
        {
            if (playerBet == "1" && RandomlyChosen <= 12) return betStake * 3;
            else if (playerBet == "2" && RandomlyChosen <= 24) return betStake * 3;
            else if (playerBet == "3" && RandomlyChosen > 24) return betStake * 3;
            else return 0;
        }

        // Oblicza wygraną na podstawie wyboru konkretnej kolumny
        public decimal ComputeColumn(decimal betStake, string playerBet)
        {
            if (playerBet == "1" && (RandomlyChosen % 3) == 1) return betStake * 3;
            else if (playerBet == "2" && (RandomlyChosen % 3) == 2) return betStake * 3;
            else if (playerBet == "3" && (RandomlyChosen % 3) == 0) return betStake * 3;
            else return 0;
        }

    }
}