using Android.Content;
using System.IO;
using System.Threading.Tasks;
using Taskio.Droid;
using Taskio.Interface;
using Xamarin.Forms;
[assembly: Dependency(typeof(PhotoPicker))]
namespace Taskio.Droid
{
    public class PhotoPicker : IPhotoPicker
    {
        public Task<Stream> GetImageStreamAsync()
        {
            //Defining intent for geting images
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);
            //start the picture picker activity (resumes in mainactivity)
            MainActivity.Instance.StartActivityForResult
                (
                    Intent.CreateChooser(intent, "SelectPhoto"),
                    MainActivity.PickImageId
                );
            //save the TaskCompletion object as a Mainactivity property
            MainActivity.Instance.PickImageTaskCompletionSource = new TaskCompletionSource<Stream>();

            //return task obj
            return MainActivity.Instance.PickImageTaskCompletionSource.Task;
        }
    }
}