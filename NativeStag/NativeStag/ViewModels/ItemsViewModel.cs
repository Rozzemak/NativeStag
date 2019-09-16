using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;

using NativeStag.Models;
using NativeStag.Views;

namespace NativeStag.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Todos";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommandAsync().ConfigureAwait(false));

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddTodo", async (obj, item) =>
            {
                var newItem = item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem).ConfigureAwait(false);
            });

            MessagingCenter.Subscribe<ItemDetailPage, Item>(this, "UpdateTodo", async (obj, item) =>
            {
                var updatedItem = item;
                Items.Remove(Items.FirstOrDefault(item1 => item1.Id.Equals(item.Id)));
                Items.Add(updatedItem);
                await DataStore.UpdateItemAsync(updatedItem).ConfigureAwait(false);
            });

            MessagingCenter.Subscribe<ItemDetailPage, Item>(this, "DeleteTodo", async (obj, item) =>
            {
                Items.Remove(Items.FirstOrDefault(item1 => item1.Id.Equals(item.Id)));
                await DataStore.DeleteItemAsync(item.Id).ConfigureAwait(false);
            });
        }

        async Task ExecuteLoadItemsCommandAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true).ConfigureAwait(false);
                foreach (var item in items)
                {
                    Items.Add(item);
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
    }
}