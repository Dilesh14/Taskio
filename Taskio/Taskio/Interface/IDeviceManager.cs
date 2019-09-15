using System;
using System.Collections.Generic;
using System.Text;

namespace Taskio.Interface
{
    public interface IDeviceManager
    {
        IDictionary<string, string> BuildImageMedia();
    }
}
