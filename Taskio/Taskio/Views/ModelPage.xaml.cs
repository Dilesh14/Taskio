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
    public partial class ModelPage : ContentPage
    {
        public ModelPage()
        {
            InitializeComponent();
        }
        public void GoBack(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}