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
        private IList<View> _viewChildren;
        private int _viewChildIndex = 0; //tooltips
        private Forms9Patch.BubblePopup _popup;
        public event PropertyChangedEventHandler PropertyChanged;
        public Items SelectedItem
        {
            get;
            set;
        }
        public ICommand ToolBarItemClickedCommand { get; set; }
        public ICommand CommandForPushPage { get; set; }
        public ViewModelForSwipe(IList<string> Keys,IList<View>children)
        {
            SetUpItemSource(Keys);
            _viewChildren = children;
            ToolBarItemClickedCommand = new Command(ToolBarItemClicked);
        }

        private void ToolBarItemClicked()
        {
            if(_viewChildIndex >= _viewChildren.Count)
            {
                _viewChildIndex = 0;
                return;
            }
            var btn = new Button { Text = "Next"};
            btn.Clicked += HelpButtonClicked;
            var pop = new Forms9Patch.BubblePopup(_viewChildren[_viewChildIndex])
            {
                PointerLength = 5,
                PointerTipRadius = 0,
                IsVisible = true,
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Children =
                    {
                       new Label{Text = "Help will be added here"},
                       btn
                    }
                }
            };
            _popup = pop;
            _viewChildIndex++;
        }

        private void HelpButtonClicked(object sender, EventArgs e)
        {
            _popup.IsVisible = false;
            ToolBarItemClicked();
        }

        private void SetUpItemSource(IList<string> Keys)
        {
            foreach (string k in Keys)
            {
                ItemSource.Add
                    (
                    new Items { Name = k, Source = k }
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
