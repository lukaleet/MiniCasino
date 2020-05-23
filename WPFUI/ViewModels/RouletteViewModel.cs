﻿using Caliburn.Micro;
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
		private string _inputBox = "0";

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

		//public bool CanOddButton 
		//{
		//	get
		//	{
		//		bool output = false;
		//		if (!OddButton) 
		//		{
		//			output = true;
		//		}

		//		return output;
		//	}
		//}

		public bool OddButton
		{
			get { return _oddButton; }
			set
			{
				_oddButton = value;

				NotifyOfPropertyChange(() => OddButton);
				NotifyOfPropertyChange(() => CanPlay);
			}
		}

		public bool NumberButton
		{
			get { return _numberButton; }
			set
			{
				_numberButton = value;

				NotifyOfPropertyChange(() => NumberButton);
				NotifyOfPropertyChange(() => CanPlay);
			}
		}

		public bool ColorButton
		{
			get { return _colorButton; }
			set
			{
				_colorButton = value;

				NotifyOfPropertyChange(() => ColorButton);
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

					else if (NumberButton && (int.Parse(InputBox) >= 0  && int.Parse(InputBox) <= 36))
					{
						output = true;
					}

					//output = true;
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
