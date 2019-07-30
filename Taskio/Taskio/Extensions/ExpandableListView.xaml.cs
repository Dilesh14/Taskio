using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Taskio.Extensions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpandableListView : ContentView
    {
        public IEnumerable<object> ExpandableContent { get; set; }
        public string HeaderText { get; set; } = "Header";
        public string Button { get; set; } = "X";
        private bool IsExpanded;
        private bool IsExpanding;
        public ExpandableListView(IEnumerable<object> items)
        {
            InitializeComponent();
            ContentLayout.HeightRequest = 0;
            ExpandableContent = items;
            OnPropertyChanged("ExpandableContent");
            OnPropertyChanged("HeaderText");
            OnPropertyChanged("Button");
            AddHeader();
            AddContent();
        }
        private void AddHeader()
        {
            OnPropertyChanged("HeaderText");
            OnPropertyChanged("Button");
            ExpanadableListElement HeadName = new ExpanadableListElement { Display = HeaderText, Button = Button };
            Header.Children.Add(HeadName);
            Header.Children.Add
                (
                    new BoxView
                    {
                        HeightRequest = 1,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        BackgroundColor = Color.Black
                    }
                ); ;
        }
        private void AddContent()
        {
            foreach (string item in ExpandableContent)
            {
                Content.Children.Add
                    (new ExpanadableListElement
                    {
                        Display = item,
                        Button = "-"
                    }
                    );
                Content.Children.Add
                    (
                        new BoxView
                        {
                            HeightRequest = 1,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            BackgroundColor = Color.Black
                        }
                    );
            }
        }
        private async void HeaderTapped(object sender, EventArgs e)
        {
            ExpanadableListElement child = new ExpanadableListElement();
            StackLayout comingfrom = sender as StackLayout;
            if(comingfrom.Children.Any(x=>x is ExpanadableListElement))
            {
                child = (ExpanadableListElement)comingfrom.Children.Where(x => x is ExpanadableListElement).ToList().First();
            }
            var height = Content.Height;
            if (!IsExpanding)
            {
                if (IsExpanded)
                {
                    IsExpanded = false;
                    ContentLayout.HeightRequest = 0;
                    ContentLayout.Opacity = 0;
                    comingfrom.BackgroundColor = Color.White;
                    ContentLayout.IsVisible = false;
                }
                else
                {
                    ContentLayout.HeightRequest = height;
                    ContentLayout.Opacity = 1;
                    ContentLayout.IsVisible = true;
                    comingfrom.BackgroundColor = Color.Gray;
                    IsExpanded = true;
                    child.Button = ">";
                    OnPropertyChanged("Button");
                }
            }
        }
    }
}