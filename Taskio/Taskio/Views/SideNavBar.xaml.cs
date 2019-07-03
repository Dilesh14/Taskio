using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskio.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Taskio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SideNavBar : ContentPage
    {
        List<string> navItems;
        public SideNavBar()
        {
            InitializeComponent();
            navItems = new ItemForSideNav().GetItems();
            ListView.ItemsSource = navItems;
        }
        public void PushModel(object sender, EventArgs e)
        {
            if (!(sender is Button))
            { return; }
            App.GlobalNavigation.PushModalAsync(new ModelPage() );
        }
    }
}