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
        public ObservableCollection<BillTypes> BillTypes { get; }

        public ObservableCollection<Bills> Bills { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Bills> ItemTapped { get; }

        public BillsViewModel()
        {
            Title = "Browse";
            Bills = new ObservableCollection<Bills>();
            BillTypes = new ObservableCollection<BillTypes>();
            loadBillTypes();

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


        private void loadBillTypes()
        {
            BillTypes.Add(new BillTypes()
            {
                Name = "Car Insurnace",
                Image = "mic.png",
                Selected = true,
                BackgroundColor = "#FCCD00",
                textColor = "#000000"
            });

            BillTypes.Add(new BillTypes()
            {
                Name = "House Hold Bills",
                Image = "ping_pong.png",
                BackgroundColor = "#29404E",
                textColor = "#FFFFFF"
            });

            BillTypes.Add(new BillTypes()
            {
                Name = "Telecomes",
                Image = "graduation.png",
                BackgroundColor = "#29404E",
                textColor = "#FFFFFF"
            });
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