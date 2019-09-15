using System;
using System.Collections.Generic;
using System.Text;

namespace NativeStag.Models.Auth
{
    public enum LogoutItemType
    {
        Logout
    }
    public class Logout
    {
        public LogoutItemType Id { get; set; }

        public string Placeholder { get; set; }
    }
}
