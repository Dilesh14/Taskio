using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using PanCardView.Droid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Taskio.Droid
{
    [Activity(Label = "Taskio", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ActivityCompat.IOnRequestPermissionsResultCallback
    {
        internal static MainActivity Instance { get; private set; }
        private PhotoObserver photoObserver;
        private DeviceManager deviceManager = new DeviceManager();
        public static readonly int PickImageId = 1000;
        public TaskCompletionSource<Stream> PickImageTaskCompletionSource { get; set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
            Instance = this;
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            CardsViewRenderer.Preserve();
            Forms9Patch.Droid.Settings.Initialize(this);
            if (ContextCompat.CheckSelfPermission(Application.Context, Manifest.Permission.ReadExternalStorage) == Permission.Granted)
            {
                IDictionary<string,string> PhotoPath = deviceManager.BuildImageMedia();
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
                    IDictionary<string,string> PhotoPath = deviceManager.BuildImageMedia();
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
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
        {
            base.OnActivityResult(requestCode, resultCode, intent);
            if (requestCode == PickImageId)
            {
                if ((resultCode == Result.Ok) && (intent != null))
                {
                    Android.Net.Uri uri = intent.Data;
                    Stream stream = ContentResolver.OpenInputStream(uri);

                    // Set the Stream as the completion of the Task
                    PickImageTaskCompletionSource.SetResult(stream);
                }
                else
                {
                    PickImageTaskCompletionSource.SetResult(null);
                }
            }
        }
    }
}