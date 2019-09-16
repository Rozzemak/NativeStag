using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NativeStag.Models;
using NativeStag.Views;
using NativeStag.ViewModels;
using Color = Android.Graphics.Color;

namespace NativeStag.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is Item item))
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item))).ConfigureAwait(false);

            // Manually deselect item.
            Device.BeginInvokeOnMainThread(() =>
            {
                ItemsListView.SelectedItem = null;
            });
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage())).ConfigureAwait(false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);

            // Little hack to enforce item re-render. IObservable will not catch this.
            ItemsListView.BeginRefresh();
            ItemsListView.EndRefresh();
        }

        private void SwipeGestureRecognizer_OnSwiped(object sender, SwipedEventArgs e)
        {
            MessagingCenter.Send(this, "DeleteTodo", viewModel?.Items.FirstOrDefault());
        }
    }
}