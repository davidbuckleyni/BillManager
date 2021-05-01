using BillManager.Services;
using BillManager.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BillManager
{
    public partial class App : Application
    {

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDM4NTU5QDMxMzkyZTMxMmUzMG5vdVU4Y2dwWGd6YzZmOHI4NGZiUy9jbWtmbTUyYkJrUGhNc1ZyMFZzWXc9");

            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
            
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
