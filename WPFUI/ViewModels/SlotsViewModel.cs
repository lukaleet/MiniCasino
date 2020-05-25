﻿using Caliburn.Micro;
using Casino.Slots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WPFUI.ViewModels
{
    public class SlotsViewModel : Screen
	{
		/*
		 Logika jest tu taka, ze tworzymy pelne wlasciwosci (full properties), ktore skladaja sie z prywatnego pola i wlasciwosci
		 do odczytu i zapisu tego pola. Robimy tak dlatego, bo wymaga tego Caliburn Micro i mechanizm MVVM. Te full propertisy maja taka sama nazwe
		 jak to co nazwalismy w SlotsView.
		 */

		// TODO WRZUCIC DI NAWET W ZWYKLE KLASY SPOZA PROJEKTU
		SlotsLogic slotsLogic = new SlotsLogic();


		// Wysokosc zakladu, polaczona z TextBoxem, w ktorego wpisuje sie wartosc
		private decimal _betStake;

		// Informacja na temat stawek wyswietlana pod blokiem na wpisywanie danych
		private string _betInfo;

		// obliczenie wygranej na podstawie zakladu, to pole nie jest polaczone bezposrednio ze SlotsView
		private decimal _winStake;

		// Wyswietlaja obrazki, polaczone z Image w Slots View
		private ImageSource _slot1;
		private ImageSource _slot2;
		private ImageSource _slot3;

		// Wlasciwosc (property), ktora sluzy do manipulowania _betStake, jednozcesnie jest polaczona z widokiem na zasadzie konwencji nazw.
		public decimal BetStake
		{
			get { return _betStake; }
			set
			{
				if (value >= 300 || value <= 0)
					_betStake = 0;
				else
					_betStake = value;

				NotifyOfPropertyChange(() => BetStake);
				NotifyOfPropertyChange(() => CanPlay);
			}
		}

		public string BetInfo
		{
			get { return _betInfo; }
			set 
			{
				_betInfo = value;
				NotifyOfPropertyChange(() => BetInfo);
			}
		}

		public ImageSource Slot1 
		{ 
			get { return _slot1; }
			set 
			{
				_slot1 = value;
				NotifyOfPropertyChange(() => Slot1);
			}
		}

		public ImageSource Slot2
		{
			get { return _slot2; }
			set
			{
				_slot2 = value;
				NotifyOfPropertyChange(() => Slot2);
			}
		}

		public ImageSource Slot3
		{
			get { return _slot3; }
			set
			{
				_slot3 = value;
				NotifyOfPropertyChange(() => Slot3);
			}
		}


		// Wlasciwosc CanPlay, ktora sluzy do sprawdzania, czy przycisk do grania (button z widoku o nazwie "Play") moze byc nacisniety
		public bool CanPlay
		{
			get
			{
				bool output = false;

				if (BetStake > 0 && !(BetStake >= 300))
				{
					output = true;
					BetInfo = "";
				}
				else if (BetStake <= 0)
				{
					BetInfo = "Możesz stawiać kwoty w przedziale 0-300";
				}

				return output;
			}
		}

		//TU NA PEWNO TO DO BO PIEKNIE TO NIE WYGLADA
		// funkcja odpalenia przycisku, tylko mozliwa gdy CanPlay == true
		public void Play()
		{
			Console.WriteLine($"Play { BetStake }");
			// tu dodac pobieranie kasy od usera, nawet zhardcodowanego i odpalic logike slotsow
			slotsLogic.RandomChoose();
			_winStake = slotsLogic.ComputeWin(BetStake);

			foreach (var element in slotsLogic.RandomlyChosen)
			{
				Console.WriteLine(element);
			}

			Console.WriteLine($"{ _winStake }");

			Slot1 = Images(slotsLogic.RandomlyChosen.ElementAt(0));
			Slot2 = Images(slotsLogic.RandomlyChosen.ElementAt(1));
			Slot3 = Images(slotsLogic.RandomlyChosen.ElementAt(2));

			if (_winStake > 0)
			{
				MessageBox.Show($"Wygrałeś { _winStake }");
			}
		}

		// PODMIANA OBRAZKA SLOT1, SLOT2 ITP
		//TO DO MOZE OBRABIAC LISTE ZAMIAST POJEDYNCZYCH POL JAK SIE BEDZIE DALO, POKI CO JEST GIT BO DZIALA
		public ImageSource Images(char which) 
		{
			ImageSource art;
			var converter = new ImageSourceConverter();
			if (which == 'C') art = (ImageSource)converter.ConvertFromString("C:/Users/luke/source/repos/WpfApp1/WpfApp1/images/cherry.png");
			//if (which == 'C') art = (ImageSource)converter.ConvertFrom("~/Images/cherry.png");
			else if (which == 'L') art = (ImageSource)converter.ConvertFromString("C:/Users/luke/source/repos/WpfApp1/WpfApp1/images/lemon.png");
			else if (which == 'O') art = (ImageSource)converter.ConvertFromString("C:/Users/luke/source/repos/WpfApp1/WpfApp1/images/orange.png");
			else if (which == 'P') art = (ImageSource)converter.ConvertFromString("C:/Users/luke/source/repos/WpfApp1/WpfApp1/images/plum.png");
			else if (which == 'W') art = (ImageSource)converter.ConvertFromString("C:/Users/luke/source/repos/WpfApp1/WpfApp1/images/watermelon.png");
			else art = (ImageSource)converter.ConvertFromString("C:/Users/luke/source/repos/WpfApp1/WpfApp1/slots.png");
			return art;
		}
	}
}