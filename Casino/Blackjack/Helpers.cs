using System;
using System.Collections.Generic;
using System.Text;

namespace Casino.Blackjack
{
    public static class Helpers
    {
        //metoda pomocnicza, w tym przypadku dodanie metody rozszerzonej dla kazdej kolekcji
        //bazuje na przetasowaniu Fishera-Yatesa

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
