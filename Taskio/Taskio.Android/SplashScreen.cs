﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Taskio.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashScreen : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
        }
        protected override void OnResume()
        {
            base.OnResume();
            Task startActivity = new Task(() => { LoadTheMainActivity(); });
            startActivity.Start();
        }
        //Prevents back button pressed action
        public override void OnBackPressed()
        {
        }
        async void LoadTheMainActivity()
        {
            await Task.Run(()=>StartActivity(new Intent(Application.Context, typeof(MainActivity))));
        }
    }
}