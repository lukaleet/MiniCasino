using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUI.ViewModels
{
	public class ShellViewModel : Conductor<object>
	{
		// Tu wszystko się zaczyna
		private SlotsViewModel _slotsVM;
		private RouletteViewModel _rouletteVM;
		private BlackjackViewModel _blackjackVM;
		private HelpViewModel _helpVM;

		// Prywatne pola poszczególnych modeli widoków są przekazywane w konstruktorze
		// Widokiem domyślnym jest widok z pomocą
		public ShellViewModel(SlotsViewModel slotsVM, RouletteViewModel rouletteVM, BlackjackViewModel blackjackVM, HelpViewModel helpVM)
		{
			_slotsVM = slotsVM;
			_rouletteVM = rouletteVM;
			_blackjackVM = blackjackVM;
			_helpVM = helpVM;
			ActivateItem(_helpVM);
		}

		// Tu wszystko niżej to mechanizmy przełączania na poszczególne widoki (przekazane wcześniej w konstruktorze)
		public void SlotsScreen()
		{
			ActivateItem(_slotsVM);
		}

		public void RouletteScreen() 
		{
			ActivateItem(_rouletteVM);
		}

		public void BlackJackScreen() 
		{
			ActivateItem(_blackjackVM);
		}

		public void HelpScreen() 
		{
			ActivateItem(_helpVM);
		}

	}
}
