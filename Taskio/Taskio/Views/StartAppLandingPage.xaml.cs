using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskio.Extensions;
using Taskio.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Taskio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartAppLandingPage : ContentPage
    {
        public StartAppLandingPage()
        {
            InitializeComponent();
            ExpandableListView l1 = new ExpandableListView(FakeData.MachineLearing) {ExpandableContent = FakeData.MachineLearing,HeaderText="Machine Learing" };
            ExpandableListView l2 = new ExpandableListView(FakeData.Mathematics) {ExpandableContent = FakeData.Mathematics,HeaderText="Mathematics" };
            ExpandableListView l3 = new ExpandableListView(FakeData.Physics) {ExpandableContent = FakeData.Physics,HeaderText="Physics" };
            MainContainer.Children.Add(l1);
            MainContainer.Children.Add(l2);
            MainContainer.Children.Add(l3);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            OnPropertyChanged("Display");
            OnPropertyChanged("Button");
            OnPropertyChanged();
            OnPropertyChanged();
        }
    }
}