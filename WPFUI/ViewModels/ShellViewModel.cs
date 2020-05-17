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
		private SlotsViewModel _slotsVM;
		private RouletteViewModel _rouletteVM;
		private BlackjackViewModel _blackjackVM;
		private HelpViewModel _helpVM;

		public ShellViewModel(SlotsViewModel slotsVM, RouletteViewModel rouletteVM, BlackjackViewModel blackjackVM, HelpViewModel helpVM)
		{
			_slotsVM = slotsVM;
			_rouletteVM = rouletteVM;
			_blackjackVM = blackjackVM;
			_helpVM = helpVM;
			ActivateItem(_helpVM);
		}

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
