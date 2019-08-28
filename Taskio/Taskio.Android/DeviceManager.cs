using Android.Database;
using Android.Provider;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskio.Droid;
using Taskio.Interface;
using Xamarin.Forms;
[assembly: Dependency(typeof(DeviceManager))]
namespace Taskio.Droid
{
    public class DeviceManager:IDeviceManager
    {
        private Android.Net.Uri uri = MediaStore.Images.Media.ExternalContentUri;
        string[] projection = { MediaStore.Images.ImageColumns.Id, MediaStore.Images.ImageColumns.Data };
        public static int PERMISSION_TO_READ_PHOTO = 100;
        private IDictionary<string, string> PhotoInfo=new Dictionary<string,string>();
        ICursor cursor;
        public static int PhotoCount { get; protected set; }
        public DeviceManager()
        {
            
        }
        public async Task<IDictionary<string,string>> BuildImageMedia()
        {
            int count = 0;
            List<string> PhotoAndPath = new List<string>();
            cursor = Android.App.Application.Context.ApplicationContext.ContentResolver.Query(uri,projection,null,null);
            PhotoCount = cursor.Count;
            while (cursor.MoveToNext())
            {
                string PhotoName = cursor.GetString(cursor.GetColumnIndex(MediaStore.Images.ImageColumns.Id));
                string PhotoPath = cursor.GetString(cursor.GetColumnIndex(MediaStore.Images.ImageColumns.Data));
                PhotoInfo.Add(PhotoName, PhotoPath);
                count++;
                if(count >= 15)
                {
                    break;
                }
            }
            cursor.Close();
            return PhotoInfo;
        }
    }
}