using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUI.ViewModels
{
	public class RouletteViewModel : Screen
	{
		private decimal _betStake;
		private string _inputBox;

		private string _info;
		private string _betInfo;

		private decimal _winStake;

		private bool _oddButton;
		private bool _numberButton;
		private bool _colorButton;

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

				return _info; 
			}
			set
			{

				NotifyOfPropertyChange(() => Info);
				NotifyOfPropertyChange(() => CanPlay);
			}
		}


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

		public bool CanPlay
		{
			get
			{
				bool output = false;

				if (BetStake > 0 && !(BetStake >= 300))
				{
					if (OddButton && (InputBox == "parzyste" || InputBox == "nieparzyste"))
					{
						output = true;
					}

					else if (ColorButton && (InputBox == "czarne" || InputBox == "czerwone"))
					{
						output = true;
					}

					else if (NumberButton && (InputBoxToNumber >= 0  && InputBoxToNumber <= 36))
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

		public void Play() 
		{ 
		}
	}
}
