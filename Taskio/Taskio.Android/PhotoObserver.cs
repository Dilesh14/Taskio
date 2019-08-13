using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Taskio.Droid
{
    public class PhotoObserver:ContentObserver
    {
        Handler handler;
        private Android.Net.Uri uri = MediaStore.Images.Media.ExternalContentUri;
        string[] projection = { MediaStore.Images.ImageColumns.BucketDisplayName, MediaStore.MediaColumns.Id };
        ICursor cursor;
        public PhotoObserver(Handler handler):base(handler)
        {
        }
        public static PhotoObserver CreatePhotoObserver()
        {
            HandlerThread worker = new HandlerThread("OnChanger");
            worker.Start();
            return new PhotoObserver(new Handler(worker.Looper));
        }

        public PhotoObserver RegisterPhotoObserver()
        {
            Application.Context.ApplicationContext.ContentResolver.RegisterContentObserver(MediaStore.Images.Media.ExternalContentUri, true, this);
            return this;
        }
        public PhotoObserver UnregisterPhotoObserver()
        {
            Application.Context.ApplicationContext.ContentResolver.UnregisterContentObserver(this);
            return this;
        }
        public override void OnChange(bool selfChange)
        {
            base.OnChange(selfChange);
            cursor = Application.Context.ApplicationContext.ContentResolver.Query(uri, projection, null, null);
            while (cursor.MoveToNext())
            {
                string PhotoName = cursor.GetString(cursor.GetColumnIndex(MediaStore.MediaColumns.Id));
                string PhotoPath = cursor.GetString(cursor.GetColumnIndex(MediaStore.Images.ImageColumns.BucketDisplayName));
                if (App.GetPhotoPathAnywhere.ContainsKey(PhotoName))
                {
                    if (App.GetPhotoPathAnywhere[PhotoName] == PhotoPath)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"******PhotoChanged*****{PhotoName}------{PhotoPath}*********");
                    }
                }
                else
                {
                    Console.WriteLine($"******PhotoAdded*****{PhotoName}------{PhotoPath}*********");
                    if (!App.GetPhotoPathAnywhere.ContainsKey(PhotoName))
                    {
                        App.GetPhotoPathAnywhere.Add(PhotoName, PhotoPath);
                    }
                }
            }
            cursor.Close();
        }
        /// <summary>
        /// Method to check if the photos are added to the files or deleted from the phone
        /// </summary>
        private void ChecKforChange()
        {

        }
    }
}