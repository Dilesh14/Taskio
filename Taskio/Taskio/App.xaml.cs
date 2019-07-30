﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Taskio.Views;
using Android.Provider;
using Android.Database;
using System.Collections.Generic;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Taskio
{
    public partial class App : Application
    {
        public static INavigation GlobalNavigation { get; private set; }
        public static List<string> GetPhotoPathAnywhere { get; protected set; }
        public App()
        {
            InitializeComponent();
            //GetPhotoPathAnywhere = photoPath;
            //var masterDetail = new MasterDetailPage();
            //masterDetail.Title = "TASKIO";
            //masterDetail.Detail = new LoadPage();
            //masterDetail.Master = new SideNavBar();
            var rootPage = new NavigationPage(new StartAppLandingPage());
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
