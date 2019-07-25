using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Database;
using Android.Net;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;

namespace Taskio.Droid
{
    public class DeviceManager
    {
        private Android.Net.Uri uri = MediaStore.Images.Media.ExternalContentUri;
        string[] projection = { MediaStore.MediaColumns.Data };
        public static int PERMISSION_TO_READ_PHOTO = 100;
        private IDictionary<string, string> PhotoInfo;
        ICursor cursor;
        public static int PhotoCount { get; protected set; }
        public DeviceManager()
        {
            
        }
        public List<string> BuildImageMedia()
        {
            List<string> PhotoAndPath = new List<string>();
            cursor = Application.Context.ApplicationContext.ContentResolver.Query(uri,projection,null,null);
            PhotoCount = cursor.Count;
            while (cursor.MoveToNext())
            {
                string absolutePathOfImage = cursor.GetString(cursor.GetColumnIndexOrThrow(MediaStore.MediaColumns.Data));
                PhotoAndPath.Add(absolutePathOfImage);
                string PhotoName = cursor.GetString(cursor.GetColumnIndex(MediaStore.MediaColumns.DisplayName));
                string PhotoPath = cursor.GetString(cursor.GetColumnIndex(MediaStore.Images.ImageColumns.BucketDisplayName));
                Console.WriteLine($"{PhotoName}--------------:${PhotoPath}");
                PhotoInfo.Add(PhotoName, PhotoPath);
            }
            cursor.Close();
            return PhotoAndPath;
        }
    }
}