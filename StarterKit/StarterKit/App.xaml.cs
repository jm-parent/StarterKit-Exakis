using Autofac;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
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

        private void InitAppCenter()
        {
			AppCenter.Start("android=030ff388-c082-4e55-a4b5-05127b9569b0;" +
				   "uwp={Your UWP App secret here};" +
				   "ios=ee80f39e-3131-4631-a9ca-a7483e6effdb;",
				   typeof(Analytics), typeof(Crashes));
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
            #region How To Register with TinyIoc
            // This is a single instance registration.
            // When I ask the container for an IAspectDependency, is will always provide the same GreetingAspect.
            //TinyIoCContainer.Current.Register<IAspectDependency>(new GreetingAspect());

            // This is a concrete type registration.
            // When I ask the container for one of these, it will build me one each time.
            //TinyIoCContainer.Current.Register<GreetingWithDependencyCi>();

            // By default we register concrete types as 
            // multi-instance, and interfaces as singletons
            //TinyIOC.Container.Register<MyConcreteType>(); // Multi-instance
            //TinyIOC.Container.Register<IMyInterface, MyConcreteType>(); // Singleton 

            // Fluent API allows us to change that behaviour
            //TinyIOC.Container.Register<MyConcreteType>().AsSingleton(); // Singleton
            //TinyIOC.Container.Register<IMyInterface, MyConcreteType>().AsMultiInstance(); // Multi-instance
            #endregion

            container.Register<IMyDataService>(new MyDataService());
		}
		protected override void OnStart()
		{
			InitAppCenter();
			
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
