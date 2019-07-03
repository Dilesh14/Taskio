using System;
using System.Collections.Generic;
using System.Text;

namespace Taskio.Interface
{
    interface IStory
    {
         string Title{ get; set; }
         string Detail { get; set; }
         int PlaceNumber { get; set; }   
         string Color { get; set; }   
    }
}
