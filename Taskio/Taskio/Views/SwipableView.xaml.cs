using PanCardView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskio.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Taskio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwipableView : ContentPage
    {
        private ViewModelForSwipe _viewModel { get; set; }
        public SwipableView(ViewModelForSwipe vm)
        {
            InitializeComponent();
            _viewModel = vm;
            SwipeContainer.SetBinding(PanCardView.CardsView.SelectedItemProperty, nameof(ViewModelForSwipe.SelectedItem));
            SwipeContainer.BindingContext = _viewModel;
        }
    }
}