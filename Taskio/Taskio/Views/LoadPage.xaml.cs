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

namespace Taskio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadPage : ContentPage
    {
        public ICommand ClickCommand { get; set; }
        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; }
        }
        public delegate IDictionary<string, string> LoadDevice();
        public LoadDevice LoadPhotos;
        public LoadPage(IDictionary<string,string> pics)
        {
            InitializeComponent();
            Grid.BackgroundColor = Color.FromRgba(0, 48, 125, 1);
            data db = new data();
            db.add();
            int col = 0;
            int i = 0;
            foreach (KeyValuePair<string, string> PhotoPath in pics)
            {
                col = i % 2 == 0 ? 0 : 1;
                //ItemView l1 = new ItemView(db.Funiture[i]);   
                CachedImage image = new CachedImage { Source = PhotoPath.Value, WidthRequest =200,HeightRequest = 200 };
                Grid.Children.Add(image);
                Grid.SetRow(image, i / 2); Grid.SetColumn(image, col);
                i++;
            }
            ClickCommand = new Command(async () =>
            {
                await App.GlobalNavigation.PushAsync(new SwipableView());
            });
            ClickBtn.BindingContext = this;
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