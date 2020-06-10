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

        // Wybór losowego symbolu
        private char RandomSlot()
        {
            string chars = "CLOPW";
            int num = random.Next(0, chars.Length);
            return chars[num];
        }

        // Wybiera losowo 3 symbole i dodaje je do listy
        public void RandomChoose()
        {
            RandomlyChosen.Clear();
            RandomlyChosen.Add(RandomSlot());
            RandomlyChosen.Add(RandomSlot());
            RandomlyChosen.Add(RandomSlot());
        }

        // Obliczenie wygranej, tylko wtedy gdy 2 lub 3 elementy są takie same
        public decimal ComputeWin(decimal betStake)
        {
            decimal winStake = 0;

            var allAreSame = RandomlyChosen.All(x => x == RandomlyChosen.First());

            if (allAreSame)
            {
                winStake = betStake * 1000M;
            }

            else if (TwoAreSame())
            {
                winStake = betStake * 1.5M;
            }

            return winStake;
        }

        // Jeśli pierwszy = sie drugiemu i nie trzeciuemu, lub jestli pierwszy rowna sie trzeciemu i nie drugiemu, lub jestli drugi rowna sie trzeciemu
        private bool TwoAreSame()
        {

            if (RandomlyChosen.ElementAt(0) == RandomlyChosen.ElementAt(1) && RandomlyChosen.ElementAt(0) != RandomlyChosen.ElementAt(2))
            {
                return true;
            }

            else if (RandomlyChosen.ElementAt(0) == RandomlyChosen.ElementAt(2) && RandomlyChosen.ElementAt(0) != RandomlyChosen.ElementAt(1))
            {
                return true;
            }

            else if (RandomlyChosen.ElementAt(1) == RandomlyChosen.ElementAt(2)) 
            {
                return true;
            }

            return false;
        }
    }
}
