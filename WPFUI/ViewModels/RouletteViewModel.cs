using Caliburn.Micro;
using Casino.Roulette;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;


namespace WPFUI.ViewModels
{
	public class RouletteViewModel : Screen
	{

		RouletteLogic rouletteLogic = new RouletteLogic();

		private decimal _betStake;
		private string _inputBox;

		private string _info;
		private string _betInfo;

		private decimal _winStake;

		private bool _oddButton;
		private bool _numberButton;
		private bool _colorButton;

		private bool _halfButton;
		private bool _thirdButton;
		private bool _columnButton;


		// Wlasciwosc polaczona na zasadzie konwencji nazw z widokiem, aktualizuje dynamicznie stawki + jest tu czesciowa walidacja
		// Jest to TextBlock na wpisywanie stawek
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

		// Wlasciwosc polaczona na zasadzie konwencji nazw z widokiem, aktualizuje dynamicznie stawki + jest tu czesciowa walidacja
		// Wyswietla aktualna stawke
		public string BetInfo
		{
			get { return _betInfo; }
			set
			{
				_betInfo = value;
				NotifyOfPropertyChange(() => BetInfo);
			}
		}

		//Na podstawie wartosci zwracanych z booli (radio buttony), wyswietla co wpisywac
		public string Info
		{

			get

			{
				if (OddButton)
					_info = "Wpisz 'parzyste' lub 'nieparzyste.'";
				else if (NumberButton)
					_info = "Wpisz liczbę z przedziału 0-36.";
				else if (ColorButton)
					_info = "Wpisz 'czarne' lub 'czerwone'.";
				else if (HalfButton)
					_info = "Wpisz '1' lub '2'.";
				else if (ThirdButton)
					_info = "Wpisz '1', '2' lub '3'.";
				else if (ColumnButton)
					_info = "Wpisz '1', '2' lub '3'.";

				return _info;
			}
			set
			{

				NotifyOfPropertyChange(() => Info);
				NotifyOfPropertyChange(() => CanPlay);
			}
		}

		// Text Box na wprowadzanie wartosci liczbowych, badz tekstowych do poszczegolnych gier
		public string InputBox
		{
			get { return _inputBox; }
			set
			{
				_inputBox = value;

				NotifyOfPropertyChange(() => InputBox);
				NotifyOfPropertyChange(() => CanPlay);
			}
		}

		// Ta wlasciwosc nie jest polaczona bezposrednio z widokiem. Sluzy tylko do posredniczenia w zamianie wartosci z powyzszego
		// InputBoxa na liczby badz stringi
		public int InputBoxToNumber
		{
			get
			{
				var input = InputBox;
				int result;
				if (String.IsNullOrEmpty(input))
				{
					return 0;
				}

				else if (int.TryParse(input, out result))
				{
					return result;
				}

				return 0;
			}
		}

		// Radio buttony, w zależności od ich wartośći możemy zagrać w daną grę
		public bool OddButton
		{
			get { return _oddButton; }
			set
			{
				_oddButton = value;
				InputBox = "";

				NotifyOfPropertyChange(() => OddButton);
				NotifyOfPropertyChange(() => Info);
				NotifyOfPropertyChange(() => CanPlay);
			}
		}

		public bool NumberButton
		{
			get { return _numberButton; }
			set
			{
				_numberButton = value;
				InputBox = "";

				NotifyOfPropertyChange(() => NumberButton);
				NotifyOfPropertyChange(() => Info);
				NotifyOfPropertyChange(() => CanPlay);
			}
		}

		public bool ColorButton
		{
			get { return _colorButton; }
			set
			{
				_colorButton = value;
				InputBox = "";

				NotifyOfPropertyChange(() => ColorButton);
				NotifyOfPropertyChange(() => Info);
				NotifyOfPropertyChange(() => CanPlay);
			}
		}
		public bool HalfButton
		{
			get { return _halfButton; }
			set
			{
				_halfButton = value;

				NotifyOfPropertyChange(() => HalfButton);
				NotifyOfPropertyChange(() => Info);
				NotifyOfPropertyChange(() => CanPlay);
			}
		}

		public bool ThirdButton
		{
			get { return _thirdButton; }
			set
			{
				_thirdButton = value;

				NotifyOfPropertyChange(() => ThirdButton);
				NotifyOfPropertyChange(() => Info);
				NotifyOfPropertyChange(() => CanPlay);
			}
		}

		public bool ColumnButton
		{
			get { return _columnButton; }
			set
			{
				_columnButton = value;

				NotifyOfPropertyChange(() => ColumnButton);
				NotifyOfPropertyChange(() => Info);
				NotifyOfPropertyChange(() => CanPlay);
			}
		}

		// Sprawdza, czy można zagrać, czyli naciśnąć przycisk zbindowany w widoku z nazwą "Play"
		public bool CanPlay
		{
			get
			{
				bool output = false;


				if (BetStake > 0 && !(BetStake > 300))
				{
					if (OddButton && (InputBox == "parzyste" || InputBox == "nieparzyste"))
					{
						output = true;
					}

					else if (ColorButton && (InputBox == "czarne" || InputBox == "czerwone"))
					{
						output = true;
					}

					else if (NumberButton && (InputBoxToNumber >= 0 && InputBoxToNumber <= 36))
					{
						output = true;
					}

					else if (HalfButton && (InputBox == "1" || InputBox == "2"))
					{
						output = true;
					}

					else if (ThirdButton && (InputBox == "1" || InputBox == "2" || InputBox == "3"))
					{
						output = true;
					}

					else if (NumberButton && (InputBoxToNumber >= 0 && InputBoxToNumber <= 36))

					{
						output = true;
					}

					BetInfo = "";
				}
				else if (BetStake <= 0)
				{
					BetInfo = "Możesz stawiać kwoty w przedziale 0-300";
				}

				return output;
			}
		}

		// Funkcja uruchamia się po naciśnięciu przycisku "Graj"
		public void Play()
		{
			Console.WriteLine($"Play { BetStake }");

			rouletteLogic.RandomNumber();
			if (NumberButton) _winStake = rouletteLogic.ComputeNumber(BetStake, InputBoxToNumber);
			if (OddButton) _winStake = rouletteLogic.ComputeOdd(BetStake, InputBox);
			if (ColorButton) _winStake = rouletteLogic.ComputeColor(BetStake, InputBox);
			if (HalfButton) _winStake = rouletteLogic.ComputeHalf(BetStake, InputBox);
			if (ThirdButton) _winStake = rouletteLogic.ComputeThird(BetStake, InputBox);
			if (ColumnButton) _winStake = rouletteLogic.ComputeColumn(BetStake, InputBox);

			Console.WriteLine($"{ _winStake }");
			MessageBox.Show($"Wypadło {rouletteLogic.RandomlyChosen}\nWygrałeś { _winStake }");

		}
	}
}
