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
    public partial class LoginPage
    {
        MainPage RootPage => Application.Current.MainPage as MainPage;
        private readonly List<Login> _loginFormItems = new List<Login>();
        public LoginPage()
        {
            InitializeComponent();
            Application.Current.MainPage = this;
            
            UserNameEntry.BindingContext = new Login
                {Id = LoginItemType.UserName, Placeholder = "Username/Email", IsPassword = false};
            PasswordEntry.BindingContext = new Login
                {Id = LoginItemType.Password, Placeholder = "Password", IsPassword = true};

        }
    }
}