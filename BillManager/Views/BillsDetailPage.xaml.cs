using BillManager.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace BillManager.Views
{
    public partial class BillsDetailPage : ContentPage
    {
        public BillsDetailPage()
        {
            InitializeComponent();
            BindingContext = new BillDetailViewModel();
        }
    }
}