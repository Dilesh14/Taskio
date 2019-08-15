using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Taskio.Database;
using Taskio.Models;
using Taskio.Views;
using Xamarin.Forms;

namespace Taskio.ViewModel
{
    public class ViewModelForSwipe : INotifyPropertyChanged
    {
        public IList<Items> ItemSource { get; set; } = new List<Items>();
        private int _currentIndex;
        public event PropertyChangedEventHandler PropertyChanged;
        public Items SelectedItem
        {
            get;
            set;
        }
        public ICommand CommandForPushPage { get; set; }
        public ViewModelForSwipe(IList<string> Keys)
        {
            SetUpItemSource(Keys);
        }
        private void SetUpItemSource(IList<string> Keys)
        {
            foreach (string k in Keys)
            {
                ItemSource.Add
                    (
                    new Items { Name = k }
                    );
            }
            CommandForPushPage = new Command(async(name) =>
            {
                SelectedItem = ItemSource.Where(x => x.Name.Equals(name)).First();
                await App.GlobalNavigation.PushAsync(new SwipableView(this));
            });
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //private void ChangeSelectedItem(int curind)
        //{
        //    SelectedItem = ItemSource.ElementAt(curind);
        //}
    }
}
