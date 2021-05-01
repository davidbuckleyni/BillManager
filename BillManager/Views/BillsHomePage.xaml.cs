using BillManager.Dal.Models;
using BillManager.Dal.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BillManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BillsHomePage : ContentPage
    {
        public ObservableCollection <BillOccuranceTypeViewModel> BillTypes { get; }
   
        public BillsHomePage()
        {
            InitializeComponent();
            BindingContext = new BillTypeViewModel(Navigation);

        }
    }
}