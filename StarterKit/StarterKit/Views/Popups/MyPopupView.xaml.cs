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
			b.Add(0, 1, new Animation(v => this.Opacity = v, 0, 1));
			b.Commit(
				 owner: ThePopup,
				 name: "show",
				 length: 1200);
		}
		void Button_Clicked(System.Object sender, System.EventArgs e)
		{
			Dismiss(null);
		}
	}
}