using Autofac;
using System;
using System.Reflection;
using TinyMvvm;
using TinyMvvm.Autofac;
using TinyMvvm.Forms;
using TinyMvvm.IoC;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StarterKit
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			InitServices();


			MainPage = new AppShell();
		}

		private void InitServices()
		{
			var navigationHelper = new ShellNavigationHelper();

			var currentAssembly = Assembly.GetExecutingAssembly();
			navigationHelper.RegisterViewsInAssembly(currentAssembly);

			var containerBuilder = new ContainerBuilder();

			containerBuilder.RegisterInstance<INavigationHelper>(navigationHelper);

			var appAssembly = typeof(App).GetTypeInfo().Assembly;
			containerBuilder.RegisterAssemblyTypes(appAssembly)
				   .Where(x => x.IsSubclassOf(typeof(Page)));

			containerBuilder.RegisterAssemblyTypes(appAssembly)
				   .Where(x => x.IsSubclassOf(typeof(ViewModelBase)));

			var container = containerBuilder.Build();

			Resolver.SetResolver(new AutofacResolver(container));
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
