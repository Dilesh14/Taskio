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
    public partial class ExpanadableListElement : ContentView
    {
        public string Display { get; set; } = "Hello world";
        public string Button { get; set; } = "x";
        public ExpanadableListElement()
        {
            InitializeComponent();
            GridContainer.BindingContext = this;
        }
    }
}