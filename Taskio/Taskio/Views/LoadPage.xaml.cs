using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Taskio.Database;
namespace Taskio.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoadPage : ContentPage
	{
		public LoadPage ()
		{
            InitializeComponent();
            data db = new data();
            db.add();
            int col =0;
            for(int i =0; i < db.Funiture.Count; i++)
            {
                col = i % 2 == 0 ? 0 : 1;
                ItemView l1 = new ItemView(db.Funiture[i]);   
                Grid.Children.Add(l1);
                Grid.SetRow(l1,i/2);Grid.SetColumn(l1, col);
            }
        }
        

    }
}