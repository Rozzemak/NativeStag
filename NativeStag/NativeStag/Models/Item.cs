using System;
using Android;
using Android.Graphics;

namespace NativeStag.Models
{
    public enum TodoType
    {
        Basic,
        Important,
        Indifferent,
        Hidden,
    }

    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime? Completed { get; set; }
        public TodoType TodoType { get; set; }

        public DateTime? MinimumDate = DateTime.Now;
        public Xamarin.Forms.Color Color => GetItemColor(TodoType);

        private Xamarin.Forms.Color GetItemColor(TodoType todoType)
        {
            switch (todoType)
            {
                case TodoType.Important:
                    return Xamarin.Forms.Color.LightCoral;
                case TodoType.Basic:
                    return Xamarin.Forms.Color.White; 
                case TodoType.Indifferent:
                    return Xamarin.Forms.Color.WhiteSmoke;
                case TodoType.Hidden:
                    return Xamarin.Forms.Color.Transparent;
                default:
                    return Xamarin.Forms.Color.White;
            }
        }
    }
}