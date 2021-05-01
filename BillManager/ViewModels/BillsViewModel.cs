using BillManager.Dal.Models;
using BillManager.Dal.ViewModels;
using BillManager.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BillManager.ViewModels
{
    public class BillsViewModel : BaseViewModel
    {
        private Bills _selectedItem;

        public ObservableCollection<Bills> Bills { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Bills> ItemTapped { get; }

        public BillsViewModel()
        {
            Title = "Browse";
            Bills = new ObservableCollection<Bills>();

           

        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Bills.Clear();
                var items = await DataStore.GetBillsAsync(true);
                foreach (var item in items)
                {
                    Bills.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Bills SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

       

        async void OnItemSelected(Bills item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(BillsDetailPage)}?{nameof(BillDetailViewModel.ItemId)}={item.Id}");
        }
    }
}