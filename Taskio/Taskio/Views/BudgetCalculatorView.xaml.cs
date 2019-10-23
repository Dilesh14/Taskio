using System;
using Taskio.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Taskio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BudgetCalculatorView : ContentPage
    {
        private BudgetCalculatorViewModel _viewModel;
        public BudgetCalculatorView()
        {
            InitializeComponent();
            _viewModel = new BudgetCalculatorViewModel();
            BindingContext = _viewModel;
        }
       private void TextChanged(object sender, EventArgs e)
       {
            _viewModel.EntryCompletedCommand?.Execute(null);
       }
    }
}