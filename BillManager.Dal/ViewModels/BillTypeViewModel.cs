using BillManager.Dal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace BillManager.Dal.ViewModels
{
    public class BillTypeViewModel : BaseViewModel
    {
        public Command SelectDateCommand { get; }
        public Command SelectBillTypeCommand { get; }
        public ObservableCollection<BillTypes> BillTypes { get; }

        private BillTypes _selectedBillType;
        public BillTypes SelectedBillType
        {
            get => _selectedBillType;
            set => SetProperty(ref _selectedBillType, value);
        }

        public BillTypeViewModel(INavigation navigation)
        {
            Navigation = navigation;

            BillTypes = new ObservableCollection<BillTypes>();

            LoadBillTypes();
        }

        private void LoadBillTypes()
        {
            BillTypes.Add(new BillTypes()
            {
                Name = "Concert",
                Image = "mic.png",
                Selected = true,
                BackgroundColor = "#FCCD00",
                textColor = "#000000"
            });

            BillTypes.Add(new BillTypes()
            {
                Name = "Sports",
                Image = "ping_pong.png",
                BackgroundColor = "#29404E",
                textColor = "#FFFFFF"
            });

            BillTypes.Add(new BillTypes()
            {
                Name = "Education",
                Image = "graduation.png",
                BackgroundColor = "#29404E",
                textColor = "#FFFFFF"
            });
        }
     

    }
}
