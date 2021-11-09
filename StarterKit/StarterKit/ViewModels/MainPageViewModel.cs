using StarterKit.Services;
using StarterKit.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TinyIoC;
using TinyMvvm;

namespace StarterKit.ViewModels
{
	public class MainPageViewModel : ViewModelBase
	{
		public MainPageViewModel()
		{
			_myDataService = TinyIoCContainer.Current.Resolve<IMyDataService>();
		}
		public string LabelText { get; set; } = "DefaultText";

		private ICommand home;
		private readonly IMyDataService _myDataService;

		public ICommand UpdateTextCommand => home ?? new TinyCommand(async () =>
		{
			LabelText += _myDataService.GetMessage();

		});
	}
}
