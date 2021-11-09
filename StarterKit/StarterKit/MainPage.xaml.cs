using StarterKit.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StarterKit
{
	public partial class MainPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		async void Button_Clicked(object sender, EventArgs e)
		{
				await Navigation.PushAsync(new View1());
		}
		async void ButtonUpdateText_Clicked(object sender, EventArgs e)
		{

		}
	}
}
