using System;
using Microsoft.Extensions.DependencyInjection;
using Spectrum.Mobile.Services;
using Spectrum.Mobile.ViewModels;
using Spectrum.Mobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Spectrum.Mobile
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public App()
        {
            InitializeComponent();

            SetupServices();
            
            MainPage = new UserPage();
        }
        
        private void SetupServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<ISpectrumService, SpectrumService>();
            
            services.AddTransient<UserPageViewModel>();
            services.AddTransient<PostPageViewModel>();

            ServiceProvider = services.BuildServiceProvider();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}