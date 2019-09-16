using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using NativeStag.Models;
using NativeStag.Services;
using Color = Android.Graphics.Color;

namespace NativeStag.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private IDataStore<Item> dataStore;
        public IDataStore<Item> DataStore
        {
            get => dataStore ?? (dataStore = new MockDataStore());
            set => SetProperty(ref dataStore, value);
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        string title = string.Empty;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        private DateTime? deadline;
        public DateTime? Deadline
        {
            get => deadline;
            set => SetProperty(ref deadline, value);
        }

        private DateTime? completed;
        public DateTime? Completed
        {
            get => completed;
            set => SetProperty(ref completed, value);
        }

        private TodoType todoType;
        public TodoType TodoType
        {
            get => todoType;
            set => SetProperty(ref todoType, value);
        }

        private Xamarin.Forms.Color color;
        public Xamarin.Forms.Color Color
        {
            get => color;
            set => SetProperty(ref color, value);
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
