using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.BlackJack
{
    public class BlackJackLogic
    {
        public List<string> deck = new List<string> { };
        public List<string> player = new List<string> { };
        public List<string> dealer = new List<string> { };

        public string winState;

        // Stworzenie nowej talii
        public void addDeck(int how_many)
        {
            int x = 0;
            while (x < how_many)
            {
                string[] fulldeck = { "ACE", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
                foreach (string z in fulldeck)
                {
                    deck.Add(z);
                }
                x++;
            }
        }

        // Dociągnięcie karty przez dealra w zależnośći od wartośći jego ręki
        public void drawDealer()
        {
            Random rnd = new Random();
            int c = rnd.Next(0, 12);
            dealer.Add(deck[c]);
            deck.RemoveAt(c);

            int z = 0;
            while (dealer.ElementAtOrDefault(z) != null)
            {
                if (dealer[z] == "ACE") dealer[z] = "11";
                z++;
            }
        }

        // Obliczenie sumy kart w ręce
        public int deckSum(List<string> some_deck)
        {
            int a = 0;

            int z = 0;
            while (some_deck.ElementAtOrDefault(z) != null)
            {
                if (some_deck[z] == "J" || some_deck[z] == "Q" || some_deck[z] == "K") a += 10;

                else a += Int32.Parse(some_deck[z]);

                z++;
            }

            return a;
        }

        // Metoda do porównania ręki gracza i krupiera, co do wartości
        public void compare()
        {
            if (deckSum(player) > 21)
            {
                Console.WriteLine("You lose");
                winState = ("Przegrywasz");
            }

            else if (deckSum(dealer) > 21)
            {
                Console.WriteLine("You win");
                winState = ("Wygrywasz!");
            }

            else if (deckSum(dealer) > deckSum(player))
            {
                Console.WriteLine("You lose");
                winState = ("Przegrywasz");
            }

            else if (deckSum(dealer) < deckSum(player))
            {
                Console.WriteLine("You lose");
                winState = ("Wygrywasz!");
            }

            else if (deckSum(dealer) == deckSum(player))
            {
                Console.WriteLine("It's a draw");
                winState = ("Remis!");
            }
        }
    }

    // Metoda rozszerzona, która działa do każdej kolekcji typu <T>, np List<T>
    // przetasowanie kart bazujące na przetasowaniu Fishera-Yatesa
    public static class Helpers
    {

        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
