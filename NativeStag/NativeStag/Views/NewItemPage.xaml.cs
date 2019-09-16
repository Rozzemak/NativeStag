using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NativeStag.Models;

namespace NativeStag.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Item
            {
                Id = Guid.NewGuid().ToString(),
                Text = "",
                Description = "",
                MinimumDate = DateTime.Now,
                Deadline = DateTime.Now.AddDays(1),
            };
            TypePicker.ItemsSource = new List<TodoType>(){ TodoType.Basic, TodoType.Important, TodoType.Indifferent, TodoType.Hidden, };
            TypePicker.SelectedIndexChanged += TypePickerOnSelectedIndexChanged;
            BindingContext = this;
        }

        private void TypePickerOnSelectedIndexChanged(object sender, EventArgs e)
        {
            Item.TodoType = (TodoType) TypePicker.SelectedItem;
        }

        void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddTodo", Item);
            Navigation.PopModalAsync();
        }

        void Cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync().ConfigureAwait(false);
        }
    }
}