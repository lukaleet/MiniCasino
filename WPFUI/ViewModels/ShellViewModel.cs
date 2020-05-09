using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
	public class ShellViewModel : Conductor<object>
	{
		//private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
		private SlotsViewModel _slotsVM;
		private 


		public ShellViewModel(SlotsViewModel slotsVM)
		{
			_slotsVM = slotsVM;
		}

		public void SlotsButton()
		{

		}
	}
}
