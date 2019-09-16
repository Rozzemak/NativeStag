using System;
using System.Collections.Generic;
using System.Text;

namespace NativeStag.Models
{
    public enum MenuLocation
    {
        Top,
        Bottom
    }
    public enum MenuItemType
    {
        Assignments,
        About,
        Logout,
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public MenuLocation Location { get; set; }

        public string Title { get; set; }
    }
}
