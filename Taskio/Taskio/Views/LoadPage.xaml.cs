using System;
using System.Collections.Generic;
using Taskio.Helpers;
using Taskio.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;

namespace Taskio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadPage : ContentPage
    {
        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; }
        }
        private IList<string> PathList = new List<string>();
        public ViewModelForSwipe _viewModel;
        
        
        public LoadPage(IDictionary<string, string> pics)
        {
            InitializeComponent();
            foreach (KeyValuePair<string, string> PhotoPath in pics)
            {
              
                    PathList.Add(PhotoPath.Value);
            }
            var children = MainPage.Children;
            Controls.Children.ToList().ForEach(x => children.Add(x));
            _viewModel = new ViewModelForSwipe(PathList,children);
            BindingContext = _viewModel;
            foreach(string str in PathList)
            {
                SwipeViewContentHelperView l1 = new SwipeViewContentHelperView(str,_viewModel);
                Frame f1 = new Frame { WidthRequest = 50, HeightRequest = 50, BorderColor = Color.Azure, BackgroundColor = Color.CornflowerBlue };
                f1.Content = l1;
               
                MainStack.Children.Add(f1);
            }
            ScrollView.Scrolled += ScrollView_Scrolled;
        }

        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            ScrollCoOrdiantes.Text = e.ScrollY.ToString();
        }

        private Action<object> async()
        {
            throw new NotImplementedException();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        private void ClickBtn_Clicked(object sender, EventArgs e)
        {
            App.GlobalNavigation.PushAsync(new ImagePickerPage());
        }

        private void ClickBtn1_Clicked(object sender, EventArgs e)
        {
            App.GlobalNavigation.PushAsync(new ToolTipTest());
        }
        private async void GoToLast(object sender, EventArgs e)
        {
            await ScrollView.ScrollToAsync(MainStack, ScrollToPosition.End, true);
        }
        private async void BudgetCalculatorClicked(object sender, EventArgs e)
        {
            await App.GlobalNavigation.PushAsync(new BudgetCalculatorView());
        }

        private async void StepSliderTest_Clicked(object sender, EventArgs e) 
        {
            await App.GlobalNavigation.PushAsync(new SliderTestPage());
        }
    }
}