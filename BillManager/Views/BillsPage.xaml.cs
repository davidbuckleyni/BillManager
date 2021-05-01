
using BillManager.Dal;
using BillManager.Dal.Models;
using BillManager.Services;
using BillManager.ViewModels;
using BillManager.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BillManager.Views
{
    public partial class BillsPage : ContentPage
    {
        List<Bills> bills = new List<Bills>();
        private BillManagerDB db;

        public BillsPage()
        {
            InitializeComponent();
            db = new BillManagerDB();

            Setup();
            
        }

        private async void Setup()
        {
            string startDate = "28/04/2021";
            DateTime startDateParse = DateTime.ParseExact(startDate, "dd/MM/yyyy", null);


            bills =await db.GetAllBills();
            listView.ItemsSource = bills;

            
            listView.ItemsSource = bills;
            billCalendar.SelectedDate = DateTime.Now;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
             
        }
        private void btnclearTestData_Clicked(object sender, EventArgs e)
        {

            db.DeleteAllTestDataAsync();

        }
        private async void btnAddBill_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("NewBillItemPage");

        }

        private void billCalendar_OnCalendarTapped(object sender, Syncfusion.SfCalendar.XForms.CalendarTappedEventArgs e)
        {
            var tappedDate = e.DateTime;
            IsBusy = true;
            listView.ItemsSource= bills.Where(x => x.Startdate == tappedDate).ToList();
            IsBusy = false; 
            
            

        }

  
        private void billRefresh_Refreshing(object sender, EventArgs e)
        {
            IsBusy = true;
            listView.ItemsSource = bills.ToList();
            IsBusy = false;

        }
    }
}