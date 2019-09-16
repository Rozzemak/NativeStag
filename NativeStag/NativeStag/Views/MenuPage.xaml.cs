using NativeStag.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NativeStag.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        private MainPage RootPage => Application.Current.MainPage as MainPage;

        private readonly List<HomeMenuItem> _menuItems;

        public MenuPage()
        {
            InitializeComponent();

            _menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Assignments, Title = "Todo", Location = MenuLocation.Top},
                //new HomeMenuItem {Id = MenuItemType.About, Title = "About", Location = MenuLocation.Top},
                new HomeMenuItem {Id = MenuItemType.About, Title = "About", Location = MenuLocation.Bottom},
                new HomeMenuItem {Id = MenuItemType.Logout, Title = "Logout", Location = MenuLocation.Bottom},
            };

            ListViewTopMenu.ItemsSource = _menuItems.Where(item => item.Location == MenuLocation.Top);
            ListViewBottomMenu.ItemsSource = _menuItems.Where(item => item.Location == MenuLocation.Bottom);
            
            //todo: check for user login => then make selected logout
            ListViewTopMenu.SelectedItem = _menuItems.FirstOrDefault(item => item.Id == MenuItemType.Assignments);
            ListViewTopMenu.ItemTapped += ListItemTapped;
            ListViewBottomMenu.ItemTapped += ListItemTapped;
            var height = FlexViewBottomMenu.Children.FirstOrDefault()?.Height;
            if (height != null)
                FlexViewBottomMenu.HeightRequest = 110 * _menuItems.Count(item => item.Location == MenuLocation.Bottom);

        }

        private async void ListItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e?.Item == null)
                return;

            var id = (int) ((HomeMenuItem) e?.Item)?.Id;
            await RootPage.NavigateFromMenuAsync(id).ConfigureAwait(false);
        }
    }
}