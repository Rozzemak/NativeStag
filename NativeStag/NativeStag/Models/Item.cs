using System;

namespace NativeStag.Models
{
    public enum TodoType
    {
        Important,
        Basic,
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
    }
}