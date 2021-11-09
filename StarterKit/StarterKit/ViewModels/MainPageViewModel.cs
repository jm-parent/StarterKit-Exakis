using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TinyMvvm;

namespace StarterKit.ViewModels
{
	public class MainPageViewModel : ViewModelBase
	{
		public string LabelText { get; set; } = "DefaultText";

		private ICommand home;
		public ICommand UpdateTextCommand => home ?? new TinyCommand(async () =>
		{
			LabelText += "X";

		});
	}
}
