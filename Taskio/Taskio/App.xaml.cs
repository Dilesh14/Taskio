using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Taskio.Views;
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Taskio
{
    public partial class App : Application
    {
        public static INavigation GlobalNavigation { get; private set; }
        public App()
        {
            InitializeComponent();
            var masterDetail = new MasterDetailPage();
            masterDetail.Title = "TASKIO";
            masterDetail.Detail = new LoadPage();
            masterDetail.Master = new SideNavBar();
            var rootPage = new NavigationPage(masterDetail);
            GlobalNavigation = rootPage.Navigation;
            MainPage = rootPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
