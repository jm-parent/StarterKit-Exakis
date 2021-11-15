using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace StarterKit.Views.Popups
{
	public partial class MyPopupView
	{
		public MyPopupView()
		{
			InitializeComponent();
			Opened += MyPopupView_OpenedAsync;
		}

		private void MyPopupView_OpenedAsync(object sender, PopupOpenedEventArgs e)
		{
			Task.Run(() =>
			{
				Animation b = new Animation();
				b.Add(0, 1, new Animation(v => this.Opacity = v, 0, 1));
				b.Commit(
					 owner: ThePopup,
					 name: "show",
					 length: 1200);
			});
			
		}

	
		//private void MyPopupView_SizeChanged(object sender, EventArgs e)
		//{

		//}

		//private void ThePopup_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		//{
		//	if(e.PropertyName == nameof(IsVisible))
		//	{
		//		ThePopup.FadeTo(0, 1);
		//		ThePopup.FadeTo(1, 3000);
		//	}
		//}

		void Button_Clicked(System.Object sender, System.EventArgs e)
		{
			Dismiss(null);
		}
	
	}
}