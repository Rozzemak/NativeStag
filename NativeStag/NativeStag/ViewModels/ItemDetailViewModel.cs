using System;

using NativeStag.Models;
using Xamarin.Forms;

namespace NativeStag.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Completed = item?.Completed;
            Deadline = item?.Deadline;
            TodoType = item?.TodoType ?? TodoType.Basic;
            Item = item;
        }
    }
}
