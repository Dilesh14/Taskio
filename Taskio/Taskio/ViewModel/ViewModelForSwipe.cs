using System;
using System.Collections.Generic;
using System.Text;
using Taskio.Database;
using Taskio.Models;

namespace Taskio.ViewModel
{
    class ViewModelForSwipe
    {
        public IList<Items> ItemSource { get; set; } = new List<Items>();
        public ViewModelForSwipe()
        {
            //data d1 = new data();
            //d1.add();
            foreach(KeyValuePair<string,string>pic in App.GetPhotoPathAnywhere)
            {
                ItemSource.Add(new Items { ImgSrc = pic.Value, Name = pic.Value});
            }
        }
    }
}
