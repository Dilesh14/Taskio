using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Taskio.ViewModel
{
    public class ImageLoadingViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private byte[] bytes = null;
        private Uri uri;
        private string filename { get; set; }
        public ImageSource Source { get; set; } 
        public ImageLoadingViewModel()
        {

        }
        public ImageLoadingViewModel(string path)
        {
            filename = path;
            Uri.TryCreate(filename, UriKind.Absolute,out uri);
            Source = ImageSource.FromStream(() => LoadBitmaps().Result);
        }
        public async Task<FileStream> LoadBitmaps()
        {
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            await fs.WriteAsync(bytes, 0, bytes.Length);
            return fs;
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
