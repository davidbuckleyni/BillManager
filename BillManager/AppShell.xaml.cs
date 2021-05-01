using BillManager.ViewModels;
using BillManager.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BillManager
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(BillsDetailPage), typeof(BillsDetailPage));
            Routing.RegisterRoute(nameof(NewBillItemPage), typeof(NewBillItemPage));
            Routing.RegisterRoute(nameof(BillsPage), typeof(BillsPage));
       }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
