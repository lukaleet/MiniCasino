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
		private HelpViewModel _helpVM;

		public ShellViewModel(SlotsViewModel slotsVM, HelpViewModel helpVM)
		{
			_slotsVM = slotsVM;
			_helpVM = helpVM;
			ActivateItem(_helpVM);
		}

		public void SlotsScreen()
		{
			ActivateItem(_slotsVM);
		}

		public void RouletteScreen() { }

		public void BlackJackScreen() { }

		public void HelpScreen() 
		{
			ActivateItem(_helpVM);
		}

	}
}
