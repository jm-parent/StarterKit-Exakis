using Autofac;
using StarterKit.Services;
using StarterKit.Services.Base;
using System;
using System.Reflection;
using TinyIoC;
using TinyMvvm;
using TinyMvvm.Autofac;
using TinyMvvm.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StarterKit
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			RegisterServices(TinyIoCContainer.Current);
			InitTinyMvvm();

			MainPage = new AppShell();
		}

		private void InitTinyMvvm()
		{
			//Setup View/ViewModel Links
			var navigationHelper = new ShellNavigationHelper();

			var currentAssembly = Assembly.GetExecutingAssembly();

			navigationHelper.InitViewModelNavigation(currentAssembly);

			var containerBuilder = new ContainerBuilder();

			containerBuilder.RegisterInstance<INavigationHelper>(navigationHelper);

			var appAssembly = typeof(App).GetTypeInfo().Assembly;

			containerBuilder.RegisterAssemblyTypes(appAssembly)
				   .Where(x => x.IsSubclassOf(typeof(Page)));

			containerBuilder.RegisterAssemblyTypes(appAssembly)
				   .Where(x => x.IsSubclassOf(typeof(ViewModelBase)));

			var container = containerBuilder.Build();
			
			Resolver.SetResolver(new AutofacResolver(container));

			MainPage = new AppShell();
		}
		private void RegisterServices(TinyIoCContainer container)
		{
			container.Register<IMyDataService, MyDataService>();
		}
		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
