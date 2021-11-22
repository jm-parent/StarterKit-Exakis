using StarterKit.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using TinyMvvm;
using Xamarin.CommunityToolkit.ObjectModel;

namespace StarterKit.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableRangeCollection<string> Names { get; set; }

        public async override Task Initialize()
        {
            IsBusy = true;

            Names = new ObservableRangeCollection<string>(new List<string>()
            {
                "Daniel",
                "Ella",
                "Willner"
            });

            await base.Initialize();

        

            IsBusy = false;
        }

        public override Task OnAppearing()
        {
            return base.OnAppearing();
        }

        public override Task OnDisappearing()
        {
            return base.OnDisappearing();
        }

        public ICommand Details =>  new TinyCommand<string>(async (name) =>
        {
            await Navigation.NavigateToAsync($"{nameof(DetailsViewModel)}?name={name}", DateTimeOffset.Now);
        });

        public bool IsRefreshing { get; set; }
        public ICommand RefreshCommand => new TinyCommand(async () =>
        {
            // Stop refreshing
            IsRefreshing = true;
            Names.Clear();

            Names.AddRange(new List<string>()
            {
                "Daniel",
                "Ella",
                "Willner"
            });

            // Stop refreshing
            IsRefreshing = false;
        });


        public ICommand Login => new TinyCommand(async () =>
        {
            await Navigation.NavigateToAsync("//LoginView");
        });
    }
}
