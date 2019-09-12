using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Taskio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToolTipTest : ContentPage
    {
        Forms9Patch.BubblePopup _toolBar;
        IList<View> _labels = new List<View>();
        int _index;
        public ToolTipTest()
        {
            InitializeComponent();
            MainStack.Children.ToList().ForEach(x =>
            {
                _labels.Add(x);
            });
            var footer = Footer.Content as StackLayout;
            if (footer != null)
            {
                footer.Children.ToList().ForEach(x => 
                {
                    _labels.Add(x);
                });
            }
        }
        void StartToolBar(int i)
        {
            if(i >= _labels.Count)
            {
                _index = 0;
                return;
            }
            Button btn = new Button
            {
                Text = "Next",
            };
            btn.Clicked += NextItem;
            var view = _labels[i];
            var tooltip = new Forms9Patch.BubblePopup(view)
            {
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Children =
                    {
                        new Label{Text="This is view"},
                        btn
                    }
                },
                PointerDirection = Forms9Patch.PointerDirection.Any,
                PointerCornerRadius = 5,
                PointerTipRadius = 8,
                PointerLength =15,
                IsVisible = true,
                CloseWhenBackgroundIsClicked = false
            };
            _toolBar = tooltip;
            _index++;
        }
        private void NextItem(object sender, EventArgs e)
        {
            _toolBar.IsVisible = false;
            StartToolBar(_index);
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            StartToolBar(0);
        }
    }
}