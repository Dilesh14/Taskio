using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Taskio.Models;

namespace Taskio.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemView : ContentView
	{
		public ItemView (Items item)
		{
            InitializeComponent ();
            Label l1 = new Label() {Text=item.Name };
            Label l2 = new Label() {Text=item.Num.ToString()};
            Label l3 = new Label() {Text= item.quantity.ToString()};
            Detail.Children.Add(l1);
            Detail.Children.Add(l2);
            Detail.Children.Add(l3);
		}
	}
}