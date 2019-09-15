using System;
using System.Collections.Generic;
using System.Text;

namespace NativeStag.Models.Auth
{
    public enum LoginItemType
    {
        UserName,
        Password
    }
    public class Login
    {
        public LoginItemType Id { get; set; }

        public string Placeholder { get; set; }
    }
}
