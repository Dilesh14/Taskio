using System.Collections.Generic;
using Taskio.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Taskio
{
    public partial class App : Application
    {
        public static INavigation GlobalNavigation { get; private set; }
        public static IDictionary<string,string> GetPhotoPathAnywhere { get; protected set; }
        public App(IDictionary<string,string>photoPath)
        {
            InitializeComponent();
            GetPhotoPathAnywhere = photoPath;
            //var masterDetail = new MasterDetailPage();
            //masterDetail.Title = "TASKIO";
            //masterDetail.Detail = new LoadPage();
            //masterDetail.Master = new SideNavBar();
            var rootPage = new NavigationPage(new LoadPage(photoPath));
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
