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
			Opened += MyPopupView_Opened;
		}

		private void MyPopupView_Opened(object sender, PopupOpenedEventArgs e)
		{

			Animation b = new Animation();
			b.Add(0, 0.7, new Animation(v => this.Opacity = v, 0, 1));

			//Popup scale animation
			b.Add(0, 0.5, new Animation(v => TheContent.Margin = v, 150,0));

			//From x:Name="Button" FontSize="1" 
			b.Add(0.5, 1, new Animation(v => TheLabel.FontSize = v, 1, 16));
			b.Add(0.5, 1, new Animation(v => TheButton.FontSize = v, 1, 16));

			b.Add(0, 0.5, new Animation(v => TheButton.HeightRequest = v, 0, 0));
			b.Add(0.5, 1, new Animation(v => TheButton.HeightRequest = v, 0, 50));


			b.Commit(
				 owner: ThePopup,
				 name: "show",
				 length: 1000);
		}
		void Button_Clicked(System.Object sender, System.EventArgs e)
		{
			Dismiss(null);
		}
	}
}