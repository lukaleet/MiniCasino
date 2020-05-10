using Caliburn.Micro;
using Casino.Slots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUI.ViewModels
{
    public class SlotsViewModel : Screen
	{
		// TODO WRZUCIC DI NAWET W ZWYKLE KLASY SPOZA PROJEKTU
		SlotsLogic slotsLogic = new SlotsLogic();

		private decimal _betStake;
		private string _betInfo;
		// tymczasowe pole
		private decimal _winStake;

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
		}
	}
}