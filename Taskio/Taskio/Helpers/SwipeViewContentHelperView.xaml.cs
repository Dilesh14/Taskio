using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskio.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Taskio.Helpers
{
    /// <summary>
    /// This view is created as a helper view to store the str [ViewName] which will be send to the viewmodel selected Item
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwipeViewContentHelperView : ContentView
    {
        public string ViewName { get; set; }
        public ViewModelForSwipe _viewModel { get; set; }
        public TapGestureRecognizer TapGesture = new TapGestureRecognizer();
        public SwipeViewContentHelperView(string name, ViewModelForSwipe vm)
        {
            InitializeComponent();
            ViewName = name;
            
            HolderName.Text = ViewName ;
            _viewModel = vm;
            BindingContext = _viewModel;
            TapGesture.SetBinding(TapGestureRecognizer.CommandProperty, nameof(ViewModelForSwipe.CommandForPushPage));
            TapGesture.CommandParameter = name;
            HolderName.GestureRecognizers.Add
                    (
                        TapGesture
                    );
        }
    }
}