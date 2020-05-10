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

		public ShellViewModel(SlotsViewModel slotsVM)
		{
			_slotsVM = slotsVM;
			ActivateItem(_slotsVM);
		}

		public void SlotsButton()
		{
			ActivateItem(_slotsVM);
		}
	}
}
