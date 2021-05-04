using BillManager.Dal;
using BillManager.Dal.Models;
using BillManager.Dal.ViewModels;
using BillManager.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BillManager.Views
{
    public partial class NewBillItemPage : ContentPage
    {
        public Bills Item { get; set; }
        private BillManagerDB db;
        public NewBillItemPage()
        {
            InitializeComponent();
            BindingContext = new BillDetailViewModel();
            db = new BillManagerDB();
            Setup();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            Bills bill = new Bills();
            bill.Description = txtDescription.Text;
            bill.Startdate = billStartDate.Date;
            bill.EndDate = billEndDate.Date;
            bill.isActive = true;
            bill.isDeleted = false;
            await db.SaveBillItem(bill);
            await DisplayAlert("Bill Saved", "Your build details have been saved.", "OK");
            await Shell.Current.GoToAsync("..");

        }

        private async  void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("BillsPage");
        }
        public void Setup()
        {

            List<BillOccuranceTypeViewModel> billOccuranceType = new List<BillOccuranceTypeViewModel>();
            billOccuranceType = new List<BillOccuranceTypeViewModel>()
            {
                  new BillOccuranceTypeViewModel {Description="Once",Type=1},
                  new BillOccuranceTypeViewModel { Description="Never",Type=2},
                  new BillOccuranceTypeViewModel { Description="Weekly",Type=3},
                  new BillOccuranceTypeViewModel { Description="Monthly",Type=4},
                  new BillOccuranceTypeViewModel { Description="Yearly",Type=5},
                  new BillOccuranceTypeViewModel { Description="Quartley",Type=6},

            };
            cboOccourances.DataSource = billOccuranceType;
        }     
    }
    }