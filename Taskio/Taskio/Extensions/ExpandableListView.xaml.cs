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
        public ExpandableListView()
        {
            InitializeComponent();
            ContentLayout.HeightRequest = 0;
            AddHeader();
            AddContent();

        }
        private void AddHeader()
        {
            ExpanadableListElement HeadName = new ExpanadableListElement { Display = HeaderText, Button = Button };
            Header.Children.Add(HeadName);
            Header.Children.Add
                (
                    new BoxView
                    {
                        HeightRequest = 1,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    }
                );
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
            }
            Content.Children.Add
                (
                    new BoxView
                    {
                        HeightRequest = 1,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    }
                );
        }
        private async void HeaderTapped(object sender, EventArgs e)
        {
            var height = Content.Height; 
            if (!IsExpanding)
            {
                if (IsExpanded)
                {
                    IsExpanded = false;
                    ContentLayout.HeightRequest = 0;
                }
                else
                {
                    ContentLayout.HeightRequest = height;
                    IsExpanded = true;
                }
            }
        }
    }
}