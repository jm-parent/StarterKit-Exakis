using StarterKit.Services;
using StarterKit.Services.Base;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TinyIoC;
using TinyMvvm;

namespace StarterKit.ViewModels
{
    public class DetailsViewModel : ViewModelBase
    {
        public async override Task Initialize()
        {
            await base.Initialize();

            Name = QueryParameters["name"];
            var dateParameter = (DateTimeOffset)NavigationParameter;

            Date = dateParameter.ToString();
        }

        public string Name { get; set; }
        public string Date { get; set; }


        public string LabelValue { get; set; }

        public ICommand UpdateLabel => new TinyCommand(() =>
        {
            var myDataService = TinyIoCContainer.Current.Resolve<IMyDataService>();
            LabelValue = myDataService.GetMessage() ;

        });
    }
}
