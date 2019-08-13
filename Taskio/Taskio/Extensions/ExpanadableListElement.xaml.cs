using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Taskio.HelperViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Taskio.Extensions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpanadableListElement : ContentView
    {
        public string Display { get; set; } 
        public string Button { get; set; } 
        public ExplandableListElementViewModel viewModel;
        public ExpanadableListElement()
        {
            OnPropertyChanged("Display");
            OnPropertyChanged("Button");
            InitializeComponent();
            viewModel = new ExplandableListElementViewModel(Display, Button);
            GridContainer.BindingContext = viewModel;
        }
    }
}