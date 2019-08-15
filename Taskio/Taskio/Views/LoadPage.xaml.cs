using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Taskio.Database;
using System.Windows.Input;
using FFImageLoading.Forms;
using Taskio.ViewModel;
using Taskio.Helpers;

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
            _viewModel = new ViewModelForSwipe(PathList);
            BindingContext = _viewModel;
            foreach(string str in PathList)
            {
                SwipeViewContentHelperView l1 = new SwipeViewContentHelperView(str,_viewModel);
                Frame f1 = new Frame { WidthRequest = 50, HeightRequest = 50, BorderColor = Color.Azure, BackgroundColor = Color.CornflowerBlue };
                f1.Content = l1;
               
                MainStack.Children.Add(f1);
            }
        }

        private Action<object> async()
        {
            throw new NotImplementedException();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}