using Caliburn.Micro;
using Casino.BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WPFUI.ViewModels
{
    public class BlackjackViewModel : Screen
    {
        BlackJackLogic blackJackLogic = new BlackJackLogic();


        // Button z widoku połączony z funkcją na zasadzie konwencji nazw
        // To jest Button o nazwie Play zbindowany z funkcją Play
        public void Play()
        {
            blackJackLogic.dealer.Clear();
            blackJackLogic.player.Clear();


            blackJackLogic.addDeck(8);
            blackJackLogic.deck.Shuffle();

            drawPlayer();
            drawPlayer();
            blackJackLogic.drawDealer();
            blackJackLogic.drawDealer();

            MessageBox.Show($"Twoje karty:{showPlayerCards()} suma: {blackJackLogic.deckSum(blackJackLogic.player)}\n\nKarty Dealera: {blackJackLogic.dealer[0]} i ?", "Karty");

            choose();

            MessageBox.Show($"{blackJackLogic.winState}\n\nTy:{showPlayerCards()} suma: {blackJackLogic.deckSum(blackJackLogic.player)}\n\nDealer:{showDealerCards()} suma: {blackJackLogic.deckSum(blackJackLogic.dealer)}", "Wynik");
        }

        public void choose()
        {
            MessageBoxResult result = MessageBox.Show("Czy chcesz dobrać kartę?", "Hit czy Stay", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    hit();
                    break;
                case MessageBoxResult.No:
                    stay();
                    break;
            }
        }

        public void hit()
        {
            drawPlayer();
            MessageBox.Show($"Dobrałeś kartę!\nTwoje karty: {showPlayerCards()} suma: {blackJackLogic.deckSum(blackJackLogic.player)}\n\nKarty Dealera: {blackJackLogic.dealer[0]} i ?", "Karty");
            if (blackJackLogic.deckSum(blackJackLogic.player) > 21)
            {
                Console.WriteLine("You lose");
                blackJackLogic.winState = ("Przegrywasz");
            }

            else choose();
        }

        public void stay()
        {
            Console.WriteLine("Dealer's cards: " + blackJackLogic.dealer[0] + " and " + blackJackLogic.dealer[1]);
            Console.WriteLine("Dealer's sum: " + blackJackLogic.deckSum(blackJackLogic.dealer));
            int a = 2;
            while (blackJackLogic.deckSum(blackJackLogic.dealer) < 17)
            {
                blackJackLogic.drawDealer();
                Console.WriteLine("Dealer draws a card, it's: " + blackJackLogic.dealer[a] + ", sum of his cards: " + blackJackLogic.deckSum(blackJackLogic.dealer));
                a++;
            }

            blackJackLogic.compare();
        }

        public void drawPlayer()
        {
            Random rnd = new Random();
            int c = rnd.Next(0, 12);
            blackJackLogic.player.Add(blackJackLogic.deck[c]);
            blackJackLogic.deck.RemoveAt(c);

            int z = 0;
            while (blackJackLogic.player.ElementAtOrDefault(z) != null)
            {
                if (blackJackLogic.player[z] == "ACE") blackJackLogic.player[z] = ace();
                z++;
            }
        }

        public string ace()
        {
            Console.WriteLine("You've got an ace");
            string a = Console.ReadLine();

            MessageBoxResult result = MessageBox.Show("Wybierz wartość asa, 11 czy 1:", "Dobrałeś asa", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    return "11";
                case MessageBoxResult.No:
                    return "1";
            }
            return "0";
        }

        public string showPlayerCards()
        {
            string playerCards = "";
            Console.WriteLine("Your cards: ");
            int z = 0;
            while (blackJackLogic.player.ElementAtOrDefault(z) != null)
            {
                Console.WriteLine(blackJackLogic.player[z]);
                playerCards += " " + blackJackLogic.player[z];
                z++;
            }
            Console.WriteLine("Sum of your cards: " + blackJackLogic.deckSum(blackJackLogic.player) + "\n");
            return playerCards;
        }

        public string showDealerCards()
        {
            string dealerCards = "";
            Console.WriteLine("Dealer's cards: ");
            int z = 0;
            while (blackJackLogic.dealer.ElementAtOrDefault(z) != null)
            {
                Console.WriteLine(blackJackLogic.dealer[z]);
                dealerCards += " " + blackJackLogic.dealer[z];
                z++;
            }
            Console.WriteLine("Sum of dealer's cards: " + blackJackLogic.deckSum(blackJackLogic.dealer) + "\n");
            return dealerCards;
        }
    }
}
