using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Taskio.ViewModel
{
    public class ImageLoadingViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private byte[] bytes = null;
        private string filename { get; set; }
        public ImageLoadingViewModel(string path)
        {
            filename = path;
        }
        public async Task LoadBitmaps()
        {
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            await fs.WriteAsync(bytes, 0, bytes.Length);
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
