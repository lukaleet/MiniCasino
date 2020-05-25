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
            int num = random.Next(0, chars.Length);
            return chars[num];
        }

        public void RandomChoose()
        {
            RandomlyChosen.Clear();
            RandomlyChosen.Add(RandomSlot());
            RandomlyChosen.Add(RandomSlot());
            RandomlyChosen.Add(RandomSlot());
        }

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

        private bool TwoAreSame()
        {
            //jesli pierwszy = sie drugiemu i nie trzeciuemu, lub jestli pierwszy rowna sie trzeciemu i nie drugiemu, lub jestli drugi rowna sie trzeciemu

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
