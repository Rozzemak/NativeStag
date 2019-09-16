using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NativeStag.Models;
using NativeStag.ViewModels;

namespace NativeStag.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            // Default constructor only for debug purposes
            Device.BeginInvokeOnMainThread(() =>
            {
                InitializeComponent();

                var item = new Item
                {
                    Text = "Item",
                    Description = "This is an item description."
                };
                viewModel = new ItemDetailViewModel(item);
                BindingContext = viewModel;
            });
        }

        void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "UpdateTodo", viewModel?.Item);
            Navigation.PopAsync();
        }

        void Delete_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "DeleteTodo", viewModel?.Item);
            Navigation.PopAsync();
        }
    }
}