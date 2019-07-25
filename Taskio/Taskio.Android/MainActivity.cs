using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Support.V4.Content;
using Android;
using Android.Support.V4.App;
using static Android.Support.V4.App.ActivityCompat;

namespace Taskio.Droid
{
    [Activity(Label = "Taskio", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ActivityCompat.IOnRequestPermissionsResultCallback
    {
        private PhotoObserver photoObserver;
        private DeviceManager deviceManager = new DeviceManager();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            if (ContextCompat.CheckSelfPermission(Application.Context, Manifest.Permission.ReadExternalStorage) == Permission.Granted)
            {
                List<string> PhotoPath = deviceManager.BuildImageMedia();
                LoadApplication(new App(PhotoPath));
            }
            else
            {
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.ReadExternalStorage }, 100);
            }
            HandlerThread thread = new HandlerThread("MainWorkerThread");
            thread.Start();
            photoObserver = new PhotoObserver(new Handler(thread.Looper));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            if (requestCode == 100)
            {
                if (grantResults.Length == 1 && grantResults[0] == Permission.Granted)
                {
                    List<string> PhotoPath = deviceManager.BuildImageMedia();
                    LoadApplication(new App(PhotoPath));
                }
            }
            else
            {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }
        protected override void OnPause()
        {
            base.OnPause();
            PhotoObserver.CreatePhotoObserver().UnregisterPhotoObserver();
        }
        protected override void OnResume()
        {
            base.OnResume();
            PhotoObserver.CreatePhotoObserver().RegisterPhotoObserver();
        }
    }
}