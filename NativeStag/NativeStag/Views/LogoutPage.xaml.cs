using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NativeStag.Models;
using NativeStag.Models.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NativeStag.Views
{
    public sealed partial class LogoutPage : ContentPage
    {
        
        public LogoutPage()
        {
            InitializeComponent();
            Application.Current.MainPage = this;
            Logout();
        }

        private void Logout()
        {
            Application.Current.MainPage = new LoginPage();
        }
    }
}